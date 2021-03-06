﻿using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaterCroweCapstone2019.Models.DAL.DALModels;

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
                        var fnameOrdinal = reader.GetOrdinal("fname");
                        var lnameOrdinal = reader.GetOrdinal("lname");
                        var minitOrdinal = reader.GetOrdinal("minit");

                        while (reader.Read())
                        {
                            student = new Student()
                            {
                                ID = reader[useridOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(useridOrdinal),
                                AccessLevel = reader[accesslevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accesslevelOrdinal),
                                StudentId = reader[studetIDOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(studetIDOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal),
                                FirstName = reader[fnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get first name.") : reader.GetString(fnameOrdinal),
                                LastName = reader[lnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get last name.") : reader.GetString(lnameOrdinal),
                                MInit = reader[minitOrdinal] == DBNull.Value ? "" : reader.GetString(minitOrdinal)
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
                            if (reader[gradeEarnedOrdinal] != DBNull.Value)
                            {
                                courses.Add(
                                    reader[courseIDOrdinal] == DBNull.Value ? throw new Exception("Could not get course id for completed courses.") : reader.GetInt32(courseIDOrdinal),
                                    reader[gradeEarnedOrdinal] == DBNull.Value ? Double.NaN : reader.GetDouble(gradeEarnedOrdinal));
                            }
                        }
                    }
                }
            }

            return courses;
        }

        public bool AssignFinalGradeByStudentIdAndCourseID(int studentID, int courseID, double gradeEarned)
        {
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "UPDATE enrolled_in " +
                            "Set grade_earned = @gradeEarned " +
                            "Where course_id = @courseID " +
                            "AND student_id = @studentID";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("gradeEarned", gradeEarned);
                    command.Parameters.AddWithValue("courseID", courseID);
                    command.Parameters.AddWithValue("studentID", studentID);

                    var rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public double GetFinalGrade(int studentID, int courseID)
        {
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = @"Select * 
                            FROM enrolled_in 
                            WHERE student_id = @studentID
                            AND course_id = @courseID";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("courseID", courseID);
                    command.Parameters.AddWithValue("studentID", studentID);

                    using (var reader = command.ExecuteReader())
                    {
                        var gradeOrdinal = reader.GetOrdinal("grade_earned");

                        reader.Read();

                        return reader[gradeOrdinal] == DBNull.Value ? Double.NaN : Convert.ToDouble(reader[gradeOrdinal]); 
                    }
                }
            }
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

                    if (rowsAffected > 0)
                    {
                        this.AssignGradeItemsToStudentWhenEnroll(courseID, studentID);
                    }

                    return rowsAffected > 0;
                }
            }
        }

        private bool AssignGradeItemsToStudentWhenEnroll(int courseId, int studentId)
        {
            var result = false;

            var ids = this.GetGradeItemsToAssign(courseId);

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "";

                foreach (var current in ids)
                {
                    query += "INSERT INTO assigned_to (student_id, grade_item_id) " +
                             "VALUES (" + studentId + ", " + current + ");\n";
                }

                if (query.Length > 0)
                {
                    using (var cmd = new MySqlCommand(query, dbConnection))
                    {
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }

            return result;
        }

        private List<int> GetGradeItemsToAssign(int courseId)
        {
            var ids = new List<int>();
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT id FROM grade_item " +
                            "WHERE course_id = @course_id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("course_id", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");

                        while (reader.Read())
                        {
                            var id = reader[idOrdinal] == DBNull.Value
                                ? throw new Exception("Failed to get grade item id.")
                                : reader.GetInt32(idOrdinal);

                            ids.Add(id);
                        }
                    }
                }
            }

            return ids;
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