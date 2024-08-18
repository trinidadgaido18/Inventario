using System.Collections;

namespace Inventario.GUI.Administrador
{
    internal interface IManejadorEmpleados1
    {
        bool Agregar(string id);
        bool Eliminar(string id);
        IEnumerable Listar();
        bool Modificar(Empleado emp);
    }
}