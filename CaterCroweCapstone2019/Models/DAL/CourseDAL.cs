using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    public class CourseDAL
    {

        public List<Course> getAllCourses()
        {
            var courses = new List<Course>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM courses";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var rubricOridnal = reader.GetOrdinal("rubric");

                        while(reader.Read())
                        {
                            Course course = new Course
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not find course id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Could not find course name.") : reader.GetString(nameOrdinal),
                                Rubric = new Rubric(JsonUtility.TryParseJson(reader.GetString(rubricOridnal)))
                            };
                            courses.Add(course);
                        }
                    }
                }
            }

            return courses;
        }

        public Course getCourseById(int id)
        {
            var course = new Course();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM courses " +
                            "WHERE " +
                            "id = @id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var rubricOridnal = reader.GetOrdinal("rubric");

                        var success = reader.Read();
                        if (success)
                        {
                            course.ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not find course id.") : reader.GetInt32(idOrdinal);
                            course.Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Could not find course name.") : reader.GetString(nameOrdinal);
                            course.Rubric = new Rubric(JsonUtility.TryParseJson(reader.GetString(rubricOridnal)));
                        }
                    }
                }
            }

            return course;
        }

    }
}