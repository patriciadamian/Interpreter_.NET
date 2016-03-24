using Interpretor.Domain.DataStructures;
using Interpretor.Domain.Expressions;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class WriteHeapStmt : IStmt
    {
        private string id;
        private Expr exp;

        public WriteHeapStmt(string id, Expr exp)
        {
            this.id = id;
            this.exp = exp;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public Expr Exp
        {
            get
            {
                return this.exp;
            }
            set
            {
                this.exp = value;
            }
        }

        public override string ToString()
        {
            return "writeHeap( " + id + ", " + exp.ToString() + ")";
        }



        public PrgState eval(PrgState state)
        {
           
            state.getHeapTable().update(state.getSymTable().getValue(id), this.exp.eval(state.getSymTable(), state.getHeapTable()));
            return null;
        }
    }
}
