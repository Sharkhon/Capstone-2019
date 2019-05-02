using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels.Users
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int AccessLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MInit { get; set; }
    }
}