using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.InputModel;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Agendamento;

public class CreateAgendamentoPage :ComponentBase
{
    [Inject]
    private IAgendamentoRepository agendamentoRepository { get; set; } = null!;

    [Inject]
    private IMedicorepository Medicorepository { get; set; } = null!;

    [Inject]
    private IPacienteRepository PacienteRepository { get; set; } = null!;

    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public AgendamentoCreateInputModel InputModel { get; set; } = new AgendamentoCreateInputModel();
    public List<Medico> Medicos { get; set; } = new List<Medico>();
    public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public TimeSpan? time = new TimeSpan(09, 00, 00);
    public DateTime? date = DateTime.Now.Date;
    public DateTime? minDate { get; set; } = DateTime.Now.Date;

    protected override async Task OnInitializedAsync()
    {
        Medicos = await Medicorepository.GetAllAsync();
        Pacientes = await PacienteRepository.GetAllAsync();
    }

    public async Task OnvalidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is AgendamentoCreateInputModel model)
            {
                model.DataConsulta = date ?? DateTime.Now.Date;
                model.HoraConsulta = time ?? new TimeSpan(09, 00, 00);

                var agendamento = new ProConsulta.Models.Agendamento
                {
                    Observacao = model.Observacao,
                    PacienteId = model.PacienteId,
                    MedicoId = model.MedicoId,
                    DataConsulta = date!.Value,
                    HoraConsulta = time!.Value
                };

                await agendamentoRepository.AddAsync(agendamento);
                snackbar.Add("Agendamento realizado com sucesso!", Severity.Success);
                Navigation.NavigateTo("/agendamentos");
            }
           
        }
        catch (Exception ex)
        {
            snackbar.Add($"Erro ao realizar agendamento: {ex.Message}", Severity.Error);
            return;
        }
    }
}
