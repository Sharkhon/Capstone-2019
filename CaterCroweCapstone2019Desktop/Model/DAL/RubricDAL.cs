using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class RubricDAL
    {
        /// <summary>
        /// Gets the rubric for a course and parses the rubric json.
        /// </summary>
        /// <param name="courseId">The course to get the rubric.</param>
        /// <returns>Returns a rubric for the given course id.</returns>
        public Rubric getRubricByCourseId(int courseId)
        {
            var rubric = new Rubric();

            using (var dbConnection = DbConnection.GetConnection())
            {
                dbConnection.Open();

                var query = "SELECT id, rubric " +
                            "FROM courses " +
                            "WHERE " +
                            "id = @courseID";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("courseID", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var rubricOrdinal = reader.GetOrdinal("rubric");

                        var success = reader.Read();
                        if (success)
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
