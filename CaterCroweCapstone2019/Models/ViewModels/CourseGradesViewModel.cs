﻿using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class CourseGradesViewModel
    { 
        public Student Student { get; set; }
        public GradeItem GradeItem { get; set; }
    }
}