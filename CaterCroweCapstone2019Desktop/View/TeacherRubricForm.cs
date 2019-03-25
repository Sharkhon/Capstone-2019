﻿using CaterCroweCapstone2019Desktop.Model;
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
    public partial class TeacherRubricForm : BaseForm
    {
        private RubricDAL rubricDAL;
        private Course course;
        private WeightTypeDAL weightTypeDAL;

        public TeacherRubricForm(Course course)
        {
            InitializeComponent();
            this.rubricDAL = new RubricDAL();
            this.weightTypeDAL = new WeightTypeDAL();
            this.course = course;
            this.course.Rubric = this.rubricDAL.getRubricByCourseId(this.course.ID);
            this.cmbType.DataSource = new BindingSource(this.getUsableTypes(), null);
            this.cmbType.ValueMember = "value";
            this.cmbType.DisplayMember = "value";
            this.reloadRubric();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Session.GoBack();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.lblAddError.Visible = false;
            var type = "";
            var weight = Convert.ToDouble(this.numWeight.Value);
            var reloadCMB = false;
            if(this.cmbType.Visible)
            {
                type = this.cmbType.SelectedValue.ToString();
                reloadCMB = true;
            }
            else
            {
                type = this.txtType.Text;
                var result = this.weightTypeDAL.addWeightType(type);
                if (result <= 0)
                {
                    this.lblAddError.Visible = true;
                    return;
                }
            }

            this.course.Rubric.RubricValues.Add(type, weight);
            if(reloadCMB)
            {
                this.cmbType.DataSource = new BindingSource(this.getUsableTypes(), null);
            }
            this.reloadRubric();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var rubric = new Dictionary<string, double>();
            var total = 0.0;
            for (int i = 0; i < this.dgvRubric.Rows.Count; i++)
            {
                var weight = Convert.ToDouble(this.dgvRubric.Rows[i].Cells[1].Value);
                total += weight;
                rubric.Add(this.dgvRubric.Rows[i].Cells[0].Value.ToString(), weight);
            }

            if (total > 100)
            {
                var result = MessageBox.Show(this, "The total weight is above 100. Would you like to proceed?", "Submit Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            var json = JsonUtility.ConvertRubricToJson(rubric);
            this.course.Rubric.RubricValues = rubric;
            var success = this.rubricDAL.updateRubricByRubric(this.course.Rubric);
            //Show a success message or something.
        }

        private void reloadRubric()
        {
            this.dgvRubric.Rows.Clear();
            foreach (var pair in this.course.Rubric.RubricValues)
            {
                string[] row = { pair.Key, pair.Value.ToString() };
                this.dgvRubric.Rows.Add(row);
            }
        }

        private Dictionary<int, string> getUsableTypes()
        {
            var weightTypes = this.weightTypeDAL.getWeightTypes();
            var itemsToRemove = new List<int>();
            foreach (var type in weightTypes)
            {
                if (this.course.Rubric.RubricValues.Keys.Contains(type.Value))
                {
                    itemsToRemove.Add(type.Key);
                }
            }

            foreach(var index in itemsToRemove)
            {
                weightTypes.Remove(index);
            }
            return weightTypes;
        }

        private void ckbType_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if(checkbox.Checked)
            {
                this.cmbType.Visible = false;
                this.txtType.Clear();
                this.txtType.Visible = true;
            }
            else
            {
                this.cmbType.Visible = true;
                this.txtType.Visible = false;
            }
        }
    }
}
