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
        private CourseDAL courseDAL;
        private GradeItemDAL gradeItemDAL;

        public TeacherGradingForm(GradeItem gradeItem)
        {
            InitializeComponent();
            this.courseDAL = new CourseDAL();
            this.gradeItemDAL = new GradeItemDAL();

            this.lblSuccess.Visible = false;
            
            var students = this.courseDAL.GetAllStudentsInCourse(gradeItem.CourseID);
            var gradeItems = new List<GradeItem>();
            foreach(var student in students)
            {
                gradeItems.Add(this.gradeItemDAL.GetGradeItemForStudent(student.StudentId, gradeItem.ID));
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
                    this.gradeItemDAL.GradeGradeItemByGradeItem(current.DataBoundItem as GradeItem);
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
