namespace OT_UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.group_sampling = new System.Windows.Forms.GroupBox();
            this.group_kendall = new System.Windows.Forms.GroupBox();
            this.radio_kendall_min = new System.Windows.Forms.RadioButton();
            this.radio_kendall_average = new System.Windows.Forms.RadioButton();
            this.radio_kendall_weighted = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.initialize = new System.Windows.Forms.Button();
            this.speed_0 = new System.Windows.Forms.Button();
            this.speed_1 = new System.Windows.Forms.Button();
            this.speed_2 = new System.Windows.Forms.Button();
            this.speed_3 = new System.Windows.Forms.Button();
            this.group_filter = new System.Windows.Forms.GroupBox();
            this.radio_filter_pincer = new System.Windows.Forms.RadioButton();
            this.radio_filter_dominance = new System.Windows.Forms.RadioButton();
            this.radio_filter_none = new System.Windows.Forms.RadioButton();
            this.group_proba = new System.Windows.Forms.GroupBox();
            this.radio_strategy_inv = new System.Windows.Forms.RadioButton();
            this.radio_strategy_det2 = new System.Windows.Forms.RadioButton();
            this.radio_strategy_det = new System.Windows.Forms.RadioButton();
            this.radio_strategy_kernel = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.group_sampling.SuspendLayout();
            this.group_kendall.SuspendLayout();
            this.group_filter.SuspendLayout();
            this.group_proba.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.group_proba);
            this.splitContainer1.Panel2.Controls.Add(this.group_filter);
            this.splitContainer1.Panel2.Controls.Add(this.group_kendall);
            this.splitContainer1.Panel2.Controls.Add(this.group_sampling);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1258, 768);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(1258, 600);
            this.splitContainer2.SplitterDistance = 629;
            this.splitContainer2.TabIndex = 0;
            // 
            // group_sampling
            // 
            this.group_sampling.Controls.Add(this.speed_3);
            this.group_sampling.Controls.Add(this.speed_2);
            this.group_sampling.Controls.Add(this.speed_1);
            this.group_sampling.Controls.Add(this.speed_0);
            this.group_sampling.Controls.Add(this.initialize);
            this.group_sampling.Controls.Add(this.comboBox1);
            this.group_sampling.Location = new System.Drawing.Point(3, 3);
            this.group_sampling.Name = "group_sampling";
            this.group_sampling.Size = new System.Drawing.Size(254, 158);
            this.group_sampling.TabIndex = 0;
            this.group_sampling.TabStop = false;
            this.group_sampling.Text = "Sampling Control";
            this.group_sampling.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // group_kendall
            // 
            this.group_kendall.Controls.Add(this.radio_kendall_weighted);
            this.group_kendall.Controls.Add(this.radio_kendall_average);
            this.group_kendall.Controls.Add(this.radio_kendall_min);
            this.group_kendall.Location = new System.Drawing.Point(263, 3);
            this.group_kendall.Name = "group_kendall";
            this.group_kendall.Size = new System.Drawing.Size(124, 158);
            this.group_kendall.TabIndex = 1;
            this.group_kendall.TabStop = false;
            this.group_kendall.Text = "Kendall Method";
            // 
            // radio_kendall_min
            // 
            this.radio_kendall_min.AutoSize = true;
            this.radio_kendall_min.Checked = true;
            this.radio_kendall_min.Location = new System.Drawing.Point(7, 20);
            this.radio_kendall_min.Name = "radio_kendall_min";
            this.radio_kendall_min.Size = new System.Drawing.Size(80, 17);
            this.radio_kendall_min.TabIndex = 0;
            this.radio_kendall_min.TabStop = true;
            this.radio_kendall_min.Text = "Min Kendall";
            this.radio_kendall_min.UseVisualStyleBackColor = true;
            this.radio_kendall_min.CheckedChanged += new System.EventHandler(this.radio_kendall_min_Checked);
            // 
            // radio_kendall_average
            // 
            this.radio_kendall_average.AutoSize = true;
            this.radio_kendall_average.Location = new System.Drawing.Point(7, 43);
            this.radio_kendall_average.Name = "radio_kendall_average";
            this.radio_kendall_average.Size = new System.Drawing.Size(102, 17);
            this.radio_kendall_average.TabIndex = 1;
            this.radio_kendall_average.Text = "Mixed - Average";
            this.radio_kendall_average.UseVisualStyleBackColor = true;
            this.radio_kendall_average.CheckedChanged += new System.EventHandler(this.radio_kendall_average_Checked);
            // 
            // radio_kendall_weighted
            // 
            this.radio_kendall_weighted.AutoSize = true;
            this.radio_kendall_weighted.Location = new System.Drawing.Point(7, 66);
            this.radio_kendall_weighted.Name = "radio_kendall_weighted";
            this.radio_kendall_weighted.Size = new System.Drawing.Size(108, 17);
            this.radio_kendall_weighted.TabIndex = 2;
            this.radio_kendall_weighted.Text = "Mixed - Weighted";
            this.radio_kendall_weighted.UseVisualStyleBackColor = true;
            this.radio_kendall_weighted.CheckedChanged += new System.EventHandler(this.radio_kendall_weighted_Checked);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // initialize
            // 
            this.initialize.Location = new System.Drawing.Point(138, 20);
            this.initialize.Name = "initialize";
            this.initialize.Size = new System.Drawing.Size(75, 23);
            this.initialize.TabIndex = 1;
            this.initialize.Text = "Initialize";
            this.initialize.UseVisualStyleBackColor = true;
            // 
            // speed_0
            // 
            this.speed_0.Enabled = false;
            this.speed_0.Image = ((System.Drawing.Image)(resources.GetObject("speed_0.Image")));
            this.speed_0.Location = new System.Drawing.Point(10, 48);
            this.speed_0.Name = "speed_0";
            this.speed_0.Size = new System.Drawing.Size(40, 40);
            this.speed_0.TabIndex = 2;
            this.speed_0.UseVisualStyleBackColor = true;
            this.speed_0.Click += new System.EventHandler(this.button_speed_0);
            // 
            // speed_1
            // 
            this.speed_1.Image = ((System.Drawing.Image)(resources.GetObject("speed_1.Image")));
            this.speed_1.Location = new System.Drawing.Point(56, 48);
            this.speed_1.Name = "speed_1";
            this.speed_1.Size = new System.Drawing.Size(40, 40);
            this.speed_1.TabIndex = 3;
            this.speed_1.UseVisualStyleBackColor = true;
            this.speed_1.Click += new System.EventHandler(this.button_speed_1);
            // 
            // speed_2
            // 
            this.speed_2.Image = ((System.Drawing.Image)(resources.GetObject("speed_2.Image")));
            this.speed_2.Location = new System.Drawing.Point(102, 48);
            this.speed_2.Name = "speed_2";
            this.speed_2.Size = new System.Drawing.Size(40, 40);
            this.speed_2.TabIndex = 4;
            this.speed_2.UseVisualStyleBackColor = true;
            this.speed_2.Click += new System.EventHandler(this.button_speed_2);
            // 
            // speed_3
            // 
            this.speed_3.Image = ((System.Drawing.Image)(resources.GetObject("speed_3.Image")));
            this.speed_3.Location = new System.Drawing.Point(148, 49);
            this.speed_3.Name = "speed_3";
            this.speed_3.Size = new System.Drawing.Size(40, 40);
            this.speed_3.TabIndex = 5;
            this.speed_3.UseVisualStyleBackColor = true;
            this.speed_3.Click += new System.EventHandler(this.button_speed_3);
            // 
            // group_filter
            // 
            this.group_filter.Controls.Add(this.radio_filter_pincer);
            this.group_filter.Controls.Add(this.radio_filter_dominance);
            this.group_filter.Controls.Add(this.radio_filter_none);
            this.group_filter.Location = new System.Drawing.Point(393, 3);
            this.group_filter.Name = "group_filter";
            this.group_filter.Size = new System.Drawing.Size(148, 158);
            this.group_filter.TabIndex = 3;
            this.group_filter.TabStop = false;
            this.group_filter.Text = "Filter Method";
            // 
            // radio_filter_pincer
            // 
            this.radio_filter_pincer.AutoSize = true;
            this.radio_filter_pincer.Location = new System.Drawing.Point(7, 66);
            this.radio_filter_pincer.Name = "radio_filter_pincer";
            this.radio_filter_pincer.Size = new System.Drawing.Size(55, 17);
            this.radio_filter_pincer.TabIndex = 2;
            this.radio_filter_pincer.Text = "Pincer";
            this.radio_filter_pincer.UseVisualStyleBackColor = true;
            // 
            // radio_filter_dominance
            // 
            this.radio_filter_dominance.AutoSize = true;
            this.radio_filter_dominance.Location = new System.Drawing.Point(7, 43);
            this.radio_filter_dominance.Name = "radio_filter_dominance";
            this.radio_filter_dominance.Size = new System.Drawing.Size(79, 17);
            this.radio_filter_dominance.TabIndex = 1;
            this.radio_filter_dominance.Text = "Dominance";
            this.radio_filter_dominance.UseVisualStyleBackColor = true;
            // 
            // radio_filter_none
            // 
            this.radio_filter_none.AutoSize = true;
            this.radio_filter_none.Checked = true;
            this.radio_filter_none.Location = new System.Drawing.Point(7, 20);
            this.radio_filter_none.Name = "radio_filter_none";
            this.radio_filter_none.Size = new System.Drawing.Size(51, 17);
            this.radio_filter_none.TabIndex = 0;
            this.radio_filter_none.TabStop = true;
            this.radio_filter_none.Text = "None";
            this.radio_filter_none.UseVisualStyleBackColor = true;
            // 
            // group_proba
            // 
            this.group_proba.Controls.Add(this.radio_strategy_kernel);
            this.group_proba.Controls.Add(this.radio_strategy_inv);
            this.group_proba.Controls.Add(this.radio_strategy_det2);
            this.group_proba.Controls.Add(this.radio_strategy_det);
            this.group_proba.Location = new System.Drawing.Point(547, 3);
            this.group_proba.Name = "group_proba";
            this.group_proba.Size = new System.Drawing.Size(164, 158);
            this.group_proba.TabIndex = 4;
            this.group_proba.TabStop = false;
            this.group_proba.Text = "Sampling Strategy";
            // 
            // radio_strategy_inv
            // 
            this.radio_strategy_inv.AutoSize = true;
            this.radio_strategy_inv.Location = new System.Drawing.Point(7, 66);
            this.radio_strategy_inv.Name = "radio_strategy_inv";
            this.radio_strategy_inv.Size = new System.Drawing.Size(98, 17);
            this.radio_strategy_inv.TabIndex = 2;
            this.radio_strategy_inv.Text = "Inverse Kendall";
            this.radio_strategy_inv.UseVisualStyleBackColor = true;
            this.radio_strategy_inv.Click += new System.EventHandler(this.radio_strategy_2);
            // 
            // radio_strategy_det2
            // 
            this.radio_strategy_det2.AutoSize = true;
            this.radio_strategy_det2.Location = new System.Drawing.Point(7, 43);
            this.radio_strategy_det2.Name = "radio_strategy_det2";
            this.radio_strategy_det2.Size = new System.Drawing.Size(128, 17);
            this.radio_strategy_det2.TabIndex = 1;
            this.radio_strategy_det2.Text = "Deterministic Random";
            this.radio_strategy_det2.UseVisualStyleBackColor = true;
            this.radio_strategy_det2.Click += new System.EventHandler(this.radio_strategy_1);
            // 
            // radio_strategy_det
            // 
            this.radio_strategy_det.AutoSize = true;
            this.radio_strategy_det.Checked = true;
            this.radio_strategy_det.Location = new System.Drawing.Point(7, 20);
            this.radio_strategy_det.Name = "radio_strategy_det";
            this.radio_strategy_det.Size = new System.Drawing.Size(123, 17);
            this.radio_strategy_det.TabIndex = 0;
            this.radio_strategy_det.TabStop = true;
            this.radio_strategy_det.Text = "Deterministic Median";
            this.radio_strategy_det.UseVisualStyleBackColor = true;
            this.radio_strategy_det.Click += new System.EventHandler(this.radio_strategy_0);
            // 
            // radio_strategy_kernel
            // 
            this.radio_strategy_kernel.AutoSize = true;
            this.radio_strategy_kernel.Location = new System.Drawing.Point(7, 89);
            this.radio_strategy_kernel.Name = "radio_strategy_kernel";
            this.radio_strategy_kernel.Size = new System.Drawing.Size(96, 17);
            this.radio_strategy_kernel.TabIndex = 3;
            this.radio_strategy_kernel.Text = "Mallows Kernel";
            this.radio_strategy_kernel.UseVisualStyleBackColor = true;
            this.radio_strategy_kernel.Click += new System.EventHandler(this.radio_strategy_3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 768);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.group_sampling.ResumeLayout(false);
            this.group_kendall.ResumeLayout(false);
            this.group_kendall.PerformLayout();
            this.group_filter.ResumeLayout(false);
            this.group_filter.PerformLayout();
            this.group_proba.ResumeLayout(false);
            this.group_proba.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox group_sampling;
        private System.Windows.Forms.GroupBox group_kendall;
        private System.Windows.Forms.RadioButton radio_kendall_min;
        private System.Windows.Forms.RadioButton radio_kendall_average;
        private System.Windows.Forms.RadioButton radio_kendall_weighted;
        private System.Windows.Forms.Button initialize;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button speed_3;
        private System.Windows.Forms.Button speed_2;
        private System.Windows.Forms.Button speed_1;
        private System.Windows.Forms.Button speed_0;
        private System.Windows.Forms.GroupBox group_filter;
        private System.Windows.Forms.RadioButton radio_filter_pincer;
        private System.Windows.Forms.RadioButton radio_filter_dominance;
        private System.Windows.Forms.RadioButton radio_filter_none;
        private System.Windows.Forms.GroupBox group_proba;
        private System.Windows.Forms.RadioButton radio_strategy_inv;
        private System.Windows.Forms.RadioButton radio_strategy_det2;
        private System.Windows.Forms.RadioButton radio_strategy_det;
        private System.Windows.Forms.RadioButton radio_strategy_kernel;
    }
}

