/*                    IPCA
 *                  2020/2021
 *                    LESI
 *             Trabalho Prático ISI
 *                Pedro Barros
 *                Marco Henriques
 * 
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeiranteAPI.Models;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;


namespace FeiranteAPI.Controllers
{
    [ApiController]
    [Route("Api/Feira")]
    public class FeiraController : Controller
    {
        
        //instancia e cria uma conexão á base de dados
        SqlConnection connection = new SqlConnection((@"Server=tcp:isi2020.database.windows.net,1433;Initial Catalog=ISI2020;Persist Security Info=False;User ID=isi2020;Password=qwerty123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

        [HttpPost("AdicionarFeira")]
        public bool Feira(Feira x)
        {
            try
            {
                // criar query
                string query = "INSERT INTO Feira ( Cod_id, Nome, cidade, concelho) VALUES (@Cod_id, @Nome, @Cidade, @Concelho)";
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
               
                // instancia parametros
                cmd.Parameters.AddWithValue("@cod_id", x.Cod_id);
                cmd.Parameters.AddWithValue("@Nome", x.Nome);
                cmd.Parameters.AddWithValue("@Cidade", x.Cidade);
                cmd.Parameters.AddWithValue("@Concelho", x.Concelho);

                //executa quary e vai retornar numero de linhas afetadas
                int cnt = cmd.ExecuteNonQuery();

                // fecha conexão
                connection.Close();

                if (cnt == 1) return true; // Foi adicionado

                return false;  // Não foi adicionado
            }
            catch (Exception cod_idEmUso)
            {
                throw new Exception(cod_idEmUso.Message);
            }

        }
 



        [HttpDelete("RemoveFeira")]
        public bool DeleteFeira(int cod_id)
        {
            int feira;
            // abre conexão
            connection.Open();

            // cria query
            string query = "DELETE FROM Feira WHERE  @cod_id = cod_id ";

            SqlCommand cmd = new SqlCommand(query, connection);

            // instancia parametro
            cmd.Parameters.AddWithValue("@cod_id", cod_id);

            // executa query 
            feira = cmd.ExecuteNonQuery();


            // fecha conexão
            connection.Close();

            if (feira >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        [HttpGet("VerFeira")]
        public string GetFeira()
        {

            // abrir conexão
            connection.Open();
            try
            {
                // cria query
                string query = "Select * FROM Feira";

                SqlDataAdapter cmd = new SqlDataAdapter(query, connection);

                // Variavel temporaria
                DataTable dt = new DataTable();
                // preenche dataset com o resultado da querry
                cmd.Fill(dt);

                //Cria uma lista com feiras
                List<Feira> f = new List<Feira>();

                //Percorre colunas da data table e adiciona lista
                foreach (DataRow line in dt.Rows)
                {

                    Feira novoFeira = new Feira(
                        Convert.ToInt32(line["cod_id"]),
                        line["nome"].ToString(),
                        line["cidade"].ToString(),
                        line["concelho"].ToString()
                        );

                    f.Add(novoFeira);
                }

                // serializa para json
                string jsonString = JsonConvert.SerializeObject(dt);

                return jsonString;

            }
            catch (Exception ErroVisualizarFeira)
            {
                // fecha conexão
                connection.Close();
                throw new Exception(ErroVisualizarFeira.Message);
            }

        }

    }
}

