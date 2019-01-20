using CaterCroweCapstone2019.Models.DAL.DALModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    public class GradeItemDAL
    {
        public List<GradeItem> GetGradeItemsForStudentInClass(int studentID, int courseID)
        {
            var gradeItems = new List<GradeItem>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM grade_item" +
                            "WHERE " +
                            "sid = @studentID AND" +
                            "cid = @courseID";

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
                        var sidOrdinal = reader.GetOrdinal("sid");
                        var cidOrdinal = reader.GetOrdinal("cid");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? string.Empty : reader.GetString(weightOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };

                            gradeItems.Add(gradeItem);
                        }
                    }
                }
            }

            return gradeItems;
        }

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
                        var sidOrdinal = reader.GetOrdinal("sid");
                        var cidOrdinal = reader.GetOrdinal("cid");

                        while (reader.Read())
                        {
                            var gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? string.Empty : reader.GetString(weightOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };

                            gradeItems.Add(gradeItem);
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
                        var sidOrdinal = reader.GetOrdinal("sid");
                        var cidOrdinal = reader.GetOrdinal("cid");

                        while (reader.Read())
                        {
                            gradeItem = new GradeItem()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(idOrdinal),
                                CourseID = reader[cidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(cidOrdinal),
                                StudentID = reader[sidOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetInt32(sidOrdinal),
                                Description = reader[descriptionOrdinal] == DBNull.Value ? string.Empty : reader.GetString(descriptionOrdinal),
                                Name = reader[nameOrdinal] == DBNull.Value ? throw new Exception("it not work") : reader.GetString(nameOrdinal),
                                WeightType = reader[weightOrdinal] == DBNull.Value ? string.Empty : reader.GetString(weightOrdinal),
                                Grade = reader[gradeOrdinal] == DBNull.Value ? double.NaN : reader.GetDouble(gradeOrdinal)
                            };
                        }
                    }
                }
            }

            return gradeItem;
        }

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
    }
}