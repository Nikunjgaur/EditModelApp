using ChargerVivo.CreateModels;
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

namespace GoldenPeacock.App
{
    public partial class ModelDataInput : Form
    {
        public ModelDataInput()
        {
            InitializeComponent();
        }

        private void ModelDataInput_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            this.Icon = new Icon(GlobalItems.icon);
            this.Text = "Enter Model Data  ";





            txt_modelname.Text = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_tt");
            txt_model_creator.Text = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_tt");



        }

        private void btn_save_model_data_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_modelname.Text))
                Console.WriteLine(" model name is null ");
            if (String.IsNullOrEmpty(txt_model_creator.Text))
                Console.WriteLine(" creator name is null  ");
            if (String.IsNullOrEmpty(txt_remark.Text))
                Console.WriteLine("remark is null  ");



            GlobalItems._Model.ModelName = txt_modelname.Text;
            GlobalItems._Model.CreatorName = txt_model_creator.Text;
            GlobalItems._Model.Remark = txt_remark.Text;


            string model_folder_path = GlobalItems.data_base_folder +GlobalItems._Model.ModelName;
            Console.WriteLine("model folder path : " + model_folder_path);

            bool exists = System.IO.Directory.Exists(model_folder_path);
            if (!exists)
            {
                Console.WriteLine(model_folder_path + " not exist ");

                System.IO.Directory.CreateDirectory(model_folder_path);
            }
            else
            {
                Console.WriteLine(model_folder_path + "Exist ");
            }


            //this.Close();
            this.Hide();

            if (Application.OpenForms["CraeteModel"] == null)
            {
                new CreateModelPage().ShowDialog();
            }

        }//btn_save_model_data_Click

    
    }
}
