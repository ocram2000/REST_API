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
    public partial class GetFeirante : Form
    {
        public GetFeirante()
        {
            InitializeComponent();
        }

        private void GetFeirante_Load(object sender, EventArgs e)
        {
            string url = "https://localhost:44385/Api/Feirante/VerFeirantes";
            //string url = "https://tp2isi-apim.azure-api.net/Api/Feirante/VerFeirantes";


            WebClient client = new WebClient();

            //
            string json = client.DownloadString(url);

            //
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Feirante>));

            //lê uma sequencia de bytes da string json
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));

            List<Feirante> h = (List<Feirante>)jsonSerializer.ReadObject(ms);

            // Percorre a Lista e atribui cada objeto a uma coluna
            foreach (Feirante f in h)
            {
                string[] row = new string[] { f.cod_id.ToString(), f.Nome.ToString(), f.Cc_number.ToString(), f.Contacto.ToString(), f.Localidade.ToString(), f.Username.ToString(), f.Pass.ToString(), f.Email.ToString() };
                dataGridGetFeirante.Rows.Add(row);

            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
