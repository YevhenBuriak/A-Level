using System.Collections;

namespace L1;

// Indexer: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
// Iterator: https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-7.0
internal static class Iterator
{
    public static void Execute()
    {
        // Indexer
        var myCollection = new MyCollection<int>();
        myCollection[0] = 1;
        myCollection[1] = 2;

        _ = myCollection[0];
        _ = myCollection["second"];


        // Iterator (IEnumerable, IEnumerator)
        var iMyCollection = new MyCollection<int>();
        iMyCollection[0] = 1;
        iMyCollection[1] = 2;
        iMyCollection[2] = 3;

        var enumerator = iMyCollection.GetEnumerator();
        var enumerator2 = iMyCollection.GetEnumerator();
        while (enumerator.MoveNext() && enumerator2.MoveNext())
        {
            _ = enumerator.Current;
            _ = enumerator2.Current;
        }

        //foreach (var i in iMyCollection)
        //{
        //    _ = i;
        //}

        // Add
        // var aMyCollection = new MyCollection<int>() { 1, 2, 3};
    }

    public class MyCollection<T> : IEnumerable<T>
    {
        private int _addIndex = 0;
        private T[] _arr = new T[100];

        public int Length => 100;
        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return _arr[i]; }
            set { _arr[i] = value; }
        }

        public T this[string i]
        {
            get
            {
                switch (i)
                {
                    case "first":
                        return _arr[0];
                    case "second":
                        return _arr[1];
                    case "third":
                        return _arr[2];

                    default:
                        return _arr[0];
                }
            }
        }

        //public void Add(T item)
        //{
        //    _arr[_addIndex] = item;
        //    _addIndex++;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return new MyCollectionEnumerator<T>(this);
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    var index = 0;
        //    while (index < _arr.Length)
        //    {
        //        yield return _arr[index];
        //        index++;
        //    }
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyCollectionEnumerator<T> : IEnumerator<T>
    {
        private MyCollection<T> _collection;
        private int _index = -1;

        public T Current
        {
            get
            {
                if (_index < 0 || _index >= _collection.Length) throw new IndexOutOfRangeException();

                return _collection[_index];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public MyCollectionEnumerator(MyCollection<T> collection)
        {
            _collection = collection;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_index < _collection.Length - 1)
            {
                _index++;
                return true;
            }

            return false;
        }

        public void Reset() => _index = -1;
    }
}
