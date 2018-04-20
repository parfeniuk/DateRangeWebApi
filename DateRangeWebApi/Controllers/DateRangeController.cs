using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateRangeWebApi.Service.DTO;
using DateRangeWebApi.Service.ServiceStorage;
using DateRangeWebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DateRangeWebApi.Controllers
{
    [Route("api/[controller]")]
    public class DateRangeController : Controller
    {
        private IDateRangeService _dateRangeService;
        public DateRangeController(IDateRangeService dateRangeService)
        {
            _dateRangeService = dateRangeService;
        }

        [HttpPost("GetIntersected")]
        [ProducesResponseType(200, Type = typeof(DateRangeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetIntersected([FromBody]DateRangeDto dateRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var datesIntersect = _dateRangeService
                    .FindBy(d => d.IsIntersectedRange(dateRange));
                if (datesIntersect != null)
                {
                    return Ok(datesIntersect);
                }
                return NotFound();
            }
        }

        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(DateRangeDto))]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody]DateRangeDto dateRange)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dateRangeService.Add(dateRange);
            return CreatedAtAction(nameof(Get), new { id = dateRange.Id }, dateRange);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(DateRangeDto))]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            var dates = _dateRangeService.GetAll();
            if (dates != null)
            {
                return Ok(dates);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(200, Type = typeof(DateRangeDto))]
        [ProducesResponseType(404)]
        public IActionResult Get(string id)
        {
            var date = _dateRangeService.FindBy(d=>d.Id.ToString()==id);
            if (date != null)
            {
                return Ok(date);
            }
            else
            {
                return NotFound();
            }
        }
    }
}