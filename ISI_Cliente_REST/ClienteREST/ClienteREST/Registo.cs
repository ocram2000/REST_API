/*                    IPCA
 *                  2020/2021
 *                    LESI
 *             Trabalho Prático ISI
 *                Pedro Barros
 *                Marco Henriques
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

//using System.Runtime.Serialization.Json;


namespace ClienteREST
{
    public partial class Registo : Form
    {
        public Registo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InsFeirante_Click(object sender, EventArgs e)
        {
            //verificar se foi introduzio alguma coisa
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" )
            {
                //criar o objeto com os dados introduzidos
                Feirante pessoa = new Feirante(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text),int.Parse(textBox4.Text), textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);

                //analisa o pedido e introduz na BD
                using (HttpClient client = new HttpClient())
                {
                    string Url = "https://localhost:44385/Api/Feirante/AdicionarFeirante";
                   // string Url = "https://tp2isi-apim.azure-api.net/Api/Feirante/AdicionarFeirante";

                    // serializa o objeto para json
                    string jsonString = JsonConvert.SerializeObject(pessoa);

                    // obtem os cabeçalhos que são enviados em cada solicitação
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // constroi o pedido
                    var request = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // manda um pedido para o uri , e retorna o resultado desse pedido -> resposta
                    var response = client.PostAsync(Url, request).Result;

                    // le o resultado da resposta
                    var result = response.Content.ReadAsStringAsync();

                    MessageBox.Show("Sucesso!", "Sucesso");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Introduza dados!", "Erro");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InsFeira_Click(object sender, EventArgs e)
        {
            //verificar se foi introduzio alguma coisa
            if (textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
            {
                //criar o objeto com os dados introduzidos
                Feira evento = new Feira(int.Parse(textBox9.Text), textBox10.Text, textBox11.Text, textBox12.Text);

                //analisa o pedido e introduz na BD
                using (HttpClient client = new HttpClient())
                {
                    string Url = "https://localhost:44385/Api/Feira/AdicionarFeira";
                    //string Url = "https://tp2isi-apim.azure-api.net/Api/Feira/AdicionarFeira";
                    // serializa o objeto para json
                    string jsonString = JsonConvert.SerializeObject(evento);

                    // obtem os cabeçalhos que são enviados em cada solicitação
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // constroi o pedido
                    var request = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // manda um pedido para o uri , e retorna o resultado desse pedido -> resposta
                    var response = client.PostAsync(Url, request).Result;

                    // le o resultado da resposta
                    var result = response.Content.ReadAsStringAsync();

                    MessageBox.Show("Sucesso!", "Sucesso");

                    //clear
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Introduza dados!", "Erro");
            }
        }

        private void RmvFeirante_Click(object sender, EventArgs e)
        {
            //verificar se foi introduzio alguma coisa
            if (textBox1.Text != "")
            {
                //criar o objeto com os dados introduzidos
                int codigo = (int.Parse(textBox1.Text)/*, textBox6.Text, textBox7.Text*/);

                //analisa o pedido e introduz na BD
                using (HttpClient client = new HttpClient())
                {
                    string Url = "https://localhost:44385/Api/Feirante/RemoveFeirante/"+ textBox1.Text;
                    //string Url = "https://tp2isi-apim.azure-api.net/Api/Feirante/RemoveFeirante/"+ textBox1.Text;

                    // serializa o objeto para json
                    string jsonString = JsonConvert.SerializeObject(codigo);

                    // obtem os cabeçalhos que são enviados em cada solicitação
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // constroi o pedido
                    var request = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // manda um pedido para o uri , e retorna o resultado desse pedido -> resposta
                    var response = client.PostAsync(Url, request).Result;

                    // le o resultado da resposta
                    var result = response.Content.ReadAsStringAsync();

                    MessageBox.Show("Sucesso!", "Sucesso");

                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Introduza dados!", "Erro");
            }
        }

        private void GetFeirante_Click(object sender, EventArgs e)
        {
            GetFeirante f2 = new GetFeirante();
            f2.ShowDialog();
        }

        private void RmvFeira_Click(object sender, EventArgs e)
        {
            // verificar se foi introduzio alguma coisa
            if (textBox9.Text != "")
            {
                //criar o objeto com os dados introduzidos
                int codigo = (int.Parse(textBox9.Text)/*, textBox6.Text, textBox7.Text*/);

                //analisa o pedido e introduz na BD
                using (HttpClient client = new HttpClient())
                {
                    string Url = "https://localhost:44385/Api/Feira/RemoveFeira/" + textBox9.Text;
                    //string Url = "https://tp2isi-apim.azure-api.net/Api/Feira/RemoveFeira/" + textBox9.Text;
                    // serializa o objeto para json
                    string jsonString = JsonConvert.SerializeObject(codigo);

                    // obtem os cabeçalhos que são enviados em cada solicitação
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // constroi o pedido
                    var request = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // manda um pedido para o uri , e retorna o resultado desse pedido -> resposta
                    var response = client.PostAsync(Url, request).Result;

                    // le o resultado da resposta
                    var result = response.Content.ReadAsStringAsync();

                    MessageBox.Show("Sucesso!", "Sucesso");

                    textBox9.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Introduza dados!", "Erro");
            }
        }

        private void GetMetrologia_Click(object sender, EventArgs e)
        {
            GetMeteorologia f2 = new GetMeteorologia();
            f2.ShowDialog();
        }

        private void GetFeira_Click(object sender, EventArgs e)
        {          
            GetFeira f2 = new GetFeira();
            f2.ShowDialog();            
        }
    }
    
}  

