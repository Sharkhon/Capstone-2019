using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
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

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT c.id, c.name, c.rubric, c.teacher_id " +
                            "FROM courses c, enrolled_in e " +
                            "WHERE e.student_id = @studentId " +
                            "AND e.course_id = c.id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("studentId", studentID);

                    courses = this.GetCourseInformationFromDataBase(cmd);
                }
            }

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

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM courses c " +
                            "WHERE c.teacher_id = @teacherId";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("teacherId", teacherID);

                    courses = this.GetCourseInformationFromDataBase(cmd);
                }
            }

            return courses;
        }

        /// <summary>
        /// Gets the students in a couse
        /// </summary>
        /// <param name="CourseID">The id of the course</param>
        /// <returns>List of students in the specified course.</returns>
        public List<Student> GetAllStudentsInCourse(int CourseID)
        {
            var students = new List<Student>();

            using(var dbConnection = DbConnection.DatabaseConnection()) {
                dbConnection.Open();

                var query = @"SELECT * 
                            FROM students 
                            JOIN enrolled_in ON students.id = enrolled_in.student_id 
                            JOIN user ON students.user_id = user.id
                            WHERE enrolled_in.course_id = @CourseID";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("CourseID", CourseID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var studetIDOrdinal = reader.GetOrdinal("student_id");
                        var useridOrdinal = reader.GetOrdinal("user_id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var accesslevelOrdinal = reader.GetOrdinal("access_level");

                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                ID = reader[useridOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(useridOrdinal),
                                AccessLevel = reader[accesslevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accesslevelOrdinal),
                                StudentId = reader[studetIDOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(studetIDOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal)
                            });
                        }
                    }
                }
            }

            return students;
        }

        /// <summary>
        /// Helper method to reduce code reuse when getting a list of courses.
        /// </summary>
        /// <param name="cmd">The query to execute.</param>
        /// <returns>List of desired courses.</returns>
        private List<Course> GetCourseInformationFromDataBase(MySqlCommand cmd)
        {
            List<Course> courses = new List<Course>();

            using (var reader = cmd.ExecuteReader())
            {
                //Might cause bug because of passed in queries alias for course
                var idOrdinal = reader.GetOrdinal("id");
                var nameOrdinal = reader.GetOrdinal("name");
                var rubricOrdinal = reader.GetOrdinal("rubric");
                var teacherIdOrdinal = reader.GetOrdinal("teacher_id");

                while (reader.Read())
                {
                    var course = new Course
                    {
                        ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get course id.") : reader.GetInt32(idOrdinal),
                        Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get course name.") : reader.GetString(nameOrdinal),
                        Rubric = reader[rubricOrdinal] == DBNull.Value ? throw new Exception("Failed to get course rubric.") : new Rubric(JsonUtility.TryParseJson(reader.GetString(rubricOrdinal))),
                        Teacher = reader[teacherIdOrdinal] == DBNull.Value ? throw new Exception("Failed to get teacher id.") : new Teacher { TeacherId = reader.GetInt32(teacherIdOrdinal) }
                    };
                    courses.Add(course);
                }
            }

            return courses;
        }
    }
}