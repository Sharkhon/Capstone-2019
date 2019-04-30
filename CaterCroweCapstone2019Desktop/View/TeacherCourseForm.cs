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
    public partial class TeacherCourseForm : BaseForm
    {
        private Course course;
        private GradeItemController gradeItemController;
        public TeacherCourseForm(Course course)
        {
            InitializeComponent();
            this.gradeItemController = new GradeItemController();
            this.course = course;
            this.dgvGradeItems.CellClick += dataGridView_CellClick;

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvGradeItems.Columns["Grade"].Index)
            {
                var gradeItem = this.dgvGradeItems.Rows[e.RowIndex].DataBoundItem as GradeItem;
                var gradingForm = new TeacherGradingForm(gradeItem);
                Session.FormStack.Push(gradingForm);
                gradingForm.Show();
                this.Hide();
            }
            else if (e.ColumnIndex == this.dgvGradeItems.Columns["Edit"].Index)
            {
                var gradeItem = this.dgvGradeItems.Rows[e.RowIndex].DataBoundItem as GradeItem;
                var editForm = new TeacherGradeItemEdit(gradeItem);
                Session.FormStack.Push(editForm);
                editForm.Show();
                this.Hide();
            }
        }

        private void btnEditRubric_Click(object sender, EventArgs e)
        {
            var rubricForm = new TeacherRubricForm(course);
            rubricForm.Show();
            Session.FormStack.Push(rubricForm);
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.GoBack();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.lblCourseName.Text = this.course.Name;
            if (this.Visible == true)
            {
                this.gradeItemBindingSource.Clear();
                var gradeItems = this.gradeItemController.GetGradeItemsForCourse(course.ID);
                foreach (var current in gradeItems)
                {
                    this.gradeItemBindingSource.Add(current);
                }
                var column = this.dgvGradeItems.Columns["descriptionDataGridViewTextBoxColumn"];
                column.Visible = false;
            }
        }

        private void btnAddGradeItem_Click(object sender, EventArgs e)
        {
            var addForm = new TeacherGradeItemCreate(this.course.ID);
            addForm.Show();
            Session.FormStack.Push(addForm);
            this.Hide();
        }
    }
}
