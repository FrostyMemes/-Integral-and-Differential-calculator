namespace Integral
{
    partial class History
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
            this.saveHistory = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveHistory = new System.Windows.Forms.Button();
            this.dtHistry = new System.Windows.Forms.DataGridView();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadHistory = new System.Windows.Forms.Button();
            this.loadHistory = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtHistry)).BeginInit();
            this.SuspendLayout();
            // 
            // saveHistory
            // 
            this.saveHistory.Filter = "Xml files(*.xml)|*.xml";
            // 
            // btnSaveHistory
            // 
            this.btnSaveHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveHistory.Location = new System.Drawing.Point(0, 319);
            this.btnSaveHistory.Name = "btnSaveHistory";
            this.btnSaveHistory.Size = new System.Drawing.Size(496, 23);
            this.btnSaveHistory.TabIndex = 23;
            this.btnSaveHistory.Text = "Сохранить как...";
            this.btnSaveHistory.UseVisualStyleBackColor = true;
            this.btnSaveHistory.Click += new System.EventHandler(this.btnSaveHistory_Click);
            // 
            // dtHistry
            // 
            this.dtHistry.AllowUserToAddRows = false;
            this.dtHistry.AllowUserToDeleteRows = false;
            this.dtHistry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtHistry.BackgroundColor = System.Drawing.Color.White;
            this.dtHistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtHistry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.function,
            this.a,
            this.b,
            this.result,
            this.method});
            this.dtHistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtHistry.Location = new System.Drawing.Point(0, 0);
            this.dtHistry.Name = "dtHistry";
            this.dtHistry.ReadOnly = true;
            this.dtHistry.RowHeadersVisible = false;
            this.dtHistry.Size = new System.Drawing.Size(496, 319);
            this.dtHistry.TabIndex = 24;
            this.dtHistry.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtHistry_CellDoubleClick);
            // 
            // function
            // 
            this.function.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.function.DataPropertyName = "function";
            this.function.Frozen = true;
            this.function.HeaderText = "Функция";
            this.function.Name = "function";
            this.function.ReadOnly = true;
            this.function.Width = 78;
            // 
            // a
            // 
            this.a.DataPropertyName = "a";
            this.a.Frozen = true;
            this.a.HeaderText = "От";
            this.a.Name = "a";
            this.a.ReadOnly = true;
            this.a.Width = 45;
            // 
            // b
            // 
            this.b.DataPropertyName = "b";
            this.b.Frozen = true;
            this.b.HeaderText = "До";
            this.b.Name = "b";
            this.b.ReadOnly = true;
            this.b.Width = 47;
            // 
            // result
            // 
            this.result.DataPropertyName = "result";
            this.result.Frozen = true;
            this.result.HeaderText = "Результат";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Width = 84;
            // 
            // method
            // 
            this.method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.method.DataPropertyName = "method";
            this.method.Frozen = true;
            this.method.HeaderText = "Метод";
            this.method.Name = "method";
            this.method.ReadOnly = true;
            this.method.Width = 64;
            // 
            // btnLoadHistory
            // 
            this.btnLoadHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoadHistory.Location = new System.Drawing.Point(0, 296);
            this.btnLoadHistory.Name = "btnLoadHistory";
            this.btnLoadHistory.Size = new System.Drawing.Size(496, 23);
            this.btnLoadHistory.TabIndex = 25;
            this.btnLoadHistory.Text = "Загрузить...";
            this.btnLoadHistory.UseVisualStyleBackColor = true;
            this.btnLoadHistory.Click += new System.EventHandler(this.btnLoadHistory_Click);
            // 
            // loadHistory
            // 
            this.loadHistory.Filter = "Xml files(*.xml)|*.xml";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 342);
            this.Controls.Add(this.btnLoadHistory);
            this.Controls.Add(this.dtHistry);
            this.Controls.Add(this.btnSaveHistory);
            this.Name = "History";
            this.ShowIcon = false;
            this.Text = "История вычислений";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.History_FormClosed);
            this.Load += new System.EventHandler(this.History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtHistry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveHistory;
        private System.Windows.Forms.Button btnSaveHistory;
        private System.Windows.Forms.DataGridView dtHistry;
        private System.Windows.Forms.Button btnLoadHistory;
        private System.Windows.Forms.OpenFileDialog loadHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
    }
}