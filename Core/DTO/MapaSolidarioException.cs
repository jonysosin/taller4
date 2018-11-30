using System;
using System.Collections.Generic;

namespace Core.DTO
{
    public class MapaSolidarioException : System.Exception
    {
        public const String GENERIC_MESSAGE = "Hubo un problema al procesar su consulta.";
        public MapaSolidarioException (Exception exception, String message): base (message, exception) {}
        public MapaSolidarioException (Exception exception): base (GENERIC_MESSAGE, exception) {}
    }
}