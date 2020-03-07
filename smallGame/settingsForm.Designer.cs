namespace smallGame
{
    partial class settingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.but_fon = new System.Windows.Forms.Button();
            this.but_ball = new System.Windows.Forms.Button();
            this.but_platf = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет фона:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цвет шарика:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Цвет платформы:";
            // 
            // but_fon
            // 
            this.but_fon.Location = new System.Drawing.Point(138, 10);
            this.but_fon.Name = "but_fon";
            this.but_fon.Size = new System.Drawing.Size(96, 23);
            this.but_fon.TabIndex = 3;
            this.but_fon.Text = "Выбрать";
            this.but_fon.UseVisualStyleBackColor = true;
            this.but_fon.Click += new System.EventHandler(this.but_fon_Click);
            // 
            // but_ball
            // 
            this.but_ball.Location = new System.Drawing.Point(159, 43);
            this.but_ball.Name = "but_ball";
            this.but_ball.Size = new System.Drawing.Size(94, 23);
            this.but_ball.TabIndex = 4;
            this.but_ball.Text = "Выбрать";
            this.but_ball.UseVisualStyleBackColor = true;
            this.but_ball.Click += new System.EventHandler(this.but_ball_Click);
            // 
            // but_platf
            // 
            this.but_platf.Location = new System.Drawing.Point(200, 76);
            this.but_platf.Name = "but_platf";
            this.but_platf.Size = new System.Drawing.Size(95, 23);
            this.but_platf.TabIndex = 5;
            this.but_platf.Text = "Выбрать";
            this.but_platf.UseVisualStyleBackColor = true;
            this.but_platf.Click += new System.EventHandler(this.but_platf_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(259, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "random";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 109);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.but_platf);
            this.Controls.Add(this.but_ball);
            this.Controls.Add(this.but_fon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "settingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки игры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button but_fon;
        private System.Windows.Forms.Button but_ball;
        private System.Windows.Forms.Button but_platf;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}