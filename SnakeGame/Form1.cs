using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int score = 0;        
        int speed = 5;         
        string direction = "Right"; 
        bool isBomb = false;   
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("snake.png"))
            {
                pbSnake.Image = Image.FromFile("snake.png");
                pbSnake.BackColor = Color.Transparent;
            }

            SpawnNewObject();
        }

        private void SpawnNewObject()
        {
            int maxX = this.ClientSize.Width - pbTarget.Width;
            int maxY = this.ClientSize.Height - pbTarget.Height;
            pbTarget.Location = new Point(rnd.Next(10, maxX), rnd.Next(35, maxY));

            int chance = rnd.Next(1, 101);
            if (chance <= 30)
            {
                isBomb = true;
                if (File.Exists("bomb.png"))
                {
                    pbTarget.Image = Image.FromFile("bomb.png");
                    pbTarget.BackColor = Color.Transparent;
                }
                else
                {
                    pbTarget.Image = null;
                    pbTarget.BackColor = Color.Black; 
                }
            }
            else
            {
                isBomb = false;
                if (File.Exists("apple.png"))
                {
                    pbTarget.Image = Image.FromFile("apple.png");
                    pbTarget.BackColor = Color.Transparent;
                }
                else
                {
                    pbTarget.Image = null;
                    pbTarget.BackColor = Color.Red; 
                }
            }

            timerSpawn.Stop();
            timerSpawn.Start();
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            if (direction == "Right") pbSnake.Left += speed;
            if (direction == "Left") pbSnake.Left -= speed;
            if (direction == "Up") pbSnake.Top -= speed;
            if (direction == "Down") pbSnake.Top += speed;

            if (pbSnake.Left > this.ClientSize.Width) pbSnake.Left = -pbSnake.Width;
            if (pbSnake.Right < 0) pbSnake.Left = this.ClientSize.Width;
            if (pbSnake.Top > this.ClientSize.Height) pbSnake.Top = -pbSnake.Height;
            if (pbSnake.Bottom < 0) pbSnake.Top = this.ClientSize.Height;

            if (pbSnake.Bounds.IntersectsWith(pbTarget.Bounds))
            {
                if (isBomb)
                {
                    GameOver();
                }
                else
                {
                    score += 10;
                    lblScore.Text = "Xal: " + score;
                    speed += 1; 
                    SpawnNewObject();
                }
            }
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            if (!isGameOver)
            {
                SpawnNewObject();
            }
        }

        private void GameOver()
        {
            isGameOver = true;
            timerMove.Stop();
            timerSpawn.Stop();

            MessageBox.Show("Bomba partladı! Oyun bitdi.\nTopladığınız xal: " + score + "\n\nYenidən başlamaq üçün ENTER düyməsini sıxın.", "Oyun Bitdi");
        }

        private void RestartGame()
        {
            score = 0;
            speed = 5;
            direction = "Right";
            isGameOver = false;
            lblScore.Text = "Xal: 0";
            pbSnake.Location = new Point(250, 200);

            SpawnNewObject();
            timerMove.Start();
            timerSpawn.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) direction = "Up";
            if (e.KeyCode == Keys.Down) direction = "Down";
            if (e.KeyCode == Keys.Left) direction = "Left";
            if (e.KeyCode == Keys.Right) direction = "Right";

            if (e.KeyCode == Keys.Enter)
            {
                RestartGame();
            }
        }
    }
}