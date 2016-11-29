using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Singletons {
    public static class StatusDisponiveis {
        public static int AGENDADA = 1;
        public static int CONFIRMADA = 2;
        public static int EM_ANDAMENTO = 3;
        public static int FINALIZADA = 4;
        public static int CANCELADA_USUARIO = 5;
        public static int CANCELADA_LAVADOR = 6;
    }
}
