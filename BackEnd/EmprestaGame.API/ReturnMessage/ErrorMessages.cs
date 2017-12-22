using EmprestaGame.Business.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmprestaGame.API.ReturnMessage
{
    public class ErrorMessages
    {
        public static Message SESSAO_ENCERRADA = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E001",
            Titulo = "Erro",
            Mensagem = "Sessão encerrada"
        };

        public static Message AUTENTICACAO_INVALIDA = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E002",
            Titulo = "Erro",
            Mensagem = "Usuário não tem permissão para acessar este recurso"
        };

        public static Message ERRO_INESPERADO = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E003",
            Titulo = "Erro",
            Mensagem = "Ocorreu um erro inesperado, caso este erro persista contate o administrador do sistema."
        };

        public static Message USUARIO_OU_SENHA_INVALIDO = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E004",
            Titulo = "Erro",
            Mensagem = "Usuário e/ou senha inválidos."
        };

        public static Message EXEPTION_NEGOCIO = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E005",
            Titulo = "Erro",
            Mensagem = ""
        };

        public static Message EXEPTION_ENTITY_BANCO = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E006",
            Titulo = "Erro",
            Mensagem = ""
        };

        public static Message LOGIN_JA_EXISTENTE = new Message()
        {
            Tipo = EnumReturnCode.ERROR.GetEnumDescription(),
            Codigo = "E007",
            Titulo = "Erro",
            Mensagem = "O campo Login já existe na base de dados."
        };
    }
}