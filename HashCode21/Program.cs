using System;

namespace HashCode21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============= HashCode21 BEGIN =============");

            NaiveSolver naiveSolverA = new NaiveSolver("a.txt", "a.out", ' ');
            NaiveSolver naiveSolverB = new NaiveSolver("b.txt", "b.out", ' ');
            NaiveSolver naiveSolverC = new NaiveSolver("c.txt", "c.out", ' ');
            NaiveSolver naiveSolverD = new NaiveSolver("d.txt", "d.out", ' ');
            NaiveSolver naiveSolverE = new NaiveSolver("e.txt", "e.out", ' ');
            NaiveSolver naiveSolverF = new NaiveSolver("f.txt", "f.out", ' ');

            Console.WriteLine("============= HashCode21 END =============");
            Console.ReadKey();
        }
    }
}
