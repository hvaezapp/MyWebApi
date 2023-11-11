using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.DTOs.Category;
using ShopApi.Application.Features.Category.Requests.Commands;
using ShopApi.Application.Features.Category.Requests.Queries;
using ShopApi.Application.Responses;


namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CategoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll(int pageNom = 1)
        {
            var categories = await _mediator.Send(new GetCategoryListRequest() { PageNom = pageNom });
            return Ok(categories);
        }




        // GET api/<CategoryController>/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdRequest { Id = id });
            return Ok(category);
        }



        // POST api/<CategoryController>
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryDto categoryDto)
        {
            var command = new CreateCategoryCommand { CreateCategoryDto = categoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }



        // PUT api/<CategoryController>
        [HttpPut]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateCategoryDto categoryDto)
        {
            var command = new UpdateCategoryCommand { UpdateCategoryDto = categoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


    }
}
