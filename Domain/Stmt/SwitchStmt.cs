using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Expressions;
using Interpretor.Domain.DataStructures;

namespace Interpretor.Domain.Stmt
{
    [Serializable]
    public class SwitchStmt:IStmt
    {
        private string var;
        private IDictionary<Expr, IStmt> caseTbl;
        //private MyLibMap<Expr, IStmt> caseTbl2;
        private IStmt defaultStmt;


        public SwitchStmt(string v, IDictionary<Expr, IStmt> ct, IStmt stmt)
        {
            this.var = v;
            this.caseTbl = ct;
            this.defaultStmt = stmt;
        }


        
        

        public override string ToString()
        {  
            string res = "switch( " + var.ToString() + " )";
            System.Collections.Generic.List<Expr> arList = new System.Collections.Generic.List<Expr>();
            System.Collections.Generic.List<Expr> keys = new System.Collections.Generic.List<Expr>();

            try
            {
                keys = caseTbl.keysDict();
                keys.ForEach(delegate(Expr key){
                    res = res + " case " + key.ToString() + ": " + caseTbl.getValue(key).ToString();
                });

            }catch(NotKeyException){
               Console.WriteLine("Please input another value!");
            }
            res = res + "default: " + defaultStmt.ToString();
            return res;
        }

        
        public string getVar()
        {
            return var;
        }

        public IDictionary<Expr, IStmt> getCaseTbl()
        {
            return caseTbl;
        }

        public IStmt getDefaultStmt()
        {
            return defaultStmt;
        }

        public PrgState eval(PrgState state)
        { 
            IDictionary<string, int> symTbl = state.getSymTable();
            System.Collections.Generic.List<Expr> list = this.getCaseTbl().keysDict();

            IStmt prevIfStmt = this.getDefaultStmt();

            foreach (Expr e in list)
            {
                try
                {
                    prevIfStmt = new IfStmt(new ArithExpr(new ConstExpr(symTbl.getValue(getVar())), e, "-"), prevIfStmt, getCaseTbl().getValue(e));
                }
                catch (Exception)
                {
                    Console.WriteLine("Controller: Input another value!");

                }

            }
            state.getExeStack().push(prevIfStmt);
            return null;
        }
    }
}
