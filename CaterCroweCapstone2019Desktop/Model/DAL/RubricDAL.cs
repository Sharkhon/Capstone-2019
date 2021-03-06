﻿using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class RubricDAL
    {
        /// <summary>
        /// Gets the rubric for a course and parses the rubric json.
        /// </summary>
        /// <param name="courseId">The course to get the rubric.</param>
        /// <returns>Returns a rubric for the given course id.</returns>
        public Rubric getRubricByCourseId(int courseId, MySqlConnection dbConnection)
        {
            var rubric = new Rubric();

            using (dbConnection)
            {
                dbConnection.Open();

                var query = "SELECT id, rubric " +
                            "FROM courses " +
                            "WHERE " +
                            "id = @courseID";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("courseID", courseId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var rubricOrdinal = reader.GetOrdinal("rubric");

                        var success = reader.Read();
                        if (success)
                        {
                            rubric.CourseID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to find a course") : reader.GetInt32(idOrdinal);
                            rubric.RubricValues = JsonUtility.TryParseJson(reader.GetString(rubricOrdinal));
                        }
                    }
                }
            }
            return rubric;
        }

        /// <summary>
        /// Updates the database rubric based on the rubric provided.
        /// </summary>
        /// <param name="rubric">The rubric to be updated.</param>
        /// <returns>The number of rows affected.</returns>
        public int updateRubricByRubric(Rubric rubric, MySqlConnection dbConnection)
        {
            var result = -1;

            using (dbConnection)
            {
                dbConnection.Open();

                var query = "UPDATE courses " +
                            "SET rubric = @rubric " +
                            "WHERE id = @id";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("rubric", JsonUtility.ConvertRubricToJson(rubric.RubricValues));
                    cmd.Parameters.AddWithValue("id", rubric.CourseID);

                    if(!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }

                    result = Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the rubric type by it's id
        /// </summary>
        /// <param name="typeID">The type's id</param>
        /// <returns>The type's name</returns>
        public string GetWeightTypeById(int typeID, MySqlConnection dbConnection)
        {
            using (dbConnection)
            {
                dbConnection.Open();

                var query = "Select * From weight_types Where id = @id";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", typeID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var nameOrdinal = reader.GetOrdinal("name");

                        reader.Read();

                        return reader[nameOrdinal] == DBNull.Value ? throw new Exception("Could not get name") : reader.GetString(nameOrdinal);
                    }
                }
            }
        }
    }
}
