using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLotis.Dtos;

namespace AppLotis.Singletons {

    /// <summary>
    /// Utilizada apenas para a primeira lavagem do usuário, quando ele ainda não é cadastrado
    /// </summary>
    public static class LavagemSingleton {

        public static int VeiculoId { get; set; }
        public static int TipoLavagemId { get; set; }
        public static string UsuarioId { get; set; }

        public static string Cidade { get; set; }
        public static string Endereco { get; set; }
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }

        public static float ValorEmReais { get; set; }
        public static float TrocoEmReais { get; set; }
        public static string LocalDeRecebimento { get; set; }
        public static float TempoTotalDeDuracaoEmHoras { get; set; }
        public static int StatusId { get; set; }

        public static DateTime DiaHorario { get; set; }
        public static ICollection<AdicionalDto> Adicionais { get; set; }

    }
}
