﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AINT354_Mobile_API.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string DeviceId { get; set; }

        [Required]
        public long FacebookId { get; set; }

        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<Event> Events{ get; set; }
    }
}