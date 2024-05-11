// *******************************************************************************************
// Ejemplo de programación orientada a objetos, tomando como base el sistema de archivos RIPS
// del Ministerio de salud de Colombia.
//
// Oftalvisión LTDA 2024.
//********************************************************************************************

// Sección donde se establecen los "Namespaces", que poseen las clases necesarias para realizar los ejemplos
using Rips;

// Sección donde se instancia un objeto, estableciendo las propiedades después de la asignación.
var consultaOptometria = new Consulta(1, "0000001", "Optometría");
consultaOptometria.ConceptoRecaudo = "02";
consultaOptometria.VrServicio = 1000;
consultaOptometria.ValorPagoModerador = 8000;

// Sección donde se instancia un objeto, estableciendo las propiedades en el mismo momento de la asignación.
var procedimientoOftalmologia = new Procedimiento(2, "0000001", "Oftalmología") { ConceptoRecaudo = "01", ValorPagoModerador = 1000, VrServicio = 2000 };

// Sección donde se realizan operaciones con los objetos.
consultaOptometria.Programar(DateTime.Now, "Consultorio 001", "Pepito Perez", "Doctor de optometría");
procedimientoOftalmologia.Programar(DateTime.Now, "Consultorio 002", "Juanito Perez", "Doctor de oftalmología");

VisualizarInformacion(consultaOptometria);
VisualizarInformacion(procedimientoOftalmologia);

// Sección donde se visualiza la información que actualmente poseen los objetos
void VisualizarInformacion(Servicio datos) 
{
    Console.WriteLine();
    Console.WriteLine(datos);
}