using System;
//using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.DataStructures;



namespace Interpretor.Domain.Expressions
{
    [Serializable]
    public class ConstExpr:Expr
    {
        private int number;


        public ConstExpr(int nr)
        {

            this.number = nr;
        }

        
        public int eval(IDictionary<string,int> tbl, IHeap<int> heap)
        {
            return this.number;
        }


        public override string ToString()
        {
            return " " + number + " ";
        }

        
        public int getNumber()
        {
            return number;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }
    }
}
