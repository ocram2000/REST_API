/*                    IPCA
 *                  2020/2021
 *                    LESI
 *             Trabalho Prático ISI
 *                Pedro Barros
 *                Marco Henriques
 * 
 * 
 */

using Nancy.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteREST
{
    public partial class GetMeteorologia : Form
    {
        public GetMeteorologia()
        {
            InitializeComponent();
        }

        private void GetMeteorologia_Load(object sender, EventArgs e)
        {

            #region Variaveis
            StringBuilder uri;
            string url;

            // Chave de acesso openweatherapi
            string apiKey = "48dfb4149fbc5cbb3612148c78f57a07";
            //
            HttpWebRequest request;
            #endregion
            try
            {
                url = "http://api.openweathermap.org/data/2.5/forecast?q={cityname}&appid={APIkey}";

                uri = new StringBuilder();
                uri.Append(url);
                uri.Replace("{cityname}", HttpUtility.UrlEncode("Barcelos")); // 2742416 code Barcelos
                uri.Replace("{APIkey}", apiKey);




                #region PreparaPedido
                // Prepara e envia pedido
                request = WebRequest.Create(uri.ToString()) as HttpWebRequest;
                #endregion

                #region EnviaPedidoeAnaliseResposta
                // Analise resposta
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("GET falhou. Recebido HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // Guarda conteudo num stream de memoria
                    var copyStream = new MemoryStream();
                    response.GetResponseStream().CopyTo(copyStream);

                    // Serealiza de json para objeto
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    copyStream.Position = 0L;   // Inicio do stream
                    Root myClass = (Root)jsonSerializer.ReadObject(copyStream);

                    //atribuição das temperaturas máximas e minimas a variáveis
                    double x = myClass.list[0].main.temp_max;
                    double y = myClass.list[0].main.temp_min;

                    //vários campos preenchidos no windows form de metereologia 
                    textBox1.Text = Convert.ToString(ConvertFarToCelsius(x) + "C");
                    textBox2.Text = Convert.ToString(ConvertFarToCelsius(y) + "C");
                    textBox3.Text = Convert.ToString(myClass.list[0].main.humidity + "%");
                    Estado.Text = myClass.list[0].weather[0].description;

                    if (myClass.city.country == "PT")
                    {
                        Pais.Text = "Portugal";
                    }
                    else
                    {
                        Pais.Text = myClass.city.country;
                    }

                    Cidade.Text = myClass.city.name;
                }

                #endregion

            }
            catch (Exception Erro)
            {
                throw new Exception(Erro.Message);
            }
        }

        #region Metodos


        double ConvertFarToCelsius(double x)
        {
            double celsius = (x - 273.15);
            return celsius;
        }
        #endregion

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

/// <summary>
/// Classes obtidas através do json do openweatherapi, https://openweathermap.org/api, utilizando um conversor de json para c# https://json2csharp.com/ 
/// </summary>
#region Weather
public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
    public int humidity { get; set; }
    public double temp_kf { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class Clouds
{
    public int all { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}

public class Sys
{
    public string pod { get; set; }
}

public class List
{
    public int dt { get; set; }
    public Main main { get; set; }
    public List<Weather> weather { get; set; }
    public Clouds clouds { get; set; }
    public Wind wind { get; set; }
    public int visibility { get; set; }
    public double pop { get; set; }
    public Sys sys { get; set; }
    public string dt_txt { get; set; }
}

public class Coord
{
    public double lat { get; set; }
    public double lon { get; set; }
}

public class City
{
    public int id { get; set; }
    public string name { get; set; }
    public Coord coord { get; set; }
    public string country { get; set; }
    public int population { get; set; }
    public int timezone { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Root
{
    public string cod { get; set; }
    public int message { get; set; }
    public int cnt { get; set; }
    public List<List> list { get; set; }
    public City city { get; set; }
}

#endregion
