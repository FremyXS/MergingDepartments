using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingDepartments.Logic
{
    internal class RoomException : ApplicationException
    {
        public int Value { get; }
        public RoomException(string message, int value)
            : base(message)
        {
            Value = value;

        }
    }
}
