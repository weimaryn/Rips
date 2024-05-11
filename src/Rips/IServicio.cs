
namespace Rips
{
    internal interface IServicio
    {
        string CodPrestador { get; }
        string? ConceptoRecaudo { get; set; }
        int Consecutivo { get; init; }
        DateTime FechalnicioAtencion { get; set; }
        decimal ValorPagoModerador { get; set; }
        decimal VrServicio { get; set; }

        void Programar(DateTime fechaInicioAtención, string consultorio, string paciente, string doctor);
    }
}