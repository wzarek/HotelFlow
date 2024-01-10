﻿using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private RoomService _roomService { get; set; }

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_roomService.GetAllRooms());
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        [Route("[action]")]
        public IActionResult AllWithInactive()
        {
            return Ok(_roomService.GetAllRooms(true));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Route("[action]")]
        public IActionResult GetByStatus(int statusId, bool getInactive)
        {
            if (statusId < 1)
            {
                return BadRequest();
            }

            var rooms = _roomService.GetRoomsByFilter(r => (getInactive && r.IsActive) && r.StatusId == statusId);

            if (rooms.Any())
            {
                return BadRequest();
            }

            return Ok(rooms);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByType(int typeId)
        {
            if (typeId < 1)
            {
                return BadRequest();
            }

            var rooms = _roomService.GetRoomsByFilter(r => r.IsActive && r.TypeId == typeId);

            if (rooms.Any())
            {
                return BadRequest();
            }

            return Ok(rooms);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult Edit(Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            
            return Ok(_roomService.UpdateRoom(room));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditMultiple(IEnumerable<Room> rooms)
        {
            if (rooms == null || !rooms.Any())
            {
                return BadRequest();
            }

            _roomService.UpdateRooms(rooms);
            return Ok();
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddRoom(Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }

            return Ok(_roomService.CreateRoom(room));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddRooms(IEnumerable<Room> rooms)
        {
            if (rooms == null || !rooms.Any())
            {
                return BadRequest();
            }

            _roomService.CreateRooms(rooms);
            return Ok();
        }
    }
}
