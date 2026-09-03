using BankSystem.Business;
using BankSystem.DTOs.Clients;
using BankSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ClientViewDTO>> GetAllClients()
        {
            List<ClientView> clients = clsClient.GetAllClients();
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
        public ActionResult<ClientDTO> GetClientByID(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Client? client = clsClient.GetClientByID(id);

            if (client == null) return NotFound($"There's no client with this Id: {id}");

            ClientDTO clientDTO = new ClientDTO
            {
                clientId = client.clientId,
                accountNumber = client.accountNumber,
                pinCode = client.pinCode,
                personId = client.personId,
                balance = client.balance
            };

            return Ok(clientDTO);
        }

        [HttpGet("AccountNumber/{accNum}", Name = "GetClientByAccNum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDTO> GetClientByAccNum(int accNum)
        {
            if (accNum < 1)
                return BadRequest("Invalid data");

            Client? client = clsClient.GetClientByAccNum(accNum);

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
        public ActionResult<bool> IsClientExist(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            if (!clsClient.IsClientExist(id))
                return NotFound(false);
            return Ok(true);
        }

        [HttpGet("Count", Name = "GetCountClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetCountClients()
        {
            int count = clsClient.GetAllClientsCount();

            if (count == 0)
                return NotFound("No Clients Found");
            return Ok(count);
        }

        [HttpGet("Balance/{accNum}", Name = "GetBalanceByAccNum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<decimal> GetBalanceByAccNum(int accNum)
        {
            Client? client = clsClient.GetClientByAccNum(accNum);
            if (client == null) return NotFound("This client isn't found");
            decimal balance = clsClient.GetBalanceByAccNum(accNum);

            return Ok(balance);
        }

        [HttpGet("TotalBalances", Name = "GetTotalBalances")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<decimal> GetTotalBalances()
        {
            decimal balance = clsClient.GetTotalBalances();

            return Ok(balance);
        }

        [HttpPut("Deposit", Name = "Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Deposit(DepositWithdrawDTO depositDTO)
        {
            Client? client = clsClient.GetClientByAccNum(depositDTO.AccNum);
            if (client == null) return NotFound("This client isn't found");
            bool deposit = clsClient.Deposit(depositDTO.AccNum, depositDTO.Amount);
            return deposit ? Ok($"Transaction Successfully, your balance become: {client.balance + depositDTO.Amount}") : StatusCode(500, new { message = "Error" });
        }

        [HttpPut("Withdrawal", Name = "Withdrawal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Withdrawal(DepositWithdrawDTO withdrawDTO)
        {
            Client? client = clsClient.GetClientByAccNum(withdrawDTO.AccNum);
            if (client == null) return NotFound("This client isn't found");
            bool deposit = clsClient.Withdrawal(withdrawDTO.AccNum, withdrawDTO.Amount);
            return deposit ? Ok($"Transaction Successfully, your balance become: {client.balance - withdrawDTO.Amount}") : StatusCode(500, new { message = "Your balance is not enough" });
        }

        [HttpPost(Name = "AddNewClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClientDTO> AddNewClient(CreateClientDTO createdClient)
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

            if (!clsClient.AddNewClient(newClient))
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
        public ActionResult<UpdateClientDTO> UpdateClient(int id, UpdateClientDTO updateClient)
        {
            if (id < 1 || updateClient.accountNumber < 1)
                return BadRequest("Invalid data");

            Client? client = clsClient.GetClientByID(id);
            if (client == null) return NotFound($"There's no client with this Id: {id}");

            client.accountNumber = updateClient.accountNumber;
            client.pinCode = updateClient.pinCode;
            client.balance = updateClient.balance;

            if (clsClient.UpdateClient(client)) return Ok(updateClient);
            else return StatusCode(500, new { message = "Error Updating Client" });
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteClient(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool client = clsClient.IsClientExist(id);
            if (!client) return NotFound($"There's no client with this Id: {id}");
            return clsClient.DeleteClient(id) ? Ok($"Client With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleteing Client" });
        }
    }
}
