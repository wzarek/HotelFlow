﻿using HotelFlow.Models;
using HotelFlow.Models.DTO;
using HotelFlow.Services;
using HotelFlow.Services.DBServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static HotelFlow.Helpers.Constants;

namespace HotelFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisualsController : ControllerBase
    {
        private FloorSchemaService _floorSchemaService { get; set; }
        private ObjectPlacementService _objectPlacementService { get; set; }
        private ObjectTypeService _objectTypeService { get; set; }

        public VisualsController(FloorSchemaService floorSchemaService, ObjectPlacementService objectPlacementService, ObjectTypeService objectTypeService)
        {
            _floorSchemaService = floorSchemaService;
            _objectPlacementService = objectPlacementService;
            _objectTypeService = objectTypeService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult All()
        {
            return Ok(_floorSchemaService.GetAllFloorSchemas());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult GetFloorById(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var floorSchema = _floorSchemaService.GetFloorSchemaById(id);

            if (floorSchema == null)
            {
                return NotFound();
            }

            return Ok(floorSchema);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditFloor(FloorSchema floorSchema)
        {
            if (floorSchema == null)
            {
                return BadRequest();
            }

            _floorSchemaService.UpdateFloorSchema(floorSchema);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult DeleteFloorSchema(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            _floorSchemaService.DeleteFloorSchema(id);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult EditObjectPlacement(ObjectPlacement objectPlacement)
        {
            if (objectPlacement == null)
            {
                return BadRequest();
            }

            _objectPlacementService.UpdateObjectPlacement(objectPlacement);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        public IActionResult DeleteObjectPlacement(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            _objectPlacementService.DeleteObjectPlacement(id);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public IActionResult AddObjectPlacement(ObjectPlacement objectPlacement)
        {
            if (objectPlacement == null)
            {
                return BadRequest();
            }

            _objectPlacementService.CreateObjectPlacement(objectPlacement);

            return Ok();
        }
    }
}
