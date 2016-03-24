using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpretor.Domain.Stmt;



namespace Interpretor.Domain.DataStructures
{
    public interface IStack<T>
    {
        void push(T e);
        T pop();
        bool isEmpty();
        T peek();
        int Count();

    }
}
