using Bazzar.Core.ApplicationServices.Advertisements.CommandHandler;
using Bazzar.Domain.Advertisements.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazzar.Endpoints.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] CreateHandler handler, Create request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("title")]
        [HttpPut]
        public IActionResult Put([FromServices] SetTitleHandler handler, SetTitle request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateTextHandler handler, UpdateText request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdatePriceHandler handler, UpdatePrice request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public IActionResult Put([FromServices] RequestToPublishHandler handler, RequestToPublish request)
        {
            handler.Handle(request);
            return Ok();
        }
    }
}
