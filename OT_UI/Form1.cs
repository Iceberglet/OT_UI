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

        //Kendall Radios
        private void radio_kendall_min_Checked(object sender, EventArgs e)
        {
            if (!radio_kendall_min.Checked)
                return;
            else Controller.selected_kendall = Controller.sl_Kendall.Min;
        }

        private void radio_kendall_average_Checked(object sender, EventArgs e)
        {
            if (!radio_kendall_average.Checked)
                return;
            else Controller.selected_kendall = Controller.sl_Kendall.Avg;
        }

        private void radio_kendall_weighted_Checked(object sender, EventArgs e)
        {
            if (!radio_kendall_weighted.Checked)
                return;
            else Controller.selected_kendall = Controller.sl_Kendall.Wtd;
        }

        //Filter Radios
        private void radio_filter_none_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_none.Checked)
                return;
            else Controller.selected_filter = Controller.sl_Filter.None;
            //System.Windows.Forms.MessageBox.Show("Filtering! " + Controller.selected_filter);
        }

        private void radio_filter_dominance_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_dominance.Checked)
                return;
            else Controller.selected_filter = Controller.sl_Filter.Domi;
            //System.Windows.Forms.MessageBox.Show("Filtering! " + Controller.selected_filter);
        }

        private void radio_filter_pincer_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_pincer.Checked)
                return;
            else Controller.selected_filter = Controller.sl_Filter.Pncr;
        }

        //Strategy Radios
        private void radio_strategy_0(object sender, EventArgs e)
        {
            if (!radio_strategy_det.Checked)
                return;
            else Controller.selected_strategy = Controller.sl_Strategy.Det1;
        }

        private void radio_strategy_1(object sender, EventArgs e)
        {
            if (!radio_strategy_det2.Checked)
                return;
            else Controller.selected_strategy = Controller.sl_Strategy.Det1;
        }

        private void radio_strategy_2(object sender, EventArgs e)
        {
            if (!radio_strategy_tour.Checked)
                return;
            else Controller.selected_strategy = Controller.sl_Strategy.Tour;
        }

        private void radio_strategy_3(object sender, EventArgs e)
        {
            if (!radio_strategy_kernel.Checked)
                return;
            else Controller.selected_strategy = Controller.sl_Strategy.Kernel;
        }

        //Sampling Meta Control
        private void button_speed_initialize(object sender, EventArgs e)
        {
            Controller.Initialize(this, graph_rank, graph_average);
            //MessageBox.Show("");
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

        private void button_speed_2(object sender, EventArgs e)
        {
            buttonClick(2);
            speed_2.Enabled = false;
        }

        private void button_speed_3(object sender, EventArgs e)
        {
            buttonClick(3);
            speed_3.Enabled = false;
        }

        private void buttonClick(int new_speed)
        {
            Controller.speed = new_speed;
            //MessageBox.Show("" + Controller.speed);
            speed_0.Enabled = true;
            speed_1.Enabled = true;
            speed_2.Enabled = true;
            speed_3.Enabled = true;
        }

        public void callBackPause()
        {
            Controller.speed = 0;
            speed_0.Enabled = false;
            speed_1.Enabled = true;
            speed_2.Enabled = true;
            speed_3.Enabled = true;
        }
    }
}
