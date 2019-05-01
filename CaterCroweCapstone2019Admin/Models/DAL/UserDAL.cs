using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019Admin.Models.DAL
{
    public class UserDAL
    {
        public bool MakeUser(User user)
        {
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();
            }
            return false;
        }

        public bool UpdateUser(User user)
        {

        }
    }
}