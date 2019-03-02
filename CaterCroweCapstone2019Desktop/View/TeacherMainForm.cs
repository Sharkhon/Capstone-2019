using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Model.DAL;
using CaterCroweCapstone2019Desktop.Model.Users;
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
    public partial class TeacherMainForm : BaseForm
    {
        private CourseDAL courseDAL;

        public TeacherMainForm()
        {
            InitializeComponent();
            this.courseDAL = new CourseDAL();
            var user = (Teacher) Session.UserSession["user"];
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.UserSession.Clear();
            Session.GoBack();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvCourses.Columns["View"].Index)
            {
                var courseInfo = this.dgvCourses.Rows[e.RowIndex].Cells;

                var course = new Course
                {
                    ID = Convert.ToInt32(courseInfo["id"].Value),
                    Name = courseInfo["name"].Value.ToString(),
                    Rubric = new Rubric(JsonUtility.TryParseJson(courseInfo["rubric"].Value.ToString())),
                    Teacher = (Teacher) Session.UserSession["user"]
                };
                var courseForm = new TeacherCourseForm(course);
                courseForm.Show();
                Session.FormStack.Push(courseForm);
                this.Hide();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible == true)
            {
                var user = (Teacher)Session.UserSession["user"];
                this.lblUsername.Text = user.Username;
                this.dgvCourses.DataSource = this.courseDAL.GetCoursesByTeacherId(user.TeacherId);
                this.dgvCourses.Columns["id"].Visible = false;
                this.dgvCourses.Columns["rubric"].Visible = false;
                if (dgvCourses.Columns["View"] == null)
                {
                    this.dgvCourses.Columns.Insert(this.dgvCourses.Columns.Count, new DataGridViewButtonColumn
                    {
                        Name = "View",
                        Text = "View",
                        UseColumnTextForButtonValue = true
                    });
                    this.dgvCourses.CellClick += this.dataGridView_CellClick;
                }
            }
        }

    }
}
