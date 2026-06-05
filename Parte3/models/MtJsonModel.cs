using System;
using System.Collections.Generic;
using System.Text;

namespace Parte3.models
{

        public class MtJsonModel
        {
            public List<string> estados
            {
                get;
                set;
            }

            public List<char> alfabetoEntrada
            {
                get;
                set;
            }

            public List<char> alfabetoFita
            {
                get;
                set;
            }

            public string estadoInicial
            {
                get;
                set;
            }

            public string estadoAceitacao
            {
                get;
                set;
            }

            public string estadoRejeicao
            {
                get;
                set;
            }

            public List<
                TransicaoMtJsonModel> transicoes
            {
                get;
                set;
            }
        }
}
