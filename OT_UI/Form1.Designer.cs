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
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.graph_rank = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.group_sampling = new System.Windows.Forms.GroupBox();
            this.speed_1 = new System.Windows.Forms.Button();
            this.speed_0 = new System.Windows.Forms.Button();
            this.initialize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graph_rank)).BeginInit();
            this.group_sampling.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.group_sampling);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1872, 933);
            this.splitContainer1.SplitterDistance = 727;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.graph_rank);
            this.splitContainer2.Size = new System.Drawing.Size(1872, 727);
            this.splitContainer2.SplitterDistance = 936;
            this.splitContainer2.SplitterWidth = 5;
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
            chartArea1.AxisY2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
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
            this.graph_rank.Margin = new System.Windows.Forms.Padding(4);
            this.graph_rank.Name = "graph_rank";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Gray;
            series1.Legend = "Legend1";
            series1.Name = "Ranks";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "upper";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "lower";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "c";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Sampled";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Color = System.Drawing.Color.Fuchsia;
            series6.Legend = "Legend1";
            series6.Name = "Filter";
            series6.YValuesPerPoint = 2;
            series7.ChartArea = "ChartArea2";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series7.Color = System.Drawing.Color.Blue;
            series7.Legend = "Legend1";
            series7.Name = "ProbaValue";
            series7.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.graph_rank.Series.Add(series1);
            this.graph_rank.Series.Add(series2);
            this.graph_rank.Series.Add(series3);
            this.graph_rank.Series.Add(series4);
            this.graph_rank.Series.Add(series5);
            this.graph_rank.Series.Add(series6);
            this.graph_rank.Series.Add(series7);
            this.graph_rank.Size = new System.Drawing.Size(932, 725);
            this.graph_rank.TabIndex = 0;
            this.graph_rank.Text = "chart1";
            this.graph_rank.Click += new System.EventHandler(this.graph_rank_Click);
            // 
            // group_sampling
            // 
            this.group_sampling.Controls.Add(this.speed_1);
            this.group_sampling.Controls.Add(this.speed_0);
            this.group_sampling.Controls.Add(this.initialize);
            this.group_sampling.Location = new System.Drawing.Point(4, 4);
            this.group_sampling.Margin = new System.Windows.Forms.Padding(4);
            this.group_sampling.Name = "group_sampling";
            this.group_sampling.Padding = new System.Windows.Forms.Padding(4);
            this.group_sampling.Size = new System.Drawing.Size(339, 194);
            this.group_sampling.TabIndex = 0;
            this.group_sampling.TabStop = false;
            this.group_sampling.Text = "Sampling Control";
            this.group_sampling.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // speed_1
            // 
            this.speed_1.Image = ((System.Drawing.Image)(resources.GetObject("speed_1.Image")));
            this.speed_1.Location = new System.Drawing.Point(136, 23);
            this.speed_1.Margin = new System.Windows.Forms.Padding(4);
            this.speed_1.Name = "speed_1";
            this.speed_1.Size = new System.Drawing.Size(53, 49);
            this.speed_1.TabIndex = 3;
            this.speed_1.UseVisualStyleBackColor = true;
            this.speed_1.Click += new System.EventHandler(this.button_speed_1);
            // 
            // speed_0
            // 
            this.speed_0.Enabled = false;
            this.speed_0.Image = ((System.Drawing.Image)(resources.GetObject("speed_0.Image")));
            this.speed_0.Location = new System.Drawing.Point(197, 23);
            this.speed_0.Margin = new System.Windows.Forms.Padding(4);
            this.speed_0.Name = "speed_0";
            this.speed_0.Size = new System.Drawing.Size(53, 49);
            this.speed_0.TabIndex = 2;
            this.speed_0.UseVisualStyleBackColor = true;
            this.speed_0.Click += new System.EventHandler(this.button_speed_0);
            // 
            // initialize
            // 
            this.initialize.Location = new System.Drawing.Point(13, 23);
            this.initialize.Margin = new System.Windows.Forms.Padding(4);
            this.initialize.Name = "initialize";
            this.initialize.Size = new System.Drawing.Size(100, 28);
            this.initialize.TabIndex = 1;
            this.initialize.Text = "Initialize";
            this.initialize.UseVisualStyleBackColor = true;
            this.initialize.Click += new System.EventHandler(this.button_speed_initialize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1872, 933);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graph_rank)).EndInit();
            this.group_sampling.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox group_sampling;
        private System.Windows.Forms.Button initialize;
        private System.Windows.Forms.Button speed_1;
        private System.Windows.Forms.Button speed_0;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph_rank;
    }
}

