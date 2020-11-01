using System;
using System.Collections.Generic;

namespace SimpleCalc
{
    class Program
    {
        static float mathfunc(string name, List<float> arg)
        {
            if (name == "pi") return (float)Math.PI;
            if (name == "sin") return (float)Math.Sin(arg[0]);
            if (name == "cos") return (float)Math.Cos(arg[0]);
            if (name == "max") return Math.Max(arg[0], arg[1]);

            return 0;
        }

        static void Test(string str, float n)
        {
            var formura = Calc.Analyze(str);
            float answer = formura.Calc(null);


            var result = n == answer ? "success" : "fail";
            Console.WriteLine($"{str}:{answer} / {n} {result}");

            if (n != answer)
            {
                List<(int tab, string str)> slist = new List<(int tab, string str)>();
                formura.TabString(slist, 0);

                foreach (var item in slist)
                {
                    Console.WriteLine(new String(' ', item.tab) + item.str);
                }
            }

        }

        static void TestList()
        {
            Test("1 + 2 + 7", 1 + 2 + 7);
            Test("-1 + 2 + 7", -1 + 2 + 7);
            Test("-1 + 2 * 7", -1 + 2 * 7);
            Test("-1 * 2 + 7", -1 * 2 + 7);
            Test("1 - 2 * 3 + 5", 1 - 2 * 3 + 5);
            Test("2 + 3 * 5", 2 + 3 * 5);
            Test("2 * 3 * 5", 2 * 3 * 5);
            Test("2 * 3 % 5", 2 * 3 % 5);
            Test("2 * 3 / 5", 2 * 3 / 5.0f);
            Test("2 * 3 + 4 * 5", 2 * 3 + 4 * 5);
        }


        static void Main(string[] args)
        {
            var formura1 = Calc.Analyze("(-5 + 2 )* -4");

            float answer1 = formura1.Calc(null);
            Console.WriteLine($"calc :{answer1}");

            var formura2 = Calc.Analyze("max(sin(theta * pi / 180), cos(theta * pi / 180))");

            for (int i = 0; i <= 90; i += 5)
            {
                Func<string, List<float>, float> f = (name, arg) =>
                {
                    if (name == "theta") return (float)i;
                    return mathfunc(name, arg);
                };

                float answer2 = formura2.Calc(f);
                Console.WriteLine($"i = {i}: calc = {answer2}");
            }


            TestList();

        }
    }
}
