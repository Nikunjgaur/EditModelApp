namespace GoldenPeacock.App
{
    partial class ModelDataInput
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
            this.lbl_model_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_modelname = new System.Windows.Forms.TextBox();
            this.txt_model_creator = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.btn_save_model_data = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_model_name
            // 
            this.lbl_model_name.AutoSize = true;
            this.lbl_model_name.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_model_name.Location = new System.Drawing.Point(24, 33);
            this.lbl_model_name.Name = "lbl_model_name";
            this.lbl_model_name.Size = new System.Drawing.Size(126, 13);
            this.lbl_model_name.TabIndex = 23;
            this.lbl_model_name.Text = "Enter The Model Name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(24, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Enter The Model Creator  Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(24, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Enter The Remark : ";
            // 
            // txt_modelname
            // 
            this.txt_modelname.Location = new System.Drawing.Point(243, 33);
            this.txt_modelname.Name = "txt_modelname";
            this.txt_modelname.Size = new System.Drawing.Size(155, 20);
            this.txt_modelname.TabIndex = 26;
            this.txt_modelname.Text = "Demo_model";
            // 
            // txt_model_creator
            // 
            this.txt_model_creator.Location = new System.Drawing.Point(243, 70);
            this.txt_model_creator.Name = "txt_model_creator";
            this.txt_model_creator.Size = new System.Drawing.Size(155, 20);
            this.txt_model_creator.TabIndex = 27;
            this.txt_model_creator.Text = "Demo_model";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(243, 106);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(155, 20);
            this.txt_remark.TabIndex = 28;
            this.txt_remark.Text = "Demo_model";
            // 
            // btn_save_model_data
            // 
            this.btn_save_model_data.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_save_model_data.Location = new System.Drawing.Point(38, 165);
            this.btn_save_model_data.Name = "btn_save_model_data";
            this.btn_save_model_data.Size = new System.Drawing.Size(341, 20);
            this.btn_save_model_data.TabIndex = 29;
            this.btn_save_model_data.Text = "Save Model Data";
            this.btn_save_model_data.UseVisualStyleBackColor = true;
            this.btn_save_model_data.Click += new System.EventHandler(this.btn_save_model_data_Click);
            // 
            // ModelDataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 255);
            this.Controls.Add(this.btn_save_model_data);
            this.Controls.Add(this.txt_remark);
            this.Controls.Add(this.txt_model_creator);
            this.Controls.Add(this.txt_modelname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_model_name);
            this.Name = "ModelDataInput";
            this.Text = "ModelDataInput";
            this.Load += new System.EventHandler(this.ModelDataInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_model_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_modelname;
        private System.Windows.Forms.TextBox txt_model_creator;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Button btn_save_model_data;
    }
}