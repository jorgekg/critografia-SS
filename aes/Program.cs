using System;
using System.IO;

namespace aes
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var simpleTextBytes = File.ReadAllBytes("./arquivo/texto.txt");
                var keyBytes = File.ReadAllBytes("./chave/chave.txt");

                var key = new AesMatrix(keyBytes);
                var simpleText = new AesMatrix(simpleTextBytes);

                Console.WriteLine("****Chave****");
                key.Print();
                Console.WriteLine("****Texto simples****");
                simpleText.Print();
                var rounds = new RoundKey(key).getAesMatrixCifred();
                Console.WriteLine("****AddRoundKey-Round 0****");
                var simpleXor = new SimpleXor(key, simpleText).GetSimpleXOR();
                var cifred = new MatrixRoundKey(simpleXor).GetRounds();
                simpleXor.Print();
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
