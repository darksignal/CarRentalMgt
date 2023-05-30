using CarRentalMgt.Server.IRepository;
using CarRentalMgt.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalMgt.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ModelsController>
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            if (_unitOfWork.Customers == null)
            {
                return NotFound();
            }
            var customers = await _unitOfWork.Customers.GetAll();
            return Ok(customers);
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST api/<ModelsController>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostMake(Customer customer)
        {
            if (_unitOfWork.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Customers.Update(customer);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
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
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CustomerExists(int id)
        {
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            return customer == null;
        }
    }
}