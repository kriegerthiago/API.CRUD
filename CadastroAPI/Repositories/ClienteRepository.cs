using CadastroAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace CadastroAPI.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }



        public JsonResult GetAll()
        {
            string query = @"select id as ""id"", nome as ""nome"", cpf as ""cpf"",
                DataNasc as ""datanasc"", telefoneum as ""telefoneum"", telefonedois as ""telefonedois"" from tableCadastro";



            DataTable table = new DataTable();
            NpgsqlDataReader myreader;
            using (NpgsqlConnection conexao = new NpgsqlConnection(Con))
            {
                conexao.Open();
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {
                    myreader = comando.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    conexao.Close();


                }
                return new JsonResult(table);
            }



        }

        public JsonResult PostAll(string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois)
        {
            string query =
                @"INSERT INTO tableCadastro (nome,cpf,datanasc,telefoneum,telefonedois) VALUES (@nome, 
                   @cpf, @datanasc, @telefoneum, @telefonedois)";


            DataTable table = new DataTable();
            

            NpgsqlDataReader myreader;
            using (NpgsqlConnection conexao = new NpgsqlConnection(Con))
            {
                conexao.Open();
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {


                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);                    
                    comando.Parameters.AddWithValue("@datanasc", datanasc);
                    comando.Parameters.AddWithValue("@telefoneum", telefoneum);
                    comando.Parameters.AddWithValue("@telefonedois", telefonedois);



                    myreader = comando.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    conexao.Close();


                }
                return new JsonResult("Pessoa Adicionada com Sucesso!");
            }
        }

        public JsonResult PutAll( int id,string nome, string cpf, DateTime datanasc, string telefoneum, string telefonedois)
        {
            string query =
                @"UPDATE tableCadastro SET nome=@nome,cpf=@cpf,
                datanasc=@datanasc,telefoneum=@telefoneum, telefonedois=@telefonedois WHERE id=@id";



            DataTable table = new DataTable();

            NpgsqlDataReader myreader;
            using (NpgsqlConnection conexao = new NpgsqlConnection(Con))
            {
                conexao.Open();
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@cpf", cpf);                    
                    comando.Parameters.AddWithValue("@datanasc", datanasc);
                    comando.Parameters.AddWithValue("@telefoneum", telefoneum);
                    comando.Parameters.AddWithValue("@telefonedois", telefonedois);

                    myreader = comando.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    conexao.Close();


                }
                return new JsonResult("Update realizado com Sucesso");

            }
        }

        public JsonResult DeleteAll(string cpf)
        {
            string query = @"DELETE from tableCadastro WHERE cpf = @cpf";

            DataTable table = new DataTable();
            NpgsqlDataReader myreader;
            using (NpgsqlConnection conexao = new NpgsqlConnection(Con))
            {
                conexao.Open();
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", cpf);
                    myreader = comando.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    conexao.Close();

                }
                return new JsonResult("Usuário deletado com Sucesso");
            }


        }
    }
}
