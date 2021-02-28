using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = 15;
            //int y = 1;
            //int z = 0;
            //for (int i = 1; i < x; i++)
            //{
            //    y *= i;
            //}
            //while (y % 10 == 0)
            //{
            //    y /= 10;
            //    z++;
            //}
            //Console.WriteLine($"нулей на конце {z}");

            string[] Line = File.ReadAllLines(@"C:\Users\Aleks\Source\Repos\s4hana-ext-deploy-custom-ui\webapp\controller\Detail.controller.js", Encoding.Default);

            List<string> Function = new List<string>();
            List<int> CountInputParametrs = new List<int>();

            int Str1, Str2;
            string Str3;

            foreach (string item in Line)
            {
                Str1 = item.IndexOf("function (");
                Str2 = item.IndexOf("_");

                if (Str1 != -1 && Str2 != -1)
                {
                    Function.Add(item);
                }
            }

            for (int i = 0; i < Function.Count; i++)
            {
                if (Function[i].IndexOf("function ()") != -1)
                {
                    Function.RemoveAt(i);
                    i--;
                }
            }

            foreach (string item in Function)
            {
                int Tmp1 = 0;
                Str3 = item;
                do
                {
                    Str1 = Str3.IndexOf(",");
                    Tmp1++;
                    if (Str1 == -1)
                    {
                        CountInputParametrs.Add(Tmp1);
                        continue;
                    }

                    Str3 = Str3.Substring(Str1 + 1);
                } while (Str1 != -1);
            }

            for (int i = 0; i < Function.Count; i++)
            {
                Str1 = Function[i].IndexOf(")") + 1;
                Function[i] = Function[i].Substring(0, Str1);
                Console.WriteLine($"{Function[i]} : {CountInputParametrs[i]}");
            }
        }
    }
}
