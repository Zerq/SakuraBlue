using Omnicatz.AccessDenied;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Helper {
    public static class Randomizer {
        static Random random;
        public static int Random(int min, int max) {

            if (random == null) { random = new System.Random(); }

            return random.Next(min, max);

        }
    }

    public static class Dice {
   
        public static Double CalculateDiceFormula(string formula) {
            var rex = new System.Text.RegularExpressions.Regex("([0-9]*)d([0-9])+", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            var newFormat = rex.Replace(formula, (match) => {
                if (match.Groups.Count == 2) {
                    return Dice.RollBase(1, int.Parse(match.Groups[1].Value)).ToString();                      
                }
                if (match.Groups.Count == 3) {    
                    return Dice.RollBase(1, int.Parse(match.Groups[2].Value)).ToString();
                }
                throw new FormatException("Bad dice formating");
            });

            return Convert.ToDouble(new NCalc.Expression(newFormat).Evaluate());


        }


          public static int RollBase(int numberOfDice, int x) {
            int resultSum = 0;
            for (int i = 0; i < numberOfDice; i++) {
                resultSum = Randomizer.Random(1, x);
            }
            return resultSum;
        }

    }

}
