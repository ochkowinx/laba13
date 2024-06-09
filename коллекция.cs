using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба13
{
    public delegate void MyCollectionChangedEventHandler(object sender, MyCollectionChangedEventArgs e);


    public class MyCollection<T> : List<T>, ICollection<T>, IList<T>
    {
        public MyCollection()
        {
        }

        public MyCollection(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public int Count => throw new NotImplementedException(); // Реализация свойства Count

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => this[index];
            set => this[index] = value;
        }

        public void Add(T item)
        {
            base.Add(item);
        }

        public void Clear()
        {
            base.Clear();
        }

        public bool Contains(T item)
        {
            return base.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return base.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            base.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return base.Remove(item);
        }

        public void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyObservableCollection<T> : MyCollection<T>
    {
        private List<MyCollectionChangedEventHandler> _handlers = new List<MyCollectionChangedEventHandler>();

        public event EventHandler<MyCollectionChangedEventArgs> CollectionChanged;

        protected virtual void OnCollectionChanged()
        {
            CollectionChanged?.Invoke(this, new MyCollectionChangedEventArgs());
        }

        public MyObservableCollection()
        {
        }

        public MyObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public new void Add(T item)
        {
            base.Add(item);
            OnCollectionChanged();
        }

        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnCollectionChanged();
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            OnCollectionChanged();
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnCollectionChanged();
        }

        public new void Clear()
        {
            base.Clear();
            OnCollectionChanged();
        }
    }

    public class MyCollectionChangedEventArgs : EventArgs
    {
        public enum ChangeType
        {
            Added,
            Removed,
            Changed
        }

        public ChangeType Type { get; }
        public T Item { get; }
        public int Index { get; }

        public MyCollectionChangedEventArgs(ChangeType type, T item = default, int index = -1)
        {
            Type = type;
            Item = item;
            Index = index;
        }

        public MyCollectionChangedEventArgs()
        {
        }
    }
}
}
