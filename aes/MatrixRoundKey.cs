using System;
using System.IO;

namespace aes
{
    public class MatrixRoundKey
    {
        private AesMatrix simpleText;
        public MatrixRoundKey(AesMatrix simpleText)
        {
            this.simpleText = simpleText;
        }

        public AesMatrix GetRounds()
        {
            for(int i = 0; i < 1; i++) {
                this.SubBytes();
                Console.WriteLine(String.Format("****SubBytes-Round {0}****", i));
                this.simpleText.Print();
                this.ShiftRows();
                Console.WriteLine(String.Format("****ShiftRows-Round 1****", i));
                this.simpleText.Print();
                this.MixColumn();
                Console.WriteLine(String.Format("****MixedColumns-Round 1****", i));
                this.simpleText.Print();
            }
            return this.simpleText;
        }

        private void MixColumn() {
            byte[,] mixColumn = new byte[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    Console.WriteLine(TableL.Replace(this.simpleText.matrix[0, i].ToString("X2")).ToString("X2"));
                    Console.WriteLine(TableL.Replace(this.getMatrixMixColumn(j)[0].ToString("X2")).ToString("X2"));
                    var result = (
                        (
                            TableL.Replace(this.simpleText.matrix[0, i].ToString("X2")) + 
                            TableL.Replace(this.getMatrixMixColumn(j)[0].ToString("X2"))
                         ) ^
                        (
                            TableL.Replace(this.simpleText.matrix[1, i].ToString("X2")) + 
                            TableL.Replace(this.getMatrixMixColumn(j)[1].ToString("X2"))
                        ) ^
                        (
                            TableL.Replace(this.simpleText.matrix[2, i].ToString("X2")) + 
                            TableL.Replace(this.getMatrixMixColumn(j)[2].ToString("X2"))
                        ) ^
                        (
                            TableL.Replace(this.simpleText.matrix[3, i].ToString("X2")) + 
                            TableL.Replace(this.getMatrixMixColumn(j)[3].ToString("X2"))
                        )
                    );
                    Console.WriteLine(result.ToString("X2"));
                    throw new Exception();
                    if (result > 255) {
                        result -= 255;
                    }
                    mixColumn[i, j] = Convert.ToByte(SBox.Replace(result.ToString("X2")));
                }
            }
            this.simpleText.matrix = mixColumn;
        }

        private int[] getMatrixMixColumn(int line) {
            switch (line) {
                case 0:
                    return new int[4] {2, 3, 1, 1};
                case 1:
                    return new int[4] {1, 2, 3, 1};
                case 2:
                    return new int[4] {1, 1, 2, 3};
                case 3:
                    return new int[4] {3, 1, 1, 2};
            }
            return null;
        }

        public void SubBytes() {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    this.simpleText.matrix[i, j] = SBox.Replace(this.simpleText.matrix[i, j].ToString("X2"));
                }
            }
        }

        private void ShiftRows() {
            var v1 = this.simpleText.matrix[1, 0];
            this.simpleText.matrix[1, 0] = this.simpleText.matrix[1, 1];
            this.simpleText.matrix[1, 1] = this.simpleText.matrix[1, 2];
            this.simpleText.matrix[1, 2] = this.simpleText.matrix[1, 3];
            this.simpleText.matrix[1, 3] = v1;

            var v11 = this.simpleText.matrix[2, 0];
            var v2 = this.simpleText.matrix[2, 1];
            this.simpleText.matrix[2, 0] = this.simpleText.matrix[2, 2];
            this.simpleText.matrix[2, 1] = this.simpleText.matrix[2, 3];
            this.simpleText.matrix[2, 2] = v11;
            this.simpleText.matrix[2, 3] = v2;

            var v111 = this.simpleText.matrix[3, 0];
            var v22 = this.simpleText.matrix[3, 1];
            var v3 = this.simpleText.matrix[3, 2];
            this.simpleText.matrix[3, 0] = this.simpleText.matrix[3, 3];
            this.simpleText.matrix[3, 1] = v111;
            this.simpleText.matrix[3, 2] = v22;
            this.simpleText.matrix[3, 3] = v3;
        }
    }
}
