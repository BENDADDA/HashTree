using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    class HashTree<TKey,TValue>
    {
        private class Root
        {
            public char Index;
            public KeyValuePair<TKey, TValue>? keyValuePair;
            public Root[] Childs = new Root[11];
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
            get
            {
                return count;
            }
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
        public TValue GetValue(TKey key)
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
        private int IndexOf(char letter)
        {
            int index= ((int)letter - (int)'0');
            return index == -3 ? 10 : index;
        }

    }
    
    
}
