using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Integral
{
    public partial class mainForm : Form
    {
        public DataTable dtHistory = new DataTable("History"); //таблица для хранения истории вычислений
        public mainForm()
        {
            InitializeComponent();
            dtHistory.Columns.Add("function");
            dtHistory.Columns.Add("a");
            dtHistory.Columns.Add("b");
            dtHistory.Columns.Add("result");
            dtHistory.Columns.Add("method");
        }

        public void TxtBox (string function)
        {
            txtFunction.Text = function;
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 8))
                e.Handled = true;
        }


        private void btnGetResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgWork.IsBusy)
                {

                    bgWork.RunWorkerAsync();
                    pbProgress.Value = 0;
                    btnGetResult.Text = "Отмена";
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                }
                else
                {
                    bgWork.WorkerSupportsCancellation = true;
                    bgWork.CancelAsync();
                    btnGetResult.Text = "Расчитать";
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 8) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != '-'))
                e.Handled = true;
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 8) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != '-'))
                e.Handled = true;
        }

        private void txtEps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '1') && (e.KeyChar != 8) && (e.KeyChar != '.') && (e.KeyChar != ','))
                e.Handled = true;
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            Action action;
            try
            {

                double epsilon, aborder, bborder;
                double result = 0.0;
                int CharsAfter = 0;

                bgWork.WorkerSupportsCancellation = true;

                if (!rbDerivative.Checked)
                    if (String.IsNullOrEmpty(txtB.Text))
                    {
                        MessageBox.Show("Поле должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        action = () => btnGetResult.Text = "Расчитать";
                        Invoke(action);
                        action = () => groupBox1.Enabled = true;
                        Invoke(action);
                        action = () => groupBox2.Enabled = true;
                        Invoke(action);
                        return;
                    }

                if (String.IsNullOrEmpty(txtA.Text) || String.IsNullOrEmpty(txtEps.Text) || String.IsNullOrEmpty(txtFunction.Text))
                {
                    MessageBox.Show("Поле должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    action = () => btnGetResult.Text = "Расчитать";
                    Invoke(action);
                    action = () => groupBox1.Enabled = true;
                    Invoke(action);
                    action = () => groupBox2.Enabled = true;
                    Invoke(action);
                    return;
                }


                epsilon = Convert.ToDouble(txtEps.Text.Replace(".", ",")) * 1.0;
                aborder = Convert.ToDouble(txtA.Text.Replace(".", ",")) * 1.0;
                for (int i = txtEps.Text.Length - 1; i >= 0; i--)
                {
                    if (txtEps.Text[i] == '.' || txtEps.Text[i] == ',')
                        break;
                    else
                        CharsAfter++;
                }
                if (!rbDerivative.Checked)
                {
                    bborder = Convert.ToDouble(txtB.Text.Replace(".", ",")) * 1.0;
                    if (aborder > bborder)
                    {
                        MessageBox.Show("Верхняя граница интегрирования должна быть больше нижней границы интегрирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Integral integral = new Integral(txtFunction.Text, this);
                    if (rbLeft.Checked)
                    {
                        result = integral.LeftMethod(aborder, bborder, epsilon, pbProgress, bgWork);
                        action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, txtB.Text, String.Format("{0:F" + CharsAfter + "}", result), rbLeft.Text);
                        Invoke(action);
                    }
                    if (rbMiddle.Checked)
                    {
                        result = integral.MiddleMethod(aborder, bborder, epsilon, pbProgress, bgWork);
                        action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, txtB.Text, String.Format("{0:F" + CharsAfter + "}", result), rbMiddle.Text);
                        Invoke(action);
                    }
                    if (rbRight.Checked)
                    {
                        result = integral.RightMethod(aborder, bborder, epsilon, pbProgress, bgWork);
                        action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, txtB.Text, String.Format("{0:F" + CharsAfter + "}", result), rbRight.Text);
                        Invoke(action);
                    }
                    if (rbTrapec.Checked)
                    {
                        result = integral.TrapecMethod(aborder, bborder, epsilon, pbProgress, bgWork);
                        action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, txtB.Text, String.Format("{0:F" + CharsAfter + "}", result), rbTrapec.Text);
                        Invoke(action);
                    }
                    if (rbSimpson.Checked)
                    {
                        result = integral.SimpsonMethod(aborder, bborder, epsilon, pbProgress, bgWork);
                        action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, txtB.Text, String.Format("{0:F" + CharsAfter + "}", result), rbSimpson.Text);
                        Invoke(action);
                    }

                }
                else
                {
                    Derivative derivative = new Derivative(txtFunction.Text);
                    result = derivative.FindDiv(aborder, epsilon);
                    action = () => dtHistory.Rows.Add(txtFunction.Text, txtA.Text, "", String.Format("{0:F" + CharsAfter + "}", result), "Дифференцирование в точке");
                    Invoke(action);
                }

                

                

                action = () => txtResult.Text = String.Format("{0:F" + CharsAfter + "}", result);
                Invoke(action);

            }
            catch (Exception error)
            {
                action = () => txtResult.Text = error.Message;
                Invoke(action);
                bgWork.CancelAsync();

            }
            action = () => btnGetResult.Text = "Расчитать";
            Invoke(action);
            action = () => groupBox1.Enabled = true;
            Invoke(action);
            action = () => groupBox2.Enabled = true;
            Invoke(action);
        }


        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWork.IsBusy)
                bgWork.CancelAsync();
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWork.WorkerSupportsCancellation = true;
            bgWork.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int serIndex = 0;
            if (String.IsNullOrEmpty(txtFunction.Text))
                MessageBox.Show("Поле должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (String.IsNullOrEmpty(txtA.Text))
                MessageBox.Show("Поле должно быть заполнено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                double x, y, b;
                x = Convert.ToDouble(txtA.Text.Replace(".", ","));
                if (rbDerivative.Checked)
                {
                    b = Convert.ToDouble(txtA.Text.Replace(".", ",")) + 1;
                }
                else
                {
                    b = Convert.ToDouble(txtB.Text.Replace(".", ","));
                }
                var Series = chart1.Series[serIndex];
                Series.Points.Clear();

                Parser parser = new Parser(txtFunction.Text);
                while (x <= b)
                {
                    try
                    {

                        y = parser.f(x);
                        if (!(y > 100) && !(y < -100))
                            Series.Points.AddXY(x, y);


                        x += 0.01;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void rbDerivative_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDerivative.Checked)
            {
                groupBox2.Text = "Данные дифференцирования";
                label2.Text = "Точка дифференцирования:";
                label3.Text = "x = ";
                label4.Visible = false;
                txtB.Visible = false;
            }
            else
            {
                groupBox2.Text = "Данные интегрирования";
                label2.Text = "Промежуток интегрирования:";
                label3.Text = "от";
                label4.Visible = true;
                txtB.Visible = true;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (Program.HistoryForm == null)
            {
                History fHistory = new History();
                fHistory.Owner = this;
                Program.HistoryForm = fHistory;
                fHistory.SetTable(dtHistory);
                fHistory.Show();
            }
            else
            {
                Program.HistoryForm.Activate();
            }
        }
    }
}
