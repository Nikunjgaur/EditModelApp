using ChargerVivo.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditModelApp
{
    public partial class EditPageLogIn : Form
    {
        public EditPageLogIn()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                //   label2.Text = "PLEASE ENTER THE PASSWORD.";

                MessageBox.Show("Invalid USER NAME ", "Alert",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_user_name.Text.Contains(" "))
            {
                //label2.Text = "PLEASE REMOVE SPACE FROM  PASSWORD.";
                return;
            }


            txt_user_name.Focus();
            string user_name = txt_user_name.Text;
            string password = txtPassword.Text;


            if (GlobalItems._LogInModel.Engineerpassword.Equals(user_name) || GlobalItems._LogInModel.Adminpassword.Equals(user_name))
            {


                if (GlobalItems._LogInModel.Engineerpassword.Equals(password) || GlobalItems._LogInModel.Adminpassword.Equals(password))
                {

                    GlobalItems.edit_page_access = true;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Invalid Password  " + user_name, "Alert",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Invalid Username " + user_name, "Alert",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditPageLogIn_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}
