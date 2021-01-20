using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EditModelApp
{

    public class Service
    {
        private static Bitmap new_image;

        public static Bitmap resizeImage(Bitmap image, int new_height, int new_width)
        {

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();


            try
            {
                if (new_image != null)
                {
                    new_image.Dispose();
                    new_image = null;
                }

                new_image = new Bitmap(new_width, new_height);
                Graphics g = Graphics.FromImage((Bitmap)new_image);
                g.InterpolationMode = InterpolationMode.High;
                g.DrawImage(image, 0, 0, new_width, new_height);
                // g.Dispose();
                Bitmap target = (Bitmap)new_image.Clone();
                return target;
            }
            catch (Exception exp)
            {
                throw new Exception(" Out of memory ");
            }


        }
    }
}