using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordBot;

namespace TGWBot
{
    public partial class Form1 : Form
    {
        private bool botRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (botRunning == true)
            {
                BotProgram foo = new BotProgram();
                foo.GenerateWeather();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (botRunning == false)
            {
                botRunning = true;
                Thread botThread = new Thread(BotProgram.StartBot) { IsBackground = true };
                botThread.Start();
                checkBox1.Checked = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            send = textBox1.Text;
        }

        string send;

        private void button3_Click(object sender, EventArgs e)
        {
            if(botRunning == true)
            {
            BotProgram foo = new BotProgram();
            foo.MessageWriteAsync(send);
            }
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
