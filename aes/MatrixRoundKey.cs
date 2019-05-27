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

        public AesMatrix GetRounds(byte[,] keyScheduler)
        {
            for (int i = 0; i < 10; i++)
            {
                this.SubBytes();
                Console.WriteLine(String.Format("****SubBytes-Round {0}****", i + 1));
                this.simpleText.Print();
                this.ShiftRows();
                Console.WriteLine(String.Format("****ShiftRows-Round {0}****", i + 1));
                this.simpleText.Print();
                this.MixColumn();
                Console.WriteLine(String.Format("****MixedColumns-Round {0}****", i + 1));
                this.simpleText.Print();
                this.addRoundKey(keyScheduler, i);
                Console.WriteLine(String.Format("****addRoundKey-Round {0}****", i + 1));
                this.simpleText.Print();
            }
            return this.simpleText;
        }

        private void addRoundKey(byte[,] keyScheduler, int roundKey)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    this.simpleText.matrix[j, i] = Convert.ToByte(
                        this.simpleText.matrix[j, i] ^
                        keyScheduler[j, (((roundKey + 1) * 4) + i)]
                    );
                }
            }
        }

        private void MixColumn()
        {
            byte[,] mixColumn = new byte[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var result = (
                        TableE.Replace(
                            ValidateWidthValue(nvl(this.simpleText.matrix[0, i], this.getMatrixMixColumn(j)[0], i, j)).ToString("X2")
                        ) ^
                        TableE.Replace(
                            ValidateWidthValue(nvl(this.simpleText.matrix[1, i], this.getMatrixMixColumn(j)[1], i, j)).ToString("X2")
                        ) ^
                        TableE.Replace(
                            ValidateWidthValue(nvl(this.simpleText.matrix[2, i], this.getMatrixMixColumn(j)[2], i, j)).ToString("X2")
                        ) ^
                        TableE.Replace(
                            ValidateWidthValue(nvl(this.simpleText.matrix[3, i], this.getMatrixMixColumn(j)[3], i, j)).ToString("X2")
                        )
                    );
                    mixColumn[j, i] = Convert.ToByte(result);
                }
            }
            this.simpleText.matrix = mixColumn;
        }

        private int nvl(int val1, int val2, int i, int j)
        {
            var val1Result = (ValidateWidthValue(TableL.Replace(val1.ToString("X2")) + TableL.Replace(val2.ToString("X2")))).ToString("X2");
            if (val1Result.ToString().ToCharArray()[0] == 0 || val1Result.ToString().ToCharArray()[1] == 0)
            {
                return 0;
            }
            if (val1Result.ToString().ToCharArray()[0] == 1)
            {
                return val1Result.ToString().ToCharArray()[1];
            }
            if (val1Result.ToString().ToCharArray()[1] == 1)
            {
                return val1Result.ToString().ToCharArray()[0];
            }
            return TableL.Replace(val1.ToString("X2")) + TableL.Replace(val2.ToString("X2"));
        }

        private int ValidateWidthValue(int value)
        {
            if (value > 255)
            {
                return value - 255;
            }
            return value;
        }

        private int[] getMatrixMixColumn(int line)
        {
            switch (line)
            {
                case 0:
                    return new int[4] { 2, 3, 1, 1 };
                case 1:
                    return new int[4] { 1, 2, 3, 1 };
                case 2:
                    return new int[4] { 1, 1, 2, 3 };
                case 3:
                    return new int[4] { 3, 1, 1, 2 };
            }
            return null;
        }

        public void SubBytes()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    this.simpleText.matrix[i, j] = SBox.Replace(this.simpleText.matrix[i, j].ToString("X2"));
                }
            }
        }

        private void ShiftRows()
        {
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
