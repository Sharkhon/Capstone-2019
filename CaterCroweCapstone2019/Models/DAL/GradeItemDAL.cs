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
                    command.Parameters["@studentID"].Value = studentID;
                    command.Parameters["@courseID"].Value = courseID;

                    using (var reader = command.ExecuteReader())
                    {
                        int idOrdinal = reader.GetOrdinal("id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int descriptionOrdinal = reader.GetOrdinal("description");
                        int gradeOrdinal = reader.GetOrdinal("grade");
                        int weightOrdinal = reader.GetOrdinal("weight_type");
                        int sidOrdinal = reader.GetOrdinal("sid");
                        int cidOrdinal = reader.GetOrdinal("cid");

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
                        int idOrdinal = reader.GetOrdinal("id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int descriptionOrdinal = reader.GetOrdinal("description");
                        int gradeOrdinal = reader.GetOrdinal("grade");
                        int weightOrdinal = reader.GetOrdinal("weight_type");
                        int sidOrdinal = reader.GetOrdinal("sid");
                        int cidOrdinal = reader.GetOrdinal("cid");

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
                            "FROM grade_item";

                using (var command = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int idOrdinal = reader.GetOrdinal("id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int descriptionOrdinal = reader.GetOrdinal("description");
                        int gradeOrdinal = reader.GetOrdinal("grade");
                        int weightOrdinal = reader.GetOrdinal("weight_type");
                        int sidOrdinal = reader.GetOrdinal("sid");
                        int cidOrdinal = reader.GetOrdinal("cid");

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
    }
}