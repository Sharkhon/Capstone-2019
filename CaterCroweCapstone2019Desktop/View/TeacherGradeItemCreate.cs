﻿using CaterCroweCapstone2019Desktop.Controller;
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
    public partial class TeacherGradeItemCreate : BaseForm
    {
        private GradeItemController gradeItemController;
        private WeightTypeController weightTypeController;
        private RubricController rubricController;
        private int courseId;

        public TeacherGradeItemCreate(int courseId)
        {
            InitializeComponent();
            this.gradeItemController = new GradeItemController();
            this.rubricController = new RubricController();
            this.weightTypeController = new WeightTypeController();
            this.courseId = courseId;
            this.setupComboBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var date = this.dtpDueDate.Value;
            var time = this.dtpDueTime.Value;
            var dueDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            var gradeItem = new GradeItem
            {
                Name = this.txtName.Text,
                Description = this.txtDescription.Text,
                MaxGrade = Convert.ToInt32(this.numMaxGrade.Value),
                WeightType = Convert.ToInt32(this.cmbWeightType.SelectedValue),
                DueDate = dueDate,
                CourseID = this.courseId
            };

            this.gradeItemController.InsertGradeItem(gradeItem);
            Session.GoBack();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Session.GoBack();
        }

        private void setupComboBox()
        {
            var rubric = this.rubricController.GetRubricByCourseId(this.courseId);
            var weightTypes = this.weightTypeController.getWeightTypes();
            var itemsToRemove = new List<int>();
            foreach (var current in weightTypes)
            {
                if (!rubric.RubricValues.Keys.Contains(current.Value))
                {
                    itemsToRemove.Add(current.Key);
                }
            }
            foreach (var current in itemsToRemove)
            {
                weightTypes.Remove(current);
            }
            this.cmbWeightType.DataSource = new BindingSource(weightTypes, null);
            this.cmbWeightType.DisplayMember = "Value";
            this.cmbWeightType.ValueMember = "Key";
        }

    }
}
