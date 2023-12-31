﻿using System;
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

        //Método Limpar
        public void Limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            mtbCPF.Clear();
            mtbCelular.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mtbCEP.Clear();
            cbSexo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtNome.BackColor = Color.White;
            cbSexo.BackColor = Color.White;
            mtbCPF.BackColor = Color.White;
        }

        //Método para editar 
        public void Alterar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.BackColor = Color.LightCoral;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;
                }
                else if (!mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightCoral;
                }
                else if (cbSexo.Text == String.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.LightCoral;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);
                    pessoa.Nome = txtNome.Text;
                    pessoa.Nascimento = dtNascimento.Text;
                    mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                    pessoa.Cpf = mtbCPF.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstado.Text;
                    mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                    pessoa.Cep = mtbCEP.Text;
                    pessoa.Sexo = cbSexo.Text;

                    pessoaBLL.Alterar(pessoa);
                    MessageBox.Show("Cadastro alterado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                    Listar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        //Método para salvar
        private void Salvar(Pessoa pessoa)
        {
            PessoaBLL pessoasBLL = new PessoaBLL();

            if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
            {
                MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.LightCoral;
                cbSexo.BackColor = Color.White;
                mtbCPF.BackColor = Color.White;
            }
            else if (!mtbCPF.MaskCompleted)
            {
                MessageBox.Show("O campo CPF não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.White;
                cbSexo.BackColor = Color.White;
                mtbCPF.BackColor = Color.LightCoral;
            }
            else if (cbSexo.Text == String.Empty)
            {
                MessageBox.Show("O campo SEXO não pode ser vazio!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.White;
                cbSexo.BackColor = Color.LightCoral;
                mtbCPF.BackColor = Color.White;
            }
            else
            {
                pessoa.Nome = txtNome.Text;
                pessoa.Nascimento = dtNascimento.Text;
                mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                pessoa.Cpf = mtbCPF.Text;
                mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                pessoa.Celular = mtbCelular.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Bairro = txtBairro .Text;
                pessoa.Cidade = txtCidade.Text;
                pessoa.Estado = cbEstado.Text;
                mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //Remove a Mascara
                pessoa.Cep = mtbCEP.Text;
                pessoa.Sexo = cbSexo.Text;

                pessoasBLL.Salvar(pessoa);
                MessageBox.Show("Cadastro Reaizado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
        }

        //Método para listar os dados no grid
        private void Listar()
        {
            PessoaBLL pessoasBLL = new PessoaBLL();
            try
            {
                dataGridView.DataSource = pessoasBLL.Listar();

                //renomear coluna
                dataGridView.Columns[0].HeaderText = "Código";
                dataGridView.Columns[1].HeaderText = "Nome";
                dataGridView.Columns[2].HeaderText = "Dt.Nasc";
                dataGridView.Columns[3].HeaderText = "Sexo";
                dataGridView.Columns[4].HeaderText = "CPF";
                dataGridView.Columns[5].HeaderText = "Tel.Celular";
                dataGridView.Columns[6].HeaderText = "Endereço";
                dataGridView.Columns[7].HeaderText = "Bairro";
                dataGridView.Columns[8].HeaderText = "Cidade";
                dataGridView.Columns[9].HeaderText = "UF";
                dataGridView.Columns[10].HeaderText = "CEP";

                //Remover colunas do datagrid
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;

                //Ajuste largura das colunas
                dataGridView.Columns[0].Width = 45;
                dataGridView.Columns[1].Width = 165;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 40;
                dataGridView.Columns[4].Width = 80;
                dataGridView.Columns[5].Width = 90;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw erro;
            }
        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            dtNascimento.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            cbSexo.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            mtbCPF.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            mtbCelular.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtBairro.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            txtCidade.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();
            cbEstado.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            mtbCEP.Text = dataGridView.CurrentRow.Cells[10].Value.ToString(); 
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Alterar(pessoa);
        }
    }
}
