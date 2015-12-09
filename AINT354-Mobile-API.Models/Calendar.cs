﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINT354_Mobile_API.Models
{
    public class Calendar
    {
        public Calendar()
        {
            CreatedDate = DateTime.Now;
            Events = new List<Event>();
            Members = new List<CalendarMember>();
        }

        //Manually added Guid Id
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ColourId { get; set; }
        public Colour Colour { get; set; }

        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<CalendarMember> Members { get; set; }

    }
}
