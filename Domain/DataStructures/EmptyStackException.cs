using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    class EmptyStackException:DomainException
    {
        public EmptyStackException() { }
    }
}
