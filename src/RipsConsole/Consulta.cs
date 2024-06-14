namespace RipsConsole;

/// <summary>
///     Clase del tipo Consulta, que se usará para generar la información de RIPS, de acuerdo a los
///     linemaientos del Ministerio de Salud de Colombia
/// </summary>
internal class Consulta(int consecutivo, string codPrestador, string codConsulta)
    : Servicio(consecutivo, codPrestador)
{
    /// <summary>
    ///     Tipo de pago moderador según el plan de beneficios o planes o pólizas adquiridas.
    ///     
    ///     Informar dato según tabla de referencia: "conceptoRecaudo", en web.sispro.gov.co.Solo aplican los siguientes valores: 
    ///         02. Cuota moderadora 
    ///         03. Pagos compartidos en planes voluntarios de salud 
    ///         05: No aplica
    ///     Solamente se puede cobrar cuota moderadora a afiliados del régimen contributivo.
    ///     Para usuarios del régimen subsidiado no se puede informar el pago de valores moderadores de planes voluntarios.
    /// </summary>
    public override string? ConceptoRecaudo
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
    ///     Código de la consulta definido en el Sistema, según la Clasificación Única de Procedimientos en Salud, CUPS.
    ///     
    ///     El código de CUPS puede ser validado que corresponda a una cobertura de consulta.
    ///     El código de CUPS puede ser validado que corresponda al sexo del usuario.
    ///     El código de CUPS puede ser validado con el grupo de servido, servicio, finalidad o causa.
    ///     El código de CUPS puede ser validado que corresponda a la cobertura o plan de beneficios registrada en la factura electrónica de venta.
    ///     El código de CUPS se puede validar según la cantidad de veces que se informe por paciente y por día.
    ///     El código de CUPS se puede validar con el diagnóstico principal.
    ///     Si se informan registros en el grupo de servicios de internación o el servicio de urgencias el código CUPS se puede validar que sea de consultas intrahospitalarias (interconsultas) y que se encuentre dentro del periodo de internación o de observación de urgencias.
    ///     Informar dato según tabla de referencia: "CUPSRips", en web.sispro.gov.co
    /// </summary>
    public string CodConsulta { get; } = !string.IsNullOrWhiteSpace(codConsulta) ? codConsulta : throw new ArgumentNullException(nameof(codConsulta));    
}