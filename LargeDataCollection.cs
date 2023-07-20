using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11
{
    public class LargeDataCollection : IDisposable
    {

        public int[] data;
        public int Length;
        public bool disposed = false;

        public LargeDataCollection(params int[] initialData) 
        {
            data = initialData;
        }

        public void Add(int item)
        {
            int currentIndex = data.Length;
            Array.Resize(ref data, currentIndex + 1);
            data[currentIndex] = item;
        }

        public void Remove(int item)
        {
            int index = Array.IndexOf(data, item);
            if(index >= 0)
            {
                for(int i = index; i < data.Length - 1; i++) 
                {
                    data[i] = data[i + 1];
                }
                Array.Resize(ref data,data.Length - 1);
            }
        }

        public int GetElement(int index)
        {
            if(index >= 0 && index < data.Length)
            {
                return data[index];
            }
            throw new IndexOutOfRangeException("Index is out of Range");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                data = null;
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~LargeDataCollection() 
        { 
            Dispose(false); 
        }

        public void DisplayCllections()
        {
            Console.WriteLine("LargeDataCollction:");
            foreach(int item in data)
            {
                Console.WriteLine(item+ "");
            }
            Console.WriteLine();
        }
    }
}
