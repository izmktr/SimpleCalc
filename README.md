# SimpleCalc

C# で文字列の数式を計算するプログラムです。  
こちらの記事をGitHubに登録したものになります。  
https://qiita.com/izmktr/items/f5fe1f3818032e172f41

以下の事項に対応しています。  
- 四則演算
- 括弧
- +/- の単項演算子
- 変数、関数

よく見かける方法と比べて、変数や関数が使えるのが特徴です。  

## 使用方法

```
using System;
using System.Collections.Generic;

namespace Calc
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

        }
    }
}
```

変数や関数はCalc時にfloat f(string name, List < float > arg) の関数を引き渡します。  
変数や関数が出てくるたびに渡した関数が呼び出されます。  

pi と書いた場合は変数とみなされ、pi()と書いた場合は引数0の関数とみなされます。  
変数の場合は、arg=null、関数の場合はarg=List となります。  

Unityの座標計算に使うために作ったので、数値はすべてfloatですが、  
Intなりdoubleなりに書き換えるといいと思います。



