using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlascoAppFuncionalTreinamento.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [Compare(otherProperty: "Senha", ErrorMessage = "As senhas informadas não conferem")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ConfirmacaSenha { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}