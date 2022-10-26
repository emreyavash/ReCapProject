using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeBanksController : ControllerBase
    {
        IFakeBankService _fakeBankService;

        public FakeBanksController(IFakeBankService fakeBankService)
        {
            _fakeBankService = fakeBankService;
        }
        [HttpPost("add")]
        public IActionResult Add(FakeBank fakeBank)
        {
            var result = _fakeBankService.Add(fakeBank);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
