using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace WebSite.Models
{
    public class Produto
    {

        public Int32 ID { get; set; }
        public String Nome { get; set; }
        public Int32 Versao { get; set; }
        public String Imagem { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public Produto() { }
    

   /* public Produto(Int32 ID)
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
        this.Versao = (Int32)Leitor["VersaoProduto"];
        this.Imagem = (String)Leitor["ImagemProduto"];
        this.Descricao = (String)Leitor["DescricaoProduto"];
        this.Preco = (Double)Leitor["PrecoProduto"];

            Conexao.Close();
    }*/
        public static List<Produto> Listar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT ID,NomeProduto,VersaoProduto,ImagemProduto,DescricaoProduto,PrecoProduto FROM Produto WHERE CategoriaID=3;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Produto> Prods = new List<Produto>();
            while (Leitor.Read())
            {
                Produto P = new Produto();
                P.ID = (Int32)Leitor["ID"];
                P.Nome = ((String)Leitor["NomeProduto"]);
                P.Versao = (Int32)Leitor["VersaoProduto"];
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