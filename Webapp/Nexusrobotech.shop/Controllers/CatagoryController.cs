using Maxishop.Application.Common;
using Maxishop.Application.DTO.Catagory;
using Maxishop.Application.Services.Interface;
using Maxishop.Domain.Contracts;
using Maxishop.Domain.Models;
using Maxishop.Infrastructure.Application_Constants;
using Maxishop.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Nexusrobotech.shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {

        private readonly ICatagoryService _catagoryService;
        protected APIResponse _response;

        public CatagoryController(ICatagoryService catagoryService)

        {
             _catagoryService = catagoryService;
            _response = new APIResponse();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task <ActionResult<APIResponse>> Create([FromBody] CreateCatagoryDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    _response.AddError(ModelState.ToString());
                    return Ok(_response);
                }
                var entity = await _catagoryService.CreateAsync(dto);
                _response.StatusCode = HttpStatusCode.Created;
                _response.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _response.IsSuccess = true;
               
                _response.Result = entity;
                
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }

            return Ok(_response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task <ActionResult<APIResponse>> Get()
        {
            try
            {
                var catagories = await _catagoryService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = catagories;
                
            }
            catch(Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return Ok(_response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Details")]
        public async Task <ActionResult<APIResponse>> Get(int id)
        {
            try
            {
                var catagory = await _catagoryService.GetByIdAsync(id);

                if (catagory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = catagory;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }

            return Ok(_response);

             
            
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        
        public async Task <ActionResult<APIResponse>> Update([FromBody] UpdateCatagoryDto dto)
        {

            try
            {
                 
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    _response.AddError(ModelState.ToString());
                    return Ok(_response);
                }
                var catagory = await _catagoryService.GetByIdAsync(dto.Id);
                if (catagory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage= CommonMessage.UpdateOperationFailed;
                    return Ok(_response);
                }
                await _catagoryService.UpdateAsync(dto);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess;
                _response.IsSuccess = true;
               
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                _response.AddError(CommonMessage.SystemError);

            }

            return Ok(_response);

        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]

        public async Task <ActionResult<APIResponse>> Delete(int id)
        {

            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);
                }

                var catagory = await _catagoryService.GetByIdAsync(id);

                if (catagory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.RecordNotFound;
                    return Ok(_response);
                }
                await _catagoryService.DeleteAsync(id);
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;
            }
            catch(Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                _response.AddError(CommonMessage.SystemError);
            }

            return Ok(_response);
        } 
    }
}
