using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EleicaoBrasilApi.Models
{
    public class Candidato
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Partido { get; set; } = string.Empty;

        public int Numero { get; set; }

        // 🔥 ADICIONE ISSO
        public string ViceNome { get; set; } = string.Empty;
    }
}