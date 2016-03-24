using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    public interface IHeap<T>
    {
        int add(T e);
        T get(int adddress);
        void update(int address, T value);
    }
}
