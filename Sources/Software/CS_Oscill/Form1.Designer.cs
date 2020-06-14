namespace CS_Oscill
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.img_Oscill = new System.Windows.Forms.PictureBox();
            this.tmr_Oscill_Poll = new System.Windows.Forms.Timer(this.components);
            this.tmr_DrawImage = new System.Windows.Forms.Timer(this.components);
            this.tmr_DrawSpectrum = new System.Windows.Forms.Timer(this.components);
            this.trc_Syncr = new System.Windows.Forms.TrackBar();
            this.trc_YPos = new System.Windows.Forms.TrackBar();
            this.lbl_YPos = new System.Windows.Forms.Label();
            this.lbl_Syncr = new System.Windows.Forms.Label();
            this.scrl_Cursor1 = new System.Windows.Forms.HScrollBar();
            this.scrl_Cursor2 = new System.Windows.Forms.HScrollBar();
            this.sw_Input = new System.Windows.Forms.CheckBox();
            this.sw_GND = new System.Windows.Forms.CheckBox();
            this.sw_Divider = new System.Windows.Forms.CheckBox();
            this.trc_TimeScale = new System.Windows.Forms.TrackBar();
            this.trc_Sens = new System.Windows.Forms.TrackBar();
            this.trc_Offset = new System.Windows.Forms.TrackBar();
            this.lbl_Cursor1 = new System.Windows.Forms.Label();
            this.lbl_Cursor2 = new System.Windows.Forms.Label();
            this.lbl_TimeScale = new System.Windows.Forms.Label();
            this.lbl_Sens = new System.Windows.Forms.Label();
            this.lbl_Offset = new System.Windows.Forms.Label();
            this.lbl_Input = new System.Windows.Forms.Label();
            this.lbl_GND = new System.Windows.Forms.Label();
            this.lbl_Divider = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.CheckBox();
            this.btnPause = new System.Windows.Forms.CheckBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lbl_VAmp_Value = new System.Windows.Forms.Label();
            this.lbl_VMin_Value = new System.Windows.Forms.Label();
            this.lbl_VMax_Value = new System.Windows.Forms.Label();
            this.lbl_CursorFreq_Value = new System.Windows.Forms.Label();
            this.lbl_CursorTime_Value = new System.Windows.Forms.Label();
            this.lbl_CursorFreq_Nom = new System.Windows.Forms.Label();
            this.lbl_CursorTime_Nom = new System.Windows.Forms.Label();
            this.lbl_VAmp = new System.Windows.Forms.Label();
            this.lbl_VMin = new System.Windows.Forms.Label();
            this.lbl_VMax = new System.Windows.Forms.Label();
            this.lbl_CursorTime = new System.Windows.Forms.Label();
            this.lbl_CursorFreq = new System.Windows.Forms.Label();
            this.YPos = new System.Windows.Forms.Button();
            this.mem_Log = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.men_SaveOscillPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.men_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.цветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.men_DarkColorScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.men_LightColorScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.men_ColorSchemeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.men_SaveColorScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_TimeScale_Value = new System.Windows.Forms.Label();
            this.lbl_Sens_Value = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cmb_AnalyticMode = new System.Windows.Forms.ComboBox();
            this.cmb_WindowType = new System.Windows.Forms.ComboBox();
            this.lbl_AnalyticMode = new System.Windows.Forms.Label();
            this.lbl_WindowType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_Oscill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Syncr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_YPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_TimeScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Sens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Offset)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // img_Oscill
            // 
            this.img_Oscill.Location = new System.Drawing.Point(76, 27);
            this.img_Oscill.Name = "img_Oscill";
            this.img_Oscill.Size = new System.Drawing.Size(770, 510);
            this.img_Oscill.TabIndex = 1;
            this.img_Oscill.TabStop = false;
            this.img_Oscill.MouseDown += new System.Windows.Forms.MouseEventHandler(this.img_Oscill_MouseDown);
            this.img_Oscill.MouseMove += new System.Windows.Forms.MouseEventHandler(this.img_Oscill_MouseMove);
            this.img_Oscill.MouseUp += new System.Windows.Forms.MouseEventHandler(this.img_Oscill_MouseUp);
            // 
            // tmr_Oscill_Poll
            // 
            this.tmr_Oscill_Poll.Interval = 25;
            this.tmr_Oscill_Poll.Tick += new System.EventHandler(this.tmr_Oscill_Poll_Tick);
            // 
            // tmr_DrawImage
            // 
            this.tmr_DrawImage.Interval = 25;
            this.tmr_DrawImage.Tick += new System.EventHandler(this.tmr_DrawImage_Tick);
            // 
            // tmr_DrawSpectrum
            // 
            this.tmr_DrawSpectrum.Interval = 25;
            this.tmr_DrawSpectrum.Tick += new System.EventHandler(this.tmr_DrawSpectrum_Tick);
            // 
            // trc_Syncr
            // 
            this.trc_Syncr.Location = new System.Drawing.Point(25, 73);
            this.trc_Syncr.Maximum = 40;
            this.trc_Syncr.Minimum = -40;
            this.trc_Syncr.Name = "trc_Syncr";
            this.trc_Syncr.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trc_Syncr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trc_Syncr.RightToLeftLayout = true;
            this.trc_Syncr.Size = new System.Drawing.Size(45, 413);
            this.trc_Syncr.TabIndex = 3;
            this.trc_Syncr.ValueChanged += new System.EventHandler(this.trc_Syncr_ValueChanged);
            // 
            // trc_YPos
            // 
            this.trc_YPos.Location = new System.Drawing.Point(852, 27);
            this.trc_YPos.Maximum = 128;
            this.trc_YPos.Minimum = -127;
            this.trc_YPos.Name = "trc_YPos";
            this.trc_YPos.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trc_YPos.Size = new System.Drawing.Size(45, 510);
            this.trc_YPos.TabIndex = 4;
            // 
            // lbl_YPos
            // 
            this.lbl_YPos.Location = new System.Drawing.Point(884, 206);
            this.lbl_YPos.Name = "lbl_YPos";
            this.lbl_YPos.Size = new System.Drawing.Size(13, 144);
            this.lbl_YPos.TabIndex = 5;
            this.lbl_YPos.Text = "Y Поправка";
            this.lbl_YPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Syncr
            // 
            this.lbl_Syncr.Location = new System.Drawing.Point(22, 236);
            this.lbl_Syncr.Name = "lbl_Syncr";
            this.lbl_Syncr.Size = new System.Drawing.Size(13, 94);
            this.lbl_Syncr.TabIndex = 6;
            this.lbl_Syncr.Text = "Синхронизация";
            // 
            // scrl_Cursor1
            // 
            this.scrl_Cursor1.LargeChange = 1;
            this.scrl_Cursor1.Location = new System.Drawing.Point(76, 556);
            this.scrl_Cursor1.Maximum = 767;
            this.scrl_Cursor1.Minimum = 2;
            this.scrl_Cursor1.Name = "scrl_Cursor1";
            this.scrl_Cursor1.Size = new System.Drawing.Size(360, 17);
            this.scrl_Cursor1.TabIndex = 7;
            this.scrl_Cursor1.Value = 2;
            // 
            // scrl_Cursor2
            // 
            this.scrl_Cursor2.LargeChange = 1;
            this.scrl_Cursor2.Location = new System.Drawing.Point(486, 556);
            this.scrl_Cursor2.Maximum = 767;
            this.scrl_Cursor2.Minimum = 2;
            this.scrl_Cursor2.Name = "scrl_Cursor2";
            this.scrl_Cursor2.Size = new System.Drawing.Size(360, 17);
            this.scrl_Cursor2.TabIndex = 8;
            this.scrl_Cursor2.Value = 767;
            // 
            // sw_Input
            // 
            this.sw_Input.Appearance = System.Windows.Forms.Appearance.Button;
            this.sw_Input.Location = new System.Drawing.Point(244, 652);
            this.sw_Input.Name = "sw_Input";
            this.sw_Input.Size = new System.Drawing.Size(50, 21);
            this.sw_Input.TabIndex = 9;
            this.sw_Input.Text = "Закр.";
            this.sw_Input.UseVisualStyleBackColor = true;
            this.sw_Input.CheckedChanged += new System.EventHandler(this.sw_InputChanged);
            // 
            // sw_GND
            // 
            this.sw_GND.Appearance = System.Windows.Forms.Appearance.Button;
            this.sw_GND.Checked = true;
            this.sw_GND.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sw_GND.Location = new System.Drawing.Point(300, 652);
            this.sw_GND.Name = "sw_GND";
            this.sw_GND.Size = new System.Drawing.Size(50, 21);
            this.sw_GND.TabIndex = 10;
            this.sw_GND.Text = " Выкл";
            this.sw_GND.UseVisualStyleBackColor = true;
            this.sw_GND.CheckedChanged += new System.EventHandler(this.sw_GND_CheckedChanged);
            // 
            // sw_Divider
            // 
            this.sw_Divider.Appearance = System.Windows.Forms.Appearance.Button;
            this.sw_Divider.Checked = true;
            this.sw_Divider.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sw_Divider.Location = new System.Drawing.Point(356, 652);
            this.sw_Divider.Name = "sw_Divider";
            this.sw_Divider.Size = new System.Drawing.Size(50, 21);
            this.sw_Divider.TabIndex = 11;
            this.sw_Divider.Text = "  x100";
            this.sw_Divider.UseVisualStyleBackColor = true;
            this.sw_Divider.CheckedChanged += new System.EventHandler(this.sw_Divider_CheckedChanged);
            // 
            // trc_TimeScale
            // 
            this.trc_TimeScale.BackColor = System.Drawing.SystemColors.Control;
            this.trc_TimeScale.Location = new System.Drawing.Point(76, 593);
            this.trc_TimeScale.Maximum = 11;
            this.trc_TimeScale.Name = "trc_TimeScale";
            this.trc_TimeScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trc_TimeScale.Size = new System.Drawing.Size(155, 45);
            this.trc_TimeScale.TabIndex = 12;
            this.trc_TimeScale.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trc_TimeScale.Value = 2;
            this.trc_TimeScale.ValueChanged += new System.EventHandler(this.trc_TimeScale_ValueChanged);
            // 
            // trc_Sens
            // 
            this.trc_Sens.Location = new System.Drawing.Point(237, 593);
            this.trc_Sens.Maximum = 6;
            this.trc_Sens.Minimum = 1;
            this.trc_Sens.Name = "trc_Sens";
            this.trc_Sens.Size = new System.Drawing.Size(155, 45);
            this.trc_Sens.TabIndex = 13;
            this.trc_Sens.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trc_Sens.Value = 1;
            this.trc_Sens.ValueChanged += new System.EventHandler(this.trc_Sens_ValueChanged);
            // 
            // trc_Offset
            // 
            this.trc_Offset.Location = new System.Drawing.Point(76, 644);
            this.trc_Offset.Maximum = 15;
            this.trc_Offset.Minimum = 1;
            this.trc_Offset.Name = "trc_Offset";
            this.trc_Offset.Size = new System.Drawing.Size(155, 45);
            this.trc_Offset.TabIndex = 14;
            this.trc_Offset.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trc_Offset.Value = 8;
            this.trc_Offset.ValueChanged += new System.EventHandler(this.trc_Offset_ValueChanged);
            // 
            // lbl_Cursor1
            // 
            this.lbl_Cursor1.AutoSize = true;
            this.lbl_Cursor1.Location = new System.Drawing.Point(214, 540);
            this.lbl_Cursor1.Name = "lbl_Cursor1";
            this.lbl_Cursor1.Size = new System.Drawing.Size(52, 13);
            this.lbl_Cursor1.TabIndex = 15;
            this.lbl_Cursor1.Text = "Курсор 1";
            // 
            // lbl_Cursor2
            // 
            this.lbl_Cursor2.AutoSize = true;
            this.lbl_Cursor2.Location = new System.Drawing.Point(644, 540);
            this.lbl_Cursor2.Name = "lbl_Cursor2";
            this.lbl_Cursor2.Size = new System.Drawing.Size(52, 13);
            this.lbl_Cursor2.TabIndex = 16;
            this.lbl_Cursor2.Text = "Курсор 2";
            // 
            // lbl_TimeScale
            // 
            this.lbl_TimeScale.AutoSize = true;
            this.lbl_TimeScale.Location = new System.Drawing.Point(79, 577);
            this.lbl_TimeScale.Name = "lbl_TimeScale";
            this.lbl_TimeScale.Size = new System.Drawing.Size(61, 13);
            this.lbl_TimeScale.TabIndex = 17;
            this.lbl_TimeScale.Text = "Развертка";
            // 
            // lbl_Sens
            // 
            this.lbl_Sens.AutoSize = true;
            this.lbl_Sens.Location = new System.Drawing.Point(241, 577);
            this.lbl_Sens.Name = "lbl_Sens";
            this.lbl_Sens.Size = new System.Drawing.Size(101, 13);
            this.lbl_Sens.TabIndex = 18;
            this.lbl_Sens.Text = "Чувствительность";
            // 
            // lbl_Offset
            // 
            this.lbl_Offset.AutoSize = true;
            this.lbl_Offset.Location = new System.Drawing.Point(134, 628);
            this.lbl_Offset.Name = "lbl_Offset";
            this.lbl_Offset.Size = new System.Drawing.Size(45, 13);
            this.lbl_Offset.TabIndex = 19;
            this.lbl_Offset.Text = "Офсетт";
            // 
            // lbl_Input
            // 
            this.lbl_Input.AutoSize = true;
            this.lbl_Input.Location = new System.Drawing.Point(243, 636);
            this.lbl_Input.Name = "lbl_Input";
            this.lbl_Input.Size = new System.Drawing.Size(31, 13);
            this.lbl_Input.TabIndex = 20;
            this.lbl_Input.Text = "Вход";
            // 
            // lbl_GND
            // 
            this.lbl_GND.AutoSize = true;
            this.lbl_GND.Location = new System.Drawing.Point(309, 636);
            this.lbl_GND.Name = "lbl_GND";
            this.lbl_GND.Size = new System.Drawing.Size(31, 13);
            this.lbl_GND.TabIndex = 21;
            this.lbl_GND.Text = "GND";
            // 
            // lbl_Divider
            // 
            this.lbl_Divider.AutoSize = true;
            this.lbl_Divider.Location = new System.Drawing.Point(356, 636);
            this.lbl_Divider.Name = "lbl_Divider";
            this.lbl_Divider.Size = new System.Drawing.Size(57, 13);
            this.lbl_Divider.TabIndex = 22;
            this.lbl_Divider.Text = "Делитель";
            // 
            // btnStart
            // 
            this.btnStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnStart.Location = new System.Drawing.Point(611, 577);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 24);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Старт";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.CheckedChanged += new System.EventHandler(this.btnStart_CheckedChanged);
            // 
            // btnPause
            // 
            this.btnPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(611, 607);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(78, 24);
            this.btnPause.TabIndex = 24;
            this.btnPause.Text = "Пауза";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.CheckedChanged += new System.EventHandler(this.btnPause_CheckedChanged);
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lbl_VAmp_Value);
            this.panelInfo.Controls.Add(this.lbl_VMin_Value);
            this.panelInfo.Controls.Add(this.lbl_VMax_Value);
            this.panelInfo.Controls.Add(this.lbl_CursorFreq_Value);
            this.panelInfo.Controls.Add(this.lbl_CursorTime_Value);
            this.panelInfo.Controls.Add(this.lbl_CursorFreq_Nom);
            this.panelInfo.Controls.Add(this.lbl_CursorTime_Nom);
            this.panelInfo.Controls.Add(this.lbl_VAmp);
            this.panelInfo.Controls.Add(this.lbl_VMin);
            this.panelInfo.Controls.Add(this.lbl_VMax);
            this.panelInfo.Controls.Add(this.lbl_CursorTime);
            this.panelInfo.Controls.Add(this.lbl_CursorFreq);
            this.panelInfo.Location = new System.Drawing.Point(419, 577);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(186, 112);
            this.panelInfo.TabIndex = 25;
            // 
            // lbl_VAmp_Value
            // 
            this.lbl_VAmp_Value.AutoSize = true;
            this.lbl_VAmp_Value.Location = new System.Drawing.Point(125, 33);
            this.lbl_VAmp_Value.Name = "lbl_VAmp_Value";
            this.lbl_VAmp_Value.Size = new System.Drawing.Size(13, 13);
            this.lbl_VAmp_Value.TabIndex = 11;
            this.lbl_VAmp_Value.Text = "0";
            // 
            // lbl_VMin_Value
            // 
            this.lbl_VMin_Value.AutoSize = true;
            this.lbl_VMin_Value.Location = new System.Drawing.Point(125, 19);
            this.lbl_VMin_Value.Name = "lbl_VMin_Value";
            this.lbl_VMin_Value.Size = new System.Drawing.Size(13, 13);
            this.lbl_VMin_Value.TabIndex = 10;
            this.lbl_VMin_Value.Text = "0";
            // 
            // lbl_VMax_Value
            // 
            this.lbl_VMax_Value.AutoSize = true;
            this.lbl_VMax_Value.Location = new System.Drawing.Point(125, 5);
            this.lbl_VMax_Value.Name = "lbl_VMax_Value";
            this.lbl_VMax_Value.Size = new System.Drawing.Size(13, 13);
            this.lbl_VMax_Value.TabIndex = 9;
            this.lbl_VMax_Value.Text = "0";
            // 
            // lbl_CursorFreq_Value
            // 
            this.lbl_CursorFreq_Value.AutoSize = true;
            this.lbl_CursorFreq_Value.Location = new System.Drawing.Point(104, 93);
            this.lbl_CursorFreq_Value.Name = "lbl_CursorFreq_Value";
            this.lbl_CursorFreq_Value.Size = new System.Drawing.Size(34, 13);
            this.lbl_CursorFreq_Value.TabIndex = 8;
            this.lbl_CursorFreq_Value.Text = "0.000";
            // 
            // lbl_CursorTime_Value
            // 
            this.lbl_CursorTime_Value.AutoSize = true;
            this.lbl_CursorTime_Value.Location = new System.Drawing.Point(104, 65);
            this.lbl_CursorTime_Value.Name = "lbl_CursorTime_Value";
            this.lbl_CursorTime_Value.Size = new System.Drawing.Size(34, 13);
            this.lbl_CursorTime_Value.TabIndex = 7;
            this.lbl_CursorTime_Value.Text = "0.000";
            // 
            // lbl_CursorFreq_Nom
            // 
            this.lbl_CursorFreq_Nom.AutoSize = true;
            this.lbl_CursorFreq_Nom.Location = new System.Drawing.Point(153, 93);
            this.lbl_CursorFreq_Nom.Name = "lbl_CursorFreq_Nom";
            this.lbl_CursorFreq_Nom.Size = new System.Drawing.Size(28, 13);
            this.lbl_CursorFreq_Nom.TabIndex = 6;
            this.lbl_CursorFreq_Nom.Text = "МГц";
            // 
            // lbl_CursorTime_Nom
            // 
            this.lbl_CursorTime_Nom.AutoSize = true;
            this.lbl_CursorTime_Nom.Location = new System.Drawing.Point(153, 64);
            this.lbl_CursorTime_Nom.Name = "lbl_CursorTime_Nom";
            this.lbl_CursorTime_Nom.Size = new System.Drawing.Size(27, 13);
            this.lbl_CursorTime_Nom.TabIndex = 5;
            this.lbl_CursorTime_Nom.Text = "мкс";
            // 
            // lbl_VAmp
            // 
            this.lbl_VAmp.AutoSize = true;
            this.lbl_VAmp.Location = new System.Drawing.Point(3, 33);
            this.lbl_VAmp.Name = "lbl_VAmp";
            this.lbl_VAmp.Size = new System.Drawing.Size(38, 13);
            this.lbl_VAmp.TabIndex = 4;
            this.lbl_VAmp.Text = "V Amp";
            // 
            // lbl_VMin
            // 
            this.lbl_VMin.AutoSize = true;
            this.lbl_VMin.Location = new System.Drawing.Point(3, 19);
            this.lbl_VMin.Name = "lbl_VMin";
            this.lbl_VMin.Size = new System.Drawing.Size(34, 13);
            this.lbl_VMin.TabIndex = 3;
            this.lbl_VMin.Text = "V Min";
            // 
            // lbl_VMax
            // 
            this.lbl_VMax.AutoSize = true;
            this.lbl_VMax.Location = new System.Drawing.Point(3, 5);
            this.lbl_VMax.Name = "lbl_VMax";
            this.lbl_VMax.Size = new System.Drawing.Size(37, 13);
            this.lbl_VMax.TabIndex = 2;
            this.lbl_VMax.Text = "V Max";
            // 
            // lbl_CursorTime
            // 
            this.lbl_CursorTime.AutoSize = true;
            this.lbl_CursorTime.Location = new System.Drawing.Point(3, 50);
            this.lbl_CursorTime.Name = "lbl_CursorTime";
            this.lbl_CursorTime.Size = new System.Drawing.Size(134, 13);
            this.lbl_CursorTime.TabIndex = 1;
            this.lbl_CursorTime.Text = "Время между курсорами";
            // 
            // lbl_CursorFreq
            // 
            this.lbl_CursorFreq.AutoSize = true;
            this.lbl_CursorFreq.Location = new System.Drawing.Point(3, 78);
            this.lbl_CursorFreq.Name = "lbl_CursorFreq";
            this.lbl_CursorFreq.Size = new System.Drawing.Size(143, 13);
            this.lbl_CursorFreq.TabIndex = 0;
            this.lbl_CursorFreq.Text = "Частота между курсорами";
            // 
            // YPos
            // 
            this.YPos.Location = new System.Drawing.Point(852, 550);
            this.YPos.Name = "YPos";
            this.YPos.Size = new System.Drawing.Size(45, 23);
            this.YPos.TabIndex = 27;
            this.YPos.Text = "Y=0";
            this.YPos.UseVisualStyleBackColor = true;
            this.YPos.Click += new System.EventHandler(this.YPos_Click);
            // 
            // mem_Log
            // 
            this.mem_Log.Location = new System.Drawing.Point(695, 577);
            this.mem_Log.Multiline = true;
            this.mem_Log.Name = "mem_Log";
            this.mem_Log.ReadOnly = true;
            this.mem_Log.Size = new System.Drawing.Size(202, 112);
            this.mem_Log.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(611, 637);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(611, 666);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(78, 23);
            this.btnMode.TabIndex = 30;
            this.btnMode.Text = "Режим";
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.цветаToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(922, 24);
            this.MainMenu.TabIndex = 31;
            this.MainMenu.Text = "MainMenu";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.men_SaveOscillPicture,
            this.toolStripSeparator1,
            this.men_Exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // men_SaveOscillPicture
            // 
            this.men_SaveOscillPicture.Name = "men_SaveOscillPicture";
            this.men_SaveOscillPicture.Size = new System.Drawing.Size(225, 22);
            this.men_SaveOscillPicture.Text = "Сохранить осциллограмму";
            this.men_SaveOscillPicture.Click += new System.EventHandler(this.men_SaveOscillPicture_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // men_Exit
            // 
            this.men_Exit.Name = "men_Exit";
            this.men_Exit.Size = new System.Drawing.Size(225, 22);
            this.men_Exit.Text = "Выход";
            this.men_Exit.Click += new System.EventHandler(this.men_Exit_Click);
            // 
            // цветаToolStripMenuItem
            // 
            this.цветаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.men_DarkColorScheme,
            this.men_LightColorScheme,
            this.toolStripSeparator2,
            this.men_ColorSchemeSettings,
            this.men_SaveColorScheme});
            this.цветаToolStripMenuItem.Name = "цветаToolStripMenuItem";
            this.цветаToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.цветаToolStripMenuItem.Text = "Цвета";
            // 
            // men_DarkColorScheme
            // 
            this.men_DarkColorScheme.Name = "men_DarkColorScheme";
            this.men_DarkColorScheme.Size = new System.Drawing.Size(167, 22);
            this.men_DarkColorScheme.Text = "Темная схема";
            this.men_DarkColorScheme.Click += new System.EventHandler(this.men_DarkColorScheme_Click);
            // 
            // men_LightColorScheme
            // 
            this.men_LightColorScheme.Name = "men_LightColorScheme";
            this.men_LightColorScheme.Size = new System.Drawing.Size(167, 22);
            this.men_LightColorScheme.Text = "Светлая схема";
            this.men_LightColorScheme.Click += new System.EventHandler(this.men_LightColorScheme_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // men_ColorSchemeSettings
            // 
            this.men_ColorSchemeSettings.Name = "men_ColorSchemeSettings";
            this.men_ColorSchemeSettings.Size = new System.Drawing.Size(167, 22);
            this.men_ColorSchemeSettings.Text = "Настроить схему";
            this.men_ColorSchemeSettings.Click += new System.EventHandler(this.men_ColorSchemeSettings_Click);
            // 
            // men_SaveColorScheme
            // 
            this.men_SaveColorScheme.Name = "men_SaveColorScheme";
            this.men_SaveColorScheme.Size = new System.Drawing.Size(167, 22);
            this.men_SaveColorScheme.Text = "Сохранить схему";
            this.men_SaveColorScheme.Click += new System.EventHandler(this.men_SaveColorScheme_Click);
            // 
            // Chart
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Hz";
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            this.Chart.Location = new System.Drawing.Point(76, 27);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "MySerie";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(770, 510);
            this.Chart.TabIndex = 32;
            this.Chart.Text = "chart1";
            this.Chart.Visible = false;
            // 
            // lbl_TimeScale_Value
            // 
            this.lbl_TimeScale_Value.AutoSize = true;
            this.lbl_TimeScale_Value.Location = new System.Drawing.Point(146, 577);
            this.lbl_TimeScale_Value.Name = "lbl_TimeScale_Value";
            this.lbl_TimeScale_Value.Size = new System.Drawing.Size(74, 13);
            this.lbl_TimeScale_Value.TabIndex = 33;
            this.lbl_TimeScale_Value.Text = "19.2 мкс/дел";
            // 
            // lbl_Sens_Value
            // 
            this.lbl_Sens_Value.AutoSize = true;
            this.lbl_Sens_Value.Location = new System.Drawing.Point(356, 577);
            this.lbl_Sens_Value.Name = "lbl_Sens_Value";
            this.lbl_Sens_Value.Size = new System.Drawing.Size(19, 13);
            this.lbl_Sens_Value.TabIndex = 34;
            this.lbl_Sens_Value.Text = "50";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "jpeg|*.jpg";
            // 
            // cmb_AnalyticMode
            // 
            this.cmb_AnalyticMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AnalyticMode.FormattingEnabled = true;
            this.cmb_AnalyticMode.Items.AddRange(new object[] {
            "Амплитудно-частотный",
            "Фазо-Частотный"});
            this.cmb_AnalyticMode.Location = new System.Drawing.Point(702, 611);
            this.cmb_AnalyticMode.Name = "cmb_AnalyticMode";
            this.cmb_AnalyticMode.Size = new System.Drawing.Size(189, 21);
            this.cmb_AnalyticMode.TabIndex = 35;
            this.cmb_AnalyticMode.Visible = false;
            this.cmb_AnalyticMode.SelectedIndexChanged += new System.EventHandler(this.cmb_AnalyticMode_SelectedIndexChanged);
            // 
            // cmb_WindowType
            // 
            this.cmb_WindowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_WindowType.FormattingEnabled = true;
            this.cmb_WindowType.Items.AddRange(new object[] {
            "Прямоугольное",
            "SIN-окно",
            "Барлетта-Ганна",
            "Хемминга",
            "Блэкмана",
            "Наталла",
            "Блэкмана-Наталла",
            "Гауса (-69 Дб)"});
            this.cmb_WindowType.Location = new System.Drawing.Point(702, 653);
            this.cmb_WindowType.Name = "cmb_WindowType";
            this.cmb_WindowType.Size = new System.Drawing.Size(189, 21);
            this.cmb_WindowType.TabIndex = 36;
            this.cmb_WindowType.Visible = false;
            this.cmb_WindowType.SelectedIndexChanged += new System.EventHandler(this.cmb_WindowType_SelectedIndexChanged);
            // 
            // lbl_AnalyticMode
            // 
            this.lbl_AnalyticMode.AutoSize = true;
            this.lbl_AnalyticMode.Location = new System.Drawing.Point(699, 597);
            this.lbl_AnalyticMode.Name = "lbl_AnalyticMode";
            this.lbl_AnalyticMode.Size = new System.Drawing.Size(89, 13);
            this.lbl_AnalyticMode.TabIndex = 37;
            this.lbl_AnalyticMode.Text = "Режим Графика";
            this.lbl_AnalyticMode.Visible = false;
            // 
            // lbl_WindowType
            // 
            this.lbl_WindowType.AutoSize = true;
            this.lbl_WindowType.Location = new System.Drawing.Point(699, 637);
            this.lbl_WindowType.Name = "lbl_WindowType";
            this.lbl_WindowType.Size = new System.Drawing.Size(120, 13);
            this.lbl_WindowType.TabIndex = 38;
            this.lbl_WindowType.Text = "Окно преобразования";
            this.lbl_WindowType.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(922, 714);
            this.Controls.Add(this.lbl_WindowType);
            this.Controls.Add(this.lbl_AnalyticMode);
            this.Controls.Add(this.cmb_WindowType);
            this.Controls.Add(this.cmb_AnalyticMode);
            this.Controls.Add(this.lbl_Sens_Value);
            this.Controls.Add(this.lbl_TimeScale_Value);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mem_Log);
            this.Controls.Add(this.YPos);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbl_Divider);
            this.Controls.Add(this.lbl_GND);
            this.Controls.Add(this.lbl_Input);
            this.Controls.Add(this.lbl_Offset);
            this.Controls.Add(this.lbl_Sens);
            this.Controls.Add(this.lbl_TimeScale);
            this.Controls.Add(this.lbl_Cursor2);
            this.Controls.Add(this.lbl_Cursor1);
            this.Controls.Add(this.trc_Offset);
            this.Controls.Add(this.trc_Sens);
            this.Controls.Add(this.trc_TimeScale);
            this.Controls.Add(this.sw_Divider);
            this.Controls.Add(this.sw_GND);
            this.Controls.Add(this.sw_Input);
            this.Controls.Add(this.scrl_Cursor2);
            this.Controls.Add(this.scrl_Cursor1);
            this.Controls.Add(this.lbl_Syncr);
            this.Controls.Add(this.lbl_YPos);
            this.Controls.Add(this.trc_YPos);
            this.Controls.Add(this.trc_Syncr);
            this.Controls.Add(this.img_Oscill);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Form1";
            this.Text = "Oscill 1.03";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_Oscill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Syncr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_YPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_TimeScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Sens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trc_Offset)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox img_Oscill;
        private System.Windows.Forms.Timer tmr_Oscill_Poll;
        private System.Windows.Forms.Timer tmr_DrawImage;
        private System.Windows.Forms.Timer tmr_DrawSpectrum;
        private System.Windows.Forms.TrackBar trc_Syncr;
        private System.Windows.Forms.TrackBar trc_YPos;
        private System.Windows.Forms.Label lbl_YPos;
        private System.Windows.Forms.Label lbl_Syncr;
        private System.Windows.Forms.HScrollBar scrl_Cursor1;
        private System.Windows.Forms.HScrollBar scrl_Cursor2;
        private System.Windows.Forms.CheckBox sw_Input;
        private System.Windows.Forms.CheckBox sw_GND;
        private System.Windows.Forms.CheckBox sw_Divider;
        private System.Windows.Forms.TrackBar trc_TimeScale;
        private System.Windows.Forms.TrackBar trc_Sens;
        private System.Windows.Forms.TrackBar trc_Offset;
        private System.Windows.Forms.Label lbl_Cursor1;
        private System.Windows.Forms.Label lbl_Cursor2;
        private System.Windows.Forms.Label lbl_TimeScale;
        private System.Windows.Forms.Label lbl_Sens;
        private System.Windows.Forms.Label lbl_Offset;
        private System.Windows.Forms.Label lbl_Input;
        private System.Windows.Forms.Label lbl_GND;
        private System.Windows.Forms.Label lbl_Divider;
        private System.Windows.Forms.CheckBox btnStart;
        private System.Windows.Forms.CheckBox btnPause;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button YPos;
        private System.Windows.Forms.TextBox mem_Log;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem men_SaveOscillPicture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem men_Exit;
        private System.Windows.Forms.ToolStripMenuItem цветаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem men_DarkColorScheme;
        private System.Windows.Forms.ToolStripMenuItem men_LightColorScheme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Label lbl_VMin;
        private System.Windows.Forms.Label lbl_VMax;
        private System.Windows.Forms.Label lbl_CursorTime;
        private System.Windows.Forms.Label lbl_CursorFreq;
        private System.Windows.Forms.Label lbl_TimeScale_Value;
        private System.Windows.Forms.Label lbl_Sens_Value;
        private System.Windows.Forms.Label lbl_VAmp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox cmb_AnalyticMode;
        private System.Windows.Forms.ComboBox cmb_WindowType;
        private System.Windows.Forms.Label lbl_AnalyticMode;
        private System.Windows.Forms.Label lbl_WindowType;
        private System.Windows.Forms.ToolStripMenuItem men_ColorSchemeSettings;
        private System.Windows.Forms.ToolStripMenuItem men_SaveColorScheme;
        private System.Windows.Forms.Label lbl_CursorFreq_Nom;
        private System.Windows.Forms.Label lbl_CursorTime_Nom;
        private System.Windows.Forms.Label lbl_VAmp_Value;
        private System.Windows.Forms.Label lbl_VMin_Value;
        private System.Windows.Forms.Label lbl_VMax_Value;
        private System.Windows.Forms.Label lbl_CursorFreq_Value;
        private System.Windows.Forms.Label lbl_CursorTime_Value;
    }
}

