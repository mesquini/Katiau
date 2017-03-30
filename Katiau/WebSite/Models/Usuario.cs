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
        public String Bio { get; set; }
        public String ImagemPerfil { get; set; }
        

        public Usuario() { }

        public Usuario(String Email, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Usuario WHERE EmailU=@Email AND SenhaU=@Senha;";
            Comando.Parameters.AddWithValue("@Email", Email);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.Email = (String)Leitor["EmailU"];
            this.Senha = (String)Leitor["SenhaU"];

            Conexao.Close();
        }

        public Boolean Salvar(String Email, String senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Usuario (ID, Email, Nome, Sobrenome, Senha, Nascimento, ImagemPerfil)"
              + "VALUES (@ID, @Email, @Nome, @Sobrenome, @Senha, @Nascimento, @ImagemPerfil GETDATE());";
            Comando.Parameters.AddWithValue("@IDUsuario", this.ID);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
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
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Usuario;";

            SqlDataReader Leitor = Comando.ExecuteReader();

            List<Usuario> Users = new List<Usuario>();
            while (Leitor.Read())
            {
                Usuario U = new Usuario();
                U.ID = (Int32)Leitor["ID"];
                U.Nome = ((String)Leitor["NomeU"]);
                U.Sobrenome = (String)Leitor["SobrenomeU"];
                U.Email = ((String)Leitor["EmailU"]);
                U.Senha = (String)Leitor["SenhaU"];
                U.Nascimento = (String)Leitor["NascimentoU"];
                U.Bio = (String)Leitor["BioU"];
                U.ImagemPerfil = (String)Leitor["ImagemU"];
                

                Users.Add(U);
            }

            Conexao.Close();

            return Users;
        }

        public static String Autenticar(String Email, String Senha)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);

            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT ID,Administrador FROM Usuario WHERE EmailU=@Email AND SenhaU=@Senha;";
            Comando.Parameters.AddWithValue("@Email", Email);
            Comando.Parameters.AddWithValue("@Senha", Senha);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            if(!Leitor.HasRows)
            {
                Conexao.Close();
                return null;
            }

            Boolean Adm = Boolean.Parse(Leitor["Administrador"].ToString());

            Conexao.Close();

            return Adm ? "Administrador" : "Usuario";
        }
    }
}