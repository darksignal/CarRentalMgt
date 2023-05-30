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
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ModelsController>
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            if (_unitOfWork.Vehicles == null)
            {
                return NotFound();
            }
            var vehicles = await _unitOfWork.Vehicles.GetAll();
            return Ok(vehicles);
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // POST api/<ModelsController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostMake(Vehicle vehicle)
        {
            if (_unitOfWork.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            await _unitOfWork.Vehicles.Insert(vehicle);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Vehicles.Update(vehicle);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(id))
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
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> VehicleExists(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            return vehicle == null;
        }
    }
}
