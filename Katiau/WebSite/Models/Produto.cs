using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace WebSite.Models
{
    public class Produto
    {

        public Int32 ID { get; set; }
        public Int32 CategoriaID { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public String Imagem { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public Produto() { }
    

    public Produto(Int32 ID)
    {
        SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
        Conexao.Open();

        SqlCommand Comando = new SqlCommand();
        Comando.Connection = Conexao;
        Comando.CommandText = "SELECT * FROM Produto WHERE ID=@ID;";
        Comando.Parameters.AddWithValue("@ID", ID);

        SqlDataReader Leitor = Comando.ExecuteReader();

        Leitor.Read();

        this.ID = (Int32)Leitor["ID"];
        this.CategoriaID = (Int32)Leitor["CategoriaID"];
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
            Comando.Parameters.AddWithValue("@NomeProduto", this.Nome);
            Comando.Parameters.AddWithValue("@NomeCategoria", this.Categoria);
            Comando.Parameters.AddWithValue("@ImagemProduto", this.Imagem);
            Comando.Parameters.AddWithValue("@PrecoProduto", this.Preco);
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
            Comando.CommandText = "UPDATE Produto SET NomeProduto = @NomeProduto, NomeCategoria = @NomeCategoria, ImagemProduto = @ImagemProduto, PrecoProduto = @PrecoProduto WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@NomeProduto", this.Nome);
            Comando.Parameters.AddWithValue("@NomeCategoria", this.Categoria);
            Comando.Parameters.AddWithValue("@ImagemProduto", this.Imagem);
            Comando.Parameters.AddWithValue("@PrecoProduto", this.Preco);
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
        public static List<Produto> ListarP()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT NomeProduto, Categoria.NomeCategoria, ImagemProduto, DescricaoProduto, PrecoProduto FROM Produto,Categoria WHERE Produto.CategoriaID = 3 AND Categoria.NomeCategoria = 'Pacote'; ";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Produto> Prods = new List<Produto>();
            while (Leitor.Read())
            {
                Produto P = new Produto();
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