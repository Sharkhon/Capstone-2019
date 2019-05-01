using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class GradeItemDAL
    {
        /// <summary>
        /// Gets all grade items for a given course.
        /// </summary>
        /// <param name="courseId">The course to get grade items for.</param>
        /// <returns>A list of grade items for the given course.</returns>
        public List<GradeItem> GetGradeItemsForCourse(int courseId, MySqlConnection dbConnection)
        {
            var gradeItems = new List<GradeItem>();

            using (dbConnection)
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

        /// <summary>
        /// Gets the GradeItem based on the student id and grade item id given
        /// </summary>
        /// <param name="studentID">The student assigned to</param>
        /// <param name="gradeItemID">The specific grade item</param>
        /// <returns>The grade item for the student</returns>
        public GradeItem GetGradeItemForStudent(int studentID, int gradeItemID, MySqlConnection dbConnection)
        {
            using (dbConnection)
            {
                dbConnection.Open();

                var query = @"SELECT * 
                            FROM grade_item 
                            JOIN assigned_to ON assigned_to.grade_item_id = grade_item.id 
                            WHERE grade_item.id = @GradeItemID 
                            AND assigned_to.student_id = @StudentID";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("GradeItemID", gradeItemID);
                    cmd.Parameters.AddWithValue("StudentID", studentID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var maxGradeOrdinal = reader.GetOrdinal("max_grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var dueDateOrdinal = reader.GetOrdinal("due_date");
                        var cidOrdinal = reader.GetOrdinal("course_id");
                        var gradeOrdinal = reader.GetOrdinal("grade");

                        reader.Read();

                        return new GradeItem
                        {
                            ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items id.") : reader.GetInt32(idOrdinal),
                            Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items name.") : reader.GetString(nameOrdinal),
                            Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                            MaxGrade = reader[maxGradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items max grade.") : reader.GetInt32(maxGradeOrdinal),
                            WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                            DueDate = reader[dueDateOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items due date.") : reader.GetDateTime(dueDateOrdinal),
                            CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items course id.") : reader.GetInt32(cidOrdinal),
                            Grade = reader[gradeOrdinal] == DBNull.Value ? 0 : reader.GetDouble(gradeOrdinal),
                            StudentID = studentID
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Updates an assigned grade items grade.
        /// </summary>
        /// <param name="gradeItem">The grade item object to update.</param>
        /// <returns>True if it passes and false if it fails.</returns>
        public bool GradeGradeItemByGradeItem(GradeItem gradeItem, MySqlConnection dbConnection)
        {
            var success = false;

            using (dbConnection)
            {
                dbConnection.Open();

                var query = "UPDATE assigned_to " +
                            "SET grade = @grade " +
                            "WHERE student_id = @student_id " +
                            "AND grade_item_id = @grade_item_id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("grade", gradeItem.Grade);
                    cmd.Parameters.AddWithValue("student_id", gradeItem.StudentID);
                    cmd.Parameters.AddWithValue("grade_item_id", gradeItem.ID);
                    if(!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }

            return success;
        }

        public bool DeleteGradeItemByGradeItem(GradeItem item, MySqlConnection dbConnection)
        {
            var result = false;

            using (dbConnection)
            {
                dbConnection.Open();

                var query = "DELETE FROM assigned_to WHERE grade_item_id = @grade_id;" +
                            "DELETE FROM grade_item WHERE id = @id;";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("grade_id", item.ID);
                    cmd.Parameters.AddWithValue("id", item.ID);
                    if (!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        /// <summary>
        /// Updates the current grade item with the values in the passed in grade item.
        /// </summary>
        /// <param name="item">The updated values.</param>
        /// <returns>Returns true or false if the operation was successful.</returns>
        public bool UpdateGradeItem(GradeItem item, MySqlConnection dbConnection)
        {
            var result = false;

            using (dbConnection)
            {
                dbConnection.Open();
                var query = "UPDATE grade_item " +
                            "SET name = @name, " +
                            "description = @description, " +
                            "max_grade = @maxgrade, " +
                            "weight_type = @type, " +
                            "due_date = @dueDate " +
                            "WHERE id = @id";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("maxgrade", item.MaxGrade);
                    cmd.Parameters.AddWithValue("type", item.WeightType);
                    cmd.Parameters.AddWithValue("dueDate", item.DueDate);
                    cmd.Parameters.AddWithValue("id", item.ID);
                    if(!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }
                    var count = Convert.ToInt32(cmd.ExecuteNonQuery());
                    result = count > 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Creates a new grade item in the database with the information passed in.
        /// </summary>
        /// <param name="item">The grade item to create.</param>
        /// <returns>Returns the amount of rows affected.</returns>
        public bool insertGradeItem(GradeItem item, MySqlConnection dbConnection)
        {
            var success = false;
            var result = 0;
            long gradeItemId = 0;

            using (dbConnection)
            {
                dbConnection.Open();
                var query = "INSERT INTO grade_item " +
                            "(name, description, max_grade, weight_type, due_date, course_id) " +
                            "VALUES " +
                            "(@name, @description, @maxgrade, @weight_type, @due_date, @course_id)";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("maxgrade", item.MaxGrade);
                    cmd.Parameters.AddWithValue("weight_type", item.WeightType);
                    cmd.Parameters.AddWithValue("due_date", item.DueDate);
                    cmd.Parameters.AddWithValue("course_id", item.CourseID);
                    if(!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }
                    result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    gradeItemId = cmd.LastInsertedId;
                }

                if (result > 0)
                {
                    success = this.AssignGradeItemToStudentsInCourse(gradeItemId, item.CourseID, dbConnection);
                }
            }

            return success;
        }

        /// <summary>
        /// Finds all students enrolled in a course and assigns them the newly created grade item.
        /// </summary>
        /// <param name="gradeItemId">The grade item to assign</param>
        /// <param name="courseId">The course to find the students</param>
        /// <param name="dbConnection">The db to use.</param>
        /// <returns>Whether or not the query succeeds.</returns>
        private bool AssignGradeItemToStudentsInCourse(long gradeItemId, int courseId, MySqlConnection dbConnection)
        {
            var success = false;
            List<int> StudentIds = new List<int>();

            var query = "SELECT student_id " +
                        "FROM enrolled_in " +
                        "WHERE course_id = @courseId";

            using (var cmd = new MySqlCommand(query, dbConnection))
            {
                cmd.Parameters.AddWithValue("courseId", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    var idOrdinal = reader.GetOrdinal("student_id");

                    while (reader.Read())
                    {
                        StudentIds.Add(reader.GetInt32(idOrdinal));
                    }
                }
            }

            query = "";

            foreach (var current in StudentIds)
            {
                //Not subject to sql injection because no user input.
                query += "INSERT INTO assigned_to(student_id, grade_item_id) VALUES(" + current + ", " + gradeItemId + ");\n";
            }
            if (query.Length > 0)
            {
                Session.WriteQueryToFile(query);
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    success = cmd.ExecuteNonQuery() > 0;
                }
            }

            return success;
        }
    }
}
