using ChargerVivo.LogInModule;
using ChargerVivo.ReportModule;
using ChargerVivo.Statics;
using GoldenPeacock.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditModelApp
{
    public partial class MenuPage : Form
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void MenuPage_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Icon = new Icon(GlobalItems.icon);
            this.Text = "Menu Page v 2.0";

            if (File.Exists(GlobalItems.password_json))
            {
                string _password = File.ReadAllText(GlobalItems.password_json);
                GlobalItems._LogInModel = JsonConvert.DeserializeObject<ChargerVivo.Models.LogInModel>(_password);
            }



        }//MenuPage_Load

        private void btn_create_model_Click(object sender, EventArgs e)
        {


            if (Application.OpenForms["ModelDataInput"] == null)
            {
                new ModelDataInput().ShowDialog();
            }


            //if (Application.OpenForms["LogInForEdirPage"] == null)
            //{
            //    new LogInForEdirPage().ShowDialog();

            //    if (GlobalItems.edit_page_access == false)
            //    {
            //        return;
            //    }
            //    else
            //    {

            //        if (Application.OpenForms["ModelDataInput"] == null)
            //        {
            //            new ModelDataInput().ShowDialog();
            //        }

            //    }

            //}
        }

        private void btn_edit_model_Click(object sender, EventArgs e)
        {
            //if (Application.OpenForms["LogInForEdirPage"] == null)
            //{
            //    new LogInForEdirPage().ShowDialog();

            //    if (GlobalItems.edit_page_access == false)
            //    {
            //        return;
            //    }
            //    else
            //    {

            //        if (Application.OpenForms["CreateModelPage"] == null)
            //        {
            //            new ChargerVivo.CreateModels.CreateModelPage().Show();
            //        }

            //    }

            //}

            if (Application.OpenForms["CreateModelPage"] == null)
            {
                new ChargerVivo.CreateModels.CreateModelPage().Show();
            }





        }

        private void btn_system_cotroller_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SystemControlPage"] == null)
            {
                new SystemControlPage().ShowDialog();
            }
        }

        private void btn_delete_model_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["LogInforAdmin"] == null)
            {
                new LogInforAdmin().ShowDialog();

                if (GlobalItems.admin_access == false)
                {
                    return;
                }
                else
                {
                    if (Application.OpenForms["DeleteModel"] == null)
                    {
                        new JLRPROJECTS.DeleteModel().ShowDialog();
                    }


                }

            }
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PageOne"] == null)
            {
                new PageOne().ShowDialog();
            }
        }

        
    }
}
