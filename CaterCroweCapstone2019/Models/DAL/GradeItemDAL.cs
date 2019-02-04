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

                var query = "SELECT * " +
                            "FROM grade_item" +
                            "WHERE " +
                            "student_id = @studentID AND" +
                            "course_id = @courseID";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("studentID", studentID);
                    command.Parameters.AddWithValue("courseID", courseID);

                    using (var reader = command.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var gradeOrdinal = reader.GetOrdinal("grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var sidOrdinal = reader.GetOrdinal("student_id");
                        var cidOrdinal = reader.GetOrdinal("course_id");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
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
        /// Gets all grade items for every student and class.
        /// </summary>
        /// <returns>Returns all grade items.</returns>
        public List<GradeItem> GetAllGradeItems()
        {
            var gradeItems = new List<GradeItem>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM grade_item";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var gradeOrdinal = reader.GetOrdinal("grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var sidOrdinal = reader.GetOrdinal("student_id");
                        var cidOrdinal = reader.GetOrdinal("course_id");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
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
        /// Gets a grade item by its unique id.
        /// </summary>
        /// <param name="id">The grade item id to get.</param>
        /// <returns>Returns the grade item based on the id.</returns>
        public GradeItem GetGradeItemByID(int id)
        {
            GradeItem gradeItem = null;


            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM grade_item " +
                            "WHERE id = @id";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    command.Parameters.AddWithValue("id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");
                        var descriptionOrdinal = reader.GetOrdinal("description");
                        var gradeOrdinal = reader.GetOrdinal("grade");
                        var weightOrdinal = reader.GetOrdinal("weight_type");
                        var sidOrdinal = reader.GetOrdinal("student_id");
                        var cidOrdinal = reader.GetOrdinal("course_id");

                        while (reader.Read())
                        {
                            gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? throw new Exception("Failed to find weight type.") : reader.GetInt32(weightOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };
                        }
                    }
                }
            }

            return gradeItem;
        }

        /// <summary>
        /// Updates the current grade item with the values in the passed in grade item.
        /// </summary>
        /// <param name="item">The updated values.</param>
        /// <returns>Returns true or false if the operation was successful.</returns>
        public bool UpdateGradeItem(GradeItem item)
        {
            var result = false;

            using(var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "UPDATE grade_item " +
                            "SET name = @name, " +
                            "description = @description, " +
                            "grade = @grade, " +
                            "weight_type = @type " +
                            "WHERE id = @id";
                using(var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("grade", item.Grade);
                    cmd.Parameters.AddWithValue("type", item.WeightType);
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
        public int insertGradeItem(GradeItem item)
        {
            var result = 0;

            using(var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "INSERT INTO grade_item " +
                            "(name, description, grade, weight_type, student_id, course_id) " +
                            "VALUES " +
                            "(@name, @description, @grade, @weight_type, @student_id, @course_id)";
                using(var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("name", item.Name);
                    cmd.Parameters.AddWithValue("description", item.Description);
                    cmd.Parameters.AddWithValue("grade", item.Grade);
                    cmd.Parameters.AddWithValue("weight_type", item.WeightType);
                    cmd.Parameters.AddWithValue("student_id", item.StudentID);
                    cmd.Parameters.AddWithValue("course_id", item.CourseID);

                    result = Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }

            return result;
        }
    }
}