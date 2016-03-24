using Interpretor.Domain.Stmt;
using Interpretor.Domain.DataStructures;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain;
using Interpretor.Domain.Expressions;

namespace GUI_Interpreter.Domain.Stmt
{
    [Serializable]
    public class RepeatStmt : IStmt
    {
        private Expr exp;
        private IStmt stmt;

        public RepeatStmt(Expr e, IStmt s)
        {
            this.exp = e;
            this.stmt = s;
        }

        public PrgState eval(PrgState state)
        {
            IDictionary<string, int> symTbl = state.getSymTable();
            IHeap<int> heap = state.getHeapTable();
            if (this.Exp.eval(symTbl, heap) != 1)
            {
                IStmt stmt = this.Stmt;
                state.getExeStack().push(this);
                state.getExeStack().push(stmt);
            }
            return null;
        }

        public override string ToString()
        {
            return "(repeat " + stmt.ToString() + " until " + exp.ToString() + ")";
        }

        public Expr Exp
        {
            get { return this.exp; }
            set { this.exp = value; }
        }

        public IStmt Stmt
        {
            get { return this.stmt; }
            set { this.stmt = value; }
        }
    }
}
