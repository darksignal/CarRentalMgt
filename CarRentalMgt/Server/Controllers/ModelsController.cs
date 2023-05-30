using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalMgt.Server.Data;
using CarRentalMgt.Shared.Domain;
using CarRentalMgt.Server.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalMgt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ModelsController>
        [HttpGet]
        public async Task<IActionResult> GetModels()
        {
            if (_unitOfWork.Models == null)
            {
                return NotFound();
            }
            var models = await _unitOfWork.Models.GetAll();
            return Ok(models);
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel(int id)
        {
            var model = await _unitOfWork.Models.Get(q => q.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST api/<ModelsController>
        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Model model)
        {
            if (_unitOfWork.Models == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Models'  is null.");
            }
            await _unitOfWork.Models.Insert(model);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetModel", new { id = model.Id }, model);
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Models.Update(model);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _unitOfWork.Models.Get(q => q.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ModelExists(int id)
        {
            var model = await _unitOfWork.Models.Get(q => q.Id == id);
            return model == null;
        }
    }
}
