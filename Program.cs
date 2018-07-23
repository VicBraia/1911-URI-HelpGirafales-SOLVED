using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static int M, N, resp;
        public static Dictionary<String, String> original = new Dictionary<string, string>();
        public static Dictionary<String, String> aula = new Dictionary<string, string>();
        public static string[] line;

        public static void Read_Class()
        {
            for (int i = 0; i < N; i++)
            {
                line = Console.ReadLine().Split();
                original.Add(line[0], line[1]);
            }

            M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                line = Console.ReadLine().Split();
                aula.Add(line[0], line[1]);
            }
        }

        public static int Check()
        {
            resp = 0;
            foreach (KeyValuePair<string, string> aluno in aula)
            {
                string key = aluno.Key;
                string assin;
                if (original.TryGetValue(key, out assin))
                {
                    if (assin != aluno.Value)
                    {
                        int diff = 0;
                        for (int i = 0; i < assin.Length; i++)
                        {
                            if (assin[i] != aluno.Value[i])
                            {
                                diff++;
                            }
                        }
                        if (diff >= 2)
                            resp++;
                    }
                }
            }
            return resp;
        }

        public static void CleanDictionaries()
        {
            original.Clear();
            aula.Clear();
        }

        static void Main(string[] args)
        {
            while ((N = int.Parse(Console.ReadLine())) != 0)
            {
                Read_Class();
                Console.WriteLine(Check());
                CleanDictionaries();
            }
        }
    }
}
