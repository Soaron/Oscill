﻿﻿
using System;
using System.Drawing;
using System.Windows.Forms;

using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace CS_Oscill
{

    public partial class Form1 : Form
    {

        OscillDev Oscill;

        private ScrollBar curCursor;

        public Form1()
        {
            InitializeComponent();

            lbl_YPos.AutoSize = false;
            lbl_YPos.Paint += lbl_YPos_Paint;

            lbl_Syncr.AutoSize = false;
            lbl_Syncr.Paint += lbl_Syncr_Paint;

            sw_Input.AutoSize = false;
            sw_Input.Paint += chkBoxPaint;

            sw_GND.AutoSize = false;
            sw_GND.Paint += chkBoxPaint;

            sw_Divider.AutoSize = false;
            sw_Divider.Paint += chkBoxPaint;

        }

        private void chkBoxPaint(object o, PaintEventArgs e)
        {
            CheckBox curCheckBox = (CheckBox)o;
            Pen pen = new Pen(Color.Black, 2.0f);
            Brush brush = Brushes.CornflowerBlue;
            Rectangle FillRect, OutlineRect;
            int FillHeight = curCheckBox.Height - 4;
            int FillWidth = (curCheckBox.Width / 2) - 4;
            OutlineRect = new Rectangle(0, 0, curCheckBox.Width, curCheckBox.Height);


            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawRectangle(pen, OutlineRect);

            if (!curCheckBox.Checked)
            {
                FillRect = new Rectangle(2, 2, FillWidth, FillHeight);
            }
            else
            {
                FillRect = new Rectangle((curCheckBox.Width/2)+2,2, FillWidth, FillHeight);
            }
            e.Graphics.FillRectangle(brush, FillRect);
            e.Graphics.DrawString(curCheckBox.Text, curCheckBox.Font, Brushes.Black, 3,4);
        }

        private void lbl_YPos_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("Y Поправка", Font, Brushes.Black, 45, -12);
        }
        private void lbl_Syncr_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Синхронизация", Font, Brushes.Black, -85, 0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialization();
            this.DoubleBuffered = true;
        }

        private void SetColorScheme(int SchemeType)
        {
            switch (SchemeType)
            {
                case 0:
                    CurrentColorScheme.BackGround = Properties.Settings.Default.DarkBackground;
                    CurrentColorScheme.Grid = Properties.Settings.Default.DarkGrid;
                    CurrentColorScheme.Graph = Properties.Settings.Default.DarkGraph;
                    CurrentColorScheme.ZeroLvl = Properties.Settings.Default.DarkZeroLvl;
                    CurrentColorScheme.Cursor1 = Properties.Settings.Default.DarkCursor1;
                    CurrentColorScheme.Cursor2 = Properties.Settings.Default.DarkCursor2;
                    CurrentColorScheme.SpectrumColor = Color.Blue;
                    break;
                case 1:
                    CurrentColorScheme.BackGround = Properties.Settings.Default.LightBackground;
                    CurrentColorScheme.Grid = Properties.Settings.Default.LightGrid;
                    CurrentColorScheme.Graph = Properties.Settings.Default.LightGraph;
                    CurrentColorScheme.ZeroLvl = Properties.Settings.Default.LightZeroLvl;
                    CurrentColorScheme.Cursor1 = Properties.Settings.Default.LightCursor1;
                    CurrentColorScheme.Cursor2 = Properties.Settings.Default.LightCursor2;
                    CurrentColorScheme.SpectrumColor = Color.Blue;
                    break;
                case 2:
                    CurrentColorScheme.BackGround = Properties.Settings.Default.UserBackground;
                    CurrentColorScheme.Grid = Properties.Settings.Default.UserGrid;
                    CurrentColorScheme.Graph = Properties.Settings.Default.UserGraph;
                    CurrentColorScheme.ZeroLvl = Properties.Settings.Default.UserZeroLvl;
                    CurrentColorScheme.Cursor1 = Properties.Settings.Default.UserCursor1;
                    CurrentColorScheme.Cursor2 = Properties.Settings.Default.UserCursor2;
                    CurrentColorScheme.SpectrumColor = Color.Blue;
                    break;
            }
        }

        private void Initialization()
        {

            if (!Properties.Settings.Default.UserSaved)
                SetColorScheme(0);
            else
                SetColorScheme(2);

            Oscill = new OscillDev();
            for (int i = 0; i < 256; i++)
                Oscill.DoneArray[i] = (byte)i;

            GetSensCaption(trc_Sens.Value);
            GetTimescaleInfo(trc_TimeScale.Value);
            CalculateCursorData();

            tmr_Oscill_Poll.Enabled = false;
            tmr_DrawSpectrum.Enabled = false;
            tmr_DrawImage.Enabled = true;

            cmb_AnalyticMode.SelectedIndex = 0;
            cmb_WindowType.SelectedIndex = 0;

            SetModeVisibility();

        }

        private void Init_102()
        {
            mem_Log.AppendText("Some fuctions will not work with this version..." + Environment.NewLine);

            sw_Divider.Enabled = false;
            sw_GND.Enabled = false;
            sw_Input.Enabled = false;
            trc_Sens.Enabled = false;

            Oscill.SendOscillCommand(Oscill.Konstants.SET_OFFSET, (byte)trc_Offset.Value);
            Oscill.SendOscillCommand(Oscill.Konstants.SET_SYNC, (byte)Math.Round((trc_Syncr.Value + 50) * 2.56));
            Oscill.SendOscillCommand(Oscill.Konstants.SET_TIMESCALE, (byte)trc_TimeScale.Value);


        }
        private void Init_103()
        {
            byte boolVal;
            if (sw_Divider.Checked)
                boolVal = 1;
            else
                boolVal = 0;
            Oscill.SendOscillCommand(Oscill.Konstants.SET_DIVIDER, boolVal);
            if (sw_Input.Checked)
                boolVal = 1;
            else
                boolVal = 0;
            Oscill.SendOscillCommand(Oscill.Konstants.SET_SHUTTER, boolVal);
            Oscill.SendOscillCommand(Oscill.Konstants.SET_SENS, (byte)trc_Sens.Value);

            Oscill.SendOscillCommand(Oscill.Konstants.SET_OFFSET, (byte)trc_Offset.Value);
            Oscill.SendOscillCommand(Oscill.Konstants.SET_SYNC, (byte)Math.Round((trc_Syncr.Value + 50) * 2.56));
            Oscill.SendOscillCommand(Oscill.Konstants.SET_TIMESCALE, (byte)trc_TimeScale.Value);
        }

        private void SetModeVisibility()
        {
            mem_Log.Visible = tmr_DrawImage.Enabled;
            btnSave.Enabled = tmr_DrawImage.Enabled;

            img_Oscill.Visible = tmr_DrawImage.Enabled;
            Chart.Visible = tmr_DrawSpectrum.Enabled;

            lbl_AnalyticMode.Visible = tmr_DrawSpectrum.Enabled;
            cmb_AnalyticMode.Visible = tmr_DrawSpectrum.Enabled;

            lbl_WindowType.Visible = tmr_DrawSpectrum.Enabled;
            cmb_WindowType.Visible = tmr_DrawSpectrum.Enabled;
        }

        private void SaveOscillPicture(string FileName)
        {
            
            Bitmap Canvas = new Bitmap(img_Oscill.Image);
            Graphics g = Graphics.FromImage(Canvas);
            g.DrawString(lbl_TimeScale_Value.Text, this.Font, Brushes.Lime, 10, 5);
            g.DrawString(lbl_CursorTime_Value.Text + " " + lbl_CursorTime_Nom.Text, this.Font, Brushes.Lime, 10, 20);
            g.DrawString(lbl_CursorFreq_Value.Text + " " + lbl_CursorFreq_Nom.Text, this.Font, Brushes.Lime, 10, 35);
            g.DrawString(lbl_VMax.Text + " " + lbl_VMax_Value.Text, this.Font, Brushes.Lime, 90, 5);
            g.DrawString(lbl_VMin.Text + " " + lbl_VMin_Value.Text, this.Font, Brushes.Lime, 90, 20);
            g.DrawString(lbl_VAmp.Text + " " + lbl_VAmp_Value.Text, this.Font, Brushes.Lime, 90, 35);
            Canvas.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            Canvas.Dispose();
            g.Dispose();
        }

        private void GetSensCaption(int Value)
        {
            switch (Value)
            {
                case 1:
                    lbl_Sens_Value.Text = "1";                    
                    OscillInfo.Sens_TextValue = 1;
                    break;
                case 2:
                    lbl_Sens_Value.Text = "2";
                    OscillInfo.Sens_TextValue = 2;
                    break;
                case 3:
                    lbl_Sens_Value.Text = "5";
                    OscillInfo.Sens_TextValue = 5;
                    break;
                case 4:
                    lbl_Sens_Value.Text = "10";
                    OscillInfo.Sens_TextValue = 10;
                    break;
                case 5:
                    lbl_Sens_Value.Text = "20";
                    OscillInfo.Sens_TextValue = 20;
                    break;
                case 6:
                    lbl_Sens_Value.Text = "50";
                    OscillInfo.Sens_TextValue = 50;
                    break;
                default:
                    lbl_Sens_Value.Text = "Err";
                    break;
            }
        }
        private void GetTimescaleInfo(int Value)
        {
            // Инфа по времени взята из прошивки.
            // За что купил - за то и продаю... Но все очень похоже на правду.
            // На быстрых развертках округлять не стоит.
            // Будет очень сильно плавать результат измерений частоты меж курсоров.
            switch (Value)
            {
                case 0:
                    lbl_TimeScale_Value.Text = "4.2 мкс/дел";
                    OscillInfo.fdisc = 5120000;
                    /*   5 uS/div (4.20  uS/div) 4.2*/
                    OscillInfo.time_coefficient = 4.2f;
                    break;
                case 1:
                    lbl_TimeScale_Value.Text = "10.6 мкс/дел";
                    OscillInfo.fdisc = 2560000;
                    /*  10 uS/div (10.6  uS/div) 10.6*/
                    OscillInfo.time_coefficient = 10.6f;
                    break;
                case 2:
                    lbl_TimeScale_Value.Text = "19.2 мкс/дел";
                    OscillInfo.fdisc = 1280000;
                    /*  20 uS/div (19.2  uS/div) 19.2*/
                    OscillInfo.time_coefficient = 19.2f;
                    break;
                case 3:
                    lbl_TimeScale_Value.Text = "51.2 мкс/дел";
                    OscillInfo.fdisc = 512000;
                    /*  50 uS/div (51.2  uS/div) 51.2*/
                    OscillInfo.time_coefficient = 51.2f;
                    break;
                case 4:
                    lbl_TimeScale_Value.Text = "0.96 мс/дел";
                    OscillInfo.fdisc = 256000;
                    /* 0.1 mS/div (0.096 mS/div)  96*/
                    OscillInfo.time_coefficient = 96.0f;
                    break;
                case 5:
                    lbl_TimeScale_Value.Text = "0.2 мс/дел";
                    OscillInfo.fdisc = 128000;
                    /* 0.2 mS/div (0.198 mS/div) 198*/
                    OscillInfo.time_coefficient = 200.0f;
                    break;
                case 6:
                    lbl_TimeScale_Value.Text = "0.5 мс/дел";
                    OscillInfo.fdisc = 51200;
                    /* 0.5 mS/div (0.499 mS/div) 499*/
                    OscillInfo.time_coefficient = 500.0f;
                    break;
                case 7:
                    lbl_TimeScale_Value.Text = "1 мс/дел";
                    OscillInfo.fdisc = 25600;
                    /*   1 mS/div (0.998 mS/div)  998*/
                    OscillInfo.time_coefficient = 1000.0f;
                    break;
                case 8:
                    lbl_TimeScale_Value.Text = "2 мс/дел";
                    OscillInfo.fdisc = 12800;
                    /*   2 mS/div (1.99  ms/div) 1990*/
                    OscillInfo.time_coefficient = 2000.0f;
                    break;
                case 9:
                    lbl_TimeScale_Value.Text = "5 мс/дел";
                    OscillInfo.fdisc = 5120;
                    /*   5 mS/div (4.99  ms/div) 4990*/
                    OscillInfo.time_coefficient = 5000.0f;
                    break;
                case 10:
                    lbl_TimeScale_Value.Text = "10 мс/дел";
                    OscillInfo.fdisc = 2560;
                    /*  10 mS/div (9.99  ms/div)  9990*/
                    OscillInfo.time_coefficient = 10000.0f;
                    break;
                case 11:
                    lbl_TimeScale_Value.Text = "20 мс/дел";
                    OscillInfo.fdisc = 1280;
                    /*  20 mS/div (19.9  ms/div) 19900*/
                    OscillInfo.time_coefficient = 20000.0f;
                    break;
            }
        }
        private void CalculateCursorData()
        {
            // period and freq between cursors
            int n1 = scrl_Cursor1.Value;
            int n2 = scrl_Cursor2.Value;

            string Time_Nom = "", Freq_Nom = "";

            // Коэффициент - это Ширина поля(770) деленая на 10.
            // Таким образом 1 деление поля - это 77 пикселей.
            // Вот мы и переводим попугаев в секунды 	=)
            float WidthCoeff = (float)img_Oscill.Width / 10.0f;
            float Period = (Math.Abs(n1 - n2) / WidthCoeff) * OscillInfo.time_coefficient;
            if (Period == 0.0f)
            {
                Period += 0.00000001f;
            }
            float Frequency = 1000000.0f / (Period);

            // time between cursors
            if (Period > 1000)             //ms
            {
                Period = Period / 1000;
                Time_Nom = "мс";
            }
            else             //us
            {
                Time_Nom = "мкс";
            }

            if (Frequency >= 1000000)
            {
                Frequency = Frequency / 1000000.0f;
                Freq_Nom = "МГц";
            }
            else if (Frequency >= 1000.0f)
            {
                Frequency = Frequency / 1000.0f;
                Freq_Nom = "кГц";
            }
            else
            {
                Freq_Nom = "Гц";
            }
            // Frequency Value

            lbl_CursorTime_Nom.Text = Time_Nom;
            lbl_CursorFreq_Nom.Text = Freq_Nom;
            
            lbl_CursorFreq_Value.Text = String.Format("{0:0.000}", Frequency); 
            lbl_CursorTime_Value.Text = String.Format("{0:0.000}", Period);

        }

        private void DrawGrid(Graphics g)
        {
            g.Clear(CurrentColorScheme.BackGround); // Залили все фоновым цветом. 

            Pen Pen = new Pen(CurrentColorScheme.Grid, 1);
            for (int i = 0; i < 11; i++)
            {
                // счетчик делений (10 шт на экран)
                int x = i * img_Oscill.Width / 10 + 2;
                g.DrawLine(Pen, new Point(x, 0), new Point(x, img_Oscill.Height));
            }

            for (int i = 0; i < 11; i++)
            {
                int y = i * img_Oscill.Height / 10;
                g.DrawLine(Pen, new Point(0, y), new Point(img_Oscill.Width, y));
            }

            // Zero level
            int zero = img_Oscill.Height / 2;
            Pen.Color = CurrentColorScheme.ZeroLvl;
            g.DrawLine(Pen, new Point(0, zero), new Point(img_Oscill.Width, zero));
        }
        private void DrawGraph(Graphics g)
        {
            Pen Pen = new Pen(CurrentColorScheme.Graph, 1);

            int y = (img_Oscill.Height - Oscill.DoneArray[0] * 2) - (trc_YPos.Value + 1);

            Point StartPoint = new Point(2, y);
            Point EndPoint = new Point();

            double vmax = -200, vmin = 200, vamp = 0;
            for (int x = 1; x < 256; x++)
            {

                EndPoint.Y = (img_Oscill.Height - Oscill.DoneArray[x] * 2) - (trc_YPos.Value + 1);
                EndPoint.X = (x * 3) + 2;
                g.DrawLine(Pen, StartPoint, EndPoint);

                StartPoint = EndPoint;

                int v = Oscill.DoneArray[x] - 128;
                if (v > vmax) vmax = v;
                if (v < vmin) vmin = v;
            }

            //zero-crossing rate:
            //Voltages
            double div = 1;
            if(!sw_Divider.Checked)
                 div = 100;
            double div_Coeff = 25.6 / (OscillInfo.Sens_TextValue / div); // must be 1 with x100 and 1 sens
            vmax = vmax / div_Coeff; 
            vmin = vmin / div_Coeff;
            vamp = vmax - vmin;

            lbl_VMax_Value.Text = String.Format("{0:0.000}", vmax);
            lbl_VMin_Value.Text = String.Format("{0:0.000}", vmin);
            lbl_VAmp_Value.Text = String.Format("{0:0.000}", vamp);

        }
        private void DrawCursors(Graphics g)
        {
            Pen Pen = new Pen(CurrentColorScheme.Cursor1, 1);

            Point StartPoint = new Point(scrl_Cursor1.Value, 0);
            Point EndPoint = new Point(scrl_Cursor1.Value, img_Oscill.Height);
            g.DrawLine(Pen, StartPoint, EndPoint);

            Pen.Color = CurrentColorScheme.Cursor2;
            StartPoint = new Point(scrl_Cursor2.Value, 0);
            EndPoint = new Point(scrl_Cursor2.Value, img_Oscill.Height);
            g.DrawLine(Pen, StartPoint, EndPoint);
        }

        private void tmr_Oscill_Poll_Tick(object sender, EventArgs e)
        {
            tmr_Oscill_Poll.Enabled = false;
            if (!Oscill.CheckDevice())
                return;
            Oscill.CollectOscillData();
            tmr_Oscill_Poll.Enabled = true;
        }
        private void tmr_DrawImage_Tick(object sender, EventArgs e)
        {
            Bitmap Canvas = new Bitmap(img_Oscill.Width, img_Oscill.Height);
            Graphics g = Graphics.FromImage(Canvas);
            DrawGrid(g);
            DrawGraph(g);
            DrawCursors(g);
            img_Oscill.Image = Canvas;
            g.Dispose();
            CalculateCursorData();
        }
        private void tmr_DrawSpectrum_Tick(object sender, EventArgs e)
        {
            Oscill.Calculate_FFT_Data(OscillInfo.fdisc,OscillInfo.WaveWindowType);
            Chart.Series[0].Points.Clear();

            if (OscillInfo.Amp_Freq_type == 0)
            {
                for (int x = 0; x < 128; x++)
                    Chart.Series[0].Points.AddXY(Oscill.freq[x], Oscill.amp[x]);
            }
            else
            {
                for (int x = 0; x < 128; x++)
                    Chart.Series[0].Points.AddXY(Oscill.freq[x], Oscill.phase[x]);
            }
        }

        private void img_Oscill_MouseDown(object sender, MouseEventArgs e)
        {
            int dx1 = Math.Abs(e.X - scrl_Cursor1.Value);
            int dx2 = Math.Abs(e.X - scrl_Cursor2.Value);
            if (dx1 <= dx2)
                curCursor = scrl_Cursor1;
            else
                curCursor = scrl_Cursor2;
        }
        private void img_Oscill_MouseUp(object sender, MouseEventArgs e)
        {
            curCursor = null;
        }
        private void img_Oscill_MouseMove(object sender, MouseEventArgs e)
        {
            if (curCursor == null)
                return;
            if (e.X > curCursor.Maximum)
                curCursor.Value = curCursor.Maximum;
            else if (e.X < curCursor.Minimum)
                curCursor.Value = curCursor.Minimum;
            else
                curCursor.Value = e.X;
        }

        private void btnStart_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnStart.Checked)
            {
                tmr_Oscill_Poll.Enabled = false;
                Oscill.Dispose();
                btnPause.Enabled = false;
                btnPause.Checked = false;
                btnPause.Text = "Пауза";
                btnStart.Text = "Старт";
                mem_Log.AppendText("Device stopped" + Environment.NewLine);
            }
            else
            {
                if (Oscill == null)
                    Oscill = new OscillDev();

                mem_Log.AppendText("Searching" + Environment.NewLine);
                mem_Log.AppendText("VID:" + Oscill.Konstants.MY_VID + Environment.NewLine);
                mem_Log.AppendText("PID:" + Oscill.Konstants.MY_PID + Environment.NewLine);
                if (!Oscill.ConnectToOscill())
                {
                    mem_Log.AppendText("Device not found" + Environment.NewLine);                    
                    btnStart.Checked = false;
                    return;
                }
                mem_Log.AppendText("Connected!" + Environment.NewLine);
                mem_Log.AppendText("Firmware Version: " + Oscill.Konstants.FirmwareVersion + Environment.NewLine);
                if (Oscill.Konstants.FirmwareVersion == "V1.03")
                    Init_103();
                else
                    Init_102();

                tmr_Oscill_Poll.Enabled = true;

                btnPause.Enabled = true;
                btnStart.Text = "Стоп";
            }
        }
        private void btnPause_CheckedChanged(object sender, EventArgs e)
        {
            if (btnPause.Checked)
            {
                tmr_Oscill_Poll.Enabled = false;
                btnPause.Text = "Продолжить";
            }
            else
            {
                tmr_Oscill_Poll.Enabled = true;
                btnPause.Text = "Пауза";
            }
        }
        private void YPos_Click(object sender, EventArgs e)
        {
            trc_YPos.Value = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                SaveOscillPicture(saveFileDialog.FileName);
        }
        private void btnMode_Click(object sender, EventArgs e)
        {
            tmr_DrawImage.Enabled = !tmr_DrawImage.Enabled;
            tmr_DrawSpectrum.Enabled = !tmr_DrawSpectrum.Enabled;
            SetModeVisibility();
        }

        private void sw_InputChanged(object sender, EventArgs e)
        {

            if (sw_Input.Checked)
            {
                sw_Input.Text = "Откр.";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SHUTTER, 1);
            }
            else
            {
                sw_Input.Text = "Закр.";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SHUTTER, 0);
            }
        }
        private void sw_GND_CheckedChanged(object sender, EventArgs e)
        {
            if (sw_GND.Checked)
            {
                sw_GND.Text = "   Выкл";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SENS, (byte)trc_Sens.Value);
            }
            else
            {
                sw_GND.Text = "   Вкл";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SENS, 9); // Magic Constant for GND
            }
                
        }
        private void sw_Divider_CheckedChanged(object sender, EventArgs e)
        {
            if (sw_Divider.Checked)
            {
                sw_Divider.Text = "   x100";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_DIVIDER, 1);
            }
            else
            {
                sw_Divider.Text = "    x1";
                if (!Oscill.CheckDevice())
                    return;
                Oscill.SendOscillCommand(Oscill.Konstants.SET_DIVIDER, 0);
            }
        }

        private void trc_Syncr_ValueChanged(object sender, EventArgs e)
        {
            if (Oscill.CheckDevice())
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SYNC, (byte)Math.Round((trc_Syncr.Value + 50) * 2.56));
        }
        private void trc_Sens_ValueChanged(object sender, EventArgs e)
        {
            if (Oscill.CheckDevice())
                Oscill.SendOscillCommand(Oscill.Konstants.SET_SENS, (byte)trc_Sens.Value);
            sw_GND.Checked = true;
            GetSensCaption(trc_Sens.Value);
        }
        private void trc_TimeScale_ValueChanged(object sender, EventArgs e)
        {
            if (Oscill.CheckDevice())
                Oscill.SendOscillCommand(Oscill.Konstants.SET_TIMESCALE, (byte)trc_TimeScale.Value);
            GetTimescaleInfo(trc_TimeScale.Value);
        }
        private void trc_Offset_ValueChanged(object sender, EventArgs e)
        {
            if(Oscill.CheckDevice())
                Oscill.SendOscillCommand(Oscill.Konstants.SET_OFFSET, (byte)trc_Offset.Value);
        }

        private void cmb_AnalyticMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            OscillInfo.Amp_Freq_type = cmb_AnalyticMode.SelectedIndex;
        }
        private void cmb_WindowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OscillInfo.WaveWindowType = cmb_WindowType.SelectedIndex;
        }

        private void men_DarkColorScheme_Click(object sender, EventArgs e)
        {
            SetColorScheme(0);
        }
        private void men_LightColorScheme_Click(object sender, EventArgs e)
        {
            SetColorScheme(1);
        }
        private void men_ColorSchemeSettings_Click(object sender, EventArgs e)
        {
            UserColorSchemeSettings FormSettings = new UserColorSchemeSettings();
            FormSettings.ShowDialog();
        }
        private void men_SaveColorScheme_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserBackground = CurrentColorScheme.BackGround;
            Properties.Settings.Default.UserGrid = CurrentColorScheme.Grid;
            Properties.Settings.Default.UserZeroLvl= CurrentColorScheme.ZeroLvl;
            Properties.Settings.Default.UserGraph = CurrentColorScheme.Graph;
            Properties.Settings.Default.UserCursor1 = CurrentColorScheme.Cursor1;
            Properties.Settings.Default.UserCursor2 = CurrentColorScheme.Cursor2;
            Properties.Settings.Default.UserSaved = true;
            Properties.Settings.Default.Save();
        }
        private void men_SaveOscillPicture_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                SaveOscillPicture(saveFileDialog.FileName);
        }
        private void men_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти ?", "Выход", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Application.Exit();
        }
    }

    public class OscillDev
    {

        private static UsbDevice OscillDevice;
        private UsbEndpointReader reader;
        private UsbEndpointWriter writer;
        
        public byte[] DoneArray = new byte[256];
        public double[] amp = new double[128];
        public double[] freq = new double[128];
        public double[] phase = new double[128];

        public struct OSC_Constants
        {
            public byte READ_VERSION;
            public byte COLLECT_OSC_DATA;
            public byte READ_OSC_DATA;
            public byte SET_OFFSET;
            public byte SET_TIMESCALE;
            public byte SET_SYNC;
            public byte SET_SENS;
            public byte SET_SHUTTER;
            public byte SET_DIVIDER;

            public int MY_VID;
            public int MY_PID;

            public ReadEndpointID rID;
            public WriteEndpointID wID;

            public string DeviceName;
            public string FirmwareVersion;
        };
        public OSC_Constants Konstants = new OSC_Constants();

        public OscillDev()
        {
            Konstants.READ_VERSION = 0;
            Konstants.COLLECT_OSC_DATA = 1;
            Konstants.READ_OSC_DATA = 2;
            Konstants.SET_OFFSET = 3;
            Konstants.SET_TIMESCALE = 4;
            Konstants.SET_SYNC = 5;
            Konstants.SET_SENS = 6;
            Konstants.SET_SHUTTER = 7;
            Konstants.SET_DIVIDER = 8;

            /* the device's vendor and product id */
            Konstants.MY_VID = 0x04d8;
            Konstants.MY_PID = 0x0002;

            Konstants.rID = ReadEndpointID.Ep01;
            Konstants.wID = WriteEndpointID.Ep01;

        }

        public void Dispose()
        {
            if(OscillDevice != null)
                OscillDevice.Close();
            if (writer != null)
                writer.Dispose();
            if(reader != null)
                reader.Dispose();
            OscillDevice = null;
        }
        public bool ConnectToOscill()
        {
            UsbRegDeviceList allDevices = UsbDevice.AllLibUsbDevices;
            foreach (UsbRegistry usbRegistry in allDevices)
            {
                if ((usbRegistry.Vid == Konstants.MY_VID) && (usbRegistry.Pid == Konstants.MY_PID))
                {
                    usbRegistry.Open(out OscillDevice);
                    if (OscillDevice != null)
                    {
                        reader = OscillDevice.OpenEndpointReader(Konstants.rID);
                        writer = OscillDevice.OpenEndpointWriter(Konstants.wID);

                        Konstants.DeviceName = OscillDevice.Info.ProductString;
                        Konstants.FirmwareVersion = OscillDevice.Info.SerialString;
                        return true;
                    }
                        
                }
            }
            return false;
        }
        public void SendOscillCommand(byte CommandType, byte Value)
        {
            byte[] sendArray = new byte[2];
            sendArray[0] = CommandType;
            sendArray[1] = Value;
            writer.Write(sendArray, 1000, out int out_l);
        }
        public void CollectOscillData()
        {

            byte[] sendArray = new byte[2];
            byte[] recieveAr = new byte[64];

            sendArray[0] = Konstants.COLLECT_OSC_DATA;
            writer.Write(sendArray, 1000, out int out_l);
            reader.Read(recieveAr, 1000, out out_l);

            // we need to fill 256 by 64.
            // so 'x' is counter for DoneArray 
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                sendArray[0] = Konstants.READ_OSC_DATA;
                sendArray[1] = (byte)i;
                writer.Write(sendArray, 1000, out out_l);
                reader.Read(recieveAr, 1000, out out_l);
                for (int j = 0; j < 64; j++, x++)
                {
                    DoneArray[x] = recieveAr[j];
                }
            }
        }

        public bool CheckDevice()
        {
            if (OscillDevice == null)
                return false;
            return OscillDevice.UsbRegistryInfo.IsAlive;
        }

        private double GetWaveWindowCoeff(int WindowType, int curIndex)
        {
            // With all respect, I do not know what here happens.
            // This part of code was copy-pasted and slightly modyfied.

            double fl_w;
            switch (WindowType)
            {
                case 0:
                    {
                        //Caption = "Прямоугольная";
                        fl_w = 1.0;
                        break;
                    }
                case 1:
                    {
                        //Caption = "SIN-окно";
                        fl_w = Math.Sin(0.012319971 * curIndex);
                        break;
                    }
                case 2:
                    {
                        //Caption = "Барлетта-Ганна";
                        fl_w = 0.62 - 0.48 * Math.Abs((curIndex / 255) - 0.5) - 0.38 * Math.Cos(0.027925268 * curIndex);
                        break;
                    }
                case 3:
                    {
                        //Caption = "Хемминга";
                        fl_w = 0.54 - 0.46 * Math.Cos(0.027925268 * curIndex);
                        break;
                    }
                case 4:
                    {
                        //Caption = "Блэкмана";
                        fl_w = 0.42 - 0.50 * Math.Cos(0.027925268 * curIndex) + 0.08 * Math.Cos(0.055850536 * curIndex);
                        break;
                    }
                case 5:
                    {
                        //Caption = "Наталла";
                        fl_w = 0.355768 - 0.487396 * Math.Cos(0.027925268 * curIndex) + 0.144232 * Math.Cos(0.055850536 * curIndex) + 0.012604 * Math.Cos(0.083775804 * curIndex);
                        break;
                    }
                case 6:
                    {
                        //Caption = "Блэкмана-Наталла";
                        fl_w = 0.3625819 - 0.4891775 * Math.Cos(0.027925268 * curIndex) + 0.1365995 * Math.Cos(0.055850536 * curIndex) + 0.0106411 * Math.Cos(0.083775804 * curIndex);
                        break;
                    }
                case 7:
                    {
                        //Caption = "Гауса (-69 Дб)";
                        fl_w = Math.Exp((-0.5) * ((curIndex - 127.5) / (38.25)) * ((curIndex - 127.5) / (38.25)));
                        break;
                    }
                default:
                    {
                        //Caption = "Прямоугольная";
                        fl_w = 1.0;
                        break;
                    }
            }
            return fl_w;
        }
        public void Calculate_FFT_Data(double NSamples, int WaveWindowType)
        {

            //Prepearing Complex Array fo fft
            alglib.complex[] ComplexArray = new alglib.complex[DoneArray.Length];
            for (int i = 0; i < 256; i++)
            {
                ComplexArray[i].x = DoneArray[i] * GetWaveWindowCoeff(WaveWindowType,i);
                ComplexArray[i].y = 0;
            }
            // FFT Magick!
            alglib.fftc1d(ref ComplexArray);

            // Analyzing recieved data.
            int Nmax = (255 + 1) / 2;
            //harmonica ampl limit
            double limit = 0.001;
            // optimization var
            double abs2min = limit * limit * 256 * 256;

            //-------finding constant part of signal------
            if (ComplexArray[0].x >= limit)
            {
                amp[0] = ComplexArray[0].x / 256;
                freq[0] = 0.0;
                phase[0] = 0.0;
            }

            int harmonic_Index = 0;
            for (int i = 1; i < Nmax; ++i)
            {
                double re = ComplexArray[i].x;
                double im = ComplexArray[i].y;

                // sqr of modul
                double abs2 = re * re + im * im;

                // low harmonics no
                if (abs2 < abs2min)
                    continue;

                // ampl (without mirror effect)
                amp[harmonic_Index] = 2.0 * Math.Sqrt(abs2) / 256;

                // phase of COS
                phase[harmonic_Index] = Math.Atan2(im, re);

                // COS >> SIN
                phase[harmonic_Index] += 1.571;
                if (phase[harmonic_Index] > 3.142)
                    phase[harmonic_Index] -= 6.283;

                // get freq
                freq[harmonic_Index] = (NSamples * i) / 256;
                ++harmonic_Index;
            }
            // harmonic_Index -  Found harmonics count. Число гармоник которые нашли.
            
        }
    }

    public static class CurrentColorScheme
    {
        public static Color BackGround;
        public static Color Graph;
        public static Color Grid;
        public static Color ZeroLvl;
        public static Color Cursor1;
        public static Color Cursor2;
        public static Color SpectrumColor;
    }
    public static class OscillInfo
    {
        //public static string TimeScale_Caption, Sens_Caption;
        //public static int vmax, vmin, vamp;
        public static double Sens_TextValue;
        public static double fdisc;
        public static float time_coefficient;
        public static int WaveWindowType;
        public static int Amp_Freq_type;
    }


}
