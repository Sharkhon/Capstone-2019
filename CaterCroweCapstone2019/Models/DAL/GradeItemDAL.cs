using CaterCroweCapstone2019.Models.DAL.DALModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    /// <summary>
    /// GradeItemDAL handles all Database access for the grade_item table.
    /// </summary>
    public class GradeItemDAL
    {
        /// <summary>
        /// Gets the list of all grade items for a student in a class.
        /// </summary>
        /// <param name="studentID">The student id to get grade items.</param>
        /// <param name="courseID">The course id to get grade items.</param>
        /// <returns>Returns a list of all grade items for a student in a class.</returns>
        public List<GradeItem> GetGradeItemsForStudentInClass(int studentID, int courseID)
        {
            var gradeItems = new List<GradeItem>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT g.id, g.name, g.description, g.max_grade, g.weight_type, g.due_date, g.course_id, a.student_id, a.grade" +
                            "FROM grade_item g, assigned_to a " +
                            "WHERE g.course_id = @courseId " +
                            "AND a.student_id = @studentId " +
                            "AND a.grade_item_id = g.id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("courseId", courseID);
                    cmd.Parameters.AddWithValue("studentId", studentID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var maxGradeOrdinal = reader.GetOrdinal("max_grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var dueDateOrdinal = reader.GetOrdinal("due_date");
                        var cidOrdinal = reader.GetOrdinal("course_id");
                        var sidOrdinal = reader.GetOrdinal("student_id");
                        var gradeOrdinal = reader.GetOrdinal("grade");
                        while (reader.Read())
                        {
                            var current = new GradeItem
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items name.") : reader.GetString(nameOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                MaxGrade = reader[maxGradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items max grade.") : reader.GetInt32(maxGradeOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                                DueDate = reader[dueDateOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items due date.") : reader.GetDateTime(dueDateOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items course id.") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the students id.") : reader.GetInt32(sidOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };
                            gradeItems.Add(current);
                        }
                    }
                }
            }

            return gradeItems;
        }

        public GradeItem GetGradeItemByID(int id)
        {
            GradeItem gradeItem = null;

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM grade_item " +
                            "WHERE id = @id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", id);
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
                            gradeItem = new GradeItem
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items name.") : reader.GetString(nameOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                MaxGrade = reader[maxGradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items max grade.") : reader.GetInt32(maxGradeOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                                DueDate = reader[dueDateOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items due date.") : reader.GetDateTime(dueDateOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items course id.") : reader.GetInt32(cidOrdinal)
                            };
                        }
                    }
                }
            }

            return gradeItem;
        }

        /// <summary>
        /// Gets all grade items for students by the grade item id.
        /// </summary>
        /// <param name="id">The grade item id to get.</param>
        /// <returns>Returns the grade items based on the id.</returns>
        public List<GradeItem> GetGradeItemsByID(int id)
        {
            List<GradeItem> gradeItems = new List<GradeItem>();


            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT g.id, g.name, g.description, g.max_grade, g.weight_type, g.due_date, g.course_id, a.student_id, a.grade " +
                            "FROM grade_item g, assigned_to a " +
                            "WHERE g.id = @id " +
                            "AND a.grade_item_id = g.id";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var maxGradeOrdinal = reader.GetOrdinal("max_grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var dueDateOrdinal = reader.GetOrdinal("due_date");
                        var cidOrdinal = reader.GetOrdinal("course_id");
                        var sidOrdinal = reader.GetOrdinal("student_id");
                        var gradeOrdinal = reader.GetOrdinal("grade");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items id.") : reader.GetInt32(idOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items name.") : reader.GetString(nameOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                MaxGrade = reader[maxGradeOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items max grade.") : reader.GetInt32(maxGradeOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                                DueDate = reader[dueDateOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items due date.") : reader.GetDateTime(dueDateOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the grade items course id.") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("Failed to get the students id.") : reader.GetInt32(sidOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };
                            gradeItems.Add(gradeItem);
                        }
                    }
                }
            }

            return gradeItems;
        }

        /// <summary>
        /// Updates the current grade item with the values in the passed in grade item.
        /// </summary>
        /// <param name="item">The updated values.</param>
        /// <returns>Returns true or false if the operation was successful.</returns>
        public bool UpdateGradeItem(GradeItem item)
        {
            var result = false;

            using (var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "UPDATE grade_item " +
                            "SET name = @name, " +
                            "description = @description, " +
                            "max_grade = @maxgrade, " +
                            "weight_type = @type, " +
                            "due_date = @dueDate" +
                            "WHERE id = @id";
                using (var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("maxgrade", item.MaxGrade);
                    cmd.Parameters.AddWithValue("type", item.WeightType);
                    cmd.Parameters.AddWithValue("dueDate", item.DueDate);
                    cmd.Parameters.AddWithValue("id", item.ID);

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
        public bool insertGradeItem(GradeItem item)
        {
            var success = false;
            var result = 0;
            long gradeItemId = 0;

            using (var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "INSERT INTO grade_item " +
                            "(name, description, max_grade, weight_type, due_date, course_id) " +
                            "VALUES " +
                            "(@name, @description, @maxgrade, @weight_type, @due_date, @course_id)";
                using (var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("maxgrade", item.MaxGrade);
                    cmd.Parameters.AddWithValue("weight_type", item.WeightType);
                    cmd.Parameters.AddWithValue("due_date", item.DueDate);
                    cmd.Parameters.AddWithValue("course_id", item.CourseID);

                    result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    gradeItemId = cmd.LastInsertedId;
                }

                if(result > 0)
                {
                    success = this.AssignGradeItemToStudentsInCourse(gradeItemId, item.CourseID, db);
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

            foreach(var current in StudentIds)
            {
                //Not subject to sql injection because no user input.
                query += "INSERT INTO assigned_to(student_id, grade_item_id) VALUES(" + current + ", " + gradeItemId + ");\n";
            }

            using (var cmd = new MySqlCommand(query, dbConnection))
            {
                success = cmd.ExecuteNonQuery() > 0;
            }

            return success;
        }
    }
}