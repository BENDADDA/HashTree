using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    class HashTree<TKey,TValue>:IEnumerable,IEnumerable<KeyValuePair<TKey,TValue>>,ICollection<KeyValuePair<TKey,TValue>>
    {
        private class Root 
        {
            public char Index;
            public KeyValuePair<TKey, TValue>? keyValuePair;
            public Root[] Childs = new Root[10];
            public Object obj=new Object();
            public Root()
            {
                this.Index=' ';
                this.keyValuePair = null;
            }
            public Root(char Index)
            {
                this.Index = Index;
                this.keyValuePair = null;
            }
            public Root(char Index, TKey Key,TValue Value)
            {
                this.Index = Index;
                this.keyValuePair = new KeyValuePair<TKey,TValue>(Key, Value);
            }
             
        }
        private Root root;
        private int count;
        public int Count
        {
            get { return count; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public HashTree()
        {
            this.root = new Root();
            this.count = 0;
        }
        public void Add(TKey key,TValue value)
        {
            int hashCode=key.GetHashCode();
            string path=hashCode.ToString();
            Root tempRoot=root;
            foreach(char letter in path)
            {
                int index = IndexOf(letter);
                if (tempRoot.Childs[index] == null)
                    tempRoot.Childs[index] = new Root(letter);
                tempRoot = tempRoot.Childs[index];   
            }
            if(tempRoot.keyValuePair==null)
            {
                tempRoot.keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
                count++;
            }
        }
        public void Add(KeyValuePair<TKey,TValue> pair)
        {
            Add(pair.Key,pair.Value);
        }
        public bool TryAdd(TKey key, TValue value)
        {
            try
            {
                Add(key, value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool TryAdd(KeyValuePair<TKey, TValue> pair)
        {
            try
            {
                Add(pair.Key, pair.Value);
                return true;
            }
            catch
            {
                return false;
            }
        }  
        private TValue GetValue(TKey key)
        {
            Root tempRoot=root;
            int hashCode=key.GetHashCode();
            string path=hashCode.ToString();
            foreach(char letter in path)
            {
                int index = IndexOf(letter);
                if (tempRoot.Childs[index] == null) throw new Exception();
                else
                {
                    tempRoot = tempRoot.Childs[index];
                }
              
            }
            if (tempRoot.keyValuePair == null) throw new Exception();
            return tempRoot.keyValuePair.Value.Value;
            
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            try
            {
                value = GetValue(key);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool Contains(KeyValuePair<TKey, TValue> pair)
        {
            TValue value;
            bool IsFound = TryGetValue(pair.Key,out value);
            if (!IsFound) return false;
            return pair.Value.Equals(value);
        }
        public void Remove(TKey key)
        {
            int hashCode = key.GetHashCode();
            string path = hashCode.ToString();
            Root TempRoot = root;
            foreach (char letter in path)
            {
                int index = IndexOf(letter);
                if (TempRoot.Childs[index]== null) throw new Exception();
                TempRoot = TempRoot.Childs[index];
            }
            if (TempRoot != null)
            {
                TempRoot.keyValuePair = null;
                count--;
            }
        }
        public bool TryRemove(TKey key)
        {
            try
            {
                Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(KeyValuePair<TKey, TValue> pair)
        {
            if (Contains(pair)) return TryRemove(pair.Key);
            return false;
        }
        private void ToList(Root root, List<KeyValuePair<TKey, TValue>> list)
        {
            if (root == null) return;
            if (root.keyValuePair != null)
                list.Add(root.keyValuePair.Value);
            for (int i = 0; i < 10; i++)
                ToList(root.Childs[i], list);
        }
        public List<KeyValuePair<TKey, TValue>> ToList()
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>();
            ToList(this.root, list);
            return list;
        }
        private void ToArray(Root root, KeyValuePair<TKey, TValue>[] Array, ref int StartIndex)
        {
            if (root == null) return;
            if (root.keyValuePair != null)
                Array[StartIndex++] = root.keyValuePair.Value;
            for (int i = 0; i < 10; i++)
                ToArray(root.Childs[i], Array, ref StartIndex);
        }
        public KeyValuePair<TKey,TValue>[] ToArray()
        {
            KeyValuePair<TKey, TValue>[] Array = new KeyValuePair<TKey, TValue>[this.count];
            int i = 0;
            ToArray(this.root, Array,ref i);
            return Array;
        }
        public void CopyTo(KeyValuePair<TKey, TValue> []array, int arrayIndex)
        { 
        }
        private int IndexOf(char letter)
        {
            int index= ((int)letter - (int)'0');
            return index == -3 ? 0 : index;
        }
        //Check if the HashTree is Empty
        public bool IsEmpty()
        {
            return count == 0;
        }
        public void Clear()
        {
            this.root = new Root();
            this.count = 0;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ToArray().GetEnumerator();
        }
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return ToList().GetEnumerator();
        }
        
        //private class HashTreeEnumerator : IEnumerator
        //{
        //    private Root root;
        //    private Root CurrentRoot;
        //    private Stack<Root> stack = new Stack<Root>();
        //    public object Current { get { return null; } }
            
        //    public HashTreeEnumerator(Root root)
        //    {
        //        this.root = root;
        //        this.CurrentRoot = root;
        //    }
        //    public bool MoveNext()
        //    {
        //        return true;
        //    }
        //    public void Reset()
        //    { }
        //}
        ~HashTree()
        {
            this.root = null;
        }
    }
    
    
}
