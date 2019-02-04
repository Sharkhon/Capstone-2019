using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CaterCroweCapstone2019.Utility
{
    /// <summary>
    /// Provides utility functions for Json parsing and converting.
    /// </summary>
    public static class JsonUtility
    {
        /// <summary>
        /// Parses json to a dictionary format.
        /// </summary>
        /// <param name="json">The json to be parsed.</param>
        /// <returns>The dictionary format of the json.</returns>
        public static Dictionary<string, double> TryParseJson(string json)
        {
            var rubric = new Dictionary<string, double>();
            json = json.Replace('{', ' ');
            json = json.Replace('}', ' ');
            json = json.Trim();

            if (string.IsNullOrEmpty(json))
            {
                return rubric;
            }

            json = json.TrimEnd(',');
            var attributes = json.Split(',');

            foreach (var current in attributes)
            {
                var attribute = current.Split(':');
                var key = attribute[0].Trim();
                var value = Convert.ToDouble(attribute[1].Trim());
                rubric.Add(key, value);
            }

            return rubric;
        }

        /// <summary>
        /// Converts a dictionary to a Json format.
        /// </summary>
        /// <param name="rubric">The dictionary to be converted.</param>
        /// <returns>The json string of the dictionary.</returns>
        public static string ConvertRubricToJson(Dictionary<string, double> rubric)
        {
            var jsonRubric = String.Empty;

            jsonRubric += "{\n";

            foreach(var current in rubric.Keys)
            {
                jsonRubric += current + " : " + rubric[current] + ",\n";
            }

            jsonRubric = jsonRubric.TrimEnd(',');
            jsonRubric += "\n}";

            return jsonRubric;
        }
    }
}