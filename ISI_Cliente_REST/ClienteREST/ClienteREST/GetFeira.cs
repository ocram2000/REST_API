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
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteREST
{
    public partial class GetFeira : Form
    {
        public GetFeira()
        {
            InitializeComponent();
        }

        private void GetFeira_Load(object sender, EventArgs e)
        {
            string url = "https://localhost:44385/Api/Feira/VerFeira";
            //string url = "https://tp2isi-apim.azure-api.net/Api/Feira/VerFeira";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            // DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Feirante>),settings);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Feira>));
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));

            // Lê o texto de json diretamente de uma stream 
            List<Feira> h = (List<Feira>)jsonSerializer.ReadObject(ms);
            foreach (Feira f in h)
            {
                string[] row = new string[] { f.cod_id.ToString(), f.nome.ToString(), f.cidade.ToString(), f.concelho.ToString() };
                dataGridViewGetFeira.Rows.Add(row);


            }
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
