using CaterCroweCapstone2019.Models.DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CaterCroweCapstone2019.Utility;

namespace CaterCroweCapstone2019.Models.DAL
{
    public class RubricDAL
    {
        public Rubric getRubricByCourseId(int courseId)
        {
            var rubric = new Rubric();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT id, rubric " +
                            "FROM courses " +
                            "WHERE " +
                            "course_id = @courseID";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("courseID", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var rubricOrdinal = reader.GetOrdinal("rubric");

                        var success = reader.Read();
                        if(success)
                        {
                            rubric.CourseID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to find a course") : reader.GetInt32(idOrdinal);
                            rubric.RubricValues = JsonUtility.TryParseJson(reader.GetString(rubricOrdinal));
                        }
                    }
                }
            }
            return rubric;
        }
    }
}