using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD2AEMANUEL.BLL;
using CRUD2AEMANUEL.Model;

namespace CRUD2AEMANUEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Método para listar os dados no grid
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                dataGridView.DataSource = pessoaBLL.Listar();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao exibir os dados!\n"+erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
