namespace Rips;

/// <summary>
/// Clase del tipo Consulta, que se usará para generar la información de RIPS, de acuerdo a los
/// linemaientos del Ministerio de Salud de Colombia
/// </summary>
internal class Consulta
{
    // Sección donde se declaran los Miembros o Campos (Members or Fields)
    private int consecutivo;
    private string codPrestador;
    private string codConsulta;
    private DateTime fechalnicioAtencion;
    
    public decimal vrServicio;
    public string conceptoRecaudo;
    public decimal valorPagoModerador;

    /// <summary>
    ///     Definición del constructor con los atributos obligatorios para una consulta
    /// </summary>
    /// <param name="consecutivo">
    ///     Debe iniciar con el número uno (1) incrementando de uno en uno.
    ///     No deben existir números idénticos repetidos.</param>
    /// <param name="codPrestador">
    ///     El código del facturador electrónico en salud se debe encontrar en la tabla "IPSCodHabilitación" 
    ///     para prestadores de servicios de salud o en "IPSnoREPS" para prestadores exceptuados del registro en REPS
    /// </param>
    public Consulta(int consecutivo, string codPrestador, string codConsulta)
    {
        this.consecutivo = consecutivo;
        this.codPrestador = codPrestador;
        this.codConsulta = codConsulta;
    }

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
        this.fechalnicioAtencion = fechaInicioAtención;
        
        // TODO: Se deben implementar los demás parámetros
    }
    
    public override string ToString()
    {
        return $"""
            Consecutivo: {consecutivo}
            Código de prestador: {codPrestador}
            Consulta: {codConsulta}
            Fecha: {fechalnicioAtencion}
            Concepto de recaudo: {conceptoRecaudo}
            Valor del recaudo: {valorPagoModerador}
            Valor del servicio: {vrServicio}
            """;
    }
}