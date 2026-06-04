using System;
using System.Collections.Generic;
using System.Text;

namespace Parte1.models
{
    public class AfdJsonModel
    {
        public List<string> estados { get; set; }

        public List<char> alfabeto { get; set; }

        public string estadoInicial { get; set; }

        public List<string> estadosFinais { get; set; }

        public List<TransicaoJsonModel> transicoes { get; set; }
    }
}
