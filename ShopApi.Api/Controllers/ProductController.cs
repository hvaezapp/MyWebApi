using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.DTOs.Product;
using ShopApi.Application.Features.Product.Requests.Commands;
using ShopApi.Application.Features.Product.Requests.Queries;
using ShopApi.Application.Responses;


namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        // GET: api/<ProductController>
        [HttpGet]

        public async Task<ActionResult<List<CategoryDto>>> GetAll(int pageNom = 1)
        {
            var products = await _mediator.Send(new GetProductListRequest() { PageNom = pageNom });
            return Ok(products);
        }




        // GET api/<ProductController>/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest { Id = id });
            return Ok(product);
        }



        // POST api/<ProductController>
        [HttpPost]
        //[Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto productDto)
        {
            var command = new CreateProductCommand { CreateProductDto = productDto   };
            var response = await _mediator.Send(command);
            return Ok(response);
        }



        // PUT api/<ProductController>/2
        [HttpPut]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateProductDto productDto)
        {
            var command = new UpdateProductCommand { UpdateProductDto = productDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


    }
}
