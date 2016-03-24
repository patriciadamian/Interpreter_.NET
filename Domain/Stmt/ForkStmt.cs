using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;


namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class ForkStmt : IStmt
    {
        private IStmt stmt;

        public ForkStmt(IStmt stmt)
        {
            this.stmt = stmt;
        }

        public IStmt Stmt
        {
            get
            {
                return stmt;
            }
            set
            {
                stmt = value;
            }
        }

        public PrgState eval(PrgState state)
        {
            IStack<IStmt> newStk = new MyLibStack<IStmt>();
            IDictionary<string, int> cloneSymTbl = new MyLibMap<string, int>((MyLibMap<string, int>)state.getSymTable());
            return new PrgState(newStk, cloneSymTbl, state.getOut(), state.getHeapTable(), stmt);
        }

        public override string ToString()
        {
            return "fork( " + stmt + " )";
        }
    }
}
