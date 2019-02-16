using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    /// <summary>
    /// CourseDAL handles all Database access for the courses table.
    /// </summary>
    public class CourseDAL
    {

        /// <summary>
        /// Returns a list of all courses in the database.
        /// </summary>
        /// <returns>The list of all courses in the database.</returns>
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

        /// <summary>
        /// Gets the course with the given id.
        /// </summary>
        /// <param name="id">The course id to get.</param>
        /// <returns>Returns the course with the given id.</returns>
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


        /// <summary>
        /// Returns the courses that the student is in.
        /// </summary>
        /// <param name="studentID">The id to search by.</param>
        /// <returns>The courses that the student is in.</returns>
        public List<Course> GetCoursesByStudent(int studentID)
        {
            var courses = new List<Course>();

            //TODO: Actually do

            return courses;
        }

        /// <summary>
        /// Returns the courses that the teacher teaches.
        /// </summary>
        /// <param name="teacherID">The id to search by.</param>
        /// <returns>The courses that the teacher teaches.</returns>
        public List<Course> GetCoursesByTeacher(int teacherID)
        {
            var courses = new List<Course>();

            //TODO: Actually do

            return courses;
        }
    }
}