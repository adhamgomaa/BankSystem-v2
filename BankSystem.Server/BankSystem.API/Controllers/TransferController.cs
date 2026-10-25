using BankSystem.Business;
using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Transfer;
using BankSystem.Shared;
using BankSystem.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Transfer")]
    [ApiController]
    [Authorize(Policy = PermissionPolicies.Transfer)]
    public class TransferController(ITransferService transferService) : ControllerBase
    {
        [HttpGet("All", Name = "GetAllTransfers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TransferDTO>>> GetAllTransfers(CancellationToken cancellationToken)
        {
            List<Transfer> transfers = await transferService.GetAllTransfersAsync(cancellationToken);
            if (transfers.Count == 0)
                return NotFound("No Transfers Found");
            var transferDTO = transfers.Select(transfer => new TransferDTO
            {
                transferId = transfer.transferId,
                transferDate = transfer.transferDate,
                senderAccount = transfer.senderAccount,
                receiverAccount = transfer.receiverAccount,
                amount = transfer.amount,
                userId = transfer.userId
            });
            return Ok(transferDTO);
        }

        [HttpPost(Name = "AddNewTransfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AddNewTransfer(
            CreateTransferDTO createTransfer,
            CancellationToken cancellationToken)
        {
            Transfer newTransfer = new Transfer
            {
                senderAccount = createTransfer.senderAccount,
                receiverAccount = createTransfer.receiverAccount,
                amount = createTransfer.amount,
                userId = createTransfer.userId,
            };

            if (!await transferService.AddNewTransferAsync(newTransfer, cancellationToken))
                return StatusCode(500, "Error Adding Transfer");

            return Ok(true);
        }
    }
}
