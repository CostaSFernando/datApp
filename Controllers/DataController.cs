using datApp.Models;
using datApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataService _dataService;

        public DataController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<List<Data>> Get()
        {

            return _dataService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetData")]
        public ActionResult<Data> Get(string id)
        {
            var data = _dataService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public async Task<ActionResult<Data>> Create(Data data)
        {
            await _dataService.atualizationList();
            _dataService.Create(data);

            return CreatedAtRoute("GetData", new { id = data.Id.ToString() }, data);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Data dataIn)
        {
            var book = _dataService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _dataService.Update(id, dataIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var data = _dataService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            _dataService.Remove(data.Id);

            return NoContent();
        }
    }
}