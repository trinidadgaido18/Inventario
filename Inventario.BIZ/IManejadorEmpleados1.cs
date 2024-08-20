using Inventario.COMMON.Entidades;

namespace Inventario.BIZ
{
    public interface IManejadorEmpleados1
    {
        List<Empleado> Listar { get; }

        bool Agregar(Empleado entidad);
        Empleado BusacarPorId(string id);
        bool Eliminar(string id);
        List<Empleado> EmpleadosPorArea(string area);
        bool Modificar(Empleado entidad);
    }
}