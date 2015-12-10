﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using AINT354_Mobile_API.BusinessLogic;
using AINT354_Mobile_API.ModelDTOs;

namespace AINT354_Mobile_API.Controllers
{
    public class CalendarsController : ApiController
    {
        private readonly CalendarService _calendarService;

        public CalendarsController()
        {
            _calendarService = new CalendarService();
        }

        /// <summary>
        /// Returns a list of calendars for the specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<CalendarDTO>))]
        public async Task<IHttpActionResult> GetUserCalendars(int id)
        {
            if (id == 0) return BadRequest();

            var calendars = await _calendarService.GetUserCalendars(id);

            return Ok(calendars);
        }
        
        /// <summary>
        /// Creates a new calendar for a user
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create(CalendarDTO calendar)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var success = await _calendarService.CreateCalendar(calendar);

            if (success)
            {
                return Ok();
            }

            return BadRequest("Unable to create the new calendar");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(CalendarDTO calendar)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var result = await _calendarService.UpdateCalendar(calendar);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Error);
        }

        /// <summary>
        /// Used to delete a calendar for the specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (id == string.Empty) { return BadRequest(); }

            var success = await _calendarService.DeleteCalendar(id);

            if (success)
            {
                return Ok();
            }

            return BadRequest("Unable to delete calendar, ID:" + id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _calendarService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}