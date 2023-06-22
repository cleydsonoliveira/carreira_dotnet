using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usu�rio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usu�rio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usu�rio")]
        [EmailAddress(ErrorMessage = "O emial informado n�o � v�lido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usu�rio")]
        public PerfilEnum? Perfil { get; set; }
    }
}