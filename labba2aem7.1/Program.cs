using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labba2sem7_1
{
    public class Tree
    {
        public float Height = 0;
        public float GrowthTime = 0;
        public string Name = "";
        public float Price = 0;
        public bool isUseful = false;
        public Tree(string Name = "", float Price = 0, bool isUseful = false, float Height = 0, float GrowthTime = 0)
        {
            this.Name = Name;
            this.Price = Price;
            this.isUseful = isUseful;
            this.Height = Height;
            this.GrowthTime = GrowthTime;
        }
        public int CompareTo(Tree p)
        {
            return this.Price.CompareTo(p.Price);
        }
        public class SortByPrice : IComparer
        {

            public int Compare(object pp1, object pp2)
            {
                Tree p1 = (Tree)pp1;
                Tree p2 = (Tree)pp2;
                if (p1.Price < p2.Price)
                    return 1;
                else if (p1.Price > p2.Price)
                    return -1;
                else
                    return 0;
            }
        }
        public class SortByHeight : IComparer
        {
            public int Compare(object pp1, object pp2)
            {
                Tree p1 = (Tree)pp1;
                Tree p2 = (Tree)pp2;
                if (p1.Height > p2.Height)
                    return 1;
                else if (p1.Height < p2.Height)
                    return -1;
                else
                    return 0;
            }
        }
        public class SortByHeightAndPrice : IComparer
        {
            public int Compare(object pp1, object pp2)
            {
                Tree p1 = (Tree)pp1;
                Tree p2 = (Tree)pp2;
                if (p1.Height > p2.Height)
                    return 1;
                else if (p1.Height < p2.Height)
                    return -1;
                else if (p1.Price > p2.Price)
                    return 1;
                else if (p1.Price < p2.Price)
                    return -1;
                else
                    return 0;
            }
        }
    }
    public class Trees : IEnumerable
    {
        int cnt = 0;
        Tree[] mas;
        public Trees(int count = 10)
        {
            mas = new Tree[count];
        }
        public void Add(Tree o)
        {
            if (cnt >= 10)
            {
                return;
            }
            mas[cnt] = o;
            cnt++;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < cnt; ++i) yield return mas[i];
        }
        public void Sort()
        {
            Array.Sort(mas, new Tree.SortByPrice());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Trees workers = new Trees(10);
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int rnd = r.Next(1, 20);
                workers.Add(new Tree("Tree" + rnd, 2.34f * rnd * 1000, (rnd % 2 == 0) ? (true) : (false), 50f * rnd, rnd));
            }
            Console.WriteLine("Not sorted");
            Console.WriteLine("Name|Price|is Useful|Height|Growth Time");
            foreach (Tree x in workers)
            {
                Console.WriteLine($"{x.Name}|{x.Price}|{x.isUseful}|{x.Height}|" + x.GrowthTime);
            }
            workers.Sort();
            Console.WriteLine("\nSorted");
            Console.WriteLine("Name|Price|is Useful|Height|Growth Time");
            foreach (Tree x in workers)
            {
                Console.WriteLine($"{x.Name}|{x.Price}|{x.isUseful}|{x.Height}|" + x.GrowthTime);
            }
            Console.ReadKey();
        }
    }
}
