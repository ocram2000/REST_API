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

namespace FeiranteAPI.Models
{
    public class Feira
    {
        #region Estados
        int cod_id;
        string nome;
        string cidade;
        string concelho;

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
            this.cod_id = cod_id;
            this.nome = nome;
            this.cidade = cidade;
            this.concelho = concelho;


        }
        #endregion

        #region Propriedades

        public int Cod_id {
            get { return cod_id; }
            set { cod_id = value; }
        }

        public string Nome {
            get { return nome; }
            set { nome = value; }
        }


        public string Cidade {
            get { return cidade; }
            set { cidade = value; }
        }



        public string Concelho {
            get { return concelho; }
            set { concelho = value; }
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return string.Format("Dados Feira: ID:{0}/nNome:{1}/nCC:{2}/nCidade:{3}/nConcelho:{4}/n", Cod_id, Nome, Cidade, Concelho );
        }
        #endregion
    }
}
