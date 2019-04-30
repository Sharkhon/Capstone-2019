using CaterCroweCapstone2019Desktop.Model.Users;
using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class CourseDAL
    {
        public DataTable GetCoursesByTeacherId(int id, MySqlConnection dbConnection)
        {
            var dt = new DataTable();

            using (dbConnection)
            {
                dbConnection.Open();
                var query = "SELECT * " +
                           "FROM courses c " +
                           "WHERE c.teacher_id = @teacherId";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("teacherId", id);
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Gets the students in a couse
        /// </summary>
        /// <param name="CourseID">The id of the course</param>
        /// <returns>List of students in the specified course.</returns>
        public List<Student> GetAllStudentsInCourse(int CourseID, MySqlConnection dbConnection)
        {
            var students = new List<Student>();

            using (dbConnection)
            {
                dbConnection.Open();

                var query = @"SELECT * 
                            FROM students 
                            JOIN enrolled_in ON students.id = enrolled_in.student_id 
                            JOIN user ON students.user_id = user.id
                            WHERE enrolled_in.course_id = @CourseID";

                using (var cmd = new MySqlCommand(query, dbConnection))
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

    }
}
