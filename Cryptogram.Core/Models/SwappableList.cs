using System.Collections.Generic;

namespace Cryptogram.Core.Models
{
    public abstract class SwappableList<T> : List<T>
    {
        public void Swap(int swapFromIndex, int swapToIndex)
        {
            T element = this[swapFromIndex];
            this[swapFromIndex] = this[swapToIndex];
            this[swapToIndex] = element;
        }
    }
}
