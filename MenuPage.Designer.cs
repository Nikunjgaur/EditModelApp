namespace EditModelApp
{
    partial class MenuPage
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
            this.btn_create_model = new System.Windows.Forms.Button();
            this.btn_edit_model = new System.Windows.Forms.Button();
            this.btn_delete_model = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.btn_system_cotroller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_create_model
            // 
            this.btn_create_model.BackColor = System.Drawing.Color.Blue;
            this.btn_create_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_create_model.ForeColor = System.Drawing.Color.Yellow;
            this.btn_create_model.Location = new System.Drawing.Point(156, 86);
            this.btn_create_model.Name = "btn_create_model";
            this.btn_create_model.Size = new System.Drawing.Size(202, 55);
            this.btn_create_model.TabIndex = 0;
            this.btn_create_model.Text = "Create Model";
            this.btn_create_model.UseVisualStyleBackColor = false;
            this.btn_create_model.Click += new System.EventHandler(this.btn_create_model_Click);
            // 
            // btn_edit_model
            // 
            this.btn_edit_model.BackColor = System.Drawing.Color.Blue;
            this.btn_edit_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit_model.ForeColor = System.Drawing.Color.Yellow;
            this.btn_edit_model.Location = new System.Drawing.Point(415, 86);
            this.btn_edit_model.Name = "btn_edit_model";
            this.btn_edit_model.Size = new System.Drawing.Size(184, 55);
            this.btn_edit_model.TabIndex = 1;
            this.btn_edit_model.Text = "Edit Model";
            this.btn_edit_model.UseVisualStyleBackColor = false;
            this.btn_edit_model.Click += new System.EventHandler(this.btn_edit_model_Click);
            // 
            // btn_delete_model
            // 
            this.btn_delete_model.BackColor = System.Drawing.Color.Blue;
            this.btn_delete_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete_model.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_delete_model.Location = new System.Drawing.Point(156, 251);
            this.btn_delete_model.Name = "btn_delete_model";
            this.btn_delete_model.Size = new System.Drawing.Size(443, 46);
            this.btn_delete_model.TabIndex = 39;
            this.btn_delete_model.Text = "Delete Model";
            this.btn_delete_model.UseVisualStyleBackColor = false;
            this.btn_delete_model.Click += new System.EventHandler(this.btn_delete_model_Click);
            // 
            // btn_report
            // 
            this.btn_report.BackColor = System.Drawing.Color.Blue;
            this.btn_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_report.Location = new System.Drawing.Point(156, 183);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(202, 45);
            this.btn_report.TabIndex = 38;
            this.btn_report.Text = "Inspection Log";
            this.btn_report.UseVisualStyleBackColor = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // btn_system_cotroller
            // 
            this.btn_system_cotroller.BackColor = System.Drawing.Color.Blue;
            this.btn_system_cotroller.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_system_cotroller.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_system_cotroller.Location = new System.Drawing.Point(415, 181);
            this.btn_system_cotroller.Name = "btn_system_cotroller";
            this.btn_system_cotroller.Size = new System.Drawing.Size(184, 46);
            this.btn_system_cotroller.TabIndex = 37;
            this.btn_system_cotroller.Text = "System Control";
            this.btn_system_cotroller.UseVisualStyleBackColor = false;
            this.btn_system_cotroller.Click += new System.EventHandler(this.btn_system_cotroller_Click);
            // 
            // MenuPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(749, 415);
            this.Controls.Add(this.btn_delete_model);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.btn_system_cotroller);
            this.Controls.Add(this.btn_edit_model);
            this.Controls.Add(this.btn_create_model);
            this.Name = "MenuPage";
            this.Text = "MenuPage";
            this.Load += new System.EventHandler(this.MenuPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_create_model;
        private System.Windows.Forms.Button btn_edit_model;
        private System.Windows.Forms.Button btn_delete_model;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.Button btn_system_cotroller;
    }
}