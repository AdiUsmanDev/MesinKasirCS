using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Dapper;

namespace WindowsFormsApp1_mdi
{
    public partial class Pencarian : Form
    {
        public Pencarian()
        {
            InitializeComponent();
        }

        private void cari_load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Nama Item", 200);
            listView1.Columns.Add("Jumlah", 200);
            listView1.Columns.Add("Harga", 200);
        }


        private void reset(object sender , EventArgs e)
        {

            listView1.Items.Clear();
            
        }

        private void cari(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;userid=root;password=root;database=mesin_kasir";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string value = "%" + textBox1.Text + "%";

                    string query = "SELECT * FROM list_barang where nama_barang LIKE @ElementSerch";
                 
                    var selectedData = connection.Query(query, new { ElementSerch = value });

                    listView1.Items.Clear();

                    foreach (var data in selectedData)
                    {

                        ListViewItem newItem = new ListViewItem(data.nama_barang);
                        newItem.SubItems.Add("1");
                        newItem.SubItems.Add(data.harga);

                        listView1.Items.Add(newItem);




                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("eror "+ex.Message);
                }
            }

        }
    }
}
