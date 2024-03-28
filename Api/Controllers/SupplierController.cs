using Application.UseCases.Supplier.Commands.UpdateSupplier;
using Application.UseCases.Supplier.Queries.GetAllSupplier;
using Application.UseCases.Supplier.Queries.GetByIdSupplier;
using Application.UseCases.Suppliers.Commands.CreateSupplier;
using Application.UseCases.Suppliers.Commands.DeleteSupplier;
using Application.UseCases.Suppliers.Dto;
using Domain.Common.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class SupplierController : ControllerBase
    {

        private IMediator _mediator = null!;
        /// <summary>
        ///  Mediator 
        /// </summary>
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

        /// <summary>
        /// Create Supplier.
        /// </summary>
        /// <remarks>
        /// To register Supplier in the DB
        /// </remarks>
        /// <response code = "201">Created Supplier successfully.</response> 

        [HttpPost]
        [Authorize]
        
       
        public async Task<ActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var response = await Mediator.Send(command);
            return StatusCode(201, response);

        }

        /// <summary>
        /// Get all Supplier.
        /// </summary>
        /// <remarks>
        /// To consult all Supplier
        /// </remarks>
        /// <response code = "201">Query successful.</response> 

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Response<IEnumerable<SupplierDto>>>> GetAll()
        {
            var result = await Mediator.Send(new GetAllSupplierQuery());
            return Ok(result);
        }


        /// <summary>
        /// Get Supplier by Id.
        /// </summary>
        /// <remarks>
        /// To consult a Supplier by Id.
        /// </remarks>
        /// <response code = "201">Query successful.</response> 

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Response<SupplierDto>>> GetById(string id)
        {
           
            return await Mediator.Send(new GetByIdSupplierQuery(id));
        }


        /// <summary>
        ///  Update Supplier.
        /// </summary>
        /// <remarks>
        /// To update a Supplier
        /// </remarks>
        /// <response code = "200">Update Successful.</response> 


        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Response<string>>> Update([FromBody] UpdateSupplierCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        ///  Delete Supplier.
        /// </summary>
        /// <remarks>
        /// To delete a Supplier
        /// </remarks>
        /// <response code = "200">Delete Successful.</response> 

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Response<string>>> Delete(string id)
        {
            var command = new DeleteSupplierCommand(id);
            return await Mediator.Send(command);
        }


    }
}
