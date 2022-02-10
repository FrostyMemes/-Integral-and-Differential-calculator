using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Integral
{
    public partial class History : Form
    {
        XmlDocument xDoc = new XmlDocument(); //переменная для обращения к xml файлу


        public History()
        {
            InitializeComponent();
        }


        public void SetTable(DataTable table)
        {
            dtHistry.DataSource = table;
        }

        private void btnSaveHistory_Click(object sender, EventArgs e)
        {
            if (saveHistory.ShowDialog() == DialogResult.Cancel)
                return;
            mainForm main = this.Owner as mainForm;
            main.dtHistory.WriteXml(saveHistory.FileName);
        }

        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.HistoryForm = null;
        }

        private void btnLoadHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("После загрузки текущая история будет удалена. Вы уверены, что хотите продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (loadHistory.ShowDialog() == DialogResult.Cancel)
                    return;
                var dataSet = new DataSet();
                dataSet.ReadXml(loadHistory.FileName);
                dtHistry.DataSource = dataSet.Tables[0];
                mainForm main = this.Owner as mainForm;
                main.dtHistory = dtHistry.DataSource as DataTable;
            }
        }

        private void dtHistry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtHistry.Rows.Count != 0)
            {
                mainForm main = this.Owner as mainForm;
                main.TxtBox(dtHistry.CurrentCell.Value.ToString());
            }
        }

        private void History_Load(object sender, EventArgs e)
        {

        }
    }
}
