using BankSystem.Business;
using BankSystem.DTOs.Transfer;
using BankSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/Transfer")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllTransfers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TransferDTO>> GetAllTransfers()
        {
            List<Transfer> transfers = clsTransfer.GetAllTransfers();
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
            return Ok(transfers);
        }

        [HttpPost(Name = "AddNewTransfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> AddNewTransfer(CreateTransferDTO createTransfer)
        {
            Transfer newTransfer = new Transfer
            {
                senderAccount = createTransfer.senderAccount,
                receiverAccount = createTransfer.receiverAccount,
                amount = createTransfer.amount,
                userId = createTransfer.userId,
            };

            if (!clsTransfer.AddNewTransfer(newTransfer))
                return StatusCode(500, "Error Adding Transfer");

            return Ok(true);
        }
    }
}
