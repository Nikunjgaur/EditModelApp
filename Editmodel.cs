using ChargerVivo.LogInModule;
using ChargerVivo.Models;
using ChargerVivo.ocr_qr_code;
using ChargerVivo.Persistance;
using ChargerVivo.Service;
using ChargerVivo.Statics;
using EditModelApp;
using Mapplication.Inspect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChargerVivo.CreateModels
{
    public partial class CreateModelPage : Form
    {
        public CreateModelPage()
        {
            InitializeComponent();
        }
        List<Rectangle> _draw_rect_list = new List<Rectangle>();
        AlgoCpp.SalcomCpp _SalcomCpp = new AlgoCpp.SalcomCpp();
        Modal _Modal = new Modal();
        CheckTextMatch _CheckTextMatch_test_algo_object = new CheckTextMatch();
        CheckClean _CheckClean_test_algo_object = new CheckClean();
        OcrReader _OcrReader_test_algo_object = new OcrReader();
        QrCodeReader _QrCodeReader_test_algo_object = new QrCodeReader();
        ExceptionModel _Exception_test_algo_object = new ExceptionModel();
        bool isToolsSelected = false;
        Modal _Model_copy = null;
        private string model_name;
        Modal _model = null;
        Pen _redPen = new Pen(Color.Red, 2);
        Pen _greenPen = new Pen(Color.Green, 2);
        bool is_add_new_region = true;
        private void CreateModelPage_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Icon = new Icon(GlobalItems.icon);
            this.Text = "Edit A specific Model .";
            cb_template.Visible = false;
            mypanel.HorizontalScroll.Enabled = true;
            mypanel.VerticalScroll.Enabled = true;
            //this.cb_region_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            btn_test_algo.Enabled = false;
            mypanel.AutoScroll = true;
            DirectoryInfo[] all_model = FolderManagement.get_all_model_folder(GlobalItems.data_base_folder.FullName);
            int total_folder_count = 0;
            int total_valid_folder_count = 0;
            foreach (DirectoryInfo dir_info in all_model)
            {
                total_folder_count++;
                string json_data_path = dir_info.FullName + @"\_data.json";
                string bigger_template_path = dir_info.FullName + @"\bigger_template.bmp";
                string smaller_template_path = dir_info.FullName + @"\smaller_template.bmp";
                Console.WriteLine("json_data_path    ---- : " + json_data_path);
                if (File.Exists(json_data_path) && File.Exists(bigger_template_path) && File.Exists(smaller_template_path))
                {
                    total_valid_folder_count++;
                    cb_model_name.Items.Add(dir_info.Name);
                }
            }
            Console.WriteLine("Total folder count : " + total_folder_count);
            Console.WriteLine("Total Valid folder count : " + total_folder_count);
            cb_region_name.Enabled = false;
            tools_option_gb.Visible = false;
            btn_test_algo.Enabled = false;
            btn_save_model.Enabled = false;
            btn_select_image_for_testing.Enabled = false;
            live_timer.Enabled = true;
            live_timer.Interval = 1000;
            live_timer.Start(); ;

        }
        private void btn_test_code_Click(object sender, EventArgs e)
        {
        }
        Boolean mouseClicked;
        Point startPoint = new Point();
        Point endPoint = new Point();
        Rectangle rectCropArea;
        Pen drawLine;
        Bitmap targetBitmap;
        private void picboxOne_Click(object sender, EventArgs e)
        {
            picboxOne.Refresh();
        }
        private bool _once = false;
        private void picboxOne_Paint(object sender, PaintEventArgs e)
        {
            drawLine = new Pen(Color.Red,2);
            
            drawLine.DashStyle = DashStyle.Dash;
            e.Graphics.DrawRectangle(drawLine, rectCropArea);


            if(_model!=null)
            {

                foreach (CheckTextMatch tc in _model.CheckTextMatch)
                {
                    if (tc.regionName.Equals(cb_region_name.Text))
                    {
                        Bitmap img = null;
                        if (File.Exists(_model.TemplateImagePathSmaller))
                        {
                            using (var bmpTemp = new Bitmap(_model.TemplateImagePathSmaller))
                            {
                                img = new Bitmap(bmpTemp);
                            }
                            // picboxOne.Image = img;
                        }
                        using (var graphics = Graphics.FromImage(img))
                        {
                            Rectangle _rectangle = new Rectangle(
                                (int)tc.PointAX,
                                (int)tc.PointAY,
                                (int)(tc.PointBX),
                                (int)tc.PointBY);
                            // graphics.DrawRectangle(_redPen, _rectangle);
                            e.Graphics.DrawRectangle(_redPen, _rectangle);
                        }

                    }
                }
                foreach (CheckClean tc in _model.CheckClean)
                {
                    if (tc.regionName.Equals(cb_region_name.Text))
                    {
                        if (tc.regionName.Equals(cb_region_name.Text))
                        {
                            Bitmap img = null;
                            if (File.Exists(_model.template_image_path_bigger))
                            {
                                using (var bmpTemp = new Bitmap(_model.template_image_path_bigger))
                                {
                                    img = new Bitmap(bmpTemp);
                                }
                                //  picboxOne.Image = img;
                            }
                            using (var graphics = Graphics.FromImage(img))
                            {

                                Rectangle _rectangle = new Rectangle(
                                    (int)tc.PointAX,
                                    (int)tc.PointAY,
                                    (int)(tc.PointBX),
                                    (int)tc.PointBY);
                                // graphics.DrawRectangle(_redPen, _rectangle);
                                e.Graphics.DrawRectangle(_redPen, _rectangle);
                            }

                        }
                    }
                }

            }



            #region    show   checkbox tools all region 
            if (_model != null)
            {

                if (cb_check_text_match.Checked == true)
                {

                    foreach (CheckTextMatch tc in _model.CheckTextMatch)
                    {

                        Rectangle _rectangle = new Rectangle(
                            (int)tc.PointAX,
                            (int)tc.PointAY,
                            (int)(tc.PointBX),
                            (int)tc.PointBY);

                        e.Graphics.DrawRectangle(_redPen, _rectangle);

                    }

                }


                if (cb_checkclean.Checked == true)
                {
                    foreach (CheckClean tc in _model.CheckClean)
                    {

                        Rectangle _rectangle = new Rectangle(
                           (int)tc.PointAX,
                           (int)tc.PointAY,
                           (int)(tc.PointBX),
                           (int)tc.PointBY);

                        e.Graphics.DrawRectangle(_redPen, _rectangle);

                    }

                }

            

            }
            #endregion  





        }//picboxOne_Paint
        private void picboxOne_MouseDown(object sender, MouseEventArgs e)
        {
            if (tools_name.Equals(""))
            {
                MessageBox.Show("Please Select Either Tools Or Region Name " + " ", "Alert",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            picBoxThresholdImage.Visible = false;
            mouseClicked = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            endPoint.X = -1;
            endPoint.Y = -1;
            rectCropArea = new Rectangle(new Point(e.X, e.Y), new Size());
        }
        private void picboxOne_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);
            // lbl_points.Text = "[ " + startPoint + " ]" + "[ " + ptCurrent + " ]";
            if (e.X > picboxOne.Width || e.Y > picboxOne.Height)
            {
                MessageBox.Show("out oF region  ");
                return;
            }
            if (mouseClicked)
            {
                if (endPoint.X != -1)
                {
                }
                endPoint = ptCurrent;
                if (e.X > startPoint.X && e.Y > startPoint.Y)
                {
                    rectCropArea.Width = e.X - startPoint.X;
                    rectCropArea.Height = e.Y - startPoint.Y;
                }
                else if (e.X < startPoint.X && e.Y > startPoint.Y)
                {
                    rectCropArea.Width = startPoint.X - e.X;
                    rectCropArea.Height = e.Y - startPoint.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = startPoint.Y;
                }
                else if (e.X > startPoint.X && e.Y < startPoint.Y)
                {
                    rectCropArea.Width = e.X - startPoint.X;
                    rectCropArea.Height = startPoint.Y - e.Y;
                    rectCropArea.X = startPoint.X;
                    rectCropArea.Y = e.Y;
                }
                else
                {
                    rectCropArea.Width = startPoint.X - e.X;
                    rectCropArea.Height = startPoint.Y - e.Y;
                    rectCropArea.X = e.X;
                    rectCropArea.Y = e.Y;
                }
                picboxOne.Refresh();
            }
        }
        private void picboxOne_MouseEnter(object sender, EventArgs e)
        {
        }
        int template_count = 0;
        private void picboxOne_MouseUp(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Is Croped Correct ? ", "Alert Message ", MessageBoxButtons.YesNo) == DialogResult.Yes == false)
            {
                mouseClicked = false;
                return;
            }
            mouseClicked = false;
            if (endPoint.X != -1)
            {
                Point currentPoint = new Point(e.X, e.Y);
            }
            endPoint.X = -1;
            endPoint.Y = -1;
            startPoint.X = -1;
            startPoint.Y = -1;
            if (picboxOne.Image != null)
            {
                if (rectCropArea.Width == 0 || rectCropArea.Height == 0)
                {
                    MessageBox.Show("not a valid points ");
                    return;
                }
                picCroppedPicture.Refresh();
                if (picboxOne.Image != null)
                {
                    if (rectCropArea.Width == 0 || rectCropArea.Height == 0)
                    {
                        MessageBox.Show("not a valid points ");
                        return;
                    }
                    picCroppedPicture.Refresh();
                    targetBitmap = new Bitmap(rectCropArea.Width, rectCropArea.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Bitmap sourceBitmap = new Bitmap(picboxOne.Image, picboxOne.Width, picboxOne.Height);
                    Graphics g = Graphics.FromImage(targetBitmap);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(sourceBitmap, new Rectangle(0, 0, rectCropArea.Width, rectCropArea.Height), rectCropArea, GraphicsUnit.Pixel);
                    if (picCroppedPicture.Image != null)
                        picCroppedPicture.Image.Dispose();
                    picCroppedPicture.Visible = true;
                    picCroppedPicture.Image = targetBitmap;
                    btn_test_algo.Enabled = true;
                    Console.WriteLine("tools_name --- " + tools_name);
                    Console.WriteLine("is_add_new_region --- " + is_add_new_region);
                    if (tools_name.Equals("CheckTextMatch") && is_add_new_region == true)
                    {
                        _CheckTextMatch_test_algo_object.PointAX = (rectCropArea.X);
                        _CheckTextMatch_test_algo_object.PointAY = (rectCropArea.Y);
                        _CheckTextMatch_test_algo_object.PointBX = (rectCropArea.Width);
                        _CheckTextMatch_test_algo_object.PointBY = (rectCropArea.Height);
                        string template_path = GlobalItems.data_base_folder + _model.ModelName + @"\" + DateTime.Now.ToString("HH_mm_ss_tt") + ".bmp";
                        targetBitmap.Save(template_path);
                        _CheckTextMatch_test_algo_object.TemplateImagePath = template_path;
                    }
                    if (tools_name.Equals("CheckClean") && is_add_new_region == true)
                    {
                        _CheckClean_test_algo_object.PointAX = (rectCropArea.X);
                        _CheckClean_test_algo_object.PointAY = (rectCropArea.Y);
                        _CheckClean_test_algo_object.PointBX = (rectCropArea.Width);
                        _CheckClean_test_algo_object.PointBY = (rectCropArea.Height);
                        string template_path = GlobalItems.data_base_folder + _model.ModelName + @"\" + DateTime.Now.ToString("HH_mm_ss_tt") + ".bmp";
                        targetBitmap.Save(template_path);
                        _CheckClean_test_algo_object.TemplateImagePath = template_path;
                    }
                }//if (picboxOne.Image != null)
            }
            else
            {
                MessageBox.Show("Image Not Available " + "Please Captured The Image ", "Alert",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//mpuse up 
        private void btn_save_model_Click(object sender, EventArgs e)
        {
            if (_save_new_tools == true)
            {
                //InputDialog dialog = new InputDialog("Region Input Dialog  ", " Region Name ", "  ");
                //string region_name_ = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    region_name_ = dialog.ResultText;
                //}
                if (tools_name.Equals("CheckTextMatch"))
                {
                    _CheckTextMatch_test_algo_object.Threshold = nm_m.Value;
                    _CheckTextMatch_test_algo_object.MatchScore = nm_n.Value;
                    _CheckTextMatch_test_algo_object.AvgColor = nm_o.Value;
                    _CheckTextMatch_test_algo_object.HeighTolerance = nm_p.Value;
                    _CheckTextMatch_test_algo_object.WidthTolerance = nm_q.Value;
                    _CheckTextMatch_test_algo_object.AreaTolerance = nm_r.Value;


                    _CheckTextMatch_test_algo_object.regionName = "Region_"+(_Model_copy.CheckTextMatch.Count()+1)+"_";
                    _Model_copy.CheckTextMatch.Add(_CheckTextMatch_test_algo_object);
                }
                if (tools_name.Equals("CheckClean"))
                {
                    _CheckClean_test_algo_object.Avg_color = nm_m.Value;
                    _CheckClean_test_algo_object.Step_Size = nm_n.Value;
                    _CheckClean_test_algo_object.HeighTolerance = nm_o.Value;
                    _CheckClean_test_algo_object.WidthTolerance = nm_p.Value;
                    _CheckClean_test_algo_object.AreaTolerance = nm_q.Value;
                    _CheckClean_test_algo_object.Threshold = nm_r.Value;
                    _CheckClean_test_algo_object.regionName = "Region_" + (_Model_copy.CheckClean.Count() + 1) + "_"; ;
                    _Model_copy.CheckTextMatch.Add(_CheckTextMatch_test_algo_object);
                    _Model_copy.CheckClean.Add(_CheckClean_test_algo_object);


                }
            }// if (_save_new_tools == true)
            else
            {
                string region_name = cb_region_name.Text;
                for (int i = 0; i < _model.CheckTextMatch.Count(); i++)
                {
                    CheckTextMatch tc = _model.CheckTextMatch.ElementAt(i);
                    if (tc.regionName.Equals(region_name))
                    {
                        _Model_copy.CheckTextMatch.ElementAt(i).Threshold = nm_m.Value;
                        _Model_copy.CheckTextMatch.ElementAt(i).MatchScore = nm_n.Value;
                        _Model_copy.CheckTextMatch.ElementAt(i).AvgColor = nm_o.Value;
                        _Model_copy.CheckTextMatch.ElementAt(i).HeighTolerance = nm_p.Value;
                        _Model_copy.CheckTextMatch.ElementAt(i).WidthTolerance = nm_q.Value;
                        _Model_copy.CheckTextMatch.ElementAt(i).AreaTolerance = nm_r.Value;
                        //_CheckTextMatch_test_algo_object.Threshold = nm_m.Value;
                        //_CheckTextMatch_test_algo_object.MatchScore = nm_n.Value;
                        //_CheckTextMatch_test_algo_object.AvgColor = nm_o.Value;
                        //_CheckTextMatch_test_algo_object.HeighTolerance = nm_p.Value;
                        //_CheckTextMatch_test_algo_object.WidthTolerance = nm_q.Value;
                        //_CheckTextMatch_test_algo_object.AreaTolerance = nm_r.Value;
                        //_CheckTextMatch_test_algo_object.TemplateImagePath = tc.TemplateImagePath;
                        _Model_copy.CheckTextMatch.ElementAt(i).TemplateImagePath = _CheckTextMatch_test_algo_object.TemplateImagePath;
                        if (_CheckTextMatch_test_algo_object.PointAX != 0)
                        {
                            _Model_copy.CheckTextMatch.ElementAt(i).PointAX = _CheckTextMatch_test_algo_object.PointAX;
                            _Model_copy.CheckTextMatch.ElementAt(i).PointAY = _CheckTextMatch_test_algo_object.PointAY;
                            _Model_copy.CheckTextMatch.ElementAt(i).PointBX = _CheckTextMatch_test_algo_object.PointBX;
                            _Model_copy.CheckTextMatch.ElementAt(i).PointBY = _CheckTextMatch_test_algo_object.PointBY;
                        }
                        //  _Model_copy.CheckTextMatch.ElementAt(i).Threshold = _CheckTextMatch_test_algo_object.Threshold;
                    }
                }
                for (int i = 0; i < _model.CheckClean.Count(); i++)
                {
                    CheckClean tc = _model.CheckClean.ElementAt(i);
                    if (tc.regionName.Equals(region_name))
                    {
                        if (tc.regionName.Equals(region_name))
                        {
                            _Model_copy.CheckClean.ElementAt(i).Avg_color = nm_m.Value;
                            _Model_copy.CheckClean.ElementAt(i).Step_Size = nm_n.Value;
                            _Model_copy.CheckClean.ElementAt(i).HeighTolerance = nm_o.Value;
                            _Model_copy.CheckClean.ElementAt(i).WidthTolerance = nm_p.Value;
                            _Model_copy.CheckClean.ElementAt(i).AreaTolerance = nm_q.Value;
                            _Model_copy.CheckClean.ElementAt(i).Threshold = nm_r.Value;
                        }
                    }
                }
            }
            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data.json";
            string json = JsonConvert.SerializeObject(_Model_copy, Formatting.Indented);
            File.WriteAllText(json_path, json);
            ServiceUtils.Log("updated file path  .......... ");
            ServiceUtils.Log(json_path);
            cb_region_name.Items.Remove(cb_region_name.SelectedItem);
            cb_region_name.Items.Clear();
            after_upadte();
            btn_save_model.Enabled = false;

            MessageBox.Show("Model Updated  " + ". ", " Notification ?",
            MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        int x_value = 0;
        int y_value = 0;
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                int change = mypanel.VerticalScroll.Value - mypanel.VerticalScroll.SmallChange * 30;
                Console.WriteLine("-------------- " + x_value * -1);
                mypanel.AutoScrollPosition = new System.Drawing.Point(x_value * -1, change);
                x_value = mypanel.AutoScrollPosition.X;
                y_value = mypanel.AutoScrollPosition.Y;
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                int change = mypanel.VerticalScroll.Value + mypanel.VerticalScroll.SmallChange * 30;
                mypanel.AutoScrollPosition = new Point(x_value * -1, change);
                x_value = mypanel.AutoScrollPosition.X;
                y_value = mypanel.AutoScrollPosition.Y;
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                int change = mypanel.HorizontalScroll.Value - mypanel.HorizontalScroll.SmallChange * 30;
                mypanel.AutoScrollPosition = new Point(change, y_value * -1);
                x_value = mypanel.AutoScrollPosition.X;
                y_value = mypanel.AutoScrollPosition.Y;
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                int change = mypanel.HorizontalScroll.Value + mypanel.HorizontalScroll.SmallChange * 10;
                mypanel.AutoScrollPosition = new Point(change, y_value * -1);
                x_value = mypanel.AutoScrollPosition.X;
                y_value = mypanel.AutoScrollPosition.Y;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void mypanel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void cb_toolsName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }//cb_toolsName_SelectedIndexChanged
        private void btn_test_algo_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            ServiceUtils.Log("tools_name  : " + tools_name);
            if (tools_name.Equals("CheckTextMatch"))
            {
                ServiceUtils.Log("");
                Bitmap small_image_test;
                using (var bmpTemp = new Bitmap(_CheckTextMatch_test_algo_object.TemplateImagePath))
                {
                    small_image_test = new Bitmap(bmpTemp);
                }
                _CheckTextMatch_test_algo_object.Threshold = nm_m.Value;
                _CheckTextMatch_test_algo_object.MatchScore = nm_n.Value;
                _CheckTextMatch_test_algo_object.AvgColor = nm_o.Value;
                _CheckTextMatch_test_algo_object.HeighTolerance = nm_p.Value;
                _CheckTextMatch_test_algo_object.WidthTolerance = nm_q.Value;
                _CheckTextMatch_test_algo_object.AreaTolerance = nm_r.Value;
                _CheckTextMatch_test_algo_object.regionName = "test algo ";
                ServiceUtils.Log(" Sending CheckTextMatch   Parameter To C++ ");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(_CheckTextMatch_test_algo_object))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(_CheckTextMatch_test_algo_object);
                    ServiceUtils.Log(" name   " + name + " values " + value);
                }
                string json = JsonConvert.SerializeObject(_CheckTextMatch_test_algo_object, Formatting.Indented);
                string _base64 = ServiceUtils.bitmap_to_base_64_string(small_image_test);
                string responce = _SalcomCpp.TestAlgo_On_image(_base64, json, "CheckTextMatch");
                CheckTextMatch CheckTextMatch_responce_obj = JsonConvert.DeserializeObject<CheckTextMatch>(responce);
                ServiceUtils.Log(" Getting CheckTextMatch   responce from c++ ");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(CheckTextMatch_responce_obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(CheckTextMatch_responce_obj);
                    ServiceUtils.Log(" name   " + name + " values " + value);
                }
                nm_n.Value = decimal.Parse(CheckTextMatch_responce_obj.MatchScore.ToString());
                nm_o.Value = decimal.Parse(CheckTextMatch_responce_obj.AvgColor.ToString());
                _CheckTextMatch_test_algo_object.MatchScore = nm_n.Value;
                _CheckTextMatch_test_algo_object.AvgColor = nm_o.Value;
                string image = _SalcomCpp.get_thresholded_image(_base64);
                picBoxThresholdImage.Image = ServiceUtils.Base64StringToBitmap(image);
                ServiceUtils.Log("");
                btn_test_algo.Enabled = false;
            }
            if (tools_name.Equals("CheckClean"))
            {

                if(_CheckClean_test_algo_object.TemplateImagePath==null)
                {
                    return;
                }



                ServiceUtils.Log("");
                Bitmap small_image_test;
                //ServiceUtils.Log("template image to test : " + _CheckClean_test_algo_object.TemplateImagePath);
                using (var bmpTemp = new Bitmap(_CheckClean_test_algo_object.TemplateImagePath))
                {
                    small_image_test = new Bitmap(bmpTemp);
                }
                _CheckClean_test_algo_object.Threshold = nm_m.Value;
                _CheckClean_test_algo_object.Step_Size = nm_n.Value;
                _CheckClean_test_algo_object.HeighTolerance = nm_o.Value;
                _CheckClean_test_algo_object.WidthTolerance = nm_p.Value;
                _CheckClean_test_algo_object.AreaTolerance = nm_q.Value;
                _CheckClean_test_algo_object.Threshold = nm_r.Value;
                ServiceUtils.Log(" Sending CheckClean   Parameter To C++ ");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(_CheckClean_test_algo_object))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(_CheckClean_test_algo_object);
                    ServiceUtils.Log(" name   " + name + " values " + value);
                }
                ServiceUtils.Log("");
                string json = JsonConvert.SerializeObject(_CheckClean_test_algo_object, Formatting.Indented);
                string _base64 = ServiceUtils.bitmap_to_base_64_string(small_image_test);
                string responce = _SalcomCpp.TestAlgo_On_image(_base64, json, "CheckClean");
                CheckClean _CheckClean = JsonConvert.DeserializeObject<CheckClean>(responce);
                ServiceUtils.Log(" Getting CheckClean   responce from c++ ");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(_CheckClean_test_algo_object))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(_CheckClean_test_algo_object);
                    ServiceUtils.Log(" name   " + name + " values " + value);
                }
                nm_m.Value = decimal.Parse(_CheckClean.Avg_color.ToString());
                string image = _SalcomCpp.get_thresholded_image(_base64);
                picBoxThresholdImage.Image = ServiceUtils.Base64StringToBitmap(image);
                ServiceUtils.Log("");
                btn_test_algo.Enabled = false;
            }
            btn_save_model.Enabled = true;
        }//btn_test_algo_Click
        private void tools_option_gb_Enter(object sender, EventArgs e)
        {
        }
        private void cb_toolsName_Click(object sender, EventArgs e)
        {
        }
        private void btn_set_Click(object sender, EventArgs e)
        {
        }
        private void timer_camera_status_Tick(object sender, EventArgs e)
        {
        }
        private void cb_cam_live_CheckedChanged(object sender, EventArgs e)
        {
        }//cb_cam_live_CheckedChanged
        private void live_timer_Tick(object sender, EventArgs e)
        {
            string ff = DateTime.Today.ToLongDateString(); ; //18 June 2020

            ff = DateTime.Now.ToString(); //06/18/2020 22:25:46
            label1.Text = ff;
        }
        private void numeric_exposure_time_ValueChanged(object sender, EventArgs e)
        {
        }
        bool exit_button = false;
        private void btn_exit_Click(object sender, EventArgs e)
        {
            exit_button = true;
            Application.Exit();
        }
        private void CreateModelPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit_button == false)
            {
                MessageBox.Show("PLEASE USE EXIT BUTTON " + " . ", "Alert ?",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cv_thresholsimage_CheckedChanged(object sender, EventArgs e)
        {
            if (cv_thresholsimage.Checked)
            {
                picBoxThresholdImage.Visible = true;
            }
            else
            {
                picBoxThresholdImage.Visible = false;
            }
        }
        private void lbl_camera_status_Click(object sender, EventArgs e)
        {
        }
        Bitmap _default_image = null;
        private void cb_model_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// verify the operatot password 
            //if (Application.OpenForms["EditPageLogIn"] == null)
            //{
            //    new EditPageLogIn().ShowDialog();
            //    if (GlobalItems.edit_page_access == false)
            //    {
            //        return;
            //    }
            //}
            //ServiceUtils.Log("Log in succussfull ....... ");

            tools_option_gb.Enabled = true;
            #region   show_ui_correcte
            txt_box_refstring.Visible = false;
            cb_is_match.Visible = false;
            tools_option_gb.Visible = true;
            lbl_a.Text = "Avg Color : ";
            lbl_b.Text = "Step Size : ";
            lbl_c.Text = "Heigh Tolerance : ";
            lbl_d.Text = "Width Tolerance : ";
            lbl_e.Text = "Area Tolerance : ";
            lbl_f.Text = "Threshold : ";
            lbl_g.Text = "Rect : ";
            lbl_a.Visible = true;
            lbl_b.Visible = true;
            lbl_c.Visible = true;
            lbl_d.Visible = true;
            lbl_e.Visible = true;
            lbl_f.Visible = true;
            lbl_g.Visible = true;
            nm_m.Visible = true;
            nm_n.Visible = true;
            nm_o.Visible = true;
            nm_p.Visible = true;
            nm_q.Visible = true;
            nm_r.Visible = true;
            nm_m.ReadOnly = true;
            nm_m.Increment = 0;
            nm_n.ReadOnly = false;
            //nm_n.Increment = 2;
            nm_o.ReadOnly = false;
            //nm_o.Increment = 2;
            //nm_p.ReadOnly = true;
            //nm_q.ReadOnly = true;
            //nm_r.ReadOnly = true;
            lbl_h.Visible = false;
            lbl_i.Visible = false;
            lbl_x.Visible = false;
            lbl_rect_v.Location = new Point(163, 218);
            #endregion 
            tools_option_gb.Visible = true;
            cb_region_name.Items.Clear();
            model_name = cb_model_name.Text;
            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data.json";
            string model_data = File.ReadAllText(json_path);
            _model = JsonConvert.DeserializeObject<Modal>(model_data);
            _Model_copy = JsonConvert.DeserializeObject<Modal>(model_data);
            string original_image_path = GlobalItems.data_base_folder + model_name + @"\original.bmp";
            //if (File.Exists(original_image_path))
            //{
            //    _default_image = new Bitmap(original_image_path);
            //}
            //else
            //{
            //    _default_image = new Bitmap(GlobalItems.default_image);
            //}
            ////lbl_original_image_path.Text = original_image_path;
            //if (_default_image != null)
            //{
            //    _default_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //}
            if (File.Exists(_model.TemplateImagePathSmaller))
            {
                using (var fs = new System.IO.FileStream(_model.TemplateImagePathSmaller, System.IO.FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    picboxOne.Image = (Bitmap)bmp.Clone();
                }
            }//dddd 
            bool color = false;
            foreach (TemplateCoordinate tc in _model.TemplateCoordinate)
            {
                //if (color == false)
                //{
                //    using (var graphics = Graphics.FromImage(_default_image))
                //    {
                //        Rectangle _rectangle = new Rectangle((int)tc.PointAX, (int)tc.PointAY, (int)(tc.PointBX - tc.PointAX), (int)tc.PointBY - (int)tc.PointAY);
                //        graphics.DrawRectangle(_redPen, _rectangle);
                //        StringFormat sf = new StringFormat();
                //        sf.LineAlignment = StringAlignment.Center;
                //        sf.Alignment = StringAlignment.Center;
                //    }
                //    color = true;
                //}
                //else
                //{
                //    using (var graphics = Graphics.FromImage(_default_image))
                //    {
                //        Rectangle _rectangle = new Rectangle((int)tc.PointAX, (int)tc.PointAY, (int)tc.PointBX, (int)tc.PointBY);
                //        graphics.DrawRectangle(_greenPen, _rectangle);
                //        StringFormat sf = new StringFormat();
                //        sf.LineAlignment = StringAlignment.Center;
                //        sf.Alignment = StringAlignment.Center;
                //    }
                //}
            }
            foreach (CheckTextMatch tc in _model.CheckTextMatch)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //        (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //        (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //        (int)(tc.PointBX),
                //        (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                cb_region_name.Items.Add(tc.regionName);
            }
            foreach (CheckClean tc in _model.CheckClean)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //        (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(0).PointAX,
                //        (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(0).PointAY,
                //        (int)(tc.PointBX),
                //        (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                cb_region_name.Items.Add(tc.regionName);
            }
            foreach (QrCodeReader tc in _model.QrCodeReader)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //      (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //      (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //      (int)(tc.PointBX),
                //      (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                // cb_region_name.Items.Add(tc.regionName);
            }
            foreach (OcrReader tc in _model.OcrReader)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //     (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //     (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //     (int)(tc.PointBX),
                //     (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                // cb_region_name.Items.Add(tc.regionName);
            }
            cb_region_name.Enabled = true;
            _once = true;
        }
        string tools_name = "";
        private void cb_region_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            string region_name = cb_region_name.Text;
            tools_option_gb.Visible = true;
            btn_test_algo.Enabled = true;



            cb_checkclean.Checked = false;
            cb_check_text_match.Checked = false;





            foreach (CheckTextMatch tc in _model.CheckTextMatch)
            {
                if (tc.regionName.Equals(region_name))
                {
                    Bitmap img = null;
                    if (File.Exists(_model.TemplateImagePathSmaller))
                    {
                        using (var bmpTemp = new Bitmap(_model.TemplateImagePathSmaller))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        picboxOne.Image = img;
                    }
                    using (var graphics = Graphics.FromImage(img))
                    {
                        //Rectangle _rectangle = new Rectangle(
                        //    (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                        //    (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                        //    (int)(tc.PointBX),
                        //    (int)tc.PointBY);
                        Rectangle _rectangle = new Rectangle(
                            (int)tc.PointAX,
                            (int)tc.PointAY,
                            (int)(tc.PointBX),
                            (int)tc.PointBY);
                        //graphics.DrawRectangle(_redPen, _rectangle);
                    }
                    #region  comming from ocr reader 
                    lbl_g.Visible = false;
                    lbl_rect_v.Visible = false;
                    lbl_h.Visible = false;
                    lbl_x.Visible = false;
                    lbl_i.Visible = false;
                    nm_m.ReadOnly = false;
                    nm_p.ReadOnly = false;
                    nm_q.ReadOnly = false;
                    nm_r.ReadOnly = false;
                    lbl_a.Visible = true;
                    lbl_b.Visible = true;
                    lbl_c.Visible = true;
                    lbl_d.Visible = true;
                    lbl_e.Visible = true;
                    lbl_f.Visible = true;
                    lbl_g.Visible = true;
                    lbl_rect_v.Visible = true;
                    lbl_g.Location = new Point(62, 218);
                    lbl_rect_v.Location = new Point(141, 218);
                    nm_m.Visible = true;
                    nm_n.Visible = true;
                    nm_o.Visible = true;
                    nm_n.ReadOnly = true;
                    nm_n.Increment = 0;
                    nm_o.ReadOnly = true;
                    nm_o.Increment = 0;
                    nm_p.Visible = true;
                    nm_q.Visible = true;
                    nm_r.Visible = true;
                    txt_box_refstring.Visible = false;
                    cb_is_match.Visible = false;
                    #endregion   ocr region 
                    tools_option_gb.Visible = true;
                    lbl_a.Text = "Threshold : ";
                    lbl_b.Text = "Match Score : ";
                    lbl_c.Text = "Avg Color : ";
                    lbl_d.Text = "High Tolerance : ";
                    lbl_e.Text = "Width Tolerance : ";
                    lbl_f.Text = "Area Tolerance : ";
                    lbl_g.Text = "Rect : ";
                    lbl_g.Visible = false;
                    lbl_rect_v.Visible = false;
                    lbl_h.Visible = false;
                    lbl_x.Visible = false;
                    lbl_i.Visible = false;
                    //lbl_h.Text = "Area Tolerance : ";
                    //lbl_i.Text = "Area Tolerance : ";
                    nm_m.Value = tc.Threshold;
                    nm_n.Value = tc.MatchScore;
                    nm_o.Value = tc.AvgColor;
                    nm_p.Value = tc.HeighTolerance;
                    nm_q.Value = tc.WidthTolerance;
                    nm_r.Value = tc.AreaTolerance;
                    _CheckTextMatch_test_algo_object.Threshold = nm_m.Value;
                    _CheckTextMatch_test_algo_object.MatchScore = nm_n.Value;
                    _CheckTextMatch_test_algo_object.AvgColor = nm_o.Value;
                    _CheckTextMatch_test_algo_object.HeighTolerance = nm_p.Value;
                    _CheckTextMatch_test_algo_object.WidthTolerance = nm_q.Value;
                    _CheckTextMatch_test_algo_object.AreaTolerance = nm_r.Value;
                    _CheckTextMatch_test_algo_object.TemplateImagePath = tc.TemplateImagePath;
                    tools_name = "CheckTextMatch";


                    if (_live_test_feature == true)
                    {


                        string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data_live.json";
                        string model_data = File.ReadAllText(json_path);
                        string _base64 = ServiceUtils.bitmap_to_base_64_string(_selected_image);
                        string image = _SalcomCpp.Get_template_match_data(_base64, "CheckTextMatch", model_data);
                        picboxOne.Image = ServiceUtils.Base64StringToBitmap(image);
                    }
                }
            }
            foreach (CheckClean tc in _model.CheckClean)
            {
                if (tc.regionName.Equals(region_name))
                {
                    if (tc.regionName.Equals(region_name))
                    {
                        Bitmap img = null;
                        if (File.Exists(_model.template_image_path_bigger))
                        {
                            using (var bmpTemp = new Bitmap(_model.template_image_path_bigger))
                            {
                                img = new Bitmap(bmpTemp);
                            }
                            picboxOne.Image = img;
                        }
                        using (var graphics = Graphics.FromImage(img))
                        {
                            //Rectangle _rectangle = new Rectangle(
                            //    (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                            //    (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                            //    (int)(tc.PointBX),
                            //    (int)tc.PointBY);
                            Rectangle _rectangle = new Rectangle(
                                (int)tc.PointAX,
                                (int)tc.PointAY,
                                (int)(tc.PointBX),
                                (int)tc.PointBY);
                           // graphics.DrawRectangle(_redPen, _rectangle);
                        }
                        tools_name = "CheckClean";
                        txt_box_refstring.Visible = false;
                        cb_is_match.Visible = false;
                        tools_option_gb.Visible = true;
                        lbl_a.Text = "Avg Color : ";
                        lbl_b.Text = "Step Size : ";
                        lbl_c.Text = "Heigh Tolerance : ";
                        lbl_d.Text = "Width Tolerance : ";
                        lbl_e.Text = "Area Tolerance : ";
                        lbl_f.Text = "Threshold : ";
                        lbl_g.Text = "Rect : ";
                        lbl_a.Visible = true;
                        lbl_b.Visible = true;
                        lbl_c.Visible = true;
                        lbl_d.Visible = true;
                        lbl_e.Visible = true;
                        lbl_f.Visible = true;
                        lbl_g.Visible = true;
                        nm_m.Visible = true;
                        nm_n.Visible = true;
                        nm_o.Visible = true;
                        nm_p.Visible = true;
                        nm_q.Visible = true;
                        nm_r.Visible = true;
                        nm_m.ReadOnly = true;
                        nm_m.Increment = 0;
                        nm_n.ReadOnly = false;
                        //nm_n.Increment = 2;
                        nm_o.ReadOnly = false;
                        //nm_o.Increment = 2;
                        //nm_p.ReadOnly = true;
                        //nm_q.ReadOnly = true;
                        //nm_r.ReadOnly = true;
                        lbl_h.Visible = false;
                        lbl_i.Visible = false;
                        lbl_x.Visible = false;
                        lbl_rect_v.Location = new Point(163, 218);


                        if (_live_test_feature == true)
                        {


                            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data_live.json";
                            string model_data = File.ReadAllText(json_path);
                            string _base64 = ServiceUtils.bitmap_to_base_64_string(_selected_image);
                            string image = _SalcomCpp.Get_template_match_data(_base64, "CheckClean", model_data);
                            picboxOne.Image = ServiceUtils.Base64StringToBitmap(image);
                        }
                    }
                }
            }
            btn_save_model.Enabled = true;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {







            tools_option_gb.Enabled = false;



            string region_name = cb_region_name.Text;
            if (_model == null)
            {
                MessageBox.Show("Please Select  The model  " + " ", "Alert",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < _model.CheckTextMatch.Count(); i++)
            {
                CheckTextMatch tc = _model.CheckTextMatch.ElementAt(i);
                if (tc.regionName.Equals(region_name))
                {
                    _Model_copy.CheckTextMatch.RemoveAt(i);
                    ServiceUtils.Log("deleted .......... ");
                    break;
                }
            }
            for (int i = 0; i < _model.CheckClean.Count(); i++)
            {
                CheckClean tc = _model.CheckClean.ElementAt(i);
                if (tc.regionName.Equals(region_name))
                {
                    if (tc.regionName.Equals(region_name))
                    {
                        _Model_copy.CheckClean.RemoveAt(i);
                        ServiceUtils.Log("deleted .......... ");
                        break;
                    }
                }
            }
            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data.json";
            string json = JsonConvert.SerializeObject(_Model_copy, Formatting.Indented);
            File.WriteAllText(json_path, json);
            ServiceUtils.Log("updated file path  .......... ");
            ServiceUtils.Log(json_path);
            cb_region_name.Items.Remove(cb_region_name.SelectedItem);
            cb_region_name.Items.Clear();



            MessageBox.Show("Please Select The Model Again To reflect The Change  " + " ", "Alert",
            MessageBoxButtons.OK, MessageBoxIcon.Information);






        }//btn_delete_Click
        bool _save_new_tools = false;
        private void btm_add_new_region_Click(object sender, EventArgs e)
        {
            //if(cb_check_text_match.Checked  ||   cb_checkclean.Checked  )
            //{
            //    is_add_new_region = true;
            //    _save_new_tools = true;
            //    btm_add_new_region.Enabled = false;
            //}
            //else
            //{
            //    MessageBox.Show("Please Select The Tools Type " + " ", "Alert",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        //#region    login modeule 
        //private bool Log_in_page()
        //{
        //    ChargerVivo.Statics.GlobalItems.edit_page_access = true;
        //    if (Application.OpenForms["LogInforAdmin"] == null)
        //    {
        //        new LogInforAdmin().ShowDialog();
        //        if (GlobalItems.admin_access == false)
        //        {
        //            return  false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}
        //#endregion  log in module
        private void after_upadte()
        {
            cb_region_name.Items.Clear();
            model_name = cb_model_name.Text;
            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data.json";
            string model_data = File.ReadAllText(json_path);
            _model = JsonConvert.DeserializeObject<Modal>(model_data);
            _Model_copy = JsonConvert.DeserializeObject<Modal>(model_data);
            string original_image_path = GlobalItems.data_base_folder + model_name + @"\original.bmp";
            if (File.Exists(original_image_path))
            {
                _default_image = new Bitmap(original_image_path);
            }
            else
            {
                _default_image = new Bitmap(GlobalItems.default_image);
            }
            //lbl_original_image_path.Text = original_image_path;
            if (_default_image != null)
            {
                _default_image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            // picboxOne.Image = _default_image;
            if (File.Exists(_model.TemplateImagePathSmaller))
            {
                using (var fs = new System.IO.FileStream(_model.TemplateImagePathSmaller, System.IO.FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    picboxOne.Image = (Bitmap)bmp.Clone();
                }
            }//dddd 
            bool color = false;
            foreach (TemplateCoordinate tc in _model.TemplateCoordinate)
            {
                if (color == false)
                {
                    using (var graphics = Graphics.FromImage(_default_image))
                    {
                        Rectangle _rectangle = new Rectangle((int)tc.PointAX, (int)tc.PointAY, (int)(tc.PointBX - tc.PointAX), (int)tc.PointBY - (int)tc.PointAY);
                        graphics.DrawRectangle(_redPen, _rectangle);
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;
                    }
                    color = true;
                }
                else
                {
                    using (var graphics = Graphics.FromImage(_default_image))
                    {
                        Rectangle _rectangle = new Rectangle((int)tc.PointAX, (int)tc.PointAY, (int)tc.PointBX, (int)tc.PointBY);
                        graphics.DrawRectangle(_greenPen, _rectangle);
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;
                    }
                }
            }
            foreach (CheckTextMatch tc in _model.CheckTextMatch)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //        (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //        (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //        (int)(tc.PointBX),
                //        (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                cb_region_name.Items.Add(tc.regionName);
            }
            foreach (CheckClean tc in _model.CheckClean)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //        (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(0).PointAX,
                //        (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(0).PointAY,
                //        (int)(tc.PointBX),
                //        (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                cb_region_name.Items.Add(tc.regionName);
            }
            foreach (QrCodeReader tc in _model.QrCodeReader)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //      (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //      (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //      (int)(tc.PointBX),
                //      (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                // cb_region_name.Items.Add(tc.regionName);
            }
            foreach (OcrReader tc in _model.OcrReader)
            {
                //using (var graphics = Graphics.FromImage(_default_image))
                //{
                //    Rectangle _rectangle = new Rectangle(
                //     (int)tc.PointAX + (int)_model.TemplateCoordinate.ElementAt(1).PointAX,
                //     (int)tc.PointAY + (int)_model.TemplateCoordinate.ElementAt(1).PointAY,
                //     (int)(tc.PointBX),
                //     (int)tc.PointBY);
                //    graphics.DrawRectangle(_redPen, _rectangle);
                //}
                // cb_region_name.Items.Add(tc.regionName);
            }
            cb_region_name.Enabled = true;
            _once = true;
        }
        private void cb_check_text_match_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_check_text_match.Checked == true)
            {
                is_add_new_region = true;
                _save_new_tools = true;
                cb_region_name.Text = "        select Region name";
                tools_name = "CheckTextMatch";
                cb_checkclean.Checked = false;
                #region  comming from ocr reader 
                lbl_g.Visible = false;
                lbl_rect_v.Visible = false;
                lbl_h.Visible = false;
                lbl_x.Visible = false;
                lbl_i.Visible = false;
                nm_m.ReadOnly = false;
                nm_p.ReadOnly = false;
                nm_q.ReadOnly = false;
                nm_r.ReadOnly = false;
                lbl_a.Visible = true;
                lbl_b.Visible = true;
                lbl_c.Visible = true;
                lbl_d.Visible = true;
                lbl_e.Visible = true;
                lbl_f.Visible = true;
                lbl_g.Visible = true;
                lbl_rect_v.Visible = true;
                lbl_g.Location = new Point(62, 218);
                lbl_rect_v.Location = new Point(141, 218);
                nm_m.Visible = true;
                nm_n.Visible = true;
                nm_o.Visible = true;
                nm_n.ReadOnly = true;
                nm_n.Increment = 0;
                nm_o.ReadOnly = true;
                nm_o.Increment = 0;
                nm_p.Visible = true;
                nm_q.Visible = true;
                nm_r.Visible = true;
                txt_box_refstring.Visible = false;
                cb_is_match.Visible = false;
                #endregion   ocr region 
                tools_option_gb.Visible = true;
                lbl_a.Text = "Threshold : ";
                lbl_b.Text = "Match Score : ";
                lbl_c.Text = "Avg Color : ";
                lbl_d.Text = "High Tolerance : ";
                lbl_e.Text = "Width Tolerance : ";
                lbl_f.Text = "Area Tolerance : ";
                lbl_g.Text = "Rect : ";
                lbl_g.Visible = false;
                lbl_rect_v.Visible = false;
                lbl_h.Visible = false;
                lbl_x.Visible = false;
                lbl_i.Visible = false;
                if (File.Exists(_model.TemplateImagePathSmaller))
                {
                    using (var fs = new System.IO.FileStream(_model.TemplateImagePathSmaller, System.IO.FileMode.Open))
                    {
                        var bmp = new Bitmap(fs);
                        picboxOne.Image = (Bitmap)bmp.Clone();
                    }
                }//dddd 
                btm_add_new_region.Enabled = false;




            }
        }
        private void cb_checkclean_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_checkclean.Checked == true)
            {
                is_add_new_region = true;
                _save_new_tools = true;
                cb_region_name.Text = "        select Region name";
                btm_add_new_region.Enabled = false;
                tools_name = "CheckClean";
                txt_box_refstring.Visible = false;
                cb_is_match.Visible = false;
                tools_option_gb.Visible = true;
                lbl_a.Text = "Avg Color : ";
                lbl_b.Text = "Step Size : ";
                lbl_c.Text = "Heigh Tolerance : ";
                lbl_d.Text = "Width Tolerance : ";
                lbl_e.Text = "Area Tolerance : ";
                lbl_f.Text = "Threshold : ";
                lbl_g.Text = "Rect : ";
                lbl_a.Visible = true;
                lbl_b.Visible = true;
                lbl_c.Visible = true;
                lbl_d.Visible = true;
                lbl_e.Visible = true;
                lbl_f.Visible = true;
                lbl_g.Visible = true;
                nm_m.Visible = true;
                nm_n.Visible = true;
                nm_o.Visible = true;
                nm_p.Visible = true;
                nm_q.Visible = true;
                nm_r.Visible = true;
                nm_m.ReadOnly = true;
                nm_m.Increment = 0;
                nm_n.ReadOnly = false;
                //nm_n.Increment = 2;
                nm_o.ReadOnly = false;
                //nm_o.Increment = 2;
                //nm_p.ReadOnly = true;
                //nm_q.ReadOnly = true;
                //nm_r.ReadOnly = true;
                lbl_h.Visible = false;
                lbl_i.Visible = false;
                lbl_x.Visible = false;
                lbl_rect_v.Location = new Point(163, 218);
                tools_name = "CheckClean";
                cb_check_text_match.Checked = false;
                if (File.Exists(_model.TemplateImagePathSmaller))
                {
                    using (var fs = new System.IO.FileStream(_model.template_image_path_bigger, System.IO.FileMode.Open))
                    {
                        var bmp = new Bitmap(fs);
                        picboxOne.Image = (Bitmap)bmp.Clone();
                    }
                }//dddd 
            }
        }
        private void cb_region_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            cb_region_name.Text = "        select Region name";
        }

        private void trackBar_threshold_Scroll(object sender, EventArgs e)
        {
            if (targetBitmap != null)
            {
                picBoxThresholdImage.Visible = true;
              //  lbl_track_bar_values.Text = trackBar_threshold.Value.ToString();
                //   string json = JsonConvert.SerializeObject(_CheckTextMatch_test_algo_object, Formatting.Indented);
              //  _bitmap_for_testing = targetBitmap;
                string _base64 = ServiceUtils.bitmap_to_base_64_string(targetBitmap);
                int trackBar_values = trackBar_threshold.Value;
                string image = _SalcomCpp.get_thresholded_image_on_track_bar(_base64, trackBar_values);
                picBoxThresholdImage.Image = ServiceUtils.Base64StringToBitmap(image);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cb_region_name.Items.Count > 0)
            {
                if (cb_region_name.SelectedIndex > 0)
                {
                    cb_region_name.SelectedIndex = cb_region_name.SelectedIndex - 1;
                }
                else
                    return;
            
            
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cb_region_name.Items.Count > 0)
            {
                if (cb_region_name.SelectedIndex <cb_region_name.Items.Count-1)
                {
                    cb_region_name.SelectedIndex = cb_region_name.SelectedIndex + 1;
                }
                else
                    return;


            }
        }


        //

        Bitmap _selected_image;
        bool _live_test_feature = false;
        private void btn_select_image_for_testing_Click(object sender, EventArgs e)
        {
            if (_Model_copy == null)
            {
                MessageBox.Show(" Please select the model  ", "Alert ?",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            cb_region_name.Text = "---------";
            string region_name = cb_region_name.Text;
            for (int i = 0; i < _model.CheckTextMatch.Count(); i++)
            {
                CheckTextMatch tc = _model.CheckTextMatch.ElementAt(i);
                if (tc.regionName.Equals(region_name))
                {
                    _Model_copy.CheckTextMatch.ElementAt(i).Threshold = nm_m.Value;
                    _Model_copy.CheckTextMatch.ElementAt(i).MatchScore = nm_n.Value;
                    _Model_copy.CheckTextMatch.ElementAt(i).AvgColor = nm_o.Value;
                    _Model_copy.CheckTextMatch.ElementAt(i).HeighTolerance = nm_p.Value;
                    _Model_copy.CheckTextMatch.ElementAt(i).WidthTolerance = nm_q.Value;
                    _Model_copy.CheckTextMatch.ElementAt(i).AreaTolerance = nm_r.Value;
                  
                    _Model_copy.CheckTextMatch.ElementAt(i).TemplateImagePath = _CheckTextMatch_test_algo_object.TemplateImagePath;
                    if (_CheckTextMatch_test_algo_object.PointAX != 0)
                    {
                        _Model_copy.CheckTextMatch.ElementAt(i).PointAX = _CheckTextMatch_test_algo_object.PointAX;
                        _Model_copy.CheckTextMatch.ElementAt(i).PointAY = _CheckTextMatch_test_algo_object.PointAY;
                        _Model_copy.CheckTextMatch.ElementAt(i).PointBX = _CheckTextMatch_test_algo_object.PointBX;
                        _Model_copy.CheckTextMatch.ElementAt(i).PointBY = _CheckTextMatch_test_algo_object.PointBY;
                    }
                    //  _Model_copy.CheckTextMatch.ElementAt(i).Threshold = _CheckTextMatch_test_algo_object.Threshold;
                }
            }
            for (int i = 0; i < _model.CheckClean.Count(); i++)
            {
                CheckClean tc = _model.CheckClean.ElementAt(i);
                if (tc.regionName.Equals(region_name))
                {
                    if (tc.regionName.Equals(region_name))
                    {
                        _Model_copy.CheckClean.ElementAt(i).Avg_color = nm_m.Value;
                        _Model_copy.CheckClean.ElementAt(i).Step_Size = nm_n.Value;
                        _Model_copy.CheckClean.ElementAt(i).HeighTolerance = nm_o.Value;
                        _Model_copy.CheckClean.ElementAt(i).WidthTolerance = nm_p.Value;
                        _Model_copy.CheckClean.ElementAt(i).AreaTolerance = nm_q.Value;
                        _Model_copy.CheckClean.ElementAt(i).Threshold = nm_r.Value;
                    }
                }
            }


            string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data_live.json";
            string json = JsonConvert.SerializeObject(_Model_copy, Formatting.Indented);
            File.WriteAllText(json_path, json);




            model_name = cb_model_name.Text;
            //string json_path = GlobalItems.data_base_folder + @"\" + model_name + @"\_data_live.json";
            if (File.Exists(json_path))
            {
                string model_data = File.ReadAllText(json_path);
                _model = JsonConvert.DeserializeObject<Modal>(model_data);
                _SalcomCpp.load_template(model_data);
            }
            else
            {
                MessageBox.Show(" Invalid model name   ", "Alert ?",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\Images",
                Title = "Browse Text Files",
                CheckFileExists = true,
                CheckPathExists = true,
                //  DefaultExt = "txt",
                // Filter = "Image files (*.jpg, *.jpeg, *.jpe,*.bmp, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var bmpTemp = new Bitmap(openFileDialog1.FileName))
                {
                    _selected_image = new Bitmap(bmpTemp);
                    _selected_image.RotateFlip(RotateFlipType.Rotate270FlipNone);


                    Bitmap bm24bit = new Bitmap(bmpTemp.Width, bmpTemp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    Graphics g = Graphics.FromImage(bm24bit);
                    g.DrawImage(bmpTemp, 0, 0, bmpTemp.Width, bmpTemp.Height);

                    // bm24bit.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                    g.Dispose();
                    bmpTemp.Dispose();
                    //bm24bit.Dispose();





                    bm24bit.RotateFlip(RotateFlipType.Rotate270FlipNone);




                    string result = _SalcomCpp.ProcessImage(bm24bit);
                    ResultModel _ResultModel = JsonConvert.DeserializeObject<ResultModel>(result);
                    //if (_ResultModel.final_result.Equals("OK"))
                    //{
                    //    label4.Text = " OK ";
                    //}
                    //else
                    //{
                    //    label4.Text = " NG ";
                    //}


                    picboxOne.Image = EditModelApp.Service.resizeImage(bm24bit, bm24bit.Width / 2, bm24bit.Height / 2);
                }
            }
            else
            {
                MessageBox.Show(" Invalid selection  " + openFileDialog1.FileName.ToString(), "Alert ?",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cb_test_image_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_test_image.Checked)
            {

                _save_new_tools = true;
                _live_test_feature = true;
                cb_test_image.Enabled = true;
                btn_test_algo.Enabled = false;
                btn_save_model.Enabled = false;


            }
            else
            {

                _live_test_feature = false;
                cb_test_image.Enabled = false;
                btn_test_algo.Enabled = true;
                btn_save_model.Enabled = true;
            }
        }
    }
}