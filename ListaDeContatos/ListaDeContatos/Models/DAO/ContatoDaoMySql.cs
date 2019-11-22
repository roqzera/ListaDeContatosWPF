using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ListaDeContatos.Service;
using ListaDeContatos.Models;
using System.Configuration;

namespace ListaDeContatos
{

    public class ContatoDaoMySql : IContatoDao
    {
        private MySqlConnection con;

        string connectionString = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;

        public void Adicionar(Contato contato)
        {
            con = new MySqlConnection(connectionString);
            String queryInsert = "INSERT INTO contato (nome, idade, cidade) VALUES (?nome, ?idade, ?cidade)";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(queryInsert, con);
                command.Parameters.AddWithValue("?nome",contato.nome);
                command.Parameters.AddWithValue("?idade", contato.idade);
                command.Parameters.AddWithValue("?cidade", contato.cidade);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public Contato BuscarPorId(int IdContato)
        {
            throw new NotImplementedException();
        }

        public List<Contato> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Contato> BuscarTodos()
        {
            List<Contato> contatos = new List<Contato>();
            con = new MySqlConnection(connectionString );
            String querySelect = "select * from contato;";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(querySelect, con);
            cmd.Prepare();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Contato contato = new Contato()
                {
                    IdContato = Convert.ToInt32(dr["id_contato"]),
                    nome = Convert.ToString(dr["nome"]),
                    idade = Convert.ToString(dr["idade"]),
                    cidade = Convert.ToString(dr["cidade"]),
                };
                contatos.Add(contato);
            }
            return contatos;
        }

        public void Remover(Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
