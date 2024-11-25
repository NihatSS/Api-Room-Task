using Api_intro.DTOs.Rooms;
using Api_intro.Helpers.Exceptions;
using Api_intro.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;   
        }


        [ProducesResponseType(typeof(RoomDto), statusCode:StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomService.GetAllAsync());
        }


        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var room = await _roomService.GetByIdAsync(id);
                return Ok(room);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _roomService.Delete(id);
                return Ok("Room successfully deleted");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RoomCreateDto room)
        {
            await _roomService.Create(room);
            return CreatedAtAction(nameof(Create), "Room succefully created");
        }



        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RoomDto), statusCode: StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] RoomEditDto room)
        {
            try
            {
                await _roomService.Update(id, room);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
