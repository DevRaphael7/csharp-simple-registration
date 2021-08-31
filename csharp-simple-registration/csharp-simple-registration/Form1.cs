using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_simple_registration
{
    public partial class Form1 : Form
    {
        String nome, senha;
        Usuario user1 = new Usuario();
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            user1.setNome(txtNome.Text);
            user1.setSenha(txtNome.Text);
        }
    }
}
