namespace ResumeCreator
{
    partial class Ready
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ready));
            this.panel1 = new System.Windows.Forms.Panel();
            this.resume = new System.Windows.Forms.PictureBox();
            this.w = new System.Windows.Forms.NumericUpDown();
            this.h = new System.Windows.Forms.NumericUpDown();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.loadPhoto = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.PictureBox();
            this.startFromBegin = new System.Windows.Forms.PictureBox();
            this.back = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFromBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.resume);
            this.panel1.Location = new System.Drawing.Point(82, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 514);
            this.panel1.TabIndex = 1;
            // 
            // resume
            // 
            this.resume.Location = new System.Drawing.Point(0, 0);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(795, 1121);
            this.resume.TabIndex = 0;
            this.resume.TabStop = false;
            // 
            // w
            // 
            this.w.Location = new System.Drawing.Point(911, 175);
            this.w.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.w.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(222, 20);
            this.w.TabIndex = 71;
            this.w.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w.Value = new decimal(new int[] {
            286,
            0,
            0,
            0});
            this.w.ValueChanged += new System.EventHandler(this.w_ValueChanged);
            // 
            // h
            // 
            this.h.Location = new System.Drawing.Point(911, 265);
            this.h.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.h.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(222, 20);
            this.h.TabIndex = 72;
            this.h.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.h.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.h.ValueChanged += new System.EventHandler(this.h_ValueChanged);
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(911, 360);
            this.x.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(222, 20);
            this.x.TabIndex = 73;
            this.x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x.ValueChanged += new System.EventHandler(this.x_ValueChanged);
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(911, 451);
            this.y.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(222, 20);
            this.y.TabIndex = 74;
            this.y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.y.ValueChanged += new System.EventHandler(this.y_ValueChanged);
            // 
            // loadPhoto
            // 
            this.loadPhoto.BackColor = System.Drawing.Color.Transparent;
            this.loadPhoto.Image = global::ResumeCreator.Properties.Resources.loadPhoto;
            this.loadPhoto.Location = new System.Drawing.Point(355, 642);
            this.loadPhoto.Name = "loadPhoto";
            this.loadPhoto.Size = new System.Drawing.Size(238, 62);
            this.loadPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadPhoto.TabIndex = 75;
            this.loadPhoto.TabStop = false;
            this.loadPhoto.Click += new System.EventHandler(this.loadPhoto_Click);
            this.loadPhoto.MouseLeave += new System.EventHandler(this.loadPhoto_MouseLeave);
            this.loadPhoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.loadPhoto_MouseMove);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.Image = global::ResumeCreator.Properties.Resources.save;
            this.save.Location = new System.Drawing.Point(960, 624);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(128, 62);
            this.save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.save.TabIndex = 69;
            this.save.TabStop = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            this.save.MouseLeave += new System.EventHandler(this.save_MouseLeave);
            this.save.MouseMove += new System.Windows.Forms.MouseEventHandler(this.save_MouseMove);
            // 
            // startFromBegin
            // 
            this.startFromBegin.BackColor = System.Drawing.Color.Transparent;
            this.startFromBegin.Image = global::ResumeCreator.Properties.Resources.startFromBegin;
            this.startFromBegin.Location = new System.Drawing.Point(960, 563);
            this.startFromBegin.Name = "startFromBegin";
            this.startFromBegin.Size = new System.Drawing.Size(128, 62);
            this.startFromBegin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.startFromBegin.TabIndex = 68;
            this.startFromBegin.TabStop = false;
            this.startFromBegin.Click += new System.EventHandler(this.startFromBegin_Click);
            this.startFromBegin.MouseLeave += new System.EventHandler(this.startFromBegin_MouseLeave);
            this.startFromBegin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.startFromBegin_MouseMove);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(959, 501);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(128, 62);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.back.TabIndex = 66;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseLeave += new System.EventHandler(this.back_MouseLeave);
            this.back.MouseMove += new System.Windows.Forms.MouseEventHandler(this.back_MouseMove);
            // 
            // background
            // 
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Image = ((System.Drawing.Image)(resources.GetObject("background.Image")));
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1205, 748);
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // Ready
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 748);
            this.Controls.Add(this.loadPhoto);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.Controls.Add(this.h);
            this.Controls.Add(this.w);
            this.Controls.Add(this.save);
            this.Controls.Add(this.startFromBegin);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.background);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1221, 787);
            this.MinimumSize = new System.Drawing.Size(1221, 787);
            this.Name = "Ready";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResumeCreator - Ваше резюме";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ready_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFromBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox resume;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.PictureBox startFromBegin;
        private System.Windows.Forms.PictureBox save;
        private System.Windows.Forms.NumericUpDown w;
        private System.Windows.Forms.NumericUpDown h;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.PictureBox loadPhoto;
    }
}