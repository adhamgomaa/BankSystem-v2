using BankSystem.Business;
using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Clients;
using BankSystem.Shared;
using BankSystem.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Client")]
    [ApiController]
    [Authorize(Policy = PermissionPolicies.Client)]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        [HttpGet("All", Name = "GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ClientViewDTO>>> GetAllClients(CancellationToken cancellationToken)
        {
            List<ClientView> clients = await clientService.GetAllClientsAsync(cancellationToken);
            if (clients.Count == 0)
                return NotFound("No Clients Found");
            var clientDTO = clients.Select(client => new ClientViewDTO
            {
                clientId = client.clientId,
                accountNumber = client.accountNumber,
                fullName = client.fullName,
                email = client.email,
                phone = client.phone,
                balance = client.balance
            });
            return Ok(clientDTO);
        }

        [HttpGet("{id}", Name = "GetClientByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDTO>> GetClientByID(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Client? client = await clientService.GetClientByIDAsync(id, cancellationToken);

            if (client == null) return NotFound($"There's no client with this Id: {id}");

            ClientDTO clientDTO = new ClientDTO
            {
                clientId = client.clientId,
                accountNumber = client.accountNumber,
                personId = client.personId,
                balance = client.balance
            };

            return Ok(clientDTO);
        }

        [HttpGet("AccountNumber/{accNum}", Name = "GetClientByAccNum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDTO>> GetClientByAccNum(int accNum, CancellationToken cancellationToken)
        {
            if (accNum < 1)
                return BadRequest("Invalid data");

            Client? client = await clientService.GetClientByAccNumAsync(accNum, cancellationToken);

            if (client == null) return NotFound($"There's no client with this AccountNumber: {accNum}");

            ClientDTO clientDTO = new ClientDTO
            {
                clientId = client.clientId,
                accountNumber = client.accountNumber,
                personId = client.personId,
                balance = client.balance
            };

            return Ok(clientDTO);
        }

        [HttpGet("Exist/{id}", Name = "IsClientExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> IsClientExist(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if (!await clientService.IsClientExistAsync(id, cancellationToken))
                return NotFound(false);
            return Ok(true);
        }

        [HttpGet("Count", Name = "GetCountClients")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetCountClients(CancellationToken cancellationToken)
        {
            int count = await clientService.GetAllClientsCountAsync(cancellationToken);

            if (count == 0)
                return NotFound("No Clients Found");
            return Ok(count);
        }

        [HttpGet("Balance/{accNum}", Name = "GetBalanceByAccNum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> GetBalanceByAccNum(int accNum, CancellationToken cancellationToken)
        {
            Client? client = await clientService.GetClientByAccNumAsync(accNum, cancellationToken);
            if (client == null) return NotFound("This client isn't found");
            decimal balance = await clientService.GetBalanceByAccNumAsync(accNum, cancellationToken);

            return Ok(balance);
        }

        [HttpGet("TotalBalances", Name = "GetTotalBalances")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetTotalBalances(CancellationToken cancellationToken)
        {
            decimal balance = await clientService.GetTotalBalancesAsync(cancellationToken);

            return Ok(balance);
        }

        [HttpPut("Deposit", Name = "Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Deposit(
            DepositWithdrawDTO depositDTO,
            CancellationToken cancellationToken)
        {
            Client? client = await clientService.GetClientByAccNumAsync(depositDTO.AccNum, cancellationToken);
            if (client == null) return NotFound("This client isn't found");
            bool deposit = await clientService.DepositAsync(depositDTO.AccNum, depositDTO.Amount, cancellationToken);
            return deposit ? Ok($"Transaction Successfully, your balance become: {client.balance + depositDTO.Amount}") : StatusCode(500, new { message = "Error" });
        }

        [HttpPut("Withdrawal", Name = "Withdrawal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Withdrawal(
            DepositWithdrawDTO withdrawDTO,
            CancellationToken cancellationToken)
        {
            Client? client = await clientService.GetClientByAccNumAsync(withdrawDTO.AccNum, cancellationToken);
            if (client == null) return NotFound("This client isn't found");
            bool deposit = await clientService.WithdrawalAsync(withdrawDTO.AccNum, withdrawDTO.Amount, cancellationToken);
            return deposit ? Ok($"Transaction Successfully, your balance become: {client.balance - withdrawDTO.Amount}") : StatusCode(500, new { message = "Your balance is not enough" });
        }

        [HttpPost(Name = "AddNewClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientDTO>> AddNewClient(
            CreateClientDTO createdClient,
            CancellationToken cancellationToken)
        {
            if (createdClient.personId < 1 || createdClient.accountNumber < 1)
                return BadRequest("Invalid data");

            Client newClient = new Client
            {
                accountNumber = createdClient.accountNumber,
                personId = createdClient.personId,
                pinCode = createdClient.pinCode,
                balance = createdClient.balance
            };

            if (!await clientService.AddNewClientAsync(newClient, cancellationToken))
                return StatusCode(500, new { message = "Error Adding Client" });

            ClientDTO client = new ClientDTO
            {
                clientId = newClient.clientId,
                accountNumber = newClient.accountNumber,
                personId = newClient.personId,
                balance = newClient.balance
            };

            return CreatedAtRoute("GetClientByID", new { id = newClient.clientId }, client);
        }

        [HttpPut("{id}", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateClientDTO>> UpdateClient(
            int id,
            UpdateClientDTO updateClient,
            CancellationToken cancellationToken)
        {
            if (id < 1 || updateClient.accountNumber < 1)
                return BadRequest("Invalid data");

            Client? client = await clientService.GetClientByIDAsync(id, cancellationToken);
            if (client == null) return NotFound($"There's no client with this Id: {id}");

            client.accountNumber = updateClient.accountNumber;
            client.pinCode = updateClient.pinCode;
            client.balance = updateClient.balance;

            if (await clientService.UpdateClientAsync(client, cancellationToken)) return Ok(updateClient);
            else return StatusCode(500, new { message = "Error Updating Client" });
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteClient(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool client = await clientService.IsClientExistAsync(id, cancellationToken);
            if (!client) return NotFound($"There's no client with this Id: {id}");
            return await clientService.DeleteClientAsync(id, cancellationToken) ? Ok($"Client With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting Client" });
        }
    }
}
