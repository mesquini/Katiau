using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Website.Models
{
    public class Categoria
    {
        public Int32 ID { get; set; }
        public String Titulo { get; set; }

        public Categoria() { }

        public Categoria(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Categoria WHERE ID=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.Titulo = (String)Leitor["Titulo"];

            Conexao.Close();
        }
        public Boolean Salvar()
        {
            throw new NotImplementedException();
        }

        public Boolean Alterar()
        {
            throw new NotImplementedException();
        }

        public Boolean Remover()
        {
            throw new NotImplementedException();
        }

        public static List<Categoria> Lista()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT NomeProduto, VersaoProduto, ImagemProduto, DescricaoProduto, PrecoProduto,Categoria.NomeCategoria FROM Produto,Categoria WHERE Produto.CategoriaID = Categoria.ID;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Categoria> Categorias = new List<Categoria>();
            while (Leitor.Read())
            {
                Categoria C = new Categoria();
                C.ID = (Int32)Leitor["ID"];
                C.Titulo = (String)Leitor["Titulo"];

                Categorias.Add(C);
            }

            Conexao.Close();

            return Categorias;
        }
    }
}