using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core.UI.Dragging
{
    public interface IDragSource<T> where T : class
    {
        /// <summary>
        /// Components that implementing this interface 
        /// can act as a source for Dragginig a 'DragItem'
        /// </summary>
        /// <typeparam name="T">The type that represents the item being dragged</typeparam>


        T GetItem();

        int GetNumber();

        void RemoveItems(int nunber);
    }
}
