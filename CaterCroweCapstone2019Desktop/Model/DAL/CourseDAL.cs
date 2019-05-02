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

         /// <summary>
        /// Gets the course with the given id.
        /// </summary>
        /// <param name="id">The course id to get.</param>
        /// <returns>Returns the course with the given id.</returns>
        public Course getCourseById(int id, MySqlConnection dbConnection)
        {
            var course = new Course();

            using (dbConnection)
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
                        var maxSeatsOrdianal = reader.GetOrdinal("max_seats");
                        var remainingSeatsOrdianal = reader.GetOrdinal("remaining_seats");

                        var success = reader.Read();
                        if (success)
                        {
                            course.ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not find course id.") : reader.GetInt32(idOrdinal);
                            course.Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Could not find course name.") : reader.GetString(nameOrdinal);
                            course.Rubric = new Rubric(JsonUtility.TryParseJson(reader.GetString(rubricOridnal)));
                            course.RemainingSeats = reader[remainingSeatsOrdianal] == DBNull.Value ? throw new Exception("Could not get seats remaining.") : reader.GetInt32(remainingSeatsOrdianal);
                            course.MaxSeats = reader[maxSeatsOrdianal] == DBNull.Value ? throw new Exception("Could not get max seats.") : reader.GetInt32(maxSeatsOrdianal);
                        }
                    }
                }
            }

            return course;
        }

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
                        var fnameOrdinal = reader.GetOrdinal("fname");
                        var minitOrdinal = reader.GetOrdinal("minit");
                        var lnameOrdinal = reader.GetOrdinal("lname");

                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                ID = reader[useridOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(useridOrdinal),
                                AccessLevel = reader[accesslevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accesslevelOrdinal),
                                StudentId = reader[studetIDOrdinal] == DBNull.Value ? throw new Exception("Failed to get student id.") : reader.GetInt32(studetIDOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal),
                                FirstName = reader[fnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get student first name.") : reader.GetString(fnameOrdinal),
                                MInit = reader[minitOrdinal] == DBNull.Value ? "" : reader.GetString(minitOrdinal),
                                LastName = reader[lnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get student last name.") : reader.GetString(lnameOrdinal) 
                            });
                        }
                    }
                }
            }

            return students;
        }

    }
}
