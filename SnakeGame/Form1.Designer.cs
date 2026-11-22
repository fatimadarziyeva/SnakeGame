namespace SnakeGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.PictureBox pbSnake;
        private System.Windows.Forms.PictureBox pbTarget;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer timerMove;
        private System.Windows.Forms.Timer timerSpawn;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbSnake = new System.Windows.Forms.PictureBox();
            this.pbTarget = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.timerMove = new System.Windows.Forms.Timer(this.components);
            this.timerSpawn = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).BeginInit();
            this.SuspendLayout();
            
            this.pbSnake.BackColor = System.Drawing.Color.Green;
            this.pbSnake.Location = new System.Drawing.Point(250, 200);
            this.pbSnake.Name = "pbSnake";
            this.pbSnake.Size = new System.Drawing.Size(45, 45);
            this.pbSnake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSnake.TabIndex = 0;
            this.pbSnake.TabStop = false;
            
            this.pbTarget.BackColor = System.Drawing.Color.Red;
            this.pbTarget.Location = new System.Drawing.Point(100, 100);
            this.pbTarget.Name = "pbTarget";
            this.pbTarget.Size = new System.Drawing.Size(40, 40);
            this.pbTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTarget.TabIndex = 1;
            this.pbTarget.TabStop = false;
             
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(12, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(65, 21);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Xal: 0";
            
            this.timerMove.Enabled = true;
            this.timerMove.Interval = 50;
            this.timerMove.Tick += new System.EventHandler(this.timerMove_Tick);
            
            this.timerSpawn.Enabled = true;
            this.timerSpawn.Interval = 5000; 
            this.timerSpawn.Tick += new System.EventHandler(this.timerSpawn_Tick);
            
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbTarget);
            this.Controls.Add(this.pbSnake);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake and apple";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}