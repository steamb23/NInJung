using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NInJung
{
    public enum ScriptEngineMode{
        Strict,
        Unstrict
    }
    public class ScriptEngine
    {
        ScriptEngineMode mode = ScriptEngineMode.Strict;
        public ScriptEngine()
        {
        }
        public ScriptEngine(ScriptEngineMode mode)
        {
            this.mode = mode;
        }
        public void Execute(string script)
        {
            StringBuilder printBuffer = new StringBuilder();
            bool unstricMode = mode == ScriptEngineMode.Unstrict;
            bool isPrint = false;
            bool isBlock = false;
            foreach (var word in script)
            {
                if (unstricMode)
                {
                    if (isPrint)
                    {
                        if (isBlock)
                        {
                            switch (word)
                            {
                                case 'ㄱ':
                                    printBuffer.Append('a');
                                    continue;
                                case 'ㄴ':
                                    printBuffer.Append('b');
                                    continue;
                                case 'ㄷ':
                                    printBuffer.Append('c');
                                    continue;
                                case 'ㄹ':
                                    printBuffer.Append('d');
                                    continue;
                                case 'ㅁ':
                                    printBuffer.Append('e');
                                    continue;
                                case '0':
                                    printBuffer.Append('f');
                                    continue;
                                case '1':
                                    printBuffer.Append('g');
                                    continue;
                                case 'ㅊ':
                                    printBuffer.Append('h');
                                    continue;
                                case 'ㅋ':
                                    printBuffer.Append('i');
                                    continue;
                                case 'ㅌ':
                                    printBuffer.Append('j');
                                    continue;
                                case 'ㅠ':
                                    printBuffer.Append('k');
                                    continue;
                                case '2':
                                    printBuffer.Append('l');
                                    continue;
                                case '3':
                                    printBuffer.Append('m');
                                    continue;
                                case '4':
                                    printBuffer.Append('n');
                                    continue;
                                case '5':
                                    printBuffer.Append('o');
                                    continue;
                                case '6':
                                    printBuffer.Append('p');
                                    continue;
                                case '7':
                                    printBuffer.Append('q');
                                    continue;
                                case '8':
                                    printBuffer.Append('r');
                                    continue;
                                case '9':
                                    printBuffer.Append('s');
                                    continue;
                                case 'ㄲ':
                                    printBuffer.Append('t');
                                    continue;
                                case 'ㄸ':
                                    printBuffer.Append('u');
                                    continue;
                                case 'ㅏ':
                                    printBuffer.Append('w');
                                    continue;
                                case 'ㅑ':
                                    printBuffer.Append('v');
                                    continue;
                                case 'ㅓ':
                                    printBuffer.Append('x');
                                    continue;
                                case 'ㅕ':
                                    printBuffer.Append('y');
                                    continue;
                                case 'ㅗ':
                                    printBuffer.Append('z');
                                    continue;
                                case ')':
                                    Console.Write(printBuffer.ToString());
                                    printBuffer.Clear();
                                    isPrint = false;
                                    continue;
                                default:
                                    printBuffer.Append(word);
                                    continue;
                            }
                        }
                        else if (word == '(')
                            isBlock = true;
                        else
                            isPrint = false;
                    }
                    else if (word == 'ㅊ')
                    {
                        isPrint = true;
                        continue;
                    }
                }
                switch (word)
                {
                    case 'ㅇ':
                        Console.WriteLine("안녕 세계");
                        break;
                    case 'ㅈ':
                        Console.WriteLine();
                        return;
                    default:
                        break;
                }
            }
        }
        public void ExecuteFromStream(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                this.Execute(reader.ReadToEnd());
            }
        }
        public void ExecuteFromFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                this.ExecuteFromStream(fs);
            }
        }
        public void ExecuteFromFile(Uri path)
        {
            ExecuteFromFile(path.AbsolutePath);
        }
    }
}
