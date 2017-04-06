using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Website.Models;
namespace Website.Models
{
    public class Post
    {
        public Int32 ID { get; set; }
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
        public String Titulo { get; set; }
        public String Texto { get; set; }
        public DateTime DataPostagem { get; set; }

        public Post() { }

        public Post(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Post WHERE ID=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.Usuario = new Usuario((Int32)Leitor["IDUsuario"]);
            this.Categoria = new Categoria((Int32)Leitor["IDCategoria"]);
            this.Titulo = (String)Leitor["Titulo"];
            this.Texto = (String)Leitor["Texto"];
            this.DataPostagem = (DateTime)Leitor["DataPostagem"];

            Conexao.Close();
        }

        public Boolean Salvar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Post (IDUsuario, IDCategoria, Titulo, Texto, DataPostagem) VALUES (@IDUsuario, @IDCategoria, @Titulo, @Texto, GETDATE());";
            Comando.Parameters.AddWithValue("@IDUsuario", this.Usuario.ID);
            Comando.Parameters.AddWithValue("@IDCategoria", this.Categoria.ID);
            Comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            Comando.Parameters.AddWithValue("@Texto", this.Texto);

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
            Comando.CommandText = "UPDATE Post SET IDCategoria = @IDCategoria, Titulo = @Titulo, Texto = @Texto WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@IDCategoria", this.Categoria.ID);
            Comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            Comando.Parameters.AddWithValue("@Texto", this.Texto);
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public Boolean Remover()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Post WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public static List<Post> Listar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Post ORDER BY DataPostagem DESC;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Post> Posts = new List<Post>();
            while (Leitor.Read())
            {
                Post P = new Post();
                P.ID = (Int32)Leitor["ID"];
                P.Usuario = new Usuario((Int32)Leitor["IDUsuario"]);
                P.Categoria = new Categoria((Int32)Leitor["IDCategoria"]);
                P.Titulo = (String)Leitor["Titulo"];
                P.Texto = (String)Leitor["Texto"];
                P.DataPostagem = (DateTime)Leitor["DataPostagem"];

                Posts.Add(P);
            }

            Conexao.Close();

            return Posts;
        }
    }
}