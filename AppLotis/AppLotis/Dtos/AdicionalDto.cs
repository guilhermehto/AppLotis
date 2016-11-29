using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Dtos {
    public class AdicionalDto {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float ValorEmReais { get; set; }
        public float TempoDeDuracaoEmHoras { get; set; }
        //public ICollection<LavagemDto> Lavagens { get; set; }
    }
}
