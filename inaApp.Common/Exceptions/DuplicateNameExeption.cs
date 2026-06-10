using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Exceptions
{
    public class DuplicateNameExeption : Exception
    {
        public DuplicateNameExeption()
        {
            
        }

        public DuplicateNameExeption(string? message):base(message)
        {
            
        }
    }
}
