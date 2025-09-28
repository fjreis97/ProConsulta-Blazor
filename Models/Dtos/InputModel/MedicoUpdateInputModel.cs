using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models.Dtos.InputModel;

public class MedicoUpdateInputModel
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]

    public string Nome { get; set; } = null!;
    [Required(ErrorMessage = "O campo Documento é obrigatório.")]

    public string Documento { get; set; } = null!;
    [Required(ErrorMessage = "O campo Email é obrigatório.")]

    public string CRM { get; set; } = null!;
    [Required(ErrorMessage = "O campo Data de Cadastro é obrigatório.")]

    public DateTime DataCadastro { get; set; }
    [Required(ErrorMessage = "O campo Celular é obrigatório.")]

    public string Celular { get; set; } = null!;

    [Required(ErrorMessage = "O campo Especialidade é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "A especialidade selecionada não é valida não é valida")]
    public int EspecialidadeId { get; set; }
}
