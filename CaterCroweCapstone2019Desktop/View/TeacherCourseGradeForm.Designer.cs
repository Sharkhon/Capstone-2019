namespace CaterCroweCapstone2019Desktop.View
{
    partial class TeacherCourseGradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvGradeItems = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gradeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAddGradeItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGradeItems
            // 
            this.dgvGradeItems.AllowUserToAddRows = false;
            this.dgvGradeItems.AllowUserToDeleteRows = false;
            this.dgvGradeItems.AutoGenerateColumns = false;
            this.dgvGradeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradeItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.maxGradeDataGridViewTextBoxColumn,
            this.weightTypeDataGridViewTextBoxColumn,
            this.dueDateDataGridViewTextBoxColumn,
            this.courseIDDataGridViewTextBoxColumn,
            this.Grade,
            this.Edit});
            this.dgvGradeItems.DataSource = this.gradeItemBindingSource;
            this.dgvGradeItems.Location = new System.Drawing.Point(160, 90);
            this.dgvGradeItems.Name = "dgvGradeItems";
            this.dgvGradeItems.ReadOnly = true;
            this.dgvGradeItems.Size = new System.Drawing.Size(960, 540);
            this.dgvGradeItems.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxGradeDataGridViewTextBoxColumn
            // 
            this.maxGradeDataGridViewTextBoxColumn.DataPropertyName = "MaxGrade";
            this.maxGradeDataGridViewTextBoxColumn.HeaderText = "MaxGrade";
            this.maxGradeDataGridViewTextBoxColumn.Name = "maxGradeDataGridViewTextBoxColumn";
            this.maxGradeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weightTypeDataGridViewTextBoxColumn
            // 
            this.weightTypeDataGridViewTextBoxColumn.DataPropertyName = "WeightType";
            this.weightTypeDataGridViewTextBoxColumn.HeaderText = "WeightType";
            this.weightTypeDataGridViewTextBoxColumn.Name = "weightTypeDataGridViewTextBoxColumn";
            this.weightTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dueDateDataGridViewTextBoxColumn
            // 
            this.dueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate";
            this.dueDateDataGridViewTextBoxColumn.HeaderText = "DueDate";
            this.dueDateDataGridViewTextBoxColumn.Name = "dueDateDataGridViewTextBoxColumn";
            this.dueDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // courseIDDataGridViewTextBoxColumn
            // 
            this.courseIDDataGridViewTextBoxColumn.DataPropertyName = "CourseID";
            this.courseIDDataGridViewTextBoxColumn.HeaderText = "CourseID";
            this.courseIDDataGridViewTextBoxColumn.Name = "courseIDDataGridViewTextBoxColumn";
            this.courseIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.Text = "Grade";
            this.Grade.UseColumnTextForButtonValue = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // gradeItemBindingSource
            // 
            this.gradeItemBindingSource.DataSource = typeof(CaterCroweCapstone2019Desktop.Model.GradeItem);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1177, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Back";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAddGradeItem
            // 
            this.btnAddGradeItem.Location = new System.Drawing.Point(160, 54);
            this.btnAddGradeItem.Name = "btnAddGradeItem";
            this.btnAddGradeItem.Size = new System.Drawing.Size(150, 30);
            this.btnAddGradeItem.TabIndex = 3;
            this.btnAddGradeItem.Text = "Add Grade Item";
            this.btnAddGradeItem.UseVisualStyleBackColor = true;
            this.btnAddGradeItem.Click += new System.EventHandler(this.btnAddGradeItem_Click);
            // 
            // TeacherCourseGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnAddGradeItem);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dgvGradeItems);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TeacherCourseGradeForm";
            this.Text = "TeacherCourseGradeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGradeItems;
        private System.Windows.Forms.BindingSource gradeItemBindingSource;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Grade;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.Button btnAddGradeItem;
    }
}