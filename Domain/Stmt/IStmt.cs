using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    public interface IStmt
    {
        PrgState eval(PrgState state);

    }
}
