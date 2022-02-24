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
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Collections;
using System.Configuration;
using System.IO;


namespace FeiranteAPI.Controllers
{
    [ApiController]
    [Route("Api/Feirante")]
    public class FeiranteController : Controller
    {
        //instancia e cria uma conexão á base de dados
        SqlConnection connection = new SqlConnection((@"Server=tcp:isi2020.database.windows.net,1433;Initial Catalog=ISI2020;Persist Security Info=False;User ID=isi2020;Password=qwerty123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));


        /// <summary>
        /// Insere novo Feirante
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpPost("AdicionarFeirante")]
        public bool Feirante(Feirante x)
        {
            // abre conexao
            connection.Open();

            try
            {

                // criar query
                string query = "INSERT INTO Feirante ( Cod_id, Nome, Cc_number, Contacto, Localidade, Username, Pass, Email) VALUES (@Cod_id, @Nome, @Cc_number, @Contacto, @Localidade, @Username, @Pass, @Email)";

                SqlCommand cmd = new SqlCommand(query, connection);

                // Instancia parametros
                cmd.Parameters.AddWithValue("@cod_id", x.Cod_id);
                cmd.Parameters.AddWithValue("@Nome", x.Nome);
                cmd.Parameters.AddWithValue("@Cc_number", x.Cc_number);
                cmd.Parameters.AddWithValue("@Contacto", x.Contacto);
                cmd.Parameters.AddWithValue("@Localidade", x.Localidade);
                cmd.Parameters.AddWithValue("@Username", x.Username);
                cmd.Parameters.AddWithValue("@Pass", x.Pass);
                cmd.Parameters.AddWithValue("@Email", x.Email);

                // executa a query e retorna o numero de linhas afetadas
                int cnt = cmd.ExecuteNonQuery();

                // fecha conexão
                connection.Close();


                if (cnt > 0)
                {
                    return true;    // Foi adicionado
                }
                else
                {
                    return false;  // Não foi adicionado
                }


            }
            catch (Exception ErroInserirValues)
            {
                throw new Exception(ErroInserirValues.Message);
            }
        }

        /// <summary>
        /// Elimina os Feirantes pelo cod_id
        /// </summary>
        /// <param name="cod_id"></param>
        /// <returns></returns>
        [HttpDelete("RemoveFeirante/{cod_id}")]
        public bool DeleteFeirante(int cod_id)
        {
            try
            {
            
                // abre conexão
                connection.Open();

                // cria query
                string query = "DELETE FROM Feirante WHERE  @cod_id = cod_id ";
                SqlCommand cmd = new SqlCommand(query, connection);
                int feirantes;

                // instancia parametro
                cmd.Parameters.AddWithValue("@cod_id", cod_id);

                // executa query e retorna numero de linhas afetadas
                feirantes = cmd.ExecuteNonQuery();



                connection.Close();

                if (feirantes >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Mostra os feirantes
        /// </summary>
        /// <returns></returns>
        [HttpGet("VerFeirantes")]
        public string GetFeirante()
        {


            // abrir conexão
            connection.Open();
            try
            {
 
                // cria query (Feirante)
                string query = "Select * FROM Feirante";

                SqlDataAdapter cmd = new SqlDataAdapter(query, connection);

                DataTable dt = new DataTable();

                // preenche dataset com o resultado da querry
                cmd.Fill(dt);

                //Cria uma lista com feirantes
                List<Feirante> h = new List<Feirante>();

                // Percorre a datatable e adiciona á lista
                foreach (DataRow line in dt.Rows)
                {

                    Feirante novoFeirante = new Feirante(
                        Convert.ToInt32(line["Cod_id"]),
                        line["nome"].ToString(),
                        Convert.ToInt32(line["cc_number"]),
                        Convert.ToInt32(line["contacto"]),
                        line["localidade"].ToString(),
                        line["username"].ToString(),
                        line["pass"].ToString(),
                        line["email"].ToString()
                        );

                    h.Add(novoFeirante);
                }

                // serializa para json
                string jsonString = JsonConvert.SerializeObject(dt);

                

                return jsonString;
            }
            //
            catch (Exception Erro)
            {
                // fecha conexão
                connection.Close();
                throw new Exception("Erro" + Erro.Message);
            }

           

        }
    
    }
}
