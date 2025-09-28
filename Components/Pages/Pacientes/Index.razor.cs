using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Pacientes;

public class IndexPage :ComponentBase
{
    [Inject]
    public IPacienteRepository repository { get; set; } = null!;
   
    [Inject]
    public IDialogService Dialog { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public List<Paciente> Pacientes = new();

    public async Task DeletePaciente(Paciente paciente)
    {
        try
        {
            bool? result = await Dialog.ShowMessageBox(
                   "Atenção",
                   $"Você tem certeza que deseja excluir o paciente {paciente.Nome}?",
                   yesText: "Sim", cancelText: "Não");
            if (result == true)
            {
                await repository.DeleteByIdAsync(paciente.Id);                
                Snackbar.Add($"Paciente {paciente.Nome} excluído com sucesso!", Severity.Success);
                await OnInitializedAsync();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao excluir paciente: {ex.Message}", Severity.Error);
        }
    }

    public void GoToUpdate(int id)
    {
        Navigation.NavigateTo($"/pacientes/update/{id}");
    }

    protected override async Task OnInitializedAsync()
    {
        Pacientes = await repository.GetAllAsync();
    }

    

    
}
