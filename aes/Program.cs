using System;
using System.IO;

namespace aes
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleTextBytes = File.ReadAllBytes("./arquivo/texto.txt");
            var keyBytes = File.ReadAllBytes("./chave/chave.txt");

            var key = new AesMatrix(keyBytes);
            var simpleText = new AesMatrix(simpleTextBytes);

            key.Print();
            simpleText.Print();
        }
    }
}
