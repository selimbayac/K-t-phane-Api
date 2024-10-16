using Business.IService;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace KutuphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher([FromBody] PublisherDTO publisherDto)
        {
            var publisher = new Publisher
            {
                Id = publisherDto.Id,
                YayinEviAdi = publisherDto.Name
            };
            if (publisher == null) return BadRequest();
            await _publisherService.AddPublisherAsync(publisher);
            return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.Id }, publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] PublisherDTO publisherDto)
        {
            var publisher = new Publisher
            {
                Id = publisherDto.Id,
                YayinEviAdi = publisherDto.Name
            };
            if (id != publisher.Id) return BadRequest();
            await _publisherService.UpdatePublisherAsync(publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}
