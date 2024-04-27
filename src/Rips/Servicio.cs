namespace Rips;

/// <summary>
///     Clase del tipo Consulta, que se usará para generar la información de RIPS, de acuerdo a los
///     linemaientos del Ministerio de Salud de Colombia
/// </summary>
internal class Servicio(int consecutivo, string codPrestador) : ServicioBase(consecutivo, codPrestador)
{
    /// <summary>
    ///     Fecha y hora de la consulta.
    ///     
    ///     La fecha y hora de la consulta no debe ser mayor a la fecha y hora de validación de los RIPS, 
    ///     ni menor a la fecha de nacimiento del usuario. Así mismo, no podrá encontrarse por fuera 
    ///     del periodo de facturación según los datos de la factura electrónica de venta.
    /// </summary>
    public DateTime FechalnicioAtencion { get; set; }

    /// <summary>
    ///     Permite realizar la programación para la cita de la consulta
    /// </summary>
    /// <param name="fechaInicioAtención">
    ///     La fecha y hora de la consulta no debe ser mayor a la fecha y hora de validación de los RIPS, ni menor a la
    ///     fecha de nacimiento del usuario. Así mismo, no podrá encontrarse por fuera del periodo de facturación
    ///     según los datos de la factura electrónica de venta.
    /// </param>
    /// <param name="consultorio">
    ///     Información del consultorio donde se realiza la consulta
    /// </param>
    /// <param name="paciente">
    ///     Información del paciente que se atiende en la consulta
    /// </param>
    /// <param name="doctor">
    ///     Información del profesional de salud que realiza la consulta
    /// </param>
    public void Programar(DateTime fechaInicioAtención, string consultorio, string paciente, string doctor)
    {
        FechalnicioAtencion = fechaInicioAtención;
        // TODO: Se deben implementar los demás parámetros
    }

    public override string ToString()
    {
        return $"""
            Consecutivo: {Consecutivo}
            Código de prestador: {CodPrestador}
            Fecha: {FechalnicioAtencion:MM/dd/yyyy}
            Valor del recaudo: {ValorPagoModerador:c2}
            Valor del servicio: {VrServicio}
            """;
    }
}