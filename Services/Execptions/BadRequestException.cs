using System;

namespace ApiClientes.Services.Exceptions
{
    public class BadRequestExeception : Exception
    {
        public BadRequestExeception(string message) : base(message)
        {
            throw new Exception(message);
        }
    }
}
