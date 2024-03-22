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
using Dapper;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Security.Policy;

namespace WindowsFormsApp1_mdi
{
    
    public partial class Login_Form : Form
    {
        Menu_Utama menu_Utama;
        public Login_Form status ;
        public Login_Form()
        {
            InitializeComponent();
            GetDataFromApi();
           
        }

        private void tutup(object sender, EventArgs s)
        {
            Login_Form login = new Login_Form();
            login.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private async Task GetDataFromApi()
        {
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://mixstore.my.id/api.php");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(json);
                    string name = (string)jsonObject["message"];
                    string city = (string)jsonObject["status"];

                    if(name == "accessFals")
                    {
                       // Process.Start("https://youtube.com");
                         MessageBox.Show("lakukan login");
                        
                    }
                    else
                    {
                        //essageBox.Show(name);

                       // this.Close();

                        //login_Form.Close();
                     //  Application.Run(new Menu_Utama(null));


                    }


                }
            }
        }

        private async Task reqapi(string username , string password)
        {
            using (HttpClient client = new HttpClient())
            {

                var requestData = new FormUrlEncodedContent(new[]
              {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });


                HttpResponseMessage response = await client.PostAsync("https://mixstore.my.id/api.php",requestData);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JObject jsonObject = JObject.Parse(json);
                    string name = (string)jsonObject["message"];
                    string city = (string)jsonObject["status"];

                    if (name == "accessFalse")
                    {
                        //Process.Start("https://youtube.com");
                        MessageBox.Show("lakukan login");

                    }
                    else
                    {
                        MessageBox.Show("berhasil login");
                        //this.Close();

                       
                    }


                }
            }
        }


        private void btn(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;userid=root;password=root;database=mesin_kasir";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM user where username = @user";

                    var parameter = new { user = textBox1.Text };


                    var selectedData = connection.Query(query, parameter);

                    foreach (var data in selectedData)
                    {
                        if (data.username == textBox1.Text)
                        {
                            if(data.password == textBox2.Text)
                            {
                                MessageBox.Show("berhasil login");
                              
                                this.Close();

                                Login_Form login_Form = new Login_Form();
                                var menu = new Menu_Utama(login_Form);

                                 Form oldform = Application.OpenForms.OfType<Menu_Utama>().FirstOrDefault();
                                    if (oldform != null)
                                    {
                                        oldform.Hide();
                                    }  
                                                                    
                                menu.Show();

                            }
                            else
                            {
                                MessageBox.Show("username atau pasword salah");
                            }
                        }
                        else
                        {
                            MessageBox.Show("username atau password salah");
                        }
                    }

                    connection.Close();
                }catch(Exception ex)
                {

                }
                }
        }
        }
    
    }

