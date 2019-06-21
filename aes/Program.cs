using System;
using System.IO;

namespace aes
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        var simpleTextBytes = File.ReadAllBytes("./arquivo/texto.txt");
        Console.WriteLine("Lendo texto simples da pasta ./arquivo/texto.txt");
        var keyBytes = File.ReadAllBytes("./chave/chave.txt");
        Console.WriteLine("Lendo chave da pasta ./chave/chave.txt");

        var key = new AesMatrix(keyBytes);
        var simpleTextMatrix = new ByteMatrix(simpleTextBytes);
        Console.WriteLine(simpleTextMatrix.byteMatrix.Count);
        byte[] bte = new byte[simpleTextMatrix.byteMatrix.Count * 16];
        var loop = 1;
        foreach (var simpleText in simpleTextMatrix.byteMatrix)
        {

          Console.WriteLine("****Chave****");
          key.Print();
          Console.WriteLine("****Texto simples****");
          simpleText.Print();
          var keyScheduler = new RoundKey(key).getAesMatrixCifred();
          var simpleXor = new SimpleXor(key, simpleText).GetSimpleXOR();
          var cifred = new MatrixRoundKey(simpleXor).GetRounds(keyScheduler);
          Console.WriteLine("****Texto cifrado****");
          cifred.Print();
          for(var i = 0; i < 4; i++) {
            for(int b = 0; b < 4; b++) {
                bte[b * loop] = cifred.matrix[b, i];
            }
          }
          loop++;
        }
        File.WriteAllBytes("./cifragem/cifragem.txt", bte);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Texto cifrado salvo na pasta ./cigragem/cigragem.txt");
        Console.ForegroundColor = ConsoleColor.White;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.StackTrace);
      }
    }
  }
}
