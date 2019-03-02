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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblCID = new System.Windows.Forms.Label();
            this.lblCN = new System.Windows.Forms.Label();
            this.lblTID = new System.Windows.Forms.Label();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnEditRubric = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCourseId = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblTeacherId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(-136, -100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 20);
            this.lblUsername.TabIndex = 0;
            // 
            // lblCID
            // 
            this.lblCID.AutoSize = true;
            this.lblCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCID.Location = new System.Drawing.Point(250, 81);
            this.lblCID.Name = "lblCID";
            this.lblCID.Size = new System.Drawing.Size(78, 20);
            this.lblCID.TabIndex = 1;
            this.lblCID.Text = "CourseId:";
            // 
            // lblCN
            // 
            this.lblCN.AutoSize = true;
            this.lblCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCN.Location = new System.Drawing.Point(250, 134);
            this.lblCN.Name = "lblCN";
            this.lblCN.Size = new System.Drawing.Size(110, 20);
            this.lblCN.TabIndex = 2;
            this.lblCN.Text = "Course Name:";
            // 
            // lblTID
            // 
            this.lblTID.AutoSize = true;
            this.lblTID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTID.Location = new System.Drawing.Point(250, 192);
            this.lblTID.Name = "lblTID";
            this.lblTID.Size = new System.Drawing.Size(89, 20);
            this.lblTID.TabIndex = 3;
            this.lblTID.Text = "Teacher Id:";
            // 
            // btnGrades
            // 
            this.btnGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrades.Location = new System.Drawing.Point(375, 300);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(75, 30);
            this.btnGrades.TabIndex = 11;
            this.btnGrades.Text = "Grades";
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnEditRubric
            // 
            this.btnEditRubric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRubric.Location = new System.Drawing.Point(265, 300);
            this.btnEditRubric.Name = "btnEditRubric";
            this.btnEditRubric.Size = new System.Drawing.Size(100, 30);
            this.btnEditRubric.TabIndex = 5;
            this.btnEditRubric.Text = "Edit Rubric";
            this.btnEditRubric.UseVisualStyleBackColor = true;
            this.btnEditRubric.Click += new System.EventHandler(this.btnEditRubric_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(460, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblCourseId
            // 
            this.lblCourseId.AutoSize = true;
            this.lblCourseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseId.Location = new System.Drawing.Point(375, 81);
            this.lblCourseId.Name = "lblCourseId";
            this.lblCourseId.Size = new System.Drawing.Size(0, 20);
            this.lblCourseId.TabIndex = 8;
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(375, 134);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(0, 20);
            this.lblCourseName.TabIndex = 9;
            // 
            // lblTeacherId
            // 
            this.lblTeacherId.AutoSize = true;
            this.lblTeacherId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherId.Location = new System.Drawing.Point(375, 192);
            this.lblTeacherId.Name = "lblTeacherId";
            this.lblTeacherId.Size = new System.Drawing.Size(0, 20);
            this.lblTeacherId.TabIndex = 10;
            // 
            // TeacherCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnGrades);
            this.Controls.Add(this.lblTeacherId);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblCourseId);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEditRubric);
            this.Controls.Add(this.lblTID);
            this.Controls.Add(this.lblCN);
            this.Controls.Add(this.lblCID);
            this.Controls.Add(this.lblUsername);
            this.Name = "TeacherCourseForm";
            this.Text = "TeacherCourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCID;
        private System.Windows.Forms.Label lblCN;
        private System.Windows.Forms.Label lblTID;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnEditRubric;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCourseId;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblTeacherId;
    }
}