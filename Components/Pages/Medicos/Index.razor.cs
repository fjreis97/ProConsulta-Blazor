using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Medicos;

public class IndexMedicoPage : ComponentBase
{
    [Inject]
    public IMedicorepository repository { get; set; } = null!;
    
    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    public List<Medico> Medicos { get; set; } = new List<Medico>();

    public bool HideButtons { get; set; }

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public async Task DeleteMedicoAsync(Medico medico)
    {
        bool? result = await DialogService.ShowMessageBox(
            "Confirmação",
            $"Tem certeza que deseja excluir o médico {medico.Nome}?",
            yesText: "Sim", noText: "Não");
        if (result == true)
        {
            try
            {
                await repository.DeleteByIdAsync(medico.Id);
                snackbar.Add("Médico excluído com sucesso!", Severity.Success);
                await OnInitializedAsync(); // Recarrega a lista após a exclusão
            }
            catch (Exception ex)
            {
                snackbar.Add($"Erro ao excluir médico: {ex.Message}", Severity.Error);
            }
        }
    }


    public void GoToUpdatePage(int id) 
        => Navigation.NavigateTo($"/medicos/update/{id}");

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;
        HideButtons = !auth.User.IsInRole("Atendente");
        Medicos = await repository.GetAllAsync();
    }

}
