using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer
{
    public static class Data
    {
        public static List<string> GetServiceWords()
        {
            return new List<string>()
            {
                "begin",
                "if",
                "else",
                "for",
                "to",
                "step",
                "next",
                "readln",
                "writeln",
                "true",
                "false",
                "int",
                "float",
                "bool",
                "while",
                "end"
            };
        }

        public static List<string> GetSeparators()
        {
            return new List<string>()
            {
                "!=",
                "==",
                "<",
                "<=",
                ">",
                ">=",
                "+",
                "-",
                "||",
                "*",
                "/",
                "&&",
                "!",
                "(*",
                "*)",
                ",",
                ":",
                "/n",
                "(",
                ")",
                ":="
            };
        }
           
    }
}
