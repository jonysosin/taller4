using System;
using System.Collections.Generic;

namespace DAL
{
    public class InvalidPostException : System.Exception
    {
        public const String GENERIC_MESSAGE = "Post invalido.";
        public InvalidPostException (String message): base (message) {}
    }
}