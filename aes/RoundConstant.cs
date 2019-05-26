using System;
using System.Collections.Generic;

namespace aes
{
    class RoundConstant
    {
        public Dictionary<int, int> roundConstants { get; set; }
        public static RoundConstant roundConstant { get; set; }


        public RoundConstant() {
            roundConstants = new Dictionary<int, int>();
            this.Initializer();
        }

        public static int GetConstant(int iterator) {
            if (roundConstant == null) {
                roundConstant = new RoundConstant();
            }
            return roundConstant.roundConstants[iterator];
        }

        private void Initializer() {
            roundConstants.Add(0, (Convert.ToInt32("01", 16)));
            roundConstants.Add(1, (Convert.ToInt32("02", 16)));
            roundConstants.Add(2, (Convert.ToInt32("03", 16)));
            roundConstants.Add(3, (Convert.ToInt32("08", 16)));
            roundConstants.Add(5, (Convert.ToInt32("10", 16)));
            roundConstants.Add(6, (Convert.ToInt32("20", 16)));
            roundConstants.Add(7, (Convert.ToInt32("40", 16)));
            roundConstants.Add(8, (Convert.ToInt32("80", 16)));
            roundConstants.Add(9, (Convert.ToInt32("1b", 16)));
            roundConstants.Add(10, (Convert.ToInt32("36", 16)));
        }

    }
}
