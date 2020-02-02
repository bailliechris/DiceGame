using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form2 main = new Form2();
            Application.Run(main);
        }
    }
    public class SplayerDetails
    {
        private readonly static Random random = new Random();
        public string name { get; set; }
        public int score { get; set; }

        public SplayerDetails()
        {
            this.name = "Player";
            this.score = 0;
        }

        public SplayerDetails(string n)
        {
            this.name = n;
            this.score = 0;
        }

        public int CreateScore()
        {
            for (int i = 0; i < 5; i++)
            {
                int r1 = random.Next(1, 6);
                int r2 = random.Next(1, 6);

                //textBox1.AppendText(player1.name + " Round " + (i + 1).ToString() + " " + r1.ToString() + Environment.NewLine);
                //textBox1.AppendText(player1.name + " Round " + (i + 1).ToString() + " " + r2.ToString() + Environment.NewLine);

                score += (r1 + r2);

                if (r1 == r2)
                {
                    int r3 = random.Next(1, 6);
                    score += r3;
                }

                if ((r1 + r2) % 2 == 0)
                {
                    score += 10;
                }
                else
                {
                    score -= 5;
                    if (score < 0)
                    {
                        score = 0;
                    }
                }

                //textBox1.AppendText(player1.name + " Score " + player1.score.ToString() + Environment.NewLine);
            }

            return score;
        }
    }

    public class UserDetails
    {
        public string name { get; set; }
        public string pw { get; set; }
    }
}
