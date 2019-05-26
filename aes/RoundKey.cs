using System;
using System.IO;

namespace aes
{
    class RoundKey
    {
        private AesMatrix aesMatrix { get; set; }
        public RoundKey(AesMatrix aesMatrix)
        {  
            this.aesMatrix = aesMatrix;
        }

        public AesMatrix getAesMatrixCifred(int roundKey) {
            this.RotateByte();
            this.SubByte();
            this.XORWithRoundConstant(roundKey);
            this.aesMatrix.Print();
            return this.aesMatrix;
        }

        private void XORWithRoundConstant(int roundKey) {
            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine(RoundConstant.GetConstant(roundKey));
                aesMatrix.matrix[0, i] = Convert.ToByte(
                    Convert.ToInt32(aesMatrix.matrix[0, i].ToString("X2"), 16) -
                    RoundConstant.GetConstant(roundKey)
                );
            }
        }

        private void SubByte() {
            var newMatrix = new byte[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++) {
                    newMatrix[i, j] = SBox.Replace(this.aesMatrix.matrix[i, j].ToString("X2"));
                }
            }
            this.aesMatrix.matrix =  newMatrix;
        }

        private void RotateByte() {
            var matrixKeyByte = new byte[4, 4];
            var matrix = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                if (i == 0) {
                    matrix = this.getLineByte(aesMatrix.matrix, i);
                } else {
                    for (var j = 0; j < 4; j++) {
                        matrixKeyByte[i - 1, j] = aesMatrix.matrix[i, j];
                    }
                }
            }
            for (var i = 0; i < 4; i++)
            {
                matrixKeyByte[3, i] = matrix[i];
            }
            this.aesMatrix.matrix = matrixKeyByte;
        }

        private byte[] getLineByte(byte[,] key, int line) {
            return new byte[4] {
                key[line, 0],
                key[line, 1],
                key[line, 2],
                key[line, 3]
            };
        }
    }
}
