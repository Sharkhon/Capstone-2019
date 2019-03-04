using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    public class StudentDAL
    {

        /// <summary>
        /// Gets the student by the id porvided
        /// </summary>
        /// <param name="studentID">The id to find the student</param>
        /// <returns></returns>
        public Student GetStudentByID(int studentID)
        {
            Student student = null;

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = @"Select * 
                            FROM students 
                            JOIN user ON students.user_id = user.id 
                            WHERE students.id = @studentID";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("studentID", studentID);

                    using (var reader = command.ExecuteReader())
                    {
                        var studetIDOrdinal = reader.GetOrdinal("id");
                        var useridOrdinal = reader.GetOrdinal("user_id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var accesslevelOrdinal = reader.GetOrdinal("access_level");

                        while (reader.Read())
                        {
                            student = new Student()
                            {
                                ID = reader[useridOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(useridOrdinal),
                                AccessLevel = reader[accesslevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accesslevelOrdinal),
                                StudentId = reader[studetIDOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(studetIDOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal)
                            };
                        }
                    }
                }
            }

            student.CompletedCourses = this.GetCompletedCourses(studentID);

            return student;
        }

        public Dictionary<int, double> GetCompletedCourses(int studentID)
        {
            var courses = new Dictionary<int, double>();

            using(var connection = DbConnection.DatabaseConnection())
            {
                connection.Open();

                var query = @"Select * 
                            FROM enrolled_in 
                            WHERE student_id = @id";

                using(var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", studentID);

                    using(var reader = command.ExecuteReader())
                    {
                        var courseIDOrdinal = reader.GetOrdinal("course_id");
                        var gradeEarnedOrdinal = reader.GetOrdinal("grade_earned");

                        while(reader.Read())
                        {
                            courses.Add(
                                reader[courseIDOrdinal] == DBNull.Value ? throw new Exception("Could not get course id for completed courses.") : reader.GetInt32(courseIDOrdinal),
                                reader[gradeEarnedOrdinal] == DBNull.Value ? -1 : reader.GetDouble(gradeEarnedOrdinal));
                        }
                    }
                }
            }

            return courses;
        }

        /// <summary>
        /// Enrolls the student in the course. 
        /// True if enrolled, false otherwise
        /// </summary>
        /// <param name="courseID">The course to be enrolled into.</param>
        /// <param name="studentID">The student to enroll in the course.</param>
        /// <returns></returns>
        public bool EnrollIntoCouse(int courseID, int studentID)
        {
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = @"INSERT INTO enrolled_in (course_id, student_id) 
                            Values (@courseID, @studentID)";

                using(var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("courseID", courseID);
                    command.Parameters.AddWithValue("studentID", studentID);

                    var rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool DropCourse(int courseID, int studentID)
        {
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "UPDATE enrolled_in " +
                            "Set status = \"D\" " +
                            "Where course_id = @courseID " +
                            "AND student_id = @studentID";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("courseID", courseID);
                    command.Parameters.AddWithValue("studentID", studentID);

                    var rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}