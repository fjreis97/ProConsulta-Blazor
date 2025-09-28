using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.InputModel;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Pacientes;

public class CreatePacientePage : ComponentBase
{
    [Inject]
    public IPacienteRepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public PacienteInputModel pacienteInput = new();

    public DateTime? DataNascimento { get; set; } = DateTime.Today;

    public DateTime MaxDate => DateTime.Today;

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if(editContext.Model is PacienteInputModel model)
            {
                var paciente = new Paciente
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCacarteres(),
                    Email = model.Email,
                    Celular = model.Celular.SomenteCacarteres(),
                    DataNascimento = model.DataNascimento
                };

                await repository.AddAsync(paciente);
                Snackbar.Add($"Paciente {paciente.Nome} criado com sucesso!", Severity.Success);
                Navigation.NavigateTo("/pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao criar paciente: {ex.Message}", Severity.Error);
        }
    }
}
