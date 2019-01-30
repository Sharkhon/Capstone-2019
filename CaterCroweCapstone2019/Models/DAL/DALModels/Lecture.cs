using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class Lecture
    {
        
        public string Text { get; set; }
        /// <summary>
        /// List of all the file names for the 
        /// </summary>
        public List<string> AttachedFiles { get; set; }
        public List<string> EmbeddedVideos { get; set; }
    }
}