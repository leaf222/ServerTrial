using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseTrialForm
{
    public partial class Form1 : Form
    {
        private DataBaseOption dataBaseOption;
        public Form1()
        {
            InitializeComponent();
            dataBaseOption = new DataBaseOption();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dataSet3.CLASSROOM”中。您可以根据需要移动或删除它。
            this.cLASSROOMTableAdapter1.Fill(this.dataSet3.CLASSROOM);
            // TODO: 这行代码将数据加载到表“dataSet2.CLASSROOM”中。您可以根据需要移动或删除它。
            this.cLASSROOMTableAdapter.Fill(this.dataSet2.CLASSROOM);
            // TODO: 这行代码将数据加载到表“dataSet1.COURSE”中。您可以根据需要移动或删除它。
            this.cOURSETableAdapter.Fill(this.dataSet1.COURSE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBaseOption.ConnectionOpen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBaseOption.ConnectionClose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "Data Source=" + textBox1.Text + ";User Id=" + textBox2.Text + ";Password=" + textBox3.Text;
            dataBaseOption = new DataBaseOption(s);
            MessageBox.Show(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataBaseOption.BindDataGridView(dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataBaseOption.InsertTrial();
        }
    }
}
