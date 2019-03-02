using CaterCroweCapstone2019Desktop.Model.DAL;
using CaterCroweCapstone2019Desktop.Utility;
using CaterCroweCapstone2019Desktop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterCroweCapstone2019Desktop
{
    public partial class Form1 : BaseForm
    {
        private AuthenticationDAL authenticationDAL;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(400, 300);
            authenticationDAL = new AuthenticationDAL();
            Session.FormStack.Push(this);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";
            try
            {
                var user = this.authenticationDAL.AuthenticateUser(this.txtUsername.Text, this.txtPassword.Text);
                if (user != null)
                {
                    if (user.AccessLevel == 2)
                    {
                        Session.UserSession.Add("user", user);

                        var teacherForm = new TeacherMainForm();
                        teacherForm.Show();
                        Session.FormStack.Push(teacherForm);

                        this.ClearFields();

                        this.Hide();
                    }
                    else
                    {
                        this.lblError.Text = "You must be a teacher to use this application.";
                    }
                }
                else
                {
                    this.lblError.Text = "Invalid Username or Password.";
                }
            } catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        private void ClearFields()
        {
            this.txtPassword.Text = string.Empty;
            this.txtUsername.Text = string.Empty;
        }

    }
}
