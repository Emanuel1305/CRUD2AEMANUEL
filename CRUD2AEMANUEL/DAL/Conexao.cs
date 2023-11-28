using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUD2AEMANUEL.DAL
{
    public class Conexao
    {
        //Propriedades para conectar com banco de dados
        string conecta = "SERVER=localhost; DATABASE=pessoas; UID=root; PWD=Suporte99";

        protected MySqlConnection conexao = null;

        //Método  para conectar ao banco de dados
        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
        //Método para fechar a conexão
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
