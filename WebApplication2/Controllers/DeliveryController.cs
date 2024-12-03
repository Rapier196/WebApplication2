using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryService _deliveryService;

        public DeliveryController(DeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var delivery = await _deliveryService.GetAllAsync();
            return Ok(delivery);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                Console.WriteLine(string.Join("; ", errors)); // Лог ошибок
                return BadRequest(ModelState);
            }

            await _deliveryService.CreateAsync(delivery);
            return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, delivery);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            await _deliveryService.UpdateAsync(delivery);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deliveryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
