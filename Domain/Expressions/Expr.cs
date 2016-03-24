using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Expressions
{
    public interface Expr
    {
        int eval(IDictionary<string, int> tbl, IHeap<int> heap);
        
    }
}
