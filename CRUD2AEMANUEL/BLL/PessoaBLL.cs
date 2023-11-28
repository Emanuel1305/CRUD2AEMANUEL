using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD2AEMANUEL.DAL;
using System.Data;

namespace CRUD2AEMANUEL.BLL
{
    public class PessoaBLL
    {
        PessoaDAL pessoaDAL = new PessoaDAL();
        //Método para listar
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDAL.Listar();
                return dt; 
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
