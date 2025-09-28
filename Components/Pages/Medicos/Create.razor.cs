using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Models.Dtos.InputModel;
using ProConsulta.Repositories;
using ProConsulta.Repositories.Interfaces;

namespace ProConsulta.Components.Pages.Medicos;

public class CreateMedicoPage : ComponentBase   
{
    [Inject]
    private IEspecialidadeRepository especialidadeRepository { get; set; } = null!;

    [Inject]
    public IMedicorepository repository { get; set; } = null!;

    [Inject]
    public ISnackbar snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
    public MedicoCreateInputModel MedicoInput { get; set; } = new MedicoCreateInputModel();

    public async Task OnvalidSubmitAsync(EditContext editContext)
    {

        try 
        {
            if (editContext.Model is MedicoCreateInputModel model)
            {
                var medico = new Medico
                {
                    Nome = model.Nome,
                    Documento = model.Documento.SomenteCacarteres(),
                    CRM = model.CRM.SomenteCacarteres(),
                    DataCadastro = model.DataCadastro,
                    Celular = model.Celular.SomenteCacarteres(),
                    EspecialidadeId = model.EspecialidadeId
                };

                await repository.AddAsync(medico);
                snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
                Navigation.NavigateTo("/medicos");
            }
        }
        catch (Exception ex)
        {
            snackbar.Add($"Erro ao cadastrar médico: {ex.Message}", Severity.Error);
            return;
        }
      
    }

    protected override async Task OnInitializedAsync()
    {
        Especialidades = await especialidadeRepository.GetAllAsync();
    }

}
