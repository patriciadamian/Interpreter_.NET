using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class SkipStmt:IStmt
    {
        public PrgState eval(PrgState state)
        {
            return state;
        }


        public override string ToString()
        {
            return "SKIP";
        }
    }
}
