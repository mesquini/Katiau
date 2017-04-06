using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace WebSite.Models
{
    public class Pacote
    {

        public Int32 ID { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public String Imagem { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public Pacote() { }
    

    public Pacote(String ID)
    {
        SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
        Conexao.Open();

        SqlCommand Comando = new SqlCommand();
        Comando.Connection = Conexao;
        Comando.CommandText = "SELECT * FROM Produto;";
        Comando.Parameters.AddWithValue("CategoriaID", ID);

        SqlDataReader Leitor = Comando.ExecuteReader();

        Leitor.Read();

        this.ID = (Int32)Leitor["ID"];
        this.Nome = (String)Leitor["NomeProduto"];
        this.Categoria = (String)Leitor["NomeCategoria"];
        this.Imagem = (String)Leitor["ImagemProduto"];
        this.Descricao = (String)Leitor["DescricaoProduto"];
        this.Preco = (Double)Leitor["PrecoProduto"];

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
        public static List<Pacote> ListarP()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT NomeProduto, Categoria.NomeCategoria, ImagemProduto, DescricaoProduto, PrecoProduto FROM Produto,Categoria WHERE Produto.CategoriaID = 3 AND Categoria.NomeCategoria = 'Pacote'; ";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Pacote> Prods = new List<Pacote>();
            while (Leitor.Read())
            {
                Pacote P = new Pacote();
                P.Nome = ((String)Leitor["NomeProduto"]);
                P.Categoria = (String)Leitor["NomeCategoria"];
                P.Imagem = ((String)Leitor["ImagemProduto"]);
                P.Descricao = (String)Leitor["DescricaoProduto"];
                P.Preco = (Double)Leitor["PrecoProduto"];


                Prods.Add(P);
            }

            Conexao.Close();

            return Prods;
        }
       

    }

}