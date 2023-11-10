using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Requests.Queries;
using ShopApi.Application.Features.Category.Requests.Commands;

using ShopApi.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.DTOs.Filter;
using ShopApi.Application.Features.Product.Requests.Queries;
using ShopApi.Application.Features.Product.Requests.Commands;
using ShopApi.Application.DTOs.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
     
        public async Task<ActionResult<List<CategoryDto>>> Get(string filterByName = "" , int pageNom = 1)
        {
            var products = await _mediator.Send(new GetProductListRequest() {  FilterByName = filterByName , PageNom = pageNom });
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
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto productDto)
        {
            var command = new CreateProductCommand { CreateProductDto = productDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }



        // PUT api/<ProductController>/2
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductDto productDto)
        {
            var command = new UpdateProductCommand { UpdateProductDto = productDto };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
