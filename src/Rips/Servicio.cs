namespace Rips;

/// <summary>
///     Clase del tipo Consulta, que se usará para generar la información de RIPS, de acuerdo a los
///     linemaientos del Ministerio de Salud de Colombia
/// </summary>
internal abstract class Servicio(int consecutivo, string codPrestador) : IServicio
{
    public abstract string? ConceptoRecaudo { get; set; }

    /// <summary>
    ///     Número consecutivo que identifique el registro.
    ///     
    ///     Debe iniciar con el número uno (1) incrementando de uno en uno. No deben existir números idénticos repetidos.
    /// </summary>
    public int Consecutivo
    {
        get { return consecutivo; }
        init { consecutivo = value; }
    }
    private readonly int consecutivo = consecutivo > 0 ? consecutivo : throw new ArgumentOutOfRangeException(nameof(consecutivo));

    /// <summary>
    ///     Código otorgado por el Ministerio de Salud y Protección Social al prestador de servicios de salud 
    ///     o del obligado a reportar. 
    /// 
    ///     El código del facturador electrónico en salud se debe encontrar en la tabla "IPSCodHabilitación" 
    ///     para prestadores de servicios de salud o en "IPSnoREPS" para prestadores exceptuados del registro en REPS.
    ///     
    ///     El código del prestador de servicios de salud o del obligado a reportar debe estar relacionado con el numDocumentoldObligado.
    /// </summary>
    public string CodPrestador { get; } = !string.IsNullOrWhiteSpace(codPrestador) ? codPrestador : throw new ArgumentNullException(nameof(codPrestador));

    /// <summary>
    ///     Fecha y hora de la consulta.
    ///     
    ///     La fecha y hora de la consulta no debe ser mayor a la fecha y hora de validación de los RIPS, 
    ///     ni menor a la fecha de nacimiento del usuario. Así mismo, no podrá encontrarse por fuera 
    ///     del periodo de facturación según los datos de la factura electrónica de venta.
    /// </summary>
    public DateTime FechalnicioAtencion { get; set; }

    /// <summary>
    ///     Valor monetario del pago moderador. 
    ///     
    ///     Cuando no aplique pago moderador se debe informar cero(0). 
    ///     Si el tipo de pago moderador es "cuota moderadora" o "bono o vale de plan voluntario" el valor del pago moderador debe ser mayor o igual auno "1". 
    ///     En el caso del RIPS soporte de factura con varios usuarios o servicios, el valor del pago moderador informado
    ///     en la factura electrónica de venta en salud, debe corresponder a la sumatoria de detalles de valores de pagos 
    ///     moderadores de estas facturas de recaudo, informados en RIPS.
    /// </summary>
    public decimal ValorPagoModerador { get; set; }

    /// <summary>
    ///     Valor monetario de la consulta según el manual tarifario o la tarifa pactada en el acuerdo de voluntades.
    ///     
    ///     Diligenciar el valor mayor a cero (0) si la modalidad de pago corresponde a "Pago por evento". 
    ///     Para las demás modalidades informar cero(0).
    ///     Si el RIPS es sin Factura Electrónica de Venta — FEV en salud, informar cero(0).
    /// </summary>
    public decimal VrServicio { get; set; }

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
            Concepto de recaudo: {ConceptoRecaudo}
            Valor del recaudo: {ValorPagoModerador:c2}
            Valor del servicio: {VrServicio:c2}
            """;
    }
}