using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace netCoreStudy
{
    class Graph<T>
    {
        Graph(int V)
        {

        }
        Graph(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
