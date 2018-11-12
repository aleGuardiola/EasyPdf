using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EasyPdf.Xaml;

namespace EasyPdf.Collections
{
    public class ChildrenContainerList<T> : IList<T> where T : PdfXamlObject
    {
        private List<T> list = new List<T>();
        private PdfXamlObject parent;

        public ChildrenContainerList(PdfXamlObject parent)
        {
            this.parent = parent;
        }

        public T this[int index] { get => list[index]; set { value.Parent = parent; list[index] = value; } }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            item.Parent = parent;
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            item.Parent = parent;
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
