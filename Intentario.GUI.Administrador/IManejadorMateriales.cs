using System.Windows.Media.Media3D;

namespace Inventario.GUI.Administrador
{
    internal interface IManejadorMateriales
    {
        bool Agregar(Material m);
        bool Agregar(object m);
        bool Eliminar(object id);
        int listar();
        bool Modificar(Material m);
    }
}