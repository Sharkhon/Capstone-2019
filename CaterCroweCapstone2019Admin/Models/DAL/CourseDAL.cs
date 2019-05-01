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

        public bool AssignTeacherToCourse(int courseId, int teacherId)
        {
            var result = false;

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
    }
}