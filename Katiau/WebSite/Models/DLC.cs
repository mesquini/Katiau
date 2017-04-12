﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class DLC
    {


        public Int32 ID { get; set; }
        public Int32 CategoriaID { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public String Imagem { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public DLC() { }


        public DLC(Int32 ID)
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

        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Produto (Nome, Categoria, Imagem, Preco) VALUES (@Nome, @Categoria, @Imagem, @Preco);";
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Categoria", this.Categoria);
            Comando.Parameters.AddWithValue("@Imagem", this.Imagem);
            Comando.Parameters.AddWithValue("@Descricao", this.Descricao);
            Comando.Parameters.AddWithValue("@Preco", this.Preco);
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public Boolean Alterar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "UPDATE Produto SET Nome = @Nome, Categoria = @Categoria, Imagem = @Imagem, Descricao = @Descricao, Preco = @Preco WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Categoria", this.Categoria);
            Comando.Parameters.AddWithValue("@Imagem", this.Imagem);
            Comando.Parameters.AddWithValue("@Descricao", this.Descricao);
            Comando.Parameters.AddWithValue("@Preco", this.Preco);
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Produto WHERE CategoriaID = @CategoriaID;";
            Comando.Parameters.AddWithValue("@CategoriaID", this.CategoriaID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<DLC> ListarDLC()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT NomeProduto, Categoria.NomeCategoria, ImagemProduto, DescricaoProduto, PrecoProduto FROM Produto,Categoria WHERE Produto.CategoriaID = 2 AND Categoria.NomeCategoria = 'DLC';";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<DLC> DLC = new List<DLC>();
            while (Leitor.Read())
            {
                DLC D = new DLC();
                D.Nome = ((String)Leitor["NomeProduto"]);
                D.Categoria = (String)Leitor["NomeCategoria"];
                D.Imagem = ((String)Leitor["ImagemProduto"]);
                D.Descricao = (String)Leitor["DescricaoProduto"];
                D.Preco = (Double)Leitor["PrecoProduto"];


                DLC.Add(D);
            }

            Conexao.Close();

            return DLC;
        }
    }
}