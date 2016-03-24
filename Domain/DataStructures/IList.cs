using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretor.Domain.DataStructures
{
    public interface IList<T>
    {

        void add(T e);
        bool isEmpty();
        T getElemAtPos(int i);
        int size();
        bool Contains(T e);

    }
}
