using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using WebSite.Models;

namespace Website.Models
{
    public class Usuario
    {
        public Int32 ID { get; set; }
        public String Email { get; set; }
        public String Nick { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public String Senha { get; set; }
        public String Nascimento { get; set; }
        public String Bio { get; set; }
        public String ImagemPerfil { get; set; }
        
        public Usuario() { }

        public Usuario(Int32 ID)
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "SELECT * FROM Usuario WHERE ID=@ID;";
            Comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader Leitor = Comando.ExecuteReader();

            Leitor.Read();

            this.ID = (Int32)Leitor["ID"];
            this.Email = (String)Leitor["EmailU"];
            this.Senha = (String)Leitor["SenhaU"];

            Conexao.Close();
        }
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
        public Boolean Novo()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "INSERT INTO Usuario (ID, EmailU, NickU, NomeU, SobrenomeU, SenhaU, NascimentoU, BioU, ImagemU, Adm)"
              + "VALUES (@ID, @Email, @NickU, @Nome, @Sobrenome, @Senha, @Nascimento, @Bio, @ImagemPerfil, @Adm);";
            Comando.Parameters.AddWithValue("@IDUsuario", this.ID);
            Comando.Parameters.AddWithValue("@Email", this.Email);
            Comando.Parameters.AddWithValue("@NickU", this.Nick);
            Comando.Parameters.AddWithValue("@Nome", this.Nome);
            Comando.Parameters.AddWithValue("@Sobrenome", this.Sobrenome);
            Comando.Parameters.AddWithValue("@Senha", this.Senha);
            Comando.Parameters.AddWithValue("@Nascimeto", this.Nascimento);
            Comando.Parameters.AddWithValue("@Bio", "Biografia");
            Comando.Parameters.AddWithValue("@ImagemPerfil", this.ImagemPerfil);
            Comando.Parameters.AddWithValue("@Adm", 0);



            Int32 Resultado = Comando.ExecuteNonQuery();

            Conexao.Close();

            return Resultado > 0 ? true : false;
        }
        public static List<Usuario> ListarU()
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
                U.Nick = Leitor["NickU"].ToString();
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
        
        
        public Boolean Apagar()
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["KatiauBD"].ConnectionString);
            Conexao.Open();

            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexao;
            Comando.CommandText = "DELETE FROM Usuario WHERE ID = @ID;";
            Comando.Parameters.AddWithValue("@ID", this.ID);

            Int32 Resultado = Comando.ExecuteNonQuery();

            

            return Resultado > 0 ? true : false;
        }
        
        public static String Autenticar(String Email, String Senha){
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