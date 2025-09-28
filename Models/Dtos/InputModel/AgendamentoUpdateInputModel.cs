using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Models.Dtos.InputModel;

public class AgendamentoUpdateInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string? Observacao { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int PacienteId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int MedicoId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public TimeSpan HoraConsulta { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateTime DataConsulta { get; set; }
}
