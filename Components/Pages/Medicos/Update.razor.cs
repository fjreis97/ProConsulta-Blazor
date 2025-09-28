using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.InputModel;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Medicos;

public class UpdateMedicoPage : ComponentBase
{
    [Parameter]
    public int MedicoId { get; set; }

    [Inject]
    private IEspecialidadeRepository especialidadeRepository { get; set; } = null!;

    [Inject]
    public IMedicorepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public Medico? CurrentMedico { get; set; }
    public MedicoUpdateInputModel MedicoInput { get; set; } = new MedicoUpdateInputModel();
    public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

    public async Task OnvalidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (CurrentMedico is null)
            {
                snackbar.Add("Médico não encontrado.", Severity.Error);
                return;
            }

           if(editContext.Model is MedicoUpdateInputModel model)
            {
                CurrentMedico.Nome = model.Nome;
                CurrentMedico.Documento = model.Documento.SomenteCacarteres();
                CurrentMedico.CRM = model.CRM.SomenteCacarteres();
                CurrentMedico.Celular = model.Celular.SomenteCacarteres();
                CurrentMedico.EspecialidadeId = model.EspecialidadeId;
            }

            await repository.UpdateAsync(CurrentMedico);
            snackbar.Add("Médico atualizado com sucesso!", Severity.Success);
            Navigation.NavigateTo("/medicos");
        }
        catch (Exception ex)
        {
            snackbar.Add($"Erro ao atualizar médico: {ex.Message}", Severity.Error);
            return;
        }
    }
    protected override async Task OnInitializedAsync()
    {

        CurrentMedico = await repository.GetByIdAsync(MedicoId);
        Especialidades = await especialidadeRepository.GetAllAsync();

        if (CurrentMedico is null)
        {
            snackbar.Add("Médico não encontrado.", Severity.Error);
            Navigation.NavigateTo("/medicos");
        }

        MedicoInput = new MedicoUpdateInputModel
        {
            Nome = CurrentMedico.Nome,
            Documento = CurrentMedico.Documento,
            CRM = CurrentMedico.CRM,
            DataCadastro = CurrentMedico.DataCadastro,
            Celular = CurrentMedico.Celular,
            EspecialidadeId = CurrentMedico.EspecialidadeId
        };
    }
}
