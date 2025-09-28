using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.InputModel;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Pacientes;

public class UpdatePaciente :ComponentBase
{
    [Parameter]
    public int PacienteId { get; set; }

    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public PacienteUpdateInputModel InputModel { get; set; } = new();

    private Paciente? CurrentPaciente { get; set; }

    public DateTime? DataNascimento { get; set; } = DateTime.Today;
    public DateTime MaxDate => DateTime.Today;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            CurrentPaciente = await repository.GetByIdAsync(PacienteId);
            if (CurrentPaciente != null)
            {
                InputModel = new PacienteUpdateInputModel
                {
                    Id = CurrentPaciente.Id,
                    Nome = CurrentPaciente.Nome,
                    Documento = CurrentPaciente.Documento,
                    Email = CurrentPaciente.Email,
                    Celular = CurrentPaciente.Celular,
                    DataNascimento = CurrentPaciente.DataNascimento
                };

                DataNascimento = CurrentPaciente.DataNascimento;
            }
            else
            {
                Snackbar.Add("Paciente não encontrado.", Severity.Error);
                Navigation.NavigateTo("/pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao carregar paciente: {ex.Message}", Severity.Error);
            Navigation.NavigateTo("/pacientes");
        }
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if(editContext.Model is PacienteUpdateInputModel model)
            {
                    CurrentPaciente.Nome = model.Nome;
                    CurrentPaciente.Documento = model.Documento.SomenteCacarteres();
                    CurrentPaciente.Email = model.Email;
                    CurrentPaciente.Celular = model.Celular.SomenteCacarteres();
                    CurrentPaciente.DataNascimento = model.DataNascimento;

                    await repository.UpdateAsync(CurrentPaciente);
                    Snackbar.Add($"Paciente {CurrentPaciente.Nome} atualizado com sucesso!", Severity.Success);
                    Navigation.NavigateTo("/pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao atualizar paciente: {ex.Message}", Severity.Error);
        }
    }

}
