namespace ChargerVivo.CreateModels
{
    partial class CreateModelPage
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
            this.picboxOne = new System.Windows.Forms.PictureBox();
            this.mypanel = new System.Windows.Forms.Panel();
            this.picCroppedPicture = new System.Windows.Forms.PictureBox();
            this.btn_save_model = new System.Windows.Forms.Button();
            this.lbl_rect = new System.Windows.Forms.Label();
            this.lbl_points = new System.Windows.Forms.Label();
            this.tools_option_gb = new System.Windows.Forms.GroupBox();
            this.cb_checkclean = new System.Windows.Forms.CheckBox();
            this.cb_check_text_match = new System.Windows.Forms.CheckBox();
            this.cb_is_match = new System.Windows.Forms.CheckBox();
            this.txt_box_refstring = new System.Windows.Forms.TextBox();
            this.nm_p = new System.Windows.Forms.NumericUpDown();
            this.nm_m = new System.Windows.Forms.NumericUpDown();
            this.lbl_i = new System.Windows.Forms.Label();
            this.lbl_h = new System.Windows.Forms.Label();
            this.lbl_g = new System.Windows.Forms.Label();
            this.nm_o = new System.Windows.Forms.NumericUpDown();
            this.nm_r = new System.Windows.Forms.NumericUpDown();
            this.nm_q = new System.Windows.Forms.NumericUpDown();
            this.nm_n = new System.Windows.Forms.NumericUpDown();
            this.lbl_rect_v = new System.Windows.Forms.Label();
            this.lbl_x = new System.Windows.Forms.Label();
            this.lbl_f = new System.Windows.Forms.Label();
            this.lbl_c = new System.Windows.Forms.Label();
            this.lbl_e = new System.Windows.Forms.Label();
            this.lbl_d = new System.Windows.Forms.Label();
            this.lbl_b = new System.Windows.Forms.Label();
            this.lbl_a = new System.Windows.Forms.Label();
            this.btn_test_algo = new System.Windows.Forms.Button();
            this.btm_add_new_region = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.timer_camera_status = new System.Windows.Forms.Timer(this.components);
            this.live_timer = new System.Windows.Forms.Timer(this.components);
            this.picBoxThresholdImage = new System.Windows.Forms.PictureBox();
            this.cv_thresholsimage = new System.Windows.Forms.CheckBox();
            this.cb_template = new System.Windows.Forms.CheckBox();
            this.cb_model_name = new System.Windows.Forms.ComboBox();
            this.cb_region_name = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_threshold = new System.Windows.Forms.TrackBar();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btn_select_image_for_testing = new System.Windows.Forms.Button();
            this.cb_test_image = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOne)).BeginInit();
            this.mypanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCroppedPicture)).BeginInit();
            this.tools_option_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_p)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_o)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThresholdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxOne
            // 
            this.picboxOne.BackColor = System.Drawing.Color.YellowGreen;
            this.picboxOne.Location = new System.Drawing.Point(-14, 3);
            this.picboxOne.Name = "picboxOne";
            this.picboxOne.Size = new System.Drawing.Size(953, 822);
            this.picboxOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picboxOne.TabIndex = 1;
            this.picboxOne.TabStop = false;
            this.picboxOne.Click += new System.EventHandler(this.picboxOne_Click);
            this.picboxOne.Paint += new System.Windows.Forms.PaintEventHandler(this.picboxOne_Paint);
            this.picboxOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picboxOne_MouseDown);
            this.picboxOne.MouseEnter += new System.EventHandler(this.picboxOne_MouseEnter);
            this.picboxOne.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picboxOne_MouseMove);
            this.picboxOne.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picboxOne_MouseUp);
            // 
            // mypanel
            // 
            this.mypanel.AutoScroll = true;
            this.mypanel.Controls.Add(this.picboxOne);
            this.mypanel.Location = new System.Drawing.Point(0, 0);
            this.mypanel.Name = "mypanel";
            this.mypanel.Size = new System.Drawing.Size(942, 837);
            this.mypanel.TabIndex = 2;
            this.mypanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mypanel_Paint);
            // 
            // picCroppedPicture
            // 
            this.picCroppedPicture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picCroppedPicture.Location = new System.Drawing.Point(1138, 38);
            this.picCroppedPicture.Name = "picCroppedPicture";
            this.picCroppedPicture.Size = new System.Drawing.Size(423, 260);
            this.picCroppedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCroppedPicture.TabIndex = 3;
            this.picCroppedPicture.TabStop = false;
            this.picCroppedPicture.Visible = false;
            // 
            // btn_save_model
            // 
            this.btn_save_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_model.ForeColor = System.Drawing.Color.Black;
            this.btn_save_model.Location = new System.Drawing.Point(19, 337);
            this.btn_save_model.Name = "btn_save_model";
            this.btn_save_model.Size = new System.Drawing.Size(183, 33);
            this.btn_save_model.TabIndex = 4;
            this.btn_save_model.Text = "Update";
            this.btn_save_model.UseVisualStyleBackColor = true;
            this.btn_save_model.Click += new System.EventHandler(this.btn_save_model_Click);
            // 
            // lbl_rect
            // 
            this.lbl_rect.AutoSize = true;
            this.lbl_rect.Location = new System.Drawing.Point(1190, 378);
            this.lbl_rect.Name = "lbl_rect";
            this.lbl_rect.Size = new System.Drawing.Size(31, 13);
            this.lbl_rect.TabIndex = 37;
            this.lbl_rect.Text = "- - - - ";
            // 
            // lbl_points
            // 
            this.lbl_points.AutoSize = true;
            this.lbl_points.Location = new System.Drawing.Point(1143, 378);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(31, 13);
            this.lbl_points.TabIndex = 36;
            this.lbl_points.Text = "- - - - ";
            // 
            // tools_option_gb
            // 
            this.tools_option_gb.Controls.Add(this.cb_checkclean);
            this.tools_option_gb.Controls.Add(this.cb_check_text_match);
            this.tools_option_gb.Controls.Add(this.cb_is_match);
            this.tools_option_gb.Controls.Add(this.txt_box_refstring);
            this.tools_option_gb.Controls.Add(this.nm_p);
            this.tools_option_gb.Controls.Add(this.nm_m);
            this.tools_option_gb.Controls.Add(this.lbl_i);
            this.tools_option_gb.Controls.Add(this.lbl_h);
            this.tools_option_gb.Controls.Add(this.lbl_g);
            this.tools_option_gb.Controls.Add(this.nm_o);
            this.tools_option_gb.Controls.Add(this.btn_save_model);
            this.tools_option_gb.Controls.Add(this.nm_r);
            this.tools_option_gb.Controls.Add(this.nm_q);
            this.tools_option_gb.Controls.Add(this.nm_n);
            this.tools_option_gb.Controls.Add(this.lbl_rect_v);
            this.tools_option_gb.Controls.Add(this.lbl_x);
            this.tools_option_gb.Controls.Add(this.lbl_f);
            this.tools_option_gb.Controls.Add(this.lbl_c);
            this.tools_option_gb.Controls.Add(this.lbl_e);
            this.tools_option_gb.Controls.Add(this.lbl_d);
            this.tools_option_gb.Controls.Add(this.lbl_b);
            this.tools_option_gb.Controls.Add(this.lbl_a);
            this.tools_option_gb.Controls.Add(this.btn_test_algo);
            this.tools_option_gb.Location = new System.Drawing.Point(1140, 420);
            this.tools_option_gb.Name = "tools_option_gb";
            this.tools_option_gb.Size = new System.Drawing.Size(396, 376);
            this.tools_option_gb.TabIndex = 70;
            this.tools_option_gb.TabStop = false;
            this.tools_option_gb.Text = "Parameters";
            this.tools_option_gb.Enter += new System.EventHandler(this.tools_option_gb_Enter);
            // 
            // cb_checkclean
            // 
            this.cb_checkclean.AutoSize = true;
            this.cb_checkclean.Location = new System.Drawing.Point(282, 347);
            this.cb_checkclean.Name = "cb_checkclean";
            this.cb_checkclean.Size = new System.Drawing.Size(84, 17);
            this.cb_checkclean.TabIndex = 2;
            this.cb_checkclean.Text = "CheckClean";
            this.cb_checkclean.UseVisualStyleBackColor = true;
            this.cb_checkclean.CheckedChanged += new System.EventHandler(this.cb_checkclean_CheckedChanged);
            // 
            // cb_check_text_match
            // 
            this.cb_check_text_match.AutoSize = true;
            this.cb_check_text_match.Location = new System.Drawing.Point(282, 313);
            this.cb_check_text_match.Name = "cb_check_text_match";
            this.cb_check_text_match.Size = new System.Drawing.Size(108, 17);
            this.cb_check_text_match.TabIndex = 90;
            this.cb_check_text_match.Text = "CheckTextMatch";
            this.cb_check_text_match.UseVisualStyleBackColor = true;
            this.cb_check_text_match.CheckedChanged += new System.EventHandler(this.cb_check_text_match_CheckedChanged);
            // 
            // cb_is_match
            // 
            this.cb_is_match.AutoSize = true;
            this.cb_is_match.Location = new System.Drawing.Point(282, 249);
            this.cb_is_match.Name = "cb_is_match";
            this.cb_is_match.Size = new System.Drawing.Size(69, 17);
            this.cb_is_match.TabIndex = 88;
            this.cb_is_match.Text = "IS Match";
            this.cb_is_match.UseVisualStyleBackColor = true;
            // 
            // txt_box_refstring
            // 
            this.txt_box_refstring.Location = new System.Drawing.Point(166, 272);
            this.txt_box_refstring.Name = "txt_box_refstring";
            this.txt_box_refstring.Size = new System.Drawing.Size(120, 20);
            this.txt_box_refstring.TabIndex = 87;
            // 
            // nm_p
            // 
            this.nm_p.Location = new System.Drawing.Point(208, 127);
            this.nm_p.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_p.Name = "nm_p";
            this.nm_p.Size = new System.Drawing.Size(120, 20);
            this.nm_p.TabIndex = 86;
            this.nm_p.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nm_m
            // 
            this.nm_m.Location = new System.Drawing.Point(208, 37);
            this.nm_m.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nm_m.Name = "nm_m";
            this.nm_m.Size = new System.Drawing.Size(120, 20);
            this.nm_m.TabIndex = 85;
            this.nm_m.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_i
            // 
            this.lbl_i.AutoSize = true;
            this.lbl_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_i.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_i.Location = new System.Drawing.Point(15, 272);
            this.lbl_i.Name = "lbl_i";
            this.lbl_i.Size = new System.Drawing.Size(63, 20);
            this.lbl_i.TabIndex = 84;
            this.lbl_i.Text = "---------";
            // 
            // lbl_h
            // 
            this.lbl_h.AutoSize = true;
            this.lbl_h.Location = new System.Drawing.Point(62, 251);
            this.lbl_h.Name = "lbl_h";
            this.lbl_h.Size = new System.Drawing.Size(34, 13);
            this.lbl_h.TabIndex = 83;
            this.lbl_h.Text = "---------";
            // 
            // lbl_g
            // 
            this.lbl_g.AutoSize = true;
            this.lbl_g.Location = new System.Drawing.Point(62, 218);
            this.lbl_g.Name = "lbl_g";
            this.lbl_g.Size = new System.Drawing.Size(34, 13);
            this.lbl_g.TabIndex = 82;
            this.lbl_g.Text = "---------";
            // 
            // nm_o
            // 
            this.nm_o.Location = new System.Drawing.Point(208, 99);
            this.nm_o.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_o.Name = "nm_o";
            this.nm_o.Size = new System.Drawing.Size(120, 20);
            this.nm_o.TabIndex = 81;
            this.nm_o.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nm_r
            // 
            this.nm_r.Location = new System.Drawing.Point(208, 184);
            this.nm_r.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_r.Name = "nm_r";
            this.nm_r.Size = new System.Drawing.Size(120, 20);
            this.nm_r.TabIndex = 80;
            this.nm_r.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nm_q
            // 
            this.nm_q.Location = new System.Drawing.Point(208, 157);
            this.nm_q.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_q.Name = "nm_q";
            this.nm_q.Size = new System.Drawing.Size(120, 20);
            this.nm_q.TabIndex = 79;
            this.nm_q.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nm_n
            // 
            this.nm_n.Location = new System.Drawing.Point(208, 70);
            this.nm_n.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nm_n.Name = "nm_n";
            this.nm_n.Size = new System.Drawing.Size(120, 20);
            this.nm_n.TabIndex = 78;
            this.nm_n.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_rect_v
            // 
            this.lbl_rect_v.AutoSize = true;
            this.lbl_rect_v.Location = new System.Drawing.Point(141, 218);
            this.lbl_rect_v.Name = "lbl_rect_v";
            this.lbl_rect_v.Size = new System.Drawing.Size(31, 13);
            this.lbl_rect_v.TabIndex = 77;
            this.lbl_rect_v.Text = "--------";
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Location = new System.Drawing.Point(163, 251);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(31, 13);
            this.lbl_x.TabIndex = 76;
            this.lbl_x.Text = "--------";
            // 
            // lbl_f
            // 
            this.lbl_f.AutoSize = true;
            this.lbl_f.Location = new System.Drawing.Point(62, 191);
            this.lbl_f.Name = "lbl_f";
            this.lbl_f.Size = new System.Drawing.Size(34, 13);
            this.lbl_f.TabIndex = 73;
            this.lbl_f.Text = "---------";
            // 
            // lbl_c
            // 
            this.lbl_c.AutoSize = true;
            this.lbl_c.Location = new System.Drawing.Point(62, 99);
            this.lbl_c.Name = "lbl_c";
            this.lbl_c.Size = new System.Drawing.Size(34, 13);
            this.lbl_c.TabIndex = 72;
            this.lbl_c.Text = "---------";
            // 
            // lbl_e
            // 
            this.lbl_e.AutoSize = true;
            this.lbl_e.Location = new System.Drawing.Point(62, 157);
            this.lbl_e.Name = "lbl_e";
            this.lbl_e.Size = new System.Drawing.Size(34, 13);
            this.lbl_e.TabIndex = 75;
            this.lbl_e.Text = "---------";
            // 
            // lbl_d
            // 
            this.lbl_d.AutoSize = true;
            this.lbl_d.Location = new System.Drawing.Point(62, 127);
            this.lbl_d.Name = "lbl_d";
            this.lbl_d.Size = new System.Drawing.Size(34, 13);
            this.lbl_d.TabIndex = 74;
            this.lbl_d.Text = "---------";
            // 
            // lbl_b
            // 
            this.lbl_b.AutoSize = true;
            this.lbl_b.Location = new System.Drawing.Point(62, 72);
            this.lbl_b.Name = "lbl_b";
            this.lbl_b.Size = new System.Drawing.Size(34, 13);
            this.lbl_b.TabIndex = 71;
            this.lbl_b.Text = "---------";
            // 
            // lbl_a
            // 
            this.lbl_a.AutoSize = true;
            this.lbl_a.Location = new System.Drawing.Point(62, 37);
            this.lbl_a.Name = "lbl_a";
            this.lbl_a.Size = new System.Drawing.Size(34, 13);
            this.lbl_a.TabIndex = 70;
            this.lbl_a.Text = "---------";
            // 
            // btn_test_algo
            // 
            this.btn_test_algo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test_algo.ForeColor = System.Drawing.Color.Black;
            this.btn_test_algo.Location = new System.Drawing.Point(19, 302);
            this.btn_test_algo.Name = "btn_test_algo";
            this.btn_test_algo.Size = new System.Drawing.Size(183, 35);
            this.btn_test_algo.TabIndex = 69;
            this.btn_test_algo.Text = "Test Algo ";
            this.btn_test_algo.UseVisualStyleBackColor = true;
            this.btn_test_algo.Click += new System.EventHandler(this.btn_test_algo_Click);
            // 
            // btm_add_new_region
            // 
            this.btm_add_new_region.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btm_add_new_region.ForeColor = System.Drawing.Color.Black;
            this.btm_add_new_region.Location = new System.Drawing.Point(975, 802);
            this.btm_add_new_region.Name = "btm_add_new_region";
            this.btm_add_new_region.Size = new System.Drawing.Size(183, 35);
            this.btm_add_new_region.TabIndex = 89;
            this.btm_add_new_region.Text = "Add New Region ";
            this.btm_add_new_region.UseVisualStyleBackColor = true;
            this.btm_add_new_region.Visible = false;
            this.btm_add_new_region.Click += new System.EventHandler(this.btm_add_new_region_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Red;
            this.btn_exit.Location = new System.Drawing.Point(1403, 816);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(161, 33);
            this.btn_exit.TabIndex = 76;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // timer_camera_status
            // 
            this.timer_camera_status.Tick += new System.EventHandler(this.timer_camera_status_Tick);
            // 
            // live_timer
            // 
            this.live_timer.Tick += new System.EventHandler(this.live_timer_Tick);
            // 
            // picBoxThresholdImage
            // 
            this.picBoxThresholdImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picBoxThresholdImage.Location = new System.Drawing.Point(1138, 38);
            this.picBoxThresholdImage.Name = "picBoxThresholdImage";
            this.picBoxThresholdImage.Size = new System.Drawing.Size(404, 145);
            this.picBoxThresholdImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxThresholdImage.TabIndex = 77;
            this.picBoxThresholdImage.TabStop = false;
            this.picBoxThresholdImage.Visible = false;
            // 
            // cv_thresholsimage
            // 
            this.cv_thresholsimage.AutoSize = true;
            this.cv_thresholsimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv_thresholsimage.Location = new System.Drawing.Point(1431, 304);
            this.cv_thresholsimage.Name = "cv_thresholsimage";
            this.cv_thresholsimage.Size = new System.Drawing.Size(105, 17);
            this.cv_thresholsimage.TabIndex = 78;
            this.cv_thresholsimage.Text = "Threshold Image";
            this.cv_thresholsimage.UseVisualStyleBackColor = true;
            this.cv_thresholsimage.Visible = false;
            this.cv_thresholsimage.CheckedChanged += new System.EventHandler(this.cv_thresholsimage_CheckedChanged);
            // 
            // cb_template
            // 
            this.cb_template.AutoSize = true;
            this.cb_template.Checked = true;
            this.cb_template.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_template.Location = new System.Drawing.Point(1466, 352);
            this.cb_template.Name = "cb_template";
            this.cb_template.Size = new System.Drawing.Size(70, 17);
            this.cb_template.TabIndex = 34;
            this.cb_template.Text = "Template";
            this.cb_template.UseVisualStyleBackColor = true;
            // 
            // cb_model_name
            // 
            this.cb_model_name.BackColor = System.Drawing.Color.White;
            this.cb_model_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_model_name.FormattingEnabled = true;
            this.cb_model_name.Location = new System.Drawing.Point(1140, 0);
            this.cb_model_name.Name = "cb_model_name";
            this.cb_model_name.Size = new System.Drawing.Size(295, 32);
            this.cb_model_name.TabIndex = 79;
            this.cb_model_name.Text = "        select model ";
            this.cb_model_name.SelectedIndexChanged += new System.EventHandler(this.cb_model_name_SelectedIndexChanged);
            // 
            // cb_region_name
            // 
            this.cb_region_name.BackColor = System.Drawing.Color.White;
            this.cb_region_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_region_name.FormattingEnabled = true;
            this.cb_region_name.Location = new System.Drawing.Point(1140, 382);
            this.cb_region_name.Name = "cb_region_name";
            this.cb_region_name.Size = new System.Drawing.Size(223, 32);
            this.cb_region_name.TabIndex = 80;
            this.cb_region_name.Text = "Select Region Name";
            this.cb_region_name.SelectedIndexChanged += new System.EventHandler(this.cb_region_name_SelectedIndexChanged);
            this.cb_region_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_region_name_KeyPress);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(1469, 382);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(95, 32);
            this.btn_delete.TabIndex = 89;
            this.btn_delete.Text = "Delete Selected";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1136, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "Time ....";
            // 
            // trackBar_threshold
            // 
            this.trackBar_threshold.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_threshold.Location = new System.Drawing.Point(1422, 324);
            this.trackBar_threshold.Maximum = 255;
            this.trackBar_threshold.Name = "trackBar_threshold";
            this.trackBar_threshold.Size = new System.Drawing.Size(133, 45);
            this.trackBar_threshold.TabIndex = 94;
            this.trackBar_threshold.Scroll += new System.EventHandler(this.trackBar_threshold_Scroll);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(1375, 382);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 16);
            this.btnPrev.TabIndex = 95;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1375, 398);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 16);
            this.btnNext.TabIndex = 96;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btn_select_image_for_testing
            // 
            this.btn_select_image_for_testing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select_image_for_testing.ForeColor = System.Drawing.Color.Black;
            this.btn_select_image_for_testing.Location = new System.Drawing.Point(948, 388);
            this.btn_select_image_for_testing.Name = "btn_select_image_for_testing";
            this.btn_select_image_for_testing.Size = new System.Drawing.Size(163, 32);
            this.btn_select_image_for_testing.TabIndex = 97;
            this.btn_select_image_for_testing.Text = "Select Image For Testing";
            this.btn_select_image_for_testing.UseVisualStyleBackColor = true;
            this.btn_select_image_for_testing.Click += new System.EventHandler(this.btn_select_image_for_testing_Click);
            // 
            // cb_test_image
            // 
            this.cb_test_image.AutoSize = true;
            this.cb_test_image.Location = new System.Drawing.Point(975, 352);
            this.cb_test_image.Name = "cb_test_image";
            this.cb_test_image.Size = new System.Drawing.Size(95, 17);
            this.cb_test_image.TabIndex = 98;
            this.cb_test_image.Text = "Test An Image";
            this.cb_test_image.UseVisualStyleBackColor = true;
            this.cb_test_image.CheckedChanged += new System.EventHandler(this.cb_test_image_CheckedChanged);
            // 
            // CreateModelPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.cb_test_image);
            this.Controls.Add(this.btn_select_image_for_testing);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.trackBar_threshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.cb_region_name);
            this.Controls.Add(this.btm_add_new_region);
            this.Controls.Add(this.cb_model_name);
            this.Controls.Add(this.cv_thresholsimage);
            this.Controls.Add(this.picBoxThresholdImage);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.tools_option_gb);
            this.Controls.Add(this.lbl_rect);
            this.Controls.Add(this.lbl_points);
            this.Controls.Add(this.cb_template);
            this.Controls.Add(this.picCroppedPicture);
            this.Controls.Add(this.mypanel);
            this.Name = "CreateModelPage";
            this.Text = "CreateModelPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateModelPage_FormClosing);
            this.Load += new System.EventHandler(this.CreateModelPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxOne)).EndInit();
            this.mypanel.ResumeLayout(false);
            this.mypanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCroppedPicture)).EndInit();
            this.tools_option_gb.ResumeLayout(false);
            this.tools_option_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_p)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_o)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThresholdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picboxOne;
        private System.Windows.Forms.Panel mypanel;
        private System.Windows.Forms.PictureBox picCroppedPicture;
        private System.Windows.Forms.Button btn_save_model;
        private System.Windows.Forms.Label lbl_rect;
        private System.Windows.Forms.Label lbl_points;
        private System.Windows.Forms.GroupBox tools_option_gb;
        private System.Windows.Forms.NumericUpDown nm_o;
        private System.Windows.Forms.NumericUpDown nm_r;
        private System.Windows.Forms.NumericUpDown nm_q;
        private System.Windows.Forms.NumericUpDown nm_n;
        private System.Windows.Forms.Label lbl_rect_v;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.Label lbl_f;
        private System.Windows.Forms.Label lbl_c;
        private System.Windows.Forms.Label lbl_e;
        private System.Windows.Forms.Label lbl_d;
        private System.Windows.Forms.Label lbl_b;
        private System.Windows.Forms.Label lbl_a;
        private System.Windows.Forms.Button btn_test_algo;
        private System.Windows.Forms.Label lbl_i;
        private System.Windows.Forms.Label lbl_h;
        private System.Windows.Forms.Label lbl_g;
        private System.Windows.Forms.NumericUpDown nm_m;
        private System.Windows.Forms.NumericUpDown nm_p;
        private System.Windows.Forms.TextBox txt_box_refstring;
        private System.Windows.Forms.CheckBox cb_is_match;
        private System.Windows.Forms.Timer timer_camera_status;
        private System.Windows.Forms.Timer live_timer;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.PictureBox picBoxThresholdImage;
        private System.Windows.Forms.CheckBox cv_thresholsimage;
        private System.Windows.Forms.CheckBox cb_template;
        private System.Windows.Forms.ComboBox cb_model_name;
        private System.Windows.Forms.ComboBox cb_region_name;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btm_add_new_region;
        private System.Windows.Forms.CheckBox cb_checkclean;
        private System.Windows.Forms.CheckBox cb_check_text_match;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar_threshold;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btn_select_image_for_testing;
        private System.Windows.Forms.CheckBox cb_test_image;
    }
}