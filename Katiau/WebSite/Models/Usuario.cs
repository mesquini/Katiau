using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Website.Models
{
    public class Usuario
    {
        public Int32 ID { get; set; }
        public String Email { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String Senha { get; set; }
        public String Nascimento { get; set; }
        public String ImagemPerfil { get; set; }
        public Usuario() { }

        public Usuario(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LPW"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Usuário WHERE ID=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            

            Conexao.Close();
        }

        public Boolean Salvar(String Email, String senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LPW"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Usuario (ID,  Nome, Sobrenome, Email, Senha, , Nascimento, ImagemPerfil)"
              + "VALUES (@ID, @Nome, @Sobrenome, @Email @Senha, @Nascimento, @ImagemPerfil GETDATE());";
            Comando.Parameters.AddWithValue("@IDUsuario", this.ID);
            Comando.Parameters.AddWithValue("@IDCategoria", this.Email);
            Comando.Parameters.AddWithValue("@Titulo", this.Nome);
            Comando.Parameters.AddWithValue("@Sobrenome", this.Sobrenome);
            Comando.Parameters.AddWithValue("@Senha", this.Senha);
            Comando.Parameters.AddWithValue("@Nascimeto", this.Nascimento);
            Comando.Parameters.AddWithValue("@ImagemPerfil", this.ImagemPerfil);
           
            

            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }

        

      

        public static List<Usuario> Listar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["LPW"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Usuario;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Usuario> Posts = new List<Usuario>();
            while (Leitor.Read())
            {
                Usuario U = new Usuario();
                U.ID = (Int32)Leitor["ID"];
                U.Email = ((String)Leitor["Email"]);
                U.Nome = ((String)Leitor["Nome"]);
                U.Sobrenome = (String)Leitor["Sobrenome"];
                U.Senha = (String)Leitor["Senha"];
                U.Nascimento = (String)Leitor["Nascimento"];
                U.ImagemPerfil = (String)Leitor["ImagemPerfil"];

                Posts.Add(U);
            }

            Conexao.Close();

            return Posts;
        }
    }
}