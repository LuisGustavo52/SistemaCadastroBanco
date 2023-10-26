using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=banco_bandas");
        public string mensagem;
        
        public bool insereBanda(Banda novaBanda)
        {
            try { 
             conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_insert", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nome", novaBanda.Nome);
                cmd.Parameters.AddWithValue("ranking", novaBanda.Ranking);
                cmd.Parameters.AddWithValue("integrantes", novaBanda.Integrantes);
                cmd.Parameters.AddWithValue("genero", novaBanda.Genero);
                cmd.ExecuteNonQuery(); //executar no banco
             return true;
            }catch(MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }

        } 
    }
}
