using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Stmt;
using Interpretor.Domain.DataStructures;
using Interpretor.Contrl;

namespace Interpretor.Domain
{
    [Serializable]
    public class PrgState
    {
        private IStack<IStmt> exeStack;
        private IDictionary<string, int> symTable;
        private IList<int> output;
        private IHeap<int> heapTbl;
        private IStmt orgProgram;
        private int id;
        private static int increment = 0;

        public PrgState(IStack<IStmt> s, IDictionary<string, int> d, IList<int> l, IHeap<int> h, IStmt prg)
        {
            id = increment++;
            exeStack = s;
            symTable = d;
            output = l;
            heapTbl = h;
            orgProgram = prg;
            exeStack.push(orgProgram);

        }

        public bool isNotComplete()
        {
            return exeStack.Count() != 0;
        }

        public PrgState oneStep()
        {
            try
            {
                IStmt crntStmt = exeStack.pop();
                return crntStmt.eval(this);
            }catch (EmptyStackException)
            {
                throw new StmtExcecutionException();
            }
        }

        public override string ToString()
        {
            return "\n\n---------------------------------------------------------------------------------------\n" +
                 "\n\nid : " + id + "\n\n"+
                 "\n\nExecution Stack : { \n" + exeStack.ToString() + "  }\n " +
                 "\n\nSymbol Table : { \n" + symTable.ToString() + " }\n " +
                 "\n\nHeap : { \n" + heapTbl.ToString() + " }\n" +
                 "\n\nOutput: { \n" + output.ToString() + " }\n" +
                 "\n\n---------------------------------------------------------------------------------------\n";
        }


        public IStack<IStmt> getExeStack()
        {
            return exeStack;
        }


        public IDictionary<string, int> getSymTable()
        {
            return symTable;
        }

        public IHeap<int> getHeapTable()
        {
            return heapTbl;
        }


        public IList<int> getOut()
        {
            return output;
        }


        public IStmt getOrgProgram()
        {
            return orgProgram;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int val)
        {
            this.id = val;
        }

    }
}
