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
        public String Titulo { get; set; }
        public String Texto { get; set; }
        public int Autor { get; set; }
        public String Imagem { get; set; }
        public DateTime Data { get; set; }

        public Post() { }

        public Post(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Posts WHERE Autor=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.Autor = (Int32)Leitor["Autor"];
            this.Titulo = (String)Leitor["Titulo"];
            this.Texto = (String)Leitor["Texto"];
            this.Data = (DateTime)Leitor["Data"];

            Conexao.Close();
        }

        public Boolean Salvar(int idUser)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Posts (Autor, Titulo, Texto, Data) VALUES (@Autor, @Titulo, @Texto, GETDATE());";
            Comando.Parameters.AddWithValue("@Autor", idUser);
            Comando.Parameters.AddWithValue("@Titulo", this.Titulo);
            Comando.Parameters.AddWithValue("@Texto", this.Texto);

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        public Boolean Alterar(int ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "UPDATE Posts SET Titulo = @Titulo, Texto = @Texto, Imagem = @Imagem WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@Imagem", this.Imagem);
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
                P.Titulo = (String)Leitor["Titulo"];
                P.Texto = (String)Leitor["Texto"];

                Posts.Add(P);
            }

            Conexao.Close();

            return Posts;
        }
    }
}