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
using System.Linq;
using System.Threading.Tasks;


namespace ClienteREST
{
    public class Feirante
    {
        #region Estados
        int Cod_id;
        string nome;
        int cc_number;
        int contacto;
        string localidade;
        string username;
        string pass;
        string email;
        #endregion

        #region Construtores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cod_id"></param>
        /// <param name="nome"></param>
        /// <param name="cc_number"></param>
        /// <param name="contacto"></param>
        /// <param name="localidade"></param>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <param name="email"></param>
        public Feirante(int cod_id, string nome, int cc_number, int contacto, string localidade, string username, string pass, string email)
        {
            this.cod_id = cod_id;
            this.nome = nome;
            this.cc_number = cc_number;
            this.contacto = contacto;
            this.localidade = localidade;
            this.username = username;
            this.pass = pass;
            this.email = email;

        }

        /// <summary>
        /// Construtor Feirante por omissão
        /// </summary>
        public Feirante()
        {
           
        }
        #endregion

        #region Propriedades

        public int cod_id
        {
            get { return Cod_id; }
            set { Cod_id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public int Cc_number
        {
            get { return cc_number; }
            set { cc_number = value; }
        }



        public int Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }


        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }


        public string Username
        {
            get { return username; }

            set { username = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return string.Format("Dados Feirante: ID:{0}/nNome:{1}/nCC:{2}/nContacto:{3}/nLocalidade:{4}/nUsername:{5}/nPass:{6}/nEmail:{7}", Cod_id, Nome, Cc_number, Contacto, Localidade, Username, Pass, Email);
        }
        #endregion        
    }

}
