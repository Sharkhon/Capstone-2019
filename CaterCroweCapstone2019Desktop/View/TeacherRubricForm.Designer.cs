namespace CaterCroweCapstone2019Desktop.View
{
    partial class TeacherRubricForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRubric = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.ckbType = new System.Windows.Forms.CheckBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblAddError = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRubric
            // 
            this.dgvRubric.AllowUserToAddRows = false;
            this.dgvRubric.AllowUserToDeleteRows = false;
            this.dgvRubric.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubric.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Weight});
            this.dgvRubric.Location = new System.Drawing.Point(150, 135);
            this.dgvRubric.MultiSelect = false;
            this.dgvRubric.Name = "dgvRubric";
            this.dgvRubric.RowTemplate.Height = 30;
            this.dgvRubric.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRubric.Size = new System.Drawing.Size(800, 450);
            this.dgvRubric.TabIndex = 0;
            // 
            // Type
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Type.DefaultCellStyle = dataGridViewCellStyle1;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 150;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1177, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(982, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(175, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New Rubric Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(995, 345);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 30);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit Changes";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(967, 163);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(63, 25);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(967, 238);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(80, 25);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "Weight:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(1042, 163);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 33);
            this.cmbType.TabIndex = 6;
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numWeight.Location = new System.Drawing.Point(1042, 237);
            this.numWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(120, 30);
            this.numWeight.TabIndex = 7;
            this.numWeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // ckbType
            // 
            this.ckbType.AutoSize = true;
            this.ckbType.Location = new System.Drawing.Point(1042, 197);
            this.ckbType.Name = "ckbType";
            this.ckbType.Size = new System.Drawing.Size(123, 29);
            this.ckbType.TabIndex = 8;
            this.ckbType.Text = "New Type";
            this.ckbType.UseVisualStyleBackColor = true;
            this.ckbType.CheckedChanged += new System.EventHandler(this.ckbType_CheckedChanged);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(1042, 163);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(120, 30);
            this.txtType.TabIndex = 9;
            this.txtType.Visible = false;
            // 
            // lblAddError
            // 
            this.lblAddError.AutoSize = true;
            this.lblAddError.ForeColor = System.Drawing.Color.Red;
            this.lblAddError.Location = new System.Drawing.Point(991, 302);
            this.lblAddError.Name = "lblAddError";
            this.lblAddError.Size = new System.Drawing.Size(200, 25);
            this.lblAddError.TabIndex = 10;
            this.lblAddError.Text = "Type must be unique.";
            this.lblAddError.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(800, 99);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Item";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // TeacherRubricForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblAddError);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.ckbType);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvRubric);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TeacherRubricForm";
            this.Text = "TeacherRubricForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRubric;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.CheckBox ckbType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblAddError;
        private System.Windows.Forms.Button btnDelete;
    }
}