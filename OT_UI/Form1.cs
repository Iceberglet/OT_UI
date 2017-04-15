using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OT_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //radio_kendall_min.Checked = true;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Sampling Meta Control
        private void button_speed_initialize(object sender, EventArgs e)
        {
            Controller.Initialize(this, graph_rank);
        }

        /*
        private void bw1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(20);
                    Controller.Iterate();
                }
            }
        }
        private void bw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }*/


        private void button_speed_0(object sender, EventArgs e)
        {
            buttonClick(0);
            speed_0.Enabled = false;
        }

        private void button_speed_1(object sender, EventArgs e)
        {
            /*
            buttonClick(1);
            speed_1.Enabled = false;*/
            Controller.Iterate();
        }
        
        private void buttonClick(int new_speed)
        {
            Controller.speed = new_speed;
            //MessageBox.Show("" + Controller.speed);
            speed_0.Enabled = true;
            speed_1.Enabled = true;
        }

        public void callBackPause()
        {
            Controller.speed = 0;
            speed_0.Enabled = false;
            speed_1.Enabled = true;
        }

        private void graph_rank_Click(object sender, EventArgs e)
        {

        }
    }
}
