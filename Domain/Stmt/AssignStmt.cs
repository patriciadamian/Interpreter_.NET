using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Expressions;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class AssignStmt:IStmt
    {
        private string id;
        private Expr exp;
        private IDictionary<string, int> symTbl;


        public AssignStmt(string i, Expr e)
        {
            this.id = i;
            this.exp = e;
        }



        public override string ToString()
        {
            return id.ToString() + " = " + exp.ToString();
        }

       

        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public Expr getExp()
        {
            return exp;
        }

        public void setExp(Expr exp)
        {
            this.exp = exp;
        }

        public IDictionary<string, int> SymTbl
        {
            get
            {
                return this.symTbl;
            }
            set
            {
                this.symTbl = value;
            }
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

        public PrgState eval(PrgState state)
        {
            IDictionary<string, int> symTbl = state.getSymTable();
            IHeap<int> heap = state.getHeapTable();

            symTbl.add(id, exp.eval(symTbl, heap));
            
            return state;
        }
    }
}
