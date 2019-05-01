using CaterCroweCapstone2019.Models.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019Admin.Models.DAL
{
    public class CourseDAL
    {
        public bool CreateCourse(Course course)
        {
            var result = false;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "INSERT INTO courses " +
                            "(name, teacher_id, max_seats, remaining_seats, semester_id, start_time, end_time, location, room_number, day_of_week) " +
                            "VALUES " +
                            "(@name, @teacher_id, @max_seats, @remaining_seats, @semester_id, @start_time, @end_time, @location, @room_number, @day_of_week)";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", course.Name);
                    cmd.Parameters.AddWithValue("teacher_id", course.TeacherId);
                    cmd.Parameters.AddWithValue("max_seats", course.MaxSeats);
                    cmd.Parameters.AddWithValue("remaining_seats", course.RemainingSeats);
                    cmd.Parameters.AddWithValue("semester_id", course.SemesterId);
                    cmd.Parameters.AddWithValue("start_time", course.StartTime);
                    cmd.Parameters.AddWithValue("end_time", course.EndTime);
                    cmd.Parameters.AddWithValue("location", course.Location);
                    cmd.Parameters.AddWithValue("room_number", course.RoomNumber);
                    cmd.Parameters.AddWithValue("day_of_week", course.DaysOfWeek);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public bool EditCourse(Course course)
        {
            var result = false;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "UPDATE courses " +
                            "SET name = @name, " +
                            "teacher_id = @teacher_id, " +
                            "max_seats = @max_seats, " +
                            "remaining_seats = @remaining_seats, " +
                            "semester_id = @semester_id, " +
                            "start_time = @start_time, " +
                            "end_time = @end_time, " +
                            "location = @location, " +
                            "room_number = @room_number, " +
                            "day_of_week = @day_of_week " +
                            "WHERE id = @id";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", course.Name);
                    cmd.Parameters.AddWithValue("teacher_id", course.TeacherId);
                    cmd.Parameters.AddWithValue("max_seats", course.MaxSeats);
                    cmd.Parameters.AddWithValue("remaining_seats", course.RemainingSeats);
                    cmd.Parameters.AddWithValue("semester_id", course.SemesterId);
                    cmd.Parameters.AddWithValue("start_time", course.StartTime);
                    cmd.Parameters.AddWithValue("end_time", course.EndTime);
                    cmd.Parameters.AddWithValue("location", course.Location);
                    cmd.Parameters.AddWithValue("room_number", course.RoomNumber);
                    cmd.Parameters.AddWithValue("day_of_week", course.DaysOfWeek);
                    cmd.Parameters.AddWithValue("id", course.Id);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public Course GetCourseById(int courseId)
        {
            Course course = null;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * FROM courses " +
                            "WHERE id = @id";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var teacherIdOrdinal = reader.GetOrdinal("teacher_id");
                        var maxSeatsOrdinal = reader.GetOrdinal("max_seats");
                        var remainingSeatsOrdinal = reader.GetOrdinal("remaining_seats");
                        var semeseterIdOrdinal = reader.GetOrdinal("semester_id");
                        var startTimeOrdinal = reader.GetOrdinal("start_time");
                        var endTimeOrdinal = reader.GetOrdinal("end_time");
                        var locationOrdinal = reader.GetOrdinal("location");
                        var roomNumberOrdinal = reader.GetOrdinal("room_number");
                        var dayOfWeekOrdinal = reader.GetOrdinal("day_of_week");

                        while(reader.Read())
                        {
                            course = new Course()
                            {
                                Id = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get course id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get course name.") : reader.GetString(nameOrdinal),
                                TeacherId = reader[teacherIdOrdinal] == DBNull.Value ? throw new Exception("Failed to get course teacher id.") : reader.GetInt32(teacherIdOrdinal),
                                MaxSeats = reader[maxSeatsOrdinal] == DBNull.Value ? throw new Exception("Failed to get course max seats.") : reader.GetInt32(maxSeatsOrdinal),
                                RemainingSeats = reader[remainingSeatsOrdinal] == DBNull.Value ? throw new Exception("Failed to get course remaining seats.") : reader.GetInt32(remainingSeatsOrdinal),
                                SemesterId = reader[semeseterIdOrdinal] == DBNull.Value ? throw new Exception("Failed to get semester id.") : reader.GetInt32(semeseterIdOrdinal),
                                StartTime = reader[startTimeOrdinal] == DBNull.Value ? throw new Exception("Failed to get course start time.") : reader.GetString(startTimeOrdinal),
                                EndTime = reader[endTimeOrdinal] == DBNull.Value ? throw new Exception("Failed to get course end time.") : reader.GetString(endTimeOrdinal),
                                Location = reader[locationOrdinal] == DBNull.Value ? throw new Exception("Failed to get course location.") : reader.GetString(locationOrdinal),
                                RoomNumber = reader[roomNumberOrdinal] == DBNull.Value ? throw new Exception("Failed to get course room number.") : reader.GetInt32(roomNumberOrdinal),
                                DaysOfWeek = reader[dayOfWeekOrdinal] == DBNull.Value ? throw new Exception("Failed to get course days of week.") : reader.GetString(dayOfWeekOrdinal),
                            };
                        }
                    }
                }
            }

            return course;
        }

        public bool AssignTeacherToCourse(int courseId, string teacherUsername)
        {
            var result = false;
            var teacherId = this.GetTeacherIdFromUsername(teacherUsername);

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "UPDATE courses " +
                            "SET teacher_id = @teacher_id " +
                            "WHERE id = @id";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("teacher_id", teacherId);
                    cmd.Parameters.AddWithValue("id", courseId);
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public List<Prereq> GetCoursePrereqsByCourseId(int courseId)
        {
            var prereqs = new List<Prereq>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query =
                    "SELECT p.prereq_id, c.name, p.minimum_grade " +
                    "FROM prerequisites p, courses c " +
                    "WHERE p.prereq_id = c.id AND p.course_id = @course_id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("course_id", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("p.prereq_id");
                        var nameOrdinal = reader.GetOrdinal("c.name");
                        var gradeOrdinal = reader.GetOrdinal("p.minimum_grade");

                        while (reader.Read())
                        {
                            var prereq = new Prereq()
                            {
                                PrereqId = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get prereq id.") : reader.GetInt32(idOrdinal),
                                PrereqName = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get prereq name.") : reader.GetString(nameOrdinal),
                                PrereqGrade = reader[gradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get prereq grade.") : reader.GetDouble(gradeOrdinal)
                            };

                            prereqs.Add(prereq);
                        }
                    }
                }
            }

            return prereqs;
        }

        public bool InsertPrereqsForCourse(int courseId, List<Prereq> prereqs)
        {
            var result = false;
            using (var dbConnection = DbConnection.DatabaseConnection()) 
            {
                dbConnection.Open();

                var query = "";

                foreach (var prereq in prereqs)
                {
                    //Not subject to sql injection from GUI design
                    query += "INSERT INTO prerequisites (course_id, prereq_id, minimum_grade) " +
                             "VALUES (" + courseId + ", " + prereq.PrereqId + ", " + prereq.PrereqGrade + ");\n";
                }

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public bool DropPrereqFromCourse(int courseId, int prereqId)
        {
            var result = false;

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "DELETE FROM prerequisites " +
                            "WHERE course_id = @course_id AND prereq_id = @prereq_id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("course_id", courseId);
                    cmd.Parameters.AddWithValue("prereq_id", prereqId);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        private int GetTeacherIdFromUsername(string username)
        {
            var result = -1;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT t.id FROM teachers t, user u " +
                            "WHERE u.id = t.user_id AND u.user_name = @username";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("username", username);

                    using(var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("t.id");
                        while(reader.Read())
                        {
                            result = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get teacher id.") : reader.GetInt32(idOrdinal);
                        }
                    }
                }
            }

            return result;
        }
    }
}