using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Utility
{
    public static class JsonUtility
    {
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
    }
}