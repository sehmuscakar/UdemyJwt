﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJwt.Back.Core.Application.Features.CQRS.Commands;
using UdemyJwt.Back.Core.Application.Features.CQRS.Queries;

namespace UdemyJwt.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetProductQueryRequest(id));
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteProductCommandRequest(id));
            return NoContent();
        
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }
    }
}
