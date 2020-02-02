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
    public partial class Form2 : Form
    {
        public string player1 = "";
        public string player2 = "";


        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<UserDetails> loadedPlayers = new List<UserDetails>();
            bool login1 = false;
            bool login2 = false;

            var file = Resources.userList1;

            try
            {
                string json = file;//.ReadToEnd();
                if (json != "")
                {
                    loadedPlayers = JsonConvert.DeserializeObject<List<UserDetails>>(json);
                }

                //_data.Add(loadedOldScores);
                textBox5.AppendText("Loaded Users.");
                
            }
            catch
            {
                textBox5.AppendText("Failed to Load File.");

            }

            for(int i=0; i<loadedPlayers.Count; i++)
            {
                if (loadedPlayers[i].name == textBox1.Text)
                {
                    if (loadedPlayers[i].pw == textBox2.Text)
                    {
                        login1 = true;
                        player1 = loadedPlayers[i].name;
                     //   MessageBox.Show("Player 1 Ok");
                    }
                }
                if (loadedPlayers[i].name == textBox3.Text)
                {
                    if (loadedPlayers[i].pw == textBox4.Text)
                    {
                        login2 = true;
                        player2 = loadedPlayers[i].name;
                   //     MessageBox.Show("Player 2 Ok");
                    }
                }
            }

            if (login1 == true && login2 == true)
            {
                textBox5.AppendText("Logging In");
                Form1 frm1 = new Form1();
                frm1.LoadNames(player1, player2);
                frm1.ShowDialog();
                this.Close();
                
            }
            else
            {
                textBox5.AppendText("Failed to Log In.");
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
