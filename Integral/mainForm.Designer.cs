namespace Integral
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTrigFunctions = new System.Windows.Forms.Label();
            this.lblBasicFunction = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDerivative = new System.Windows.Forms.RadioButton();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.rbMiddle = new System.Windows.Forms.RadioButton();
            this.rbSimpson = new System.Windows.Forms.RadioButton();
            this.rbTrapec = new System.Windows.Forms.RadioButton();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrigFunctions
            // 
            this.lblTrigFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrigFunctions.Location = new System.Drawing.Point(339, 209);
            this.lblTrigFunctions.Name = "lblTrigFunctions";
            this.lblTrigFunctions.Size = new System.Drawing.Size(370, 275);
            this.lblTrigFunctions.TabIndex = 17;
            this.lblTrigFunctions.Text = resources.GetString("lblTrigFunctions.Text");
            // 
            // lblBasicFunction
            // 
            this.lblBasicFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBasicFunction.Location = new System.Drawing.Point(26, 213);
            this.lblBasicFunction.Name = "lblBasicFunction";
            this.lblBasicFunction.Size = new System.Drawing.Size(370, 275);
            this.lblBasicFunction.TabIndex = 16;
            this.lblBasicFunction.Text = resources.GetString("lblBasicFunction.Text");
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(448, 12);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Ответ";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(448, 28);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(183, 116);
            this.txtResult.TabIndex = 14;
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(12, 178);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(619, 30);
            this.btnGetResult.TabIndex = 13;
            this.btnGetResult.Text = "Рассчет";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEps);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtFunction);
            this.groupBox2.Controls.Add(this.txtB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtA);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(245, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 160);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные интегрирования";
            // 
            // txtEps
            // 
            this.txtEps.Location = new System.Drawing.Point(61, 108);
            this.txtEps.Name = "txtEps";
            this.txtEps.Size = new System.Drawing.Size(58, 20);
            this.txtEps.TabIndex = 12;
            this.txtEps.Text = "0,00001";
            this.txtEps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEps_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "f(x) = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Точность";
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(41, 22);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(123, 20);
            this.txtFunction.TabIndex = 5;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(110, 75);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(54, 20);
            this.txtB.TabIndex = 10;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Промежуток интегрирования:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(30, 75);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(54, 20);
            this.txtA.TabIndex = 9;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "от";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "до";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDerivative);
            this.groupBox1.Controls.Add(this.rbLeft);
            this.groupBox1.Controls.Add(this.rbRight);
            this.groupBox1.Controls.Add(this.rbMiddle);
            this.groupBox1.Controls.Add(this.rbSimpson);
            this.groupBox1.Controls.Add(this.rbTrapec);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вычисление";
            // 
            // rbDerivative
            // 
            this.rbDerivative.AutoSize = true;
            this.rbDerivative.Location = new System.Drawing.Point(9, 138);
            this.rbDerivative.Name = "rbDerivative";
            this.rbDerivative.Size = new System.Drawing.Size(174, 17);
            this.rbDerivative.TabIndex = 5;
            this.rbDerivative.Text = "Дифференцирование в точке";
            this.rbDerivative.UseVisualStyleBackColor = true;
            this.rbDerivative.CheckedChanged += new System.EventHandler(this.rbDerivative_CheckedChanged);
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Checked = true;
            this.rbLeft.Location = new System.Drawing.Point(9, 22);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(200, 17);
            this.rbLeft.TabIndex = 4;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Формула левых прямоугольников";
            this.rbLeft.UseVisualStyleBackColor = true;
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(9, 68);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(206, 17);
            this.rbRight.TabIndex = 3;
            this.rbRight.Text = "Формула правых прямоугольников";
            this.rbRight.UseVisualStyleBackColor = true;
            // 
            // rbMiddle
            // 
            this.rbMiddle.AutoSize = true;
            this.rbMiddle.Location = new System.Drawing.Point(9, 45);
            this.rbMiddle.Name = "rbMiddle";
            this.rbMiddle.Size = new System.Drawing.Size(210, 17);
            this.rbMiddle.TabIndex = 0;
            this.rbMiddle.Text = "Формула средних прямоугольников";
            this.rbMiddle.UseVisualStyleBackColor = true;
            // 
            // rbSimpson
            // 
            this.rbSimpson.AutoSize = true;
            this.rbSimpson.Location = new System.Drawing.Point(9, 115);
            this.rbSimpson.Name = "rbSimpson";
            this.rbSimpson.Size = new System.Drawing.Size(178, 17);
            this.rbSimpson.TabIndex = 2;
            this.rbSimpson.Text = "Формула Симпсона (парабол)";
            this.rbSimpson.UseVisualStyleBackColor = true;
            // 
            // rbTrapec
            // 
            this.rbTrapec.AutoSize = true;
            this.rbTrapec.Location = new System.Drawing.Point(9, 91);
            this.rbTrapec.Name = "rbTrapec";
            this.rbTrapec.Size = new System.Drawing.Size(123, 17);
            this.rbTrapec.TabIndex = 1;
            this.rbTrapec.Text = "Формула трапеций";
            this.rbTrapec.UseVisualStyleBackColor = true;
            // 
            // bgWork
            // 
            this.bgWork.WorkerReportsProgress = true;
            this.bgWork.WorkerSupportsCancellation = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(0, 466);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(962, 23);
            this.pbProgress.TabIndex = 18;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(646, 90);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(763, 396);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(75, 23);
            this.bUpdate.TabIndex = 20;
            this.bUpdate.Text = "Обновить";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(747, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "График функции";
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(448, 149);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(183, 23);
            this.btnHistory.TabIndex = 23;
            this.btnHistory.Text = "История";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 489);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblTrigFunctions);
            this.Controls.Add(this.lblBasicFunction);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нахождение приближённого значения интеграла";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbSimpson;
        private System.Windows.Forms.RadioButton rbTrapec;
        private System.Windows.Forms.RadioButton rbMiddle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.Label lblBasicFunction;
        private System.Windows.Forms.Label lblTrigFunctions;
        private System.ComponentModel.BackgroundWorker bgWork;
        public System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbDerivative;
        private System.Windows.Forms.Button btnHistory;
    }
}

