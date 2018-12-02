using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AoC2018.Lib
{
    public class Day02
    {
        public enum Checks {
            NONE, TWO, THREE, BOTH
        }

        public int Part1(string input)
        {
            string[] numbers = input.Split(Environment.NewLine.ToCharArray()); ;

            int two = 0;
            int three = 0;

            foreach (string number in numbers)
            {
                Checks check = this.Checksum(number);

                if (check == Checks.TWO || check == Checks.BOTH) {
                    two++;
                }

                if (check >= Checks.THREE) {
                    three++;
                }
            }

            return two *  three;
        }


        public Checks Checksum(String number) {
            var map = new Dictionary<char, int>();

            foreach (char c in number) {
                if (map.ContainsKey(c)) {
                    map[c] = map[c] + 1;
                } else {
                    map[c] = 1;
                }
            }

            int two = 0;
            int three = 0;

            foreach(char c in map.Keys) {
                if (map[c] == 2) {
                    two++;
                } else if(map[c] == 3) {
                    three++;
                }
            }

            if (three >  0 && two > 0) {
                return Checks.BOTH;
            } 

            if (three > 0) {
                return Checks.THREE;
            }

            if (two > 0) {
                return Checks.TWO;
            }

            return Checks.NONE;
        }

        public int DiffOnOnePosition(string one, string two) {
            if (one.Length != two.Length) {
                return -1;
            }

            int diff = -1;

            for (int i = 0; i < one.Length; i++) {
                if (one[i] != two[i]) {
                    if (diff == -1) {
                        diff = i;
                    } else {
                        return -1;
                    }
                }
            }

            return diff;
        }

        public string Part2(string input)
        {
            string[] numbers = input.Split(Environment.NewLine.ToCharArray()); ;

            foreach (string numberOne in numbers)
            {
                foreach (string numberTwo in numbers) {
                    int pos = this.DiffOnOnePosition(numberOne, numberTwo);

                    if (pos != -1) {
                        StringBuilder sb = new StringBuilder(numberOne);
                        sb.Remove(pos, 1);

                        return sb.ToString();
                    }
                }
            }

            return "";
        }
    }
}
