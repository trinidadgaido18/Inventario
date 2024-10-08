﻿using System.Collections;

namespace Inventario.GUI.Administrador
{
    internal interface IManejadorEmpleados
    {
        IEnumerable Listar { get; set; }

        bool Agregar(string id);
        bool Eliminar(string id);
        bool Modificar(Empleado emp);
    }
}