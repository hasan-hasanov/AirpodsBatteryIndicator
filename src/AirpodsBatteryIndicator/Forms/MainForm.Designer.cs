
namespace AirpodsBatteryIndicator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelRightBud = new System.Windows.Forms.Button();
            this.labelCase = new System.Windows.Forms.Button();
            this.labelLeftBud = new System.Windows.Forms.Button();
            this.airpodsBatteryCheckTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 208);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(128, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 208);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(261, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(190, 208);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // labelRightBud
            // 
            this.labelRightBud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRightBud.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.labelRightBud.FlatAppearance.BorderSize = 0;
            this.labelRightBud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.labelRightBud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.labelRightBud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRightBud.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRightBud.Location = new System.Drawing.Point(124, 233);
            this.labelRightBud.Name = "labelRightBud";
            this.labelRightBud.Size = new System.Drawing.Size(110, 29);
            this.labelRightBud.TabIndex = 4;
            this.labelRightBud.Text = "Connecting...";
            this.labelRightBud.UseVisualStyleBackColor = true;
            // 
            // labelCase
            // 
            this.labelCase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCase.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.labelCase.FlatAppearance.BorderSize = 0;
            this.labelCase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.labelCase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.labelCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCase.Location = new System.Drawing.Point(261, 233);
            this.labelCase.Name = "labelCase";
            this.labelCase.Size = new System.Drawing.Size(187, 29);
            this.labelCase.TabIndex = 5;
            this.labelCase.Text = "Connecting...";
            this.labelCase.UseVisualStyleBackColor = true;
            // 
            // labelLeftBud
            // 
            this.labelLeftBud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLeftBud.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.labelLeftBud.FlatAppearance.BorderSize = 0;
            this.labelLeftBud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.labelLeftBud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.labelLeftBud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLeftBud.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLeftBud.Location = new System.Drawing.Point(8, 233);
            this.labelLeftBud.Name = "labelLeftBud";
            this.labelLeftBud.Size = new System.Drawing.Size(110, 29);
            this.labelLeftBud.TabIndex = 6;
            this.labelLeftBud.Text = "Connecting...";
            this.labelLeftBud.UseVisualStyleBackColor = true;
            // 
            // airpodsBatteryCheckTimer
            // 
            this.airpodsBatteryCheckTimer.Enabled = true;
            this.airpodsBatteryCheckTimer.Interval = 10;
            this.airpodsBatteryCheckTimer.Tick += new System.EventHandler(this.AirpodsBatteryCheckTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(463, 274);
            this.Controls.Add(this.labelLeftBud);
            this.Controls.Add(this.labelCase);
            this.Controls.Add(this.labelRightBud);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Airpods Battery Status";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button labelRightBud;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button labelLeftBud;
        private System.Windows.Forms.Button labelCase;
        private System.Windows.Forms.Timer airpodsBatteryCheckTimer;
    }
}

