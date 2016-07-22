using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NInJung;

namespace NinJung_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = new ScriptEngine();
            ScriptEngine unstrictEngine = new ScriptEngine(ScriptEngineMode.Unstrict);
            Console.WriteLine("==표준 인정 테스트");
            engine.Execute("ㅇㅇㅈ");
            Console.WriteLine();
            Console.WriteLine("==Unstrict 인정 테스트");
            unstrictEngine.Execute("ㅇㅊ(Hㅁ225, W582ㄹ.)ㅈ");
            Console.WriteLine();
            Console.WriteLine("==파일 테스트");
            engine.ExecuteFromFile("인정.ㅇㅈ");
        }
    }
}
