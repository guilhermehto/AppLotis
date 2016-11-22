using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Dtos {
    public class LavagemDto {
        public int Id { get; set; }

        public int VeiculoId { get; set; }
        public int TipoLavagemId { get; set; }

        public int? AvaliacaoId { get; set; }

        public string UsuarioId { get; set; }
        public string LavadorId { get; set; }

        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public float ValorEmReais { get; set; }
        public float TrocoEmReais { get; set; }

        public string LocalDeRecebimento { get; set; }

        public DateTime DiaHorario { get; set; }
    }
}
