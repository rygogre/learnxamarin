using System;
using System.Runtime.Serialization;

namespace D3.Resources.DataHelper
{
    [Serializable]
    internal class SQLiteExcepcion : Exception
    {
        public SQLiteExcepcion()
        {
        }

        public SQLiteExcepcion(string message) : base(message)
        {
        }

        public SQLiteExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SQLiteExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}