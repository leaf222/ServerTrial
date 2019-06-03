using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataBaseTrial
{
    class Text
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=orcl;User Id=system;Password=Yyf1314520";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            

            Console.WriteLine("Connection State:" + conn.State + "\n");

            try
            {

                OracleCommand oracleCommand = conn.CreateCommand();
                oracleCommand.CommandText = "insert into student(ID, name, dept_name, tot_cred) values ('77777','mingkai','Comp.Sci.','777')";
                int result = 0;
                result = oracleCommand.ExecuteNonQuery();


                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                oracleDataAdapter.InsertCommand = oracleCommand;

                OracleParameter[] oracleParameters =
                {
                    new OracleParameter(":ID",OracleDbType.NVarchar2,5,"77777"),
                    new OracleParameter(":name",OracleDbType.NVarchar2,20,"mingkai"),
                    new OracleParameter(":dept_name",OracleDbType.NVarchar2,20,"Comp.Sci."),
                    new OracleParameter(":tot_cred",OracleDbType.Decimal,4,"777"),
                };
                oracleDataAdapter.InsertCommand.Parameters.AddRange(oracleParameters);


                Console.WriteLine(result.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
             }
            
            conn.Close();
            Console.ReadLine();
        }
    }
}
