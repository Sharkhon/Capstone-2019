using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaterCroweCapstone2019Desktop.Controller;
using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Model.Users;
using CaterCroweCapstone2019Desktop.Utility;

namespace CaterCroweCapstone2019Desktop.View
{
    public partial class TeacherCourseGradeSummaryForm : BaseForm
    {
        private int rowCount;
        private TableLayoutPanel tlpGradeSummary;
        private List<Student> students;
        private Course course;

        private CourseController courseController;
        private GradeItemController gradeItemController;
        private RubricController rubricController;
        public TeacherCourseGradeSummaryForm(Course course)
        {
            InitializeComponent();
            this.students = new List<Student>();
            this.course = course;
            this.courseController = new CourseController();
            this.gradeItemController = new GradeItemController();
            this.rubricController = new RubricController();

            this.students = this.courseController.GetAllStudentsInCourse(course.ID);
            List<Student> modifiedStudents = new List<Student>();

            foreach (var student in this.students)
            {
                modifiedStudents.Add(this.gradeItemController.GetGradeItemsForStudentInClass(student, course.ID));
            }

            this.students = modifiedStudents;
            this.SetupGradeSummaryTable();
        }

        private void SetupGradeSummaryTable()
        {
            this.rowCount = 0;
            this.tlpGradeSummary = new TableLayoutPanel
            {
                Location = new Point(-50, 48),
                Name = "tlpGradeSummary",
                Size = new Size(1000, 550),
                TabIndex = 0
            };
            this.tlpGradeSummary.AutoScroll = true;
            this.tlpGradeSummary.ColumnCount = 3;
            this.tlpGradeSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            this.tlpGradeSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400));
            this.tlpGradeSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            this.tlpGradeSummary.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            if (this.students.Count == 0)
            {
                this.NameRow();
            }

            foreach (var student in this.students)
            {
                this.NameRow();
                this.CreateStudentNameRow(student);
                this.CreateGradeRow();
                foreach (var studentGradeItem in student.GradeItems)
                {
                    this.CreateStudentGradeRow(studentGradeItem);
                }
            }

            this.Controls.Add(this.tlpGradeSummary);
            this.Refresh();
        }

        private void AddRow()
        {
            this.rowCount += 1;
            this.tlpGradeSummary.RowCount += this.rowCount;
            this.tlpGradeSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        }

        private void NameRow()
        {
            this.AddRow();
            Label nameLabel = new Label();
            nameLabel.Location = new Point(0,0);
            nameLabel.Text = "Name";
            nameLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Size = new Size(300, 50);
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(nameLabel, 0, this.rowCount - 1);

            Label overallGradeLabel = new Label();
            overallGradeLabel.Location = new Point(0,0);
            overallGradeLabel.Text = "Overall Grade";
            overallGradeLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            overallGradeLabel.Size = new Size(400, 50);
            overallGradeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(overallGradeLabel, 1, this.rowCount - 1);
        }

        private void CreateGradeRow()
        {
            this.AddRow();
            Label gradeItemLabel = new Label();
            gradeItemLabel.Location = new Point(0,0);
            gradeItemLabel.Text = "Grade Item Name";
            gradeItemLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            gradeItemLabel.Size = new Size(400, 50);
            gradeItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(gradeItemLabel, 1, this.rowCount - 1);

            Label gradeLabel = new Label();
            gradeLabel.Location = new Point(0,0);
            gradeLabel.Text = "Grade";
            gradeLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            gradeLabel.Size = new Size(300, 50);
            gradeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(gradeLabel, 2, this.rowCount - 1);
        }

        private void CreateStudentGradeRow(GradeItem item)
        {
            this.AddRow();

            Label gradeItemLabel = new Label();
            gradeItemLabel.Location = new Point(0,0);
            gradeItemLabel.Text = item.Name;
            gradeItemLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            gradeItemLabel.Size = new Size(400, 50);
            gradeItemLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(gradeItemLabel, 1, this.rowCount - 1);

            Label gradeLabel = new Label();
            gradeLabel.Location = new Point(0,0);
            gradeLabel.Text = item.Grade.ToString();
            gradeLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            gradeLabel.Size = new Size(300, 50);
            gradeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(gradeLabel, 2, this.rowCount - 1);
        }

        private void CreateStudentNameRow(Student student)
        {
            this.AddRow();
            Label nameLabel = new Label();
            nameLabel.Location = new Point(0,0);
            nameLabel.Text = student.FirstName + " " + student.LastName;
            nameLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Size = new Size(300, 50);
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(nameLabel, 0, this.rowCount - 1);

            Label overallGradeLabel = new Label();
            overallGradeLabel.Location = new Point(0,0);
            overallGradeLabel.Text = this.GetStudentOverallGrade(student).ToString();
            overallGradeLabel.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular, GraphicsUnit.Point);
            overallGradeLabel.Size = new Size(400, 50);
            overallGradeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.tlpGradeSummary.Controls.Add(overallGradeLabel, 1, this.rowCount - 1);
        }

        private double GetStudentOverallGrade(Student student)
        {
            var overallGrade = 0.0;

            var gradeDict = new Dictionary<int, double>();

            foreach (var studentGradeItem in student.GradeItems)
            {
                if (!double.IsNaN(studentGradeItem.Grade))
                {
                    if (gradeDict.ContainsKey(studentGradeItem.WeightType))
                    {
                        gradeDict[studentGradeItem.WeightType] += (studentGradeItem.Grade / studentGradeItem.MaxGrade);
                    }
                    else
                    {
                        gradeDict[studentGradeItem.WeightType] = (studentGradeItem.Grade / studentGradeItem.MaxGrade);
                    }
                }
            }

            foreach (var calcGrade in gradeDict)
            {
                overallGrade += calcGrade.Value *
                                (this.course.Rubric.RubricValues[this.rubricController.GetWeightTypeById(calcGrade.Key)]
                                );
            }

            return overallGrade;
        }

        private void BuildGradeSummary()
        {
            if (this.students.Count > 0)
            {
                foreach (var student in this.students)
                {
                    this.AddRow();

                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.GoBack();
        }
    }
}
