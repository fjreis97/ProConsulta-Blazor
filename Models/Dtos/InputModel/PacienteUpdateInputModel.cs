using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models.Dtos.InputModel
{
    public class PacienteUpdateInputModel
    {

        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "O documento é obrigatório.")]
        [StringLength(20, ErrorMessage = "O documento não pode exceder 20 caracteres.")]
        public string Documento { get; set; } = null!;
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        [StringLength(100, ErrorMessage = "O email não pode exceder 100 caracteres.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "O celular é obrigatório.")]
        [Phone(ErrorMessage = "O celular não é válido.")]
        [StringLength(15, ErrorMessage = "O celular não pode exceder 15 caracteres.")]
        public string Celular { get; set; } = null!;
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento não é válida.")]
        public DateTime DataNascimento { get; set; }
    }
}
