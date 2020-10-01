using System;
using System.Collections.Generic;
using System.Linq;


namespace Search_biggest_ampl
{
    class Program
    {
        static int[] Search(List<int> sequence)
        {
            sequence = sequence.Distinct().ToList();
            if (sequence.Count == 1)
            {
                return new int[] { sequence[0], sequence[0] };
            }
            int[] seq = sequence.ToArray();
            Array.Sort(seq);
            List<int> current = new List<int>();
            List<int> last = new List<int>();

            foreach (var item in seq)
            {

                if (current.Count == 0)
                {
                    current.Add(item);
                    continue;
                }
                
                if (item - 1 == current[current.Count - 1])
                {
                    current.Add(item);
                    if (item == seq[seq.Length - 1])
                    {
                        current.Add(item);
                        if (current.Count > last.Count)
                        {
                            last = current;
                            current = new List<int>();
                        }
                        continue;
                    }
                }
                else
                {
                    if (current.Count > last.Count)
                    {
                        last = current;
                        current = new List<int>();
                    }
                    current.Add(item);
                }

            }
            return new int[] { last[0], last[last.Count - 1] };
        }


        static void Main(string[] args)
        {
            int[] input = new int[] { -7 ,-7 ,-7 ,-7 ,8 ,-8 ,0 ,9 ,19 ,-1 ,-3 ,18 ,17 ,2 ,10 ,3 ,12 ,5 ,16 ,4 ,11 ,-6 ,8 ,7 ,6 ,15 ,12 ,12 ,-5 ,2 ,1 ,6 ,13 ,14 ,-4 ,-2 };

            int[] r = Search(input.ToList<int>());
            foreach (var item in r)
            {
                Console.WriteLine(item + " ");
            }
            Console.ReadLine();
        }
    }
}
