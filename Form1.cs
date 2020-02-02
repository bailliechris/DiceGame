using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using DiceGame.Properties;

namespace DiceGame
{
    public partial class Form1 : Form
    {
        //Set up variable
        //List<SplayerDetails> players = new List<SplayerDetails>() { SplayerDetails() };
        //       private readonly static Random random = new Random();

        public SplayerDetails player1 = new SplayerDetails();
        public SplayerDetails player2 = new SplayerDetails();


        public Form1()
        {
            InitializeComponent();
        }

        public void LoadNames(string name1, string name2)
        {
            player1.name = name1;
            player2.name = name2;
        }

     /*   private int Scoring(SplayerDetails player)
        {

            for (int i = 0; i < 5; i++)
            {
                int r1 = random.Next(1, 6);
                int r2 = random.Next(1, 6);

                //textBox1.AppendText(player1.name + " Round " + (i + 1).ToString() + " " + r1.ToString() + Environment.NewLine);
                //textBox1.AppendText(player1.name + " Round " + (i + 1).ToString() + " " + r2.ToString() + Environment.NewLine);

                player.score += (r1 + r2);

                if (r1 == r2)
                {
                    int r3 = random.Next(1, 6);
                    player.score += r3;
                }

                if ((r1 + r2) % 2 == 0)
                {
                    player.score += 10;
                }
                else
                {
                    player.score -= 5;
                    if (player.score < 0)
                    {
                        player.score = 0;
                    }
                }

                //textBox1.AppendText(player1.name + " Score " + player1.score.ToString() + Environment.NewLine);
            }
            return player.score;
        }

    */

        private void Button1_Click(object sender, EventArgs e)
        {
            player1.CreateScore();
            textBox1.AppendText(player1.name + " Score " + player1.score.ToString() + Environment.NewLine);
            player2.CreateScore();
            textBox1.AppendText(player2.name + " Score " + player2.score.ToString() + Environment.NewLine);

            if (player1.score > player2.score)
            {
                textBox1.AppendText(player1.name + " Wins!" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText(player2.name + " Wins!" + Environment.NewLine);
            }

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            //Create blank list of scores from JSON file
            //List<SplayerDetails> _data = new List<SplayerDetails>();
            List<SplayerDetails> loadedOldScores = new List<SplayerDetails>();


           // string path = System.Directory.GetCurrentDirectory;
            string scoresFile = "c:/code/diceGameScores.txt";

            //C:\Code\diceGameScores.txt

            try
            {
                // deserialize JSON directly from a file
                using (System.IO.StreamReader file = System.IO.File.OpenText(@scoresFile))
                {
                    string json = file.ReadToEnd();
                    if (json != "")
                    {
                        loadedOldScores = JsonConvert.DeserializeObject<List<SplayerDetails>>(json);
                    }
                }

                //_data.Add(loadedOldScores);
                textBox1.AppendText("Loaded: " + Environment.NewLine);
            }
            catch
            {
                textBox1.AppendText("Failed to Load File." + Environment.NewLine);

            }

            //Add latest scores
            loadedOldScores.Add(player1);
            loadedOldScores.Add(player2);
            
            //Add Formatting.Indented to have it indent
            string WriteJson = JsonConvert.SerializeObject(loadedOldScores.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@scoresFile, WriteJson);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            List<SplayerDetails> loadedScores = new List<SplayerDetails>();

            string scoresFile = "c:/code/diceGameScores.txt";

            try
            {
                // deserialize JSON directly from a file
                using (System.IO.StreamReader file = System.IO.File.OpenText(@scoresFile))
                {
                    string json = file.ReadToEnd();
                    if (json != "")
                    {
                        loadedScores = JsonConvert.DeserializeObject<List<SplayerDetails>>(json);
                    }
                }

                //_data.Add(loadedOldScores);
                textBox1.AppendText("Loaded: " + Environment.NewLine);
            }
            catch
            {
                textBox1.AppendText("Failed to Load File." + Environment.NewLine);

            }

            List<SplayerDetails> SortedList = loadedScores.OrderByDescending(o => o.score).ToList();

            textBox1.AppendText("=== High Scores ===" + Environment.NewLine);

            for(int i = 0; i<5; i++)
            {
                textBox1.AppendText((i+1).ToString() + " " + SortedList[i].name + " : " + SortedList[i].score.ToString() + Environment.NewLine);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
