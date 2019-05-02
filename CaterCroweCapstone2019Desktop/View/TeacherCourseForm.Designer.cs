namespace CaterCroweCapstone2019Desktop.View
{
    partial class TeacherCourseForm
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblCN = new System.Windows.Forms.Label();
            this.btnEditRubric = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.dgvGradeItems = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gradeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddGradeItem = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGradeSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(-181, -123);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 25);
            this.lblUsername.TabIndex = 0;
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCN.Location = new System.Drawing.Point(16, 11);
            this.lblCN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(139, 25);
            this.lblCN.TabIndex = 2;
            this.lblCN.Text = "Course Name:";
            // 
            // btnEditRubric
            // 
            this.btnEditRubric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRubric.Location = new System.Drawing.Point(16, 54);
            this.btnEditRubric.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditRubric.Name = "btnEditRubric";
            this.btnEditRubric.Size = new System.Drawing.Size(133, 37);
            this.btnEditRubric.TabIndex = 5;
            this.btnEditRubric.Text = "Edit Rubric";
            this.btnEditRubric.UseVisualStyleBackColor = true;
            this.btnEditRubric.Click += new System.EventHandler(this.btnEditRubric_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1569, 15);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 37);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(183, 11);
            this.lblCourseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(0, 25);
            this.lblCourseName.TabIndex = 9;
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
            this.Grade,
            this.Edit});
            this.dgvGradeItems.DataSource = this.gradeItemBindingSource;
            this.dgvGradeItems.Location = new System.Drawing.Point(213, 111);
            this.dgvGradeItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGradeItems.MultiSelect = false;
            this.dgvGradeItems.Name = "dgvGradeItems";
            this.dgvGradeItems.ReadOnly = true;
            this.dgvGradeItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGradeItems.Size = new System.Drawing.Size(1280, 665);
            this.dgvGradeItems.TabIndex = 12;
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
            // btnAddGradeItem
            // 
            this.btnAddGradeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGradeItem.Location = new System.Drawing.Point(213, 54);
            this.btnAddGradeItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddGradeItem.Name = "btnAddGradeItem";
            this.btnAddGradeItem.Size = new System.Drawing.Size(200, 37);
            this.btnAddGradeItem.TabIndex = 13;
            this.btnAddGradeItem.Text = "Add Grade Item";
            this.btnAddGradeItem.UseVisualStyleBackColor = true;
            this.btnAddGradeItem.Click += new System.EventHandler(this.btnAddGradeItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(432, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(200, 37);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete Grade Item";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGradeSummary
            // 
            this.btnGradeSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGradeSummary.Location = new System.Drawing.Point(1293, 57);
            this.btnGradeSummary.Name = "btnGradeSummary";
            this.btnGradeSummary.Size = new System.Drawing.Size(200, 37);
            this.btnGradeSummary.TabIndex = 16;
            this.btnGradeSummary.Text = "Grade Summary";
            this.btnGradeSummary.UseVisualStyleBackColor = true;
            this.btnGradeSummary.Click += new System.EventHandler(this.btnGradeSummary_Click);
            // 
            // TeacherCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.btnGradeSummary);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddGradeItem);
            this.Controls.Add(this.dgvGradeItems);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEditRubric);
            this.Controls.Add(this.lblCN);
            this.Controls.Add(this.lblUsername);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeacherCourseForm";
            this.Text = "TeacherCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Button btnEditRubric;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.DataGridView dgvGradeItems;
        private System.Windows.Forms.BindingSource gradeItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Grade;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.Button btnAddGradeItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGradeSummary;
    }
}