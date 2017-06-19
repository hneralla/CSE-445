using System;
using System.Threading;

namespace Assignment_2
{
    // ASU CSE 445 Summer '17
    // Name: Harith Neralla
    // 06/03/2017

    public class MultiCellBuffer
    {
        public string[] bufferString;
        private const int N = 5;
        private int n; //number of bufferCells
        private int elementCount; 
        private static Semaphore write_pool; //pool of writing resources
        private static Semaphore read_pool; //pool of reading resources

        public MultiCellBuffer(int n) //constructor 
        {
            lock (this) //ensures that there are no interruptions
            {
                elementCount = 0; //initialize elementCount

                if (n <= N)
                {
                    this.n = n; 
                    write_pool = new Semaphore(n, n);
                    read_pool = new Semaphore(n, n);
                    bufferString = new string[n]; //create 'n' bufferString cells

                    for (int i = 0; i < n; i++)
                    {
                        bufferString[i] = "0"; //initialize all bufferString cells with "0"
                    }
                }
                else
                    Console.WriteLine("'n' value for number of buffer cells needs to be less than {0}.", N);
            }
        }

        public void setOneCell(string data) 
        {
            write_pool.WaitOne();
            
            lock (this)
            {
                while (elementCount == n) //thread waits if all bufferCells are full
                {
                    Monitor.Wait(this);
                }
                
                for (int i = 0; i < n; i++)
                {
                    if (bufferString[i] == "0") //makes sure there is no data being over-written 
                    {
                        bufferString[i] = data;
                        elementCount++;
                        i = n; //exits loop
                    }
                }
                write_pool.Release(); 
                Monitor.Pulse(this);
            }
        }

        public string getOneCell() 
        {
            read_pool.WaitOne();
            string output = "";

            lock (this)
            {
                while (elementCount == 0) //thread waits if no cells are full
                {
                    Monitor.Wait(this);
                }

                for (int i = 0 ; i < n; i++)
                {
                    if (bufferString[i] != "0") //makes sure there is valid data
                    {
                        output = bufferString[i];
                        bufferString[i] = "0";
                        elementCount--;
                        i = n; //exits loop
                    }
                }
                read_pool.Release();
                Monitor.Pulse(this);
            }
            return output;
        }
    }
}