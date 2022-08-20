using AdminDashboard.Core.Contracts.Facade;
using AdminDashboard.Core.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellManagementController : ControllerBase
    {
        private readonly ISellManagementFacade sellManagementFacade;
        public SellManagementController(ISellManagementFacade sellManagementFacade)
        {
            this.sellManagementFacade = sellManagementFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<SellManagementDTO>> model = new ResponseViewModel<IEnumerable<SellManagementDTO>>();
            try
            {
                model.Data = sellManagementFacade.GetAll().ToList();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<SellManagementDTO> model = new ResponseViewModel<SellManagementDTO>();
            try
            {
                model.Data = sellManagementFacade.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                model.AddError("کتاب وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostBook(SellManagementDTO sellManagement)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = sellManagementFacade.Add(sellManagement);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }

            return Created($"/api/sellManagement/{model.Data}", model);
        }
        [HttpPut]
        [Route("Edit/{book}")]
        public IActionResult EditBook(SellManagementDTO sellManagement)
        {
            if (sellManagement.SellManagementID == 0)
            {
                return BadRequest("ID Not Found");
            }
            sellManagementFacade.Update(sellManagement);
            return Ok(sellManagement);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var sellManagement = sellManagementFacade.GetById(id);
            sellManagementFacade.Remove(sellManagement);
            return Ok($"/api/sellManagement/Delete/{sellManagement}");
        }
    }
}
