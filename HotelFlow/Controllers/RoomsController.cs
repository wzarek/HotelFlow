using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private RoomService _roomService { get; set; }

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_roomService.GetAllRooms());
        }

        [HttpGet]
        [Route("[action]")]
        public string Dupa()
        {
            return "ass";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]")]
        public IActionResult AllWithInactive()
        {
            return Ok(_roomService.GetAllRooms(true));
        }

        [HttpGet]
        [Route("[action]/{offset}")]
        public IActionResult GetWithOffset(int offset)
        {
            if (offset < 0)
            {
                return BadRequest(OffsetWrongExceptionMessage);
            }

            return Ok(_roomService.GetTopNRoomsWithOffset(offset));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("{id}")]
        public IActionResult GetRoomById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var room = _roomService.GetRoomById(id);

            if (room == null)
            {
                return BadRequest();
            }

            return Ok(room);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]/{statusid}")]
        public IActionResult GetByStatus(int statusId, bool getInactive = false)
        {
            if (statusId < 1)
            {
                return BadRequest();
            }

            var rooms = _roomService.GetRoomsByFilter(r => (getInactive && r.IsActive) && r.StatusId == statusId);

            if (!rooms.Any())
            {
                return BadRequest();
            }

            return Ok(rooms);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetByTypes(IEnumerable<int> types)
        {
            if (types == null || !types.Any())
            {
                return BadRequest();
            }

            var rooms = _roomService.GetRoomsByFilter(r => r.IsActive && types.Contains(r.TypeId));

            if (!rooms.Any())
            {
                return BadRequest();
            }

            return Ok(rooms);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{roomId}")]
        public IActionResult Edit(int roomId, RoomDto room_dto)
        {
            if (roomId < 1 || room_dto == null)
            {
                return BadRequest();
            }

            return Ok(_roomService.UpdateRoom(roomId, room_dto));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditMultiple((IEnumerable<int>, IEnumerable<RoomDto>) zipped)
        {
            if (zipped.Item1 == null || !zipped.Item1.Any() || zipped.Item2 == null || !zipped.Item2.Any())
            {
                return BadRequest();
            }

            _roomService.UpdateRooms(zipped.Item1, zipped.Item2);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Delete(Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            _roomService.DeleteRoom(room.Id);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            _roomService.DeleteRoom(id);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult DeleteMultipleByIds(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest();
            }

            _roomService.DeleteRooms(ids);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Add(RoomDto roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest();
            }

            return Ok(_roomService.CreateRoom(roomDto));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddMultiple(IEnumerable<RoomDto> roomsDto)
        {
            if (roomsDto == null || !roomsDto.Any())
            {
                return BadRequest();
            }

            _roomService.CreateRooms(roomsDto);
            return Ok();
        }
    }
}
