using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Website.Models;

namespace WebSite.Models
{
    public class Produto
    {

        public Int32 ID { get; set; }
        public Int32 CategoriaID { get; set; }
        public String Nome { get; set; }
        public int Versao { get; set; }
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
            Comando.CommandText = "SELECT * From Produto WHERE ID = @ID; ";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();


            this.ID = (int)Leitor["ID"];
            this.CategoriaID = (Int32)Leitor["CategoriaID"];
            this.Nome = (String)Leitor["NomeProduto"];
            //this.Versao = (int)Leitor["VersaoCategoria"];
            this.Imagem = (String)Leitor["ImagemProduto"];
            this.Descricao = (String)Leitor["DescricaoProduto"];
            this.Preco = (Double)Leitor["PrecoProduto"];

            Conexao.Close();
        }
        public Boolean NovoProd()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Produto (NomeProduto, CategoriaID, VersaoProduto, ImagemProduto, DescricaoProduto, PrecoProduto) VALUES (@NomeProduto, @CategoriaID, @Versao, @ImagemProduto, @DescricaoProduto, @PrecoProduto);";
            Comando.Parameters.AddWithValue("@NomeProduto", this.Nome);
            Comando.Parameters.AddWithValue("@CategoriaID", this.CategoriaID);
            Comando.Parameters.AddWithValue("@Versao", this.Versao);
            Comando.Parameters.AddWithValue("@ImagemProduto", this.Imagem);
            Comando.Parameters.AddWithValue("@DescricaoProduto", this.Descricao);
            Comando.Parameters.AddWithValue("@PrecoProduto", this.Preco);
            

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public Boolean AlterarProd()
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
            Comando.CommandText = "DELETE FROM Produto WHERE Produto.ID = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.ID);

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
            Comando.CommandText = "SELECT Produto.ID, NomeProduto,Categoria.NomeCategoria, ImagemProduto, DescricaoProduto, PrecoProduto FROM Produto,Categoria WHERE Produto.CategoriaID = 3 AND Categoria.NomeCategoria = 'Pacote'; ";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Produto> Prods = new List<Produto>();
            while (Leitor.Read())
            {
                Produto P = new Produto();
                P.ID = ((Int32)Leitor["ID"]);
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
    public class DLC
    {
        public Int32 ID { get; set; }
        public Int32 CategoriaID { get; set; }
        public String Nome { get; set; }
        public String Categoria { get; set; }
        public String Imagem { get; set; }

        public int Versao { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public DLC() { }
        public DLC(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Produto WHERE ID = @ID";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.CategoriaID = (Int32)Leitor["CategoriaID"];
            this.Nome = (String)Leitor["NomeProduto"];
            this.Imagem = (String)Leitor["ImagemProduto"];
            this.Descricao = (String)Leitor["DescricaoProduto"];
            this.Preco = (Double)Leitor["PrecoProduto"];

            Conexao.Close();
        }
        public static List<DLC> ListarDLC()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT Produto.ID, CategoriaID, NomeProduto, Categoria.NomeCategoria, ImagemProduto, DescricaoProduto, PrecoProduto FROM Produto,Categoria WHERE Produto.CategoriaID = 2 AND Categoria.NomeCategoria = 'DLC';";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<DLC> DLC = new List<DLC>();
            while (Leitor.Read())
            {
                DLC D = new DLC();
                D.ID = ((Int32)Leitor["ID"]);
                D.CategoriaID = ((Int32)Leitor["CategoriaID"]);
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
        public Boolean NovaDLC()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Produto (NomeProduto, CategoriaID, VersaoProduto, ImagemProduto, PrecoProduto, DescricaoProduto) VALUES (@Nome, @CategoriaID, @VersaoProduto, @Imagem, @Preco, @Descricao);";
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@CategoriaID", this.CategoriaID);
            Comando.Parameters.AddWithValue("@VersaoProduto", this.Versao);
            Comando.Parameters.AddWithValue("@Imagem", this.Imagem);
            Comando.Parameters.AddWithValue("@Preco", this.Preco);
            Comando.Parameters.AddWithValue("@Descricao", this.Descricao);


            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public Boolean AlterarDLC()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "UPDATE Produto SET NomeProduto = @NomeProduto, ImagemProduto = @ImagemProduto, PrecoProduto = @PrecoProduto, DescricaoProduto = @DescricaoProduto WHERE Produto.CategoriaID = 2;";
            Comando.Parameters.AddWithValue("@NomeProduto", this.Nome);
            Comando.Parameters.AddWithValue("@ImagemProduto", this.Imagem);
            Comando.Parameters.AddWithValue("@PrecoProduto", this.Preco);
            Comando.Parameters.AddWithValue("@DescricaoProduto", this.Descricao);

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
            Comando.CommandText = "DELETE FROM Produto WHERE Produto.ID = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
    }
}