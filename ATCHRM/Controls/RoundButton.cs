using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

using System.Text;
namespace ATCHRM.Controls
{
    
        public class RoundButton : Button
        {
            protected override void OnResize(EventArgs e)
            {
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(new Rectangle(2, 2, this.Width - 5, this.Height - 5));
                    this.Region = new Region(path);
                }
                base.OnResize(e);
            }
       
    }
}
