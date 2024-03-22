using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_mdi
{
    public partial class Menu_Utama : Form
    {
        private int childFormNumber = 0;
        Login_Form login;
        Penjualan jual;
        Input_barang input; 
        view_barang viewbarang;

        Login_Form login_form;
 
    
        public Menu_Utama(Login_Form login_Form)
        {
            

            InitializeComponent();
            this.login_form = login_Form;
            menuStrip.Items[1].Enabled = false;
            menuStrip.Items[2].Enabled = false;
            menuStrip.Items[3].Enabled = false;
            menuStrip.Items[4].Enabled = false;
            aktif();    
        }

       
        

        private void aktif()
        {
            if (login_form != null)
            {
                menuStrip.Items[1].Enabled = true;
                menuStrip.Items[2].Enabled = true;
                menuStrip.Items[3].Enabled = true;
                menuStrip.Items[4].Enabled = true;
            }
        }


        private void logout(object sender , EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin Logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                login_form = null;

                menuStrip.Items[1].Enabled = false;
                menuStrip.Items[2].Enabled = false;
                menuStrip.Items[3].Enabled = false;
                menuStrip.Items[4].Enabled = false;
            }

        }

        void login_FormClosed(object sender,FormClosedEventArgs e)
        {
            login = null;
        }

        private void lgn (object sender,EventArgs e)
        {

            if (login == null)
            {

                login = new Login_Form();
                login.MdiParent = this;
                login.FormClosed += new FormClosedEventHandler(login_FormClosed);
                login.Show();
            }
            else
            {
                 login.Activate(); 
            }
            
        }

        //from jual
        void jual_FormClosed(object sender, FormClosedEventArgs e)
        {
            jual = null;


        }

        private void scan(object sender, EventArgs e)
        {

            if (jual == null)
            {

                jual = new Penjualan();
                jual.MdiParent = this;
                jual.FormClosed += new FormClosedEventHandler(jual_FormClosed);
                jual.Show();
            }
            else
            {
                jual.Activate();
            }

        }


        void input_FormClosed(object sender, FormClosedEventArgs e)
        {
            input = null;


        }

        private void inpt(object sender, EventArgs e)
        {

            if (input == null)
            {

                input = new Input_barang();
                input.MdiParent = this;
                input.FormClosed += new FormClosedEventHandler(input_FormClosed);
                input.Show();
            }
            else
            {
                input.Activate();
            }

        }


        void view_barang_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewbarang = null;


        }

        private void view_brg(object sender, EventArgs e)
        {

            if (viewbarang == null)
            {

                viewbarang = new view_barang();
                viewbarang.MdiParent = this;
                viewbarang.FormClosed += new FormClosedEventHandler(view_barang_FormClosed);
                viewbarang.Show();
            }
            else
            {
                viewbarang.Activate();
            }

        }

void pencarian_FormClosed(object sender, FormClosedEventArgs e)
{
    pencarian = null;


}

private void pencarian_brg(object sender, EventArgs e)
{

    if (pencarian  == null)
    {

        pencarian = new Pencarian();
        pencarian.MdiParent = this;
        pencarian.FormClosed += new FormClosedEventHandler(pencarian_FormClosed);
        pencarian.Show();
    }
    else
    {
        pencarian.Activate();
    }

}



        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Menu_Utama_Load(object sender, EventArgs e)
        {

        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
