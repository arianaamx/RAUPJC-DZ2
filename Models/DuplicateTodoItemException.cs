using System;
using System.Runtime.Serialization;

namespace Models
{
    public class DuplicateTodoItemException : Exception
    {
         public DuplicateTodoItemException() : base()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }
    }
}