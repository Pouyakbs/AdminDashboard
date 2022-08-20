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
    public class StoreController : ControllerBase
    {
        private readonly IStoreFacade storeFacade;
        public StoreController(IStoreFacade storeFacade)
        {
            this.storeFacade = storeFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<StoreDTO>> model = new ResponseViewModel<IEnumerable<StoreDTO>>();
            try
            {
                model.Data = storeFacade.GetAll().ToList();
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
            ResponseViewModel<StoreDTO> model = new ResponseViewModel<StoreDTO>();
            try
            {
                model.Data = storeFacade.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                model.AddError("کتاب وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostBook(StoreDTO store)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = storeFacade.Add(store);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }

            return Created($"/api/store/{model.Data}", model);
        }
        [HttpPut]
        [Route("Edit/{store}")]
        public IActionResult EditBook(StoreDTO store)
        {
            if (store.StoreID == 0)
            {
                return BadRequest("ID Not Found");
            }
            storeFacade.Update(store);
            return Ok(store);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var store = storeFacade.GetById(id);
            storeFacade.Remove(store);
            return Ok($"/api/store/Delete/{store}");
        }
    }
}
