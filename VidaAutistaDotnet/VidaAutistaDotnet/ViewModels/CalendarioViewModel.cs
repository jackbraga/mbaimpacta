namespace VidaAutistaDotnet.API.ViewModels
{
  public class CalendarioViewModel
  {
    public int IdCalendario { get; set; }
    public int IdUsuario { get; set; }
    public DateTime DataHoraEvento { get; set; }
    public string EspecialidadeMedico { get; set; }
    public string NomeMedico { get; set; }
    public string Anotacoes { get; set; }
  }
}
