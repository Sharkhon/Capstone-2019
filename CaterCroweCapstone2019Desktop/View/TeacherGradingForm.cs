using CaterCroweCapstone2019Desktop.Controller;
using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Model.DAL;
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
    public partial class TeacherGradingForm : BaseForm
    {
        private CourseController courseController;
        private GradeItemController gradeItemController;

        public TeacherGradingForm(GradeItem gradeItem)
        {
            InitializeComponent();
            this.courseController = new CourseController();
            this.gradeItemController = new GradeItemController();

            this.lblSuccess.Visible = false;
            
            var students = this.courseController.GetAllStudentsInCourse(gradeItem.CourseID);
            var gradeItems = new List<GradeItem>();
            foreach(var student in students)
            {
                gradeItems.Add(this.gradeItemController.GetGradeItemForStudent(student.StudentId, gradeItem.ID));
            }
            foreach(var current in gradeItems)
            {
                this.gradeItemBindingSource.Add(current);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.GoBack(); 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblSuccess.Visible = false;
            this.lblError.Text = string.Empty;
            try
            {
                foreach (DataGridViewRow current in this.dgvGradeEdit.Rows)
                {
                    this.gradeItemController.GradeGradeItemByGradeItem(current.DataBoundItem as GradeItem);
                }
                this.lblSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }
    }
}
