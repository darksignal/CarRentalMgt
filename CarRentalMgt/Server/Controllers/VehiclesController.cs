using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpCcontextAccessor;

        public VehiclesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _httpCcontextAccessor = contextAccessor;
        }

        // GET: api/<VehiclesController>
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _unitOfWork.Vehicles.GetAll(includes: q => q.Include(x => x.Make)
                                                                             .Include(x => x.Model)
                                                                             .Include(x => x.Colour));
            return Ok(vehicles);
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id, includes: q => q.Include(x => x.Make)
                                                                                          .Include(x => x.Model)
                                                                                          .Include(x => x.Colour)
                                                                                          .Include(x => x.Bookings));

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (_unitOfWork.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }

            vehicle.ImageName = CreateFile(vehicle.Image, vehicle.ImageName);


            await _unitOfWork.Vehicles.Insert(vehicle);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            vehicle.ImageName = CreateFile(vehicle.Image, vehicle.ImageName);

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

        // DELETE api/<VehiclesController>/5
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

        private string CreateFile(byte[]? image, string? name)
        {
            var imageName = "";
            if (image != null)
            {
                var url = _httpCcontextAccessor.HttpContext.Request.Host.Value;
                var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{name}";
                var fileStream = System.IO.File.Create(path);
                fileStream.Write(image, 0, image.Length);
                fileStream.Close();
                imageName = $"https://{url}/uploads/{name}";
            }
            return imageName;
        }
    }
}
