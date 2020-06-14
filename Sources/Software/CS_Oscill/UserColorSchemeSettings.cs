using System;
using System.Drawing;
using System.Windows.Forms;

namespace CS_Oscill
{
    public partial class UserColorSchemeSettings : Form
    {
        public UserColorSchemeSettings()
        {
            InitializeComponent();
            pan_Background.BackColor = CurrentColorScheme.BackGround;
            pan_Grid.BackColor = CurrentColorScheme.Grid;
            pan_ZeroLvl.BackColor = CurrentColorScheme.ZeroLvl;
            pan_Graph.BackColor = CurrentColorScheme.Graph;
            pan_Cursor1.BackColor = CurrentColorScheme.Cursor1;
            pan_Cursor2.BackColor = CurrentColorScheme.Cursor2;

            DrawExample();

        }

        private void DrawExample()
        {

            Bitmap Canvas = new Bitmap(img_Example.Width, img_Example.Height);
            Graphics g = Graphics.FromImage(Canvas);

            g.Clear(pan_Background.BackColor); // Залили все фоновым цветом. 

            Pen Pen = new Pen(pan_Grid.BackColor, 1);
            for (int i = 0; i < 11; i++)
            {
                // счетчик делений (10 шт на экран)
                int x = i * img_Example.Width / 10 + 2;
                g.DrawLine(Pen, new Point(x, 0), new Point(x, img_Example.Height));
            }

            for (int i = 0; i < 11; i++)
            {
                int y1 = i * img_Example.Height / 10;
                g.DrawLine(Pen, new Point(0, y1), new Point(img_Example.Width, y1));
            }
            // Zero level
            int zero = img_Example.Height / 2;
            Pen.Color = pan_ZeroLvl.BackColor;
            g.DrawLine(Pen, new Point(0, zero), new Point(img_Example.Width, zero));

            Pen = new Pen(pan_Graph.BackColor, 1);

            int y = (img_Example.Height);

            Point StartPoint = new Point(0, y);
            Point EndPoint = new Point();

            for (int x = 1; x < 256; x++)
            {
                EndPoint.Y = (img_Example.Height - x * 2);
                EndPoint.X = (x * 3) + 2;
                g.DrawLine(Pen, StartPoint, EndPoint);
                StartPoint = EndPoint;
            }
            Pen = new Pen(pan_Cursor1.BackColor, 1);

            StartPoint = new Point(10, 0);
            EndPoint = new Point(10, img_Example.Height);
            g.DrawLine(Pen, StartPoint, EndPoint);

            Pen.Color = pan_Cursor2.BackColor;
            StartPoint = new Point(200, 0);
            EndPoint = new Point(200, img_Example.Height);
            g.DrawLine(Pen, StartPoint, EndPoint);

            img_Example.Image = Canvas;
            g.Dispose();
        }

        private void pan_Background_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_Background.BackColor = colorDialog.Color;
            DrawExample();
        }
        private void pan_Grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_Grid.BackColor = colorDialog.Color;
            ((Panel)sender).Refresh();
            DrawExample();
        }
        private void pan_ZeroLvl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_ZeroLvl.BackColor = colorDialog.Color;
            ((Panel)sender).Refresh();
            DrawExample();
        }
        private void pan_Graph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_Graph.BackColor = colorDialog.Color;
            ((Panel)sender).Refresh();
            DrawExample();
        }
        private void pan_Cursor1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_Cursor1.BackColor = colorDialog.Color;
            ((Panel)sender).Refresh();
            DrawExample();
        }
        private void pan_Cursor2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pan_Cursor2.BackColor = colorDialog.Color;
            ((Panel)sender).Refresh();
            DrawExample();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            CurrentColorScheme.BackGround = pan_Background.BackColor;
            CurrentColorScheme.Grid = pan_Grid.BackColor;
            CurrentColorScheme.ZeroLvl = pan_ZeroLvl.BackColor;
            CurrentColorScheme.Graph = pan_Graph.BackColor;
            CurrentColorScheme.Cursor1 = pan_Cursor1.BackColor;
            CurrentColorScheme.Cursor2 = pan_Cursor2.BackColor;
            this.Close();
        }
    }
}
