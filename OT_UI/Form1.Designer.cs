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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.graph_rank = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graph_average = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.group_proba = new System.Windows.Forms.GroupBox();
            this.radio_strategy_kernel = new System.Windows.Forms.RadioButton();
            this.radio_strategy_tour = new System.Windows.Forms.RadioButton();
            this.radio_strategy_det2 = new System.Windows.Forms.RadioButton();
            this.radio_strategy_det = new System.Windows.Forms.RadioButton();
            this.group_filter = new System.Windows.Forms.GroupBox();
            this.radio_filter_pincer = new System.Windows.Forms.RadioButton();
            this.radio_filter_dominance = new System.Windows.Forms.RadioButton();
            this.radio_filter_none = new System.Windows.Forms.RadioButton();
            this.group_kendall = new System.Windows.Forms.GroupBox();
            this.radio_kendall_weighted = new System.Windows.Forms.RadioButton();
            this.radio_kendall_average = new System.Windows.Forms.RadioButton();
            this.radio_kendall_min = new System.Windows.Forms.RadioButton();
            this.group_sampling = new System.Windows.Forms.GroupBox();
            this.speed_3 = new System.Windows.Forms.Button();
            this.speed_2 = new System.Windows.Forms.Button();
            this.speed_1 = new System.Windows.Forms.Button();
            this.speed_0 = new System.Windows.Forms.Button();
            this.initialize = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_rank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_average)).BeginInit();
            this.group_proba.SuspendLayout();
            this.group_filter.SuspendLayout();
            this.group_kendall.SuspendLayout();
            this.group_sampling.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1404, 758);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.graph_rank);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.graph_average);
            this.splitContainer2.Size = new System.Drawing.Size(1404, 592);
            this.splitContainer2.SplitterDistance = 702;
            this.splitContainer2.TabIndex = 0;
            // 
            // graph_rank
            // 
            chartArea1.AlignWithChartArea = "ChartArea2";
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 91F;
            chartArea1.Position.Width = 73.23495F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 9F;
            chartArea2.AlignWithChartArea = "ChartArea1";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea2";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 91F;
            chartArea2.Position.Width = 73.23495F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 9F;
            this.graph_rank.ChartAreas.Add(chartArea1);
            this.graph_rank.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.graph_rank.Legends.Add(legend1);
            this.graph_rank.Location = new System.Drawing.Point(0, 0);
            this.graph_rank.Name = "graph_rank";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Gray;
            series1.Legend = "Legend1";
            series1.Name = "Ranks";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "LeftTauValue";
            series3.ChartArea = "ChartArea2";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "RightTauValue";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Sampled";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Color = System.Drawing.Color.Fuchsia;
            series5.Legend = "Legend1";
            series5.Name = "Filter";
            series5.YValuesPerPoint = 2;
            this.graph_rank.Series.Add(series1);
            this.graph_rank.Series.Add(series2);
            this.graph_rank.Series.Add(series3);
            this.graph_rank.Series.Add(series4);
            this.graph_rank.Series.Add(series5);
            this.graph_rank.Size = new System.Drawing.Size(699, 589);
            this.graph_rank.TabIndex = 0;
            this.graph_rank.Text = "chart1";
            // 
            // graph_average
            // 
            chartArea3.Name = "ChartArea1";
            this.graph_average.ChartAreas.Add(chartArea3);
            legend2.Name = "Legend1";
            this.graph_average.Legends.Add(legend2);
            this.graph_average.Location = new System.Drawing.Point(3, 0);
            this.graph_average.Name = "graph_average";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.graph_average.Series.Add(series6);
            this.graph_average.Size = new System.Drawing.Size(699, 589);
            this.graph_average.TabIndex = 1;
            this.graph_average.Text = "chart1";
            // 
            // group_proba
            // 
            this.group_proba.Controls.Add(this.radio_strategy_kernel);
            this.group_proba.Controls.Add(this.radio_strategy_tour);
            this.group_proba.Controls.Add(this.radio_strategy_det2);
            this.group_proba.Controls.Add(this.radio_strategy_det);
            this.group_proba.Location = new System.Drawing.Point(547, 3);
            this.group_proba.Name = "group_proba";
            this.group_proba.Size = new System.Drawing.Size(164, 158);
            this.group_proba.TabIndex = 4;
            this.group_proba.TabStop = false;
            this.group_proba.Text = "Sampling Strategy";
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
            // radio_strategy_tour
            // 
            this.radio_strategy_tour.AutoSize = true;
            this.radio_strategy_tour.Location = new System.Drawing.Point(7, 66);
            this.radio_strategy_tour.Name = "radio_strategy_tour";
            this.radio_strategy_tour.Size = new System.Drawing.Size(82, 17);
            this.radio_strategy_tour.TabIndex = 2;
            this.radio_strategy_tour.Text = "Tournament";
            this.radio_strategy_tour.UseVisualStyleBackColor = true;
            this.radio_strategy_tour.Click += new System.EventHandler(this.radio_strategy_2);
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
            this.radio_filter_pincer.Click += new System.EventHandler(this.radio_filter_pincer_Checked);
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
            this.radio_filter_dominance.Click += new System.EventHandler(this.radio_filter_dominance_Checked);
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
            this.radio_filter_none.Click += new System.EventHandler(this.radio_filter_none_Checked);
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
            // initialize
            // 
            this.initialize.Location = new System.Drawing.Point(138, 20);
            this.initialize.Name = "initialize";
            this.initialize.Size = new System.Drawing.Size(75, 23);
            this.initialize.TabIndex = 1;
            this.initialize.Text = "Initialize";
            this.initialize.UseVisualStyleBackColor = true;
            this.initialize.Click += new System.EventHandler(this.button_speed_initialize);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 758);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graph_rank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_average)).EndInit();
            this.group_proba.ResumeLayout(false);
            this.group_proba.PerformLayout();
            this.group_filter.ResumeLayout(false);
            this.group_filter.PerformLayout();
            this.group_kendall.ResumeLayout(false);
            this.group_kendall.PerformLayout();
            this.group_sampling.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton radio_strategy_tour;
        private System.Windows.Forms.RadioButton radio_strategy_det2;
        private System.Windows.Forms.RadioButton radio_strategy_det;
        private System.Windows.Forms.RadioButton radio_strategy_kernel;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph_rank;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph_average;
    }
}

