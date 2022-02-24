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
    public class Feira
    {

        #region Estados
        int Cod_id;
        string Nome;
        string Cidade;
        string Concelho;

        #endregion

        #region Construtores
        /// <summary>
        /// Construtor Feirante por omissão
        /// </summary>
        public Feira()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cod_id"></param>
        /// <param name="nome"></param>
        /// <param name="cidade"></param>
        /// <param name="concelho"></param>
        public Feira(int cod_id, string nome, string cidade, string concelho)
        {
            this.Cod_id = cod_id;
            this.Nome = nome;
            this.Cidade = cidade;
            this.Concelho = concelho;


        }
        #endregion

        #region Propriedades

        public int cod_id
        {
            get { return Cod_id; }
            set { Cod_id = value; }
        }

        public string nome
        {
            get { return Nome; }
            set { Nome = value; }
        }


        public string cidade
        {
            get { return Cidade; }
            set { Cidade = value; }
        }



        public string concelho
        {
            get { return Concelho; }
            set { Concelho = value; }
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return string.Format("Dados Feira: ID:{0}/nNome:{1}/nCC:{2}/nCidade:{3}/nConcelho:{4}/n", Cod_id, Nome, Cidade, Concelho);
        }
        #endregion
    }


    
}
