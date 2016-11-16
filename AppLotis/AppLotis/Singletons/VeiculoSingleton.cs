using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Singletons {
    public static class VeiculoSingleton {
        public static void Iniciar(string placa, string modelo, string marca, string cor) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
        }
        public static int Id { get; set; }
        public static string Placa { get; set; }
        public static string Modelo { get; set; }
        public static string Marca { get; set; }
        public static string Cor { get; set; }
        public static string UsuarioId { get; set; }
    }
}
