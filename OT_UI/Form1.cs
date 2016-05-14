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
        public enum sl_Kendall {Min, Avg, Wtd};
        private sl_Kendall selected_kendall = sl_Kendall.Min;
        public enum sl_Filter { None, Domi, Pncr };
        private sl_Filter selected_filter = sl_Filter.None;
        public enum sl_Strategy { Det1, Det2, InvKen, Kernel };
        private sl_Strategy selected_strategy = sl_Strategy.Det1;

        public int speed; //0-paused, 1-sample, 2-iteration, 3-grand_average

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
            else selected_kendall = sl_Kendall.Min;
        }

        private void radio_kendall_average_Checked(object sender, EventArgs e)
        {
            if (!radio_kendall_average.Checked)
                return;
            else selected_kendall = sl_Kendall.Avg;
        }

        private void radio_kendall_weighted_Checked(object sender, EventArgs e)
        {
            if (!radio_kendall_weighted.Checked)
                return;
            else selected_kendall = sl_Kendall.Wtd;
        }

        //Filter Radios
        private void radio_filter_none_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_none.Checked)
                return;
            else selected_filter = sl_Filter.None;
        }

        private void radio_filter_dominance_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_dominance.Checked)
                return;
            else selected_filter = sl_Filter.Domi;
        }

        private void radio_filter_pincer_Checked(object sender, EventArgs e)
        {
            if (!radio_filter_pincer.Checked)
                return;
            else selected_filter = sl_Filter.Pncr;
        }

        //Strategy Radios
        private void radio_strategy_0(object sender, EventArgs e)
        {
            if (!radio_strategy_det.Checked)
                return;
            else selected_strategy = sl_Strategy.Det1;
        }

        private void radio_strategy_1(object sender, EventArgs e)
        {
            if (!radio_strategy_det2.Checked)
                return;
            else selected_strategy = sl_Strategy.Det1;
        }

        private void radio_strategy_2(object sender, EventArgs e)
        {
            if (!radio_strategy_inv.Checked)
                return;
            else selected_strategy = sl_Strategy.InvKen;
        }

        private void radio_strategy_3(object sender, EventArgs e)
        {
            if (!radio_strategy_kernel.Checked)
                return;
            else selected_strategy = sl_Strategy.Kernel;
        }

        //Sampling Meta Control
        private void button_speed_initialize(object sender, EventArgs e)
        {

        }

        private void button_speed_0(object sender, EventArgs e)
        {
            buttonClick(0);
            speed_0.Enabled = false;
        }

        private void button_speed_1(object sender, EventArgs e)
        {
            buttonClick(1);
            speed_1.Enabled = false;
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
            speed = new_speed;
            speed_0.Enabled = true;
            speed_1.Enabled = true;
            speed_2.Enabled = true;
            speed_3.Enabled = true;
        }
    }
}
