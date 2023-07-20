using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
    
            Console.WriteLine("Enter initial data for the LargeDataCollection separated by commas:");
            string inputData = Console.ReadLine();
            string[] dataItems = inputData.Split(',');
            int[] initialData = Array.ConvertAll(dataItems, int.Parse);

            LargeDataCollection largeDataCollection = new LargeDataCollection(initialData);
            try
            {
                largeDataCollection.DisplayCllections();

                Console.WriteLine("\nEnter additional elements to add to the collection separated by commas:");
                string inputAdd = Console.ReadLine();
                string[] addItems = inputAdd.Split(',');
                foreach (string item in addItems)
                {
                    if (int.TryParse(item, out int numToAdd))
                    {
                        largeDataCollection.Add(numToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: '{0}'. Skipping this element.", item);
                    }
                }

                Console.WriteLine("\nEnter elements to remove from the collection separated by commas:");
                string inputRemove = Console.ReadLine();
                string[] removeItems = inputRemove.Split(',');
                foreach (string item in removeItems)
                {
                    if (int.TryParse(item, out int numToRemove))
                    {
                        largeDataCollection.Remove(numToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: '{0}'. Skipping this element.", item);
                    }
                }

                Console.WriteLine("\nLargeDataCollection after removing elements:");
                largeDataCollection.DisplayCllections();

                Console.WriteLine("\nEnter index to access an element from the collection:");
                if (int.TryParse(Console.ReadLine(), out int indexToAccess))
                {
                    try
                    {
                        int element = largeDataCollection.GetElement(indexToAccess);
                        Console.WriteLine("Element at index {0}: {1}", indexToAccess, element);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index is out of range.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for index. Please enter a valid integer.");
                }
            }
            finally
            {
                // Explicitly call Dispose to release resources and free memory.
                largeDataCollection.Dispose();
                Console.WriteLine("Collections has been disposed") ;
            }


            Console.ReadKey();
        }
    }
}
