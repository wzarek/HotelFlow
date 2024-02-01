using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("[action]/{num}")]
        public IActionResult Random(int num)
        {
            var rooms = _roomService.GetAllRooms();
            var roomsToSend = new List<RoomDataToSend>();

            foreach (var room in rooms)
            {
                roomsToSend.Add(
                    new RoomDataToSend
                    {
                        Id = room.Id,
                        Number = room.Number,
                        Type = room.Type.Name,
                        NumberOfPeople = room.Type.NumberOfPeople,
                        Status = room.Status.Name,
                        IsActive = room.IsActive
                    }    
                );
            }

            roomsToSend = roomsToSend.OrderBy(x => Guid.NewGuid()).Take(num).ToList();

            return Ok(roomsToSend);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult All()
        {
            var rooms = _roomService.GetAllRooms();
            var roomsToSend = new List<RoomDataToSend>();

            foreach (var room in rooms)
            {
                roomsToSend.Add(
                    new RoomDataToSend
                    {
                        Id = room.Id,
                        Number = room.Number,
                        Type = room.Type.Name,
                        Status = room.Status.Name,
                        NumberOfPeople = room.Type.NumberOfPeople,
                        IsActive = room.IsActive
                    }
                );
            }

            return Ok(roomsToSend);
        }

        public class RoomFilter
        {
            public string? dateFrom { get; set; }
            public string? dateTo { get; set; }
            public int numberOfPeople { get; set; }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AllFiltered(RoomFilter filter)
        {
            DateTime dateFromD = DateTime.MaxValue;
            DateTime dateToD = DateTime.MaxValue;

            if (filter.dateFrom != null && filter.dateFrom != string.Empty)
            {
                dateFromD = DateTime.ParseExact(filter.dateFrom, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (filter.dateTo != null && filter.dateTo != string.Empty)
            {
                dateToD = DateTime.ParseExact(filter.dateTo, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            var rooms = _roomService.GetRoomsByFilter(
                room => (!room.Reservations.Any(
                    res => (res.DateFrom <= dateFromD && res.DateTo > dateFromD) 
                            || (res.DateFrom < dateToD && res.DateTo > dateToD) 
                ) &&
                    (filter.numberOfPeople == 0 || room.Type.NumberOfPeople >= filter.numberOfPeople)
                )
            );
            var roomsToSend = new List<RoomDataToSend>();

            foreach (var room in rooms)
            {
                roomsToSend.Add(
                    new RoomDataToSend
                    {
                        Id = room.Id,
                        Number = room.Number,
                        Type = room.Type.Name,
                        Status = room.Status.Name,
                        NumberOfPeople = room.Type.NumberOfPeople,
                        IsActive = room.IsActive
                    }
                );
            }

            return Ok(roomsToSend);
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
        [Authorize(Roles = "Admin,Employee,User")]
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

            var roomToSend = new RoomDataToSend
            {
                Id = room.Id,
                Number = room.Number,
                Type = room.Type.Name,
                Status = room.Status.Name,
                NumberOfPeople = room.Type.NumberOfPeople,
                IsActive = room.IsActive
            };

            return Ok(roomToSend);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee,User")]
        [Route("[action]/{number}")]
        public IActionResult GetRoomByNumber(int number)
        {
            if (number < 1)
            {
                return BadRequest();
            }

            var room = _roomService.GetRoomsByFilter(r => r.Number == number).FirstOrDefault();

            if (room == null)
            {
                return BadRequest();
            }

            var roomToSend = new RoomDataToSend
            {
                Id = room.Id,
                Number = room.Number,
                Type = room.Type.Name,
                Status = room.Status.Name,
                NumberOfPeople = room.Type.NumberOfPeople,
                IsActive = room.IsActive
            };

            return Ok(roomToSend);
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
