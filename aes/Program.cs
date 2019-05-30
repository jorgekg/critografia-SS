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
                var simpleTextMatrix = new ByteMatrix(simpleTextBytes);
                Console.WriteLine("teste");
                Console.WriteLine(simpleTextMatrix.byteMatrix.Count);
                foreach(var simpleText in simpleTextMatrix.byteMatrix) {

                    Console.WriteLine("****Chave****");
                    key.Print();
                    Console.WriteLine("****Texto simples****");
                    simpleText.Print();
                    var keyScheduler = new RoundKey(key).getAesMatrixCifred();
                    var simpleXor = new SimpleXor(key, simpleText).GetSimpleXOR();
                    var cifred = new MatrixRoundKey(simpleXor).GetRounds(keyScheduler);
                    Console.WriteLine("****Texto cifrado****");
                    cifred.Print();
                    // edvese gravar o cifred em formato byte num arquivo.
                }
                Console.WriteLine(simpleTextMatrix.byteMatrix.Count);
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
