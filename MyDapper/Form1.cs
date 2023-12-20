using Dapper;
using MyDapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                var result = db.Query<Users>("[dbo].[pUsers]", new { id = tbFind.Text == "" ? null : tbFind.Text }, commandType: CommandType.StoredProcedure);
                gvUsers.DataSource = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("id", 0);
                p.Add("last_name", "test");
                p.Add("iin", "111111111111");                
                p.Add("category_id", 2);                
                p.Add("id_out", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = db.ExecuteScalar<string>("pUsers;2", p, commandType: CommandType.StoredProcedure);
                //button1_Click(null, null);

                gvUsers.DataSource = db.Query<Users>("[dbo].[pUsers]", new { id = tbFind.Text == "" ? null : tbFind.Text }, commandType: CommandType.StoredProcedure);
                
                MessageBox.Show(result);
                MessageBox.Show("new id = " + p.Get<int>("id_out").ToString());
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                Users2 user = new Users2()
                {
                    id = 0,
                    iin = "123",
                    last_name = "test666",
                    category_id = "1"
                };
                DynamicParameters p = new DynamicParameters(user);                
                p.Add("id_out", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = db.ExecuteScalar<string>("pUsers;2", p, commandType: CommandType.StoredProcedure);
                gvUsers.DataSource = db.Query<Users>("[dbo].[pUsers]", new { id = tbFind.Text == "" ? null : tbFind.Text }, commandType: CommandType.StoredProcedure);
                MessageBox.Show(result);
                MessageBox.Show("new id = " + p.Get<int>("id_out").ToString());
            }
        }
    }
}
