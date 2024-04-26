namespace Rips;

/// <summary>
///     Clase del tipo Consulta, que se usará para generar la información de RIPS, de acuerdo a los
///     linemaientos del Ministerio de Salud de Colombia
/// </summary>
internal class Consulta
{
    #region Propiedades

    /// <summary>
    ///     Debe iniciar con el número uno (1) incrementando de uno en uno. No deben existir números idénticos repetidos.
    /// </summary>
    public int Consecutivo
    {
        get { return consecutivo; }
        init { consecutivo = value; }
    }
    private readonly int consecutivo;

    /// <summary>
    ///     El código del facturador electrónico en salud se debe encontrar en la tabla "IPSCodHabilitación" 
    ///     para prestadores de servicios de salud o en "IPSnoREPS" para prestadores exceptuados del registro en REPS.
    ///     
    ///     El código del prestador de servicios de salud o del obligado a reportar debe estar relacionado con el numDocumentoldObligado.
    /// </summary>
    public string CodPrestador { get; }

    /// <summary>
    ///     El código de CUPS puede ser validado que corresponda a una cobertura de consulta.
    ///     El código de CUPS puede ser validado que corresponda al sexo del usuario.
    ///     El código de CUPS puede ser validado con el grupo de servido, servicio, finalidad o causa.
    ///     El código de CUPS puede ser validado que corresponda a la cobertura o plan de beneficios registrada en la factura electrónica de venta.
    ///     El código de CUPS se puede validar según la cantidad de veces que se informe por paciente y por día.
    ///     El código de CUPS se puede validar con el diagnóstico principal.
    ///     Si se informan registros en el grupo de servicios de internación o el servicio de urgencias el código CUPS se puede validar que sea de consultas intrahospitalarias (interconsultas) y que se encuentre dentro del periodo de internación o de observación de urgencias.
    ///     Informar dato según tabla de referencia: "CUPSRips", en web.sispro.gov.co
    /// </summary>
    public string CodConsulta { get; }

    /// <summary>
    ///     La fecha y hora de la consulta no debe ser mayor a la fecha y hora de validación de los RIPS, 
    ///     ni menor a la fecha de nacimiento del usuario. Así mismo, no podrá encontrarse por fuera 
    ///     del periodo de facturación según los datos de la factura electrónica de venta.
    /// </summary>
    public DateTime FechalnicioAtencion { get; set; }

    /// <summary>
    ///     Diligenciar el valor mayor a cero (0) si la modalidad de pago corresponde a "Pago por evento". 
    ///     Para las demás modalidades informar cero(0).
    ///     Si el RIPS es sin Factura Electrónica de Venta — FEV en salud, informar cero(0).
    /// </summary>
    public decimal VrServicio { get; set; }

    /// <summary>
    ///     Informar dato según tabla de referencia: "conceptoRecaudo", en web.sispro.gov.co.Solo aplican los siguientes valores: 
    ///         02. Cuota moderadora 
    ///         03. Pagos compartidos en planes voluntarios de salud 
    ///         05: No aplica
    ///     Solamente se puede cobrar cuota moderadora a afiliados del régimen contributivo.
    ///     Para usuarios del régimen subsidiado no se puede informar el pago de valores moderadores de planes voluntarios.
    /// </summary>
    public string? ConceptoRecaudo
    {
        get => $"{conceptoRecaudo} <{conceptoRecaudo switch { "02" => "Cuota moderadora", "03" => "Pago compartido", "05" => "No aplica", _ => "Desconocido" }}>";
        set
        {
            if (value == conceptoRecaudo)
                return;
            
            string[] valoresValidos = ["02", "03", "05"];
            if (!valoresValidos.Contains(value))                
                throw new ApplicationException("El valor que asignó al concepto de recaudo no es válido. Solo sepermite 02, 03, 05");

            conceptoRecaudo = value;
        }
    }
    private string? conceptoRecaudo;

    /// <summary>
    ///     Cuando no aplique pago moderador se debe informar cero(0). 
    ///     Si el tipo de pago moderador es "cuota moderadora" o "bono o vale de plan voluntario" el valor del pago moderador debe ser mayor o igual auno "1". 
    ///     En el caso del RIPS soporte de factura con varios usuarios o servicios, el valor del pago moderador informado
    ///     en la factura electrónica de venta en salud, debe corresponder a la sumatoria de detalles de valores de pagos 
    ///     moderadores de estas facturas de recaudo, informados en RIPS.
    /// </summary>
    public decimal ValorPagoModerador { get; set; }    

    #endregion

    #region Constructorer

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
        if (string.IsNullOrWhiteSpace(codPrestador))
            throw new ArgumentNullException(nameof(codPrestador));

        Consecutivo = consecutivo;
        CodPrestador = codPrestador;
        CodConsulta = codConsulta;
    }

    #endregion

    #region Métodos
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
            Consecutivo: {consecutivo}
            Código de prestador: {CodPrestador}
            Consulta: {CodConsulta}
            Fecha: {FechalnicioAtencion:MM/dd/yyyy}
            Concepto de recaudo: {ConceptoRecaudo}
            Valor del recaudo: {ValorPagoModerador:c2}
            Valor del servicio: {VrServicio}
            """;
    }
    #endregion
}