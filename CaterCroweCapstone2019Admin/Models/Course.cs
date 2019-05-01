using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019Admin.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int MaxSeats { get; set; }
        public int RemainingSeats { get; set; }
        public int SemesterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public int RoomNumber { get; set; }
        public string DaysOfWeek { get; set; }

    }
}