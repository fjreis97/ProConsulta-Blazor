using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Agendamento;

public class IndexAgendamentoPage : ComponentBase   
{
    [Inject]
    private IAgendamentoRepository agendamentoRepository { get; set; } = null!;

    [Inject]
    public IDialogService Dialog { get;set; } = null!;  

    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;
    public List<ProConsulta.Models.Agendamento> Agendamentos { get; set; } = new List<ProConsulta.Models.Agendamento>();

    public bool HideButtons { get; set; }

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }
    public async Task DeleteAgendamento(int agendamentoId)
    {
        bool? result = await Dialog.ShowMessageBox(
            "Atenção",
            "Tem certeza que deseja excluir este agendamento?",
            yesText: "Sim", 
            cancelText: "Não");
        if (result is true)
        {
            try
            {
                await agendamentoRepository.DeleteByIdAsync(agendamentoId);
                snackbar.Add("Agendamento excluído com sucesso!", Severity.Success);
                await OnInitializedAsync();
            }
            catch (Exception ex)
            {
                snackbar.Add($"Erro ao excluir agendamento: {ex.Message}", Severity.Error);
            }
        }
    }

    override protected async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;
        HideButtons = !auth.User.IsInRole("Atendente");
        Agendamentos = await agendamentoRepository.GetAllAsync();
    }

}
