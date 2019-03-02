using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterCroweCapstone2019Desktop.View
{
    public partial class TeacherCourseForm : BaseForm
    {
        private Course course;
        public TeacherCourseForm(Course course)
        {
            InitializeComponent();
            this.course = course;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnEditRubric_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.GoBack();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {

        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.lblCourseId.Text = this.course.ID.ToString();
            this.lblCourseName.Text = this.course.Name;
            this.lblTeacherId.Text = this.course.Teacher.ID.ToString();
        }
    }
}
