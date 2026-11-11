using BankSystem.Business.Interfaces;
using BankSystem.DTOs.Transfer;
using BankSystem.Shared.Entities;
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
                TransferId = transfer.TransferID,
                TransferDate = transfer.TransferDate,
                SenderAccount = transfer.SenderAcc,
                ReceiverAccount = transfer.ReceiverAcc,
                Amount = transfer.Amount,
                UserId = transfer.CreatedByUserID
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
            Transfer newTransfer = new()
            {
                SenderAcc = createTransfer.SenderAccount,
                ReceiverAcc = createTransfer.ReceiverAccount,
                Amount = createTransfer.Amount,
                CreatedByUserID = createTransfer.UserId,
            };

            if (!await transferService.AddNewTransferAsync(newTransfer, cancellationToken))
                return StatusCode(500, "Error Adding Transfer");

            return Ok(true);
        }
    }
}
