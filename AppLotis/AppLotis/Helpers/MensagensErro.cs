using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLotis.Helpers {
    public static class MensagensErro {
        public static readonly string SEM_INTERNET = "Por favor, verifique que você possui conexão com a internet e tente novamente.";
        public static readonly string SENHA_CONFIRMACAO_ERRADA = "Por favor, configura sua senha e sua confirmação de senha";
        public static readonly string ERRO_REST = "Algo deu errado, por favor, tente novamente mais tarde.";
        public static readonly string NOME_INVALIDO = "Nome muito curto";
        public static readonly string NOME_EM_BRANCO = "Digite seu nome";
        public static readonly string TELEFONE_INVALIDO = "Telefone deve conter ao menos 8 caracteres.";
        public static readonly string LOCAL_DE_PAGAMENTO_BRANCO = "Digite o local do pagamento";
        public static readonly string CEP_NAO_ENCONTRADO = "CEP não encontrado, tente novamente";
        public static readonly string CAMPOS_EM_BRANCO = "Por favor, preencha todos os campos.";
    }
}
