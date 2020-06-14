namespace CS_Oscill
{
    partial class UserColorSchemeSettings
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lbl_Backgroung = new System.Windows.Forms.Label();
            this.lbl_Grid = new System.Windows.Forms.Label();
            this.lbl_ZeroLvl = new System.Windows.Forms.Label();
            this.lbl_Graph = new System.Windows.Forms.Label();
            this.lbl_Cursor1 = new System.Windows.Forms.Label();
            this.lbl_Cursor2 = new System.Windows.Forms.Label();
            this.pan_Background = new System.Windows.Forms.Panel();
            this.pan_Grid = new System.Windows.Forms.Panel();
            this.pan_ZeroLvl = new System.Windows.Forms.Panel();
            this.pan_Graph = new System.Windows.Forms.Panel();
            this.pan_Cursor1 = new System.Windows.Forms.Panel();
            this.pan_Cursor2 = new System.Windows.Forms.Panel();
            this.img_Example = new System.Windows.Forms.PictureBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Example = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_Example)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(101, 215);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Backgroung
            // 
            this.lbl_Backgroung.AutoSize = true;
            this.lbl_Backgroung.Location = new System.Drawing.Point(48, 23);
            this.lbl_Backgroung.Name = "lbl_Backgroung";
            this.lbl_Backgroung.Size = new System.Drawing.Size(30, 13);
            this.lbl_Backgroung.TabIndex = 1;
            this.lbl_Backgroung.Text = "Фон";
            // 
            // lbl_Grid
            // 
            this.lbl_Grid.AutoSize = true;
            this.lbl_Grid.Location = new System.Drawing.Point(48, 52);
            this.lbl_Grid.Name = "lbl_Grid";
            this.lbl_Grid.Size = new System.Drawing.Size(37, 13);
            this.lbl_Grid.TabIndex = 2;
            this.lbl_Grid.Text = "Сетка";
            // 
            // lbl_ZeroLvl
            // 
            this.lbl_ZeroLvl.AutoSize = true;
            this.lbl_ZeroLvl.Location = new System.Drawing.Point(48, 80);
            this.lbl_ZeroLvl.Name = "lbl_ZeroLvl";
            this.lbl_ZeroLvl.Size = new System.Drawing.Size(94, 13);
            this.lbl_ZeroLvl.TabIndex = 3;
            this.lbl_ZeroLvl.Text = "Нулевой уровень";
            // 
            // lbl_Graph
            // 
            this.lbl_Graph.AutoSize = true;
            this.lbl_Graph.Location = new System.Drawing.Point(48, 108);
            this.lbl_Graph.Name = "lbl_Graph";
            this.lbl_Graph.Size = new System.Drawing.Size(45, 13);
            this.lbl_Graph.TabIndex = 4;
            this.lbl_Graph.Text = "График";
            // 
            // lbl_Cursor1
            // 
            this.lbl_Cursor1.AutoSize = true;
            this.lbl_Cursor1.Location = new System.Drawing.Point(48, 136);
            this.lbl_Cursor1.Name = "lbl_Cursor1";
            this.lbl_Cursor1.Size = new System.Drawing.Size(52, 13);
            this.lbl_Cursor1.TabIndex = 5;
            this.lbl_Cursor1.Text = "Курсор 1";
            // 
            // lbl_Cursor2
            // 
            this.lbl_Cursor2.AutoSize = true;
            this.lbl_Cursor2.Location = new System.Drawing.Point(48, 164);
            this.lbl_Cursor2.Name = "lbl_Cursor2";
            this.lbl_Cursor2.Size = new System.Drawing.Size(52, 13);
            this.lbl_Cursor2.TabIndex = 6;
            this.lbl_Cursor2.Text = "Курсор 2";
            // 
            // pan_Background
            // 
            this.pan_Background.Location = new System.Drawing.Point(152, 23);
            this.pan_Background.Name = "pan_Background";
            this.pan_Background.Size = new System.Drawing.Size(24, 22);
            this.pan_Background.TabIndex = 7;
            this.pan_Background.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_Background_MouseDoubleClick);
            // 
            // pan_Grid
            // 
            this.pan_Grid.Location = new System.Drawing.Point(152, 52);
            this.pan_Grid.Name = "pan_Grid";
            this.pan_Grid.Size = new System.Drawing.Size(24, 22);
            this.pan_Grid.TabIndex = 8;
            this.pan_Grid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_Grid_MouseDoubleClick);
            // 
            // pan_ZeroLvl
            // 
            this.pan_ZeroLvl.Location = new System.Drawing.Point(152, 80);
            this.pan_ZeroLvl.Name = "pan_ZeroLvl";
            this.pan_ZeroLvl.Size = new System.Drawing.Size(24, 22);
            this.pan_ZeroLvl.TabIndex = 9;
            this.pan_ZeroLvl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_ZeroLvl_MouseDoubleClick);
            // 
            // pan_Graph
            // 
            this.pan_Graph.Location = new System.Drawing.Point(152, 108);
            this.pan_Graph.Name = "pan_Graph";
            this.pan_Graph.Size = new System.Drawing.Size(24, 22);
            this.pan_Graph.TabIndex = 10;
            this.pan_Graph.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_Graph_MouseDoubleClick);
            // 
            // pan_Cursor1
            // 
            this.pan_Cursor1.Location = new System.Drawing.Point(152, 136);
            this.pan_Cursor1.Name = "pan_Cursor1";
            this.pan_Cursor1.Size = new System.Drawing.Size(24, 22);
            this.pan_Cursor1.TabIndex = 11;
            this.pan_Cursor1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_Cursor1_MouseDoubleClick);
            // 
            // pan_Cursor2
            // 
            this.pan_Cursor2.Location = new System.Drawing.Point(152, 164);
            this.pan_Cursor2.Name = "pan_Cursor2";
            this.pan_Cursor2.Size = new System.Drawing.Size(24, 22);
            this.pan_Cursor2.TabIndex = 12;
            this.pan_Cursor2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pan_Cursor2_MouseDoubleClick);
            // 
            // img_Example
            // 
            this.img_Example.Location = new System.Drawing.Point(226, 52);
            this.img_Example.Name = "img_Example";
            this.img_Example.Size = new System.Drawing.Size(230, 140);
            this.img_Example.TabIndex = 13;
            this.img_Example.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(313, 215);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 14;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Example
            // 
            this.lbl_Example.AutoSize = true;
            this.lbl_Example.Location = new System.Drawing.Point(322, 32);
            this.lbl_Example.Name = "lbl_Example";
            this.lbl_Example.Size = new System.Drawing.Size(47, 13);
            this.lbl_Example.TabIndex = 15;
            this.lbl_Example.Text = "Пример";
            // 
            // UserColorSchemeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 261);
            this.Controls.Add(this.lbl_Example);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.img_Example);
            this.Controls.Add(this.pan_Cursor2);
            this.Controls.Add(this.pan_Cursor1);
            this.Controls.Add(this.pan_Graph);
            this.Controls.Add(this.pan_ZeroLvl);
            this.Controls.Add(this.pan_Grid);
            this.Controls.Add(this.pan_Background);
            this.Controls.Add(this.lbl_Cursor2);
            this.Controls.Add(this.lbl_Cursor1);
            this.Controls.Add(this.lbl_Graph);
            this.Controls.Add(this.lbl_ZeroLvl);
            this.Controls.Add(this.lbl_Grid);
            this.Controls.Add(this.lbl_Backgroung);
            this.Controls.Add(this.btn_OK);
            this.Name = "UserColorSchemeSettings";
            this.Text = "UserColorSchemeSettings";
            ((System.ComponentModel.ISupportInitialize)(this.img_Example)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lbl_Backgroung;
        private System.Windows.Forms.Label lbl_Grid;
        private System.Windows.Forms.Label lbl_ZeroLvl;
        private System.Windows.Forms.Label lbl_Graph;
        private System.Windows.Forms.Label lbl_Cursor1;
        private System.Windows.Forms.Label lbl_Cursor2;
        private System.Windows.Forms.Panel pan_Background;
        private System.Windows.Forms.Panel pan_Grid;
        private System.Windows.Forms.Panel pan_ZeroLvl;
        private System.Windows.Forms.Panel pan_Graph;
        private System.Windows.Forms.Panel pan_Cursor1;
        private System.Windows.Forms.Panel pan_Cursor2;
        private System.Windows.Forms.PictureBox img_Example;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Example;
    }
}