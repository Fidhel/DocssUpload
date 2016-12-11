using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocSS_SyncFile
{
    public partial class SenhaAdminMsgBox : Form
    {
        public SenhaAdminMsgBox()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Owner;
            if (form.autenticaAdministrador(textUser.Text))
            {
                this.Close();
            }
            else {
                MessageBox.Show("Senha Invalida!");
            }
            
        }

        private void SenhaAdminMsgBox_Load(object sender, EventArgs e)
        {

        }
    }
}
