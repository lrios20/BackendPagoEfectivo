using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagoEfectivoApi.Interfaces;
using PagoEfectivoApi.Models;
using PagoEfectivoApi.Requests;

namespace PagoEfectivoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodePromotionController : ControllerBase
    {
        private readonly ILogger<CodePromotionController> _logger;
        private readonly ICodePromotionReadable _codePromotionReadable;
        private readonly ICodePromotionWriteable _codePromotionWriteable;
        public CodePromotionController(ILogger<CodePromotionController> logger,
        ICodePromotionReadable codePromotionReadable,
        ICodePromotionWriteable codePromotionWriteable)
        {
            _logger = logger;
            _codePromotionReadable = codePromotionReadable;
            _codePromotionWriteable = codePromotionWriteable;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _codePromotionReadable.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCodePromotion([FromBody] CodePromotionRequestCreate obj)
        {
            try
            {
                await _codePromotionWriteable.CreateCodePromotion(obj);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("RedeemedCodePromotion")]
        public async Task<IActionResult> RedeemedCodePromotion([FromBody] CodePromotionRequestRedeemed obj)
        {
            try
            {
                await _codePromotionWriteable.RedeemCodePromotion(obj);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
