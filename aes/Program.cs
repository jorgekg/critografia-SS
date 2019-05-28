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
                var keyScheduler = new RoundKey(key).getAesMatrixCifred();
                var simpleXor = new SimpleXor(key, simpleText).GetSimpleXOR();
                var cifred = new MatrixRoundKey(simpleXor).GetRounds(keyScheduler);
                Console.WriteLine("****Texto cifrado****");
                cifred.Print();
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
