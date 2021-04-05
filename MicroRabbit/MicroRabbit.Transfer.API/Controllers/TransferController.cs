using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MicroRabbit.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        #region Get
        [HttpGet]
        public   ActionResult<IEnumerable<TransferLog>> Get()
        {
            try
            {
                return Ok(_transferService.GetTransferLogs());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
