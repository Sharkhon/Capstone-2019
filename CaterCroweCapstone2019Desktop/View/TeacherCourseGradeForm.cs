using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Model.DAL;
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
    public partial class TeacherCourseGradeForm : BaseForm
    {
        private GradeItemDAL gradeItemDAL;

        public TeacherCourseGradeForm(Course course)
        {
            InitializeComponent();
            this.gradeItemDAL = new GradeItemDAL();
            var gradeItems = this.gradeItemDAL.GetGradeItemsForCourse(course.ID);
            foreach(var current in gradeItems)
            {
                this.gradeItemBindingSource.Add(current);
            }
            this.dgvGradeItems.CellClick += dataGridView_CellClick;
            var column = this.dgvGradeItems.Columns["descriptionDataGridViewTextBoxColumn"];
            column.Visible = false;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvGradeItems.Columns["Grade"].Index)
            {
                var gradeItem = this.dgvGradeItems.Rows[e.RowIndex].DataBoundItem as GradeItem;


                //GOTO Grading screen
            }
            else if(e.ColumnIndex == this.dgvGradeItems.Columns["Edit"].Index)
            {
                //GOTO EDIT PAGE
            }
        }
    }
}
