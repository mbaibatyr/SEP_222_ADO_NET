using System.Data.SqlClient;

namespace MyTran
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Trantest test = new Trantest();
            test.TranTest_1();
        }
    }

    class Trantest
    {
        string connStr = "Server=206-P;Database=testDB;Trusted_Connection=True;";

        public void TranTest_1()
        {
            using (SqlConnection db = new SqlConnection(connStr))
            {
                db.Open();
                SqlTransaction tran = db.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("insert into account_1 values(1, 100)", db))
                    {
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("ok");
                    }

                    using (SqlCommand cmd = new SqlCommand("insert into account_1 values(1, 100)", db))
                    {
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("ok");
                    }
                    Console.WriteLine("all ok");
                    tran.Commit();
                }
                catch (Exception err)
                {
                    Console.WriteLine("err");
                    tran.Rollback();
                }
                db.Close();
            }
        }
    }
}