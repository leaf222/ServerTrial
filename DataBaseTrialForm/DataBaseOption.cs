using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseTrialForm
{
    public class DataBaseOption
    {
        private OracleConnection conn;
        public DataBaseOption()
        {
            conn = new OracleConnection();
        }
        public DataBaseOption(string s)
        {
            conn = new OracleConnection();
            conn.ConnectionString = s;
        }
        public void ConnectionOpen()
        {
            try
            {
                conn.Open();
                
                MessageBox.Show("Connection State:" + conn.State);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        public void ConnectionClose()
        {
            conn.Close();
            MessageBox.Show("Connection State:" + conn.State);
        }
        public void BindDataGridView(DataGridView dataGridView)
        {
            try
            {
                

                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "select * from student";
//                     "select name " + 
//                     "from student " +
//                     "where ID = '00128'";
                    
//                     "with dept_total(dept_name, ins_total) as " +
//                     "(select dept_name, count(distinct ID) " +
//                     "from instructor " +
//                     "group by dept_name) " +
//                     "select department.dept_name, department.budget " +
//                     "from dept_total,department " +
//                     "where ins_total > 1 " +
//                     "and dept_total.dept_name = department.dept_name";

                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                oracleDataAdapter.SelectCommand = oracleCommand;
                


                DataSet dataSet = new DataSet();
                oracleDataAdapter.Fill(dataSet,"T");

                dataGridView.DataSource = dataSet;
                dataGridView.DataMember = "T";

                /*dataGridView.DataSource = dataSet.Tables["T"];*/
            }
            catch(Exception e)
            {
               MessageBox.Show(e.Message.ToString());
            }
        }
        public void InsertTrial()
        {
            try
            {
                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into student(ID, name, dept_name, tot_cred) values (:ID,:name,:dept_name,:tot_cred)";
                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
//                oracleDataAdapter.InsertCommand.CommandType = CommandType.Text;
                oracleDataAdapter.InsertCommand = oracleCommand;

                OracleParameter[] oracleParameters =
                {
                    new OracleParameter(":ID",OracleDbType.Varchar2,5,"77777"),
                    new OracleParameter(":name",OracleDbType.Varchar2,20,"mingkai"),
                    new OracleParameter(":dept_name",OracleDbType.Varchar2,20,"Comp.Sci."),
                    new OracleParameter(":tot_cred",OracleDbType.Varchar2,4,"777"),
                };
                oracleDataAdapter.InsertCommand.Parameters.AddRange(oracleParameters);
                oracleDataAdapter.InsertCommand.Connection = conn;
                int k = oracleDataAdapter.InsertCommand.ExecuteNonQuery();

                DataTable dataTable = new DataTable();
                
                oracleDataAdapter.Update(dataTable);
                dataTable.AcceptChanges();

                MessageBox.Show(k.ToString());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }
}
