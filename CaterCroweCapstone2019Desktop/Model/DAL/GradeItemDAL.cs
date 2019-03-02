using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class GradeItemDAL
    {
        /// <summary>
        /// Gets all grade items for a given course.
        /// </summary>
        /// <param name="courseId">The course to get grade items for.</param>
        /// <returns>A list of grade items for the given course.</returns>
        public List<GradeItem> GetGradeItemsForCourse(int courseId)
        {
            var gradeItems = new List<GradeItem>();

            using (var dbConnection = DbConnection.GetConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM grade_item " +
                            "WHERE course_id = @id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var maxGradeOrdinal = reader.GetOrdinal("max_grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var dueDateOrdinal = reader.GetOrdinal("due_date");
                        var cidOrdinal = reader.GetOrdinal("course_id");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items name.") : reader.GetString(nameOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                MaxGrade = reader[maxGradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items max grade.") : reader.GetInt32(maxGradeOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                                DueDate = reader[dueDateOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items due date.") : reader.GetDateTime(dueDateOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items course id.") : reader.GetInt32(cidOrdinal)
                            };
                            gradeItems.Add(gradeItem);
                        }
                    }
                }
            }

            return gradeItems;
        }
    }
}
