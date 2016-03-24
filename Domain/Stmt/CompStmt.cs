using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class CompStmt:IStmt
    {
        private IStmt first;
        private IStmt snd;


        public CompStmt(IStmt f, IStmt s)
        {
            this.first = f;
            this.snd = s;

        }



        public override string ToString()
        {
            return first.ToString() + " ; " + snd.ToString() ;
        }
       

        public IStmt getFirst()
        {
            return first;
        }

        public void setFirst(IStmt first)
        {
            this.first = first;
        }

        public IStmt getSnd()
        {
            return snd;
        }

        public void setSnd(IStmt snd)
        {
            this.snd = snd;
        }

        public PrgState eval(PrgState state)
        {
            state.getExeStack().push(snd);
            state.getExeStack().push(first);
            return state;
        }
    }
}
