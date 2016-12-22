using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MorseCode
{
    class Program
    {
        private static char[][] morseAplhabet;

        static void Main(string[] args)
        {
            Console.Write("Set speed : ");
            int speed = int.Parse(Console.ReadLine());
            Console.Write("Set Tone : ");
            int tone = int.Parse(Console.ReadLine());

            char[] letters = Console.ReadLine().ToUpper().ToArray();

            var rows = new List<int>();


            FillAlphabet();

            for (int letter = 0; letter < letters.Length; letter++)
            {
                if ((int)letters[letter] == 32)
                {
                    rows.Add(26);
                }
                else
                {
                    rows.Add((int)letters[letter] - 65);
                }

            }

            for (int i = 0; i < rows.Count; i++)
            {
                int currentRow = rows[i];

                for (int col = 0; col < morseAplhabet[currentRow].Length; col++)
                {
                    if (morseAplhabet[currentRow][col] == '.')
                    {
                        Console.Beep(tone, speed);

                    }
                    else if (morseAplhabet[currentRow][col] == '-')
                    {
                        Console.Beep(tone, speed * 3);

                    }
                    else
                    {
                        Thread.Sleep(speed * 3);
                    }
                }


            }

        }


        private static void FillAlphabet()
        {
            morseAplhabet = new char[27][];

            morseAplhabet[0] = new char[2];         //A
            morseAplhabet[0][0] = '.';
            morseAplhabet[0][1] = '-';

            morseAplhabet[1] = new char[4];         //B
            morseAplhabet[1][0] = '-';
            morseAplhabet[1][1] = '.';
            morseAplhabet[1][2] = '.';
            morseAplhabet[1][3] = '.';

            morseAplhabet[2] = new char[4];         //C
            morseAplhabet[2][0] = '-';
            morseAplhabet[2][1] = '.';
            morseAplhabet[2][2] = '-';
            morseAplhabet[2][3] = '.';

            morseAplhabet[3] = new char[3];         //D
            morseAplhabet[3][0] = '-';
            morseAplhabet[3][1] = '.';
            morseAplhabet[3][2] = '.';

            morseAplhabet[4] = new char[1];         //E
            morseAplhabet[4][0] = '.';

            morseAplhabet[5] = new char[4];         //F
            morseAplhabet[5][0] = '.';
            morseAplhabet[5][1] = '.';
            morseAplhabet[5][2] = '-';
            morseAplhabet[5][3] = '.';

            morseAplhabet[6] = new char[3];         //G
            morseAplhabet[6][0] = '-';
            morseAplhabet[6][1] = '-';
            morseAplhabet[6][2] = '.';

            morseAplhabet[7] = new char[4];         //H
            morseAplhabet[7][0] = '.';
            morseAplhabet[7][1] = '.';
            morseAplhabet[7][2] = '.';
            morseAplhabet[7][3] = '.';

            morseAplhabet[8] = new char[2];         //I
            morseAplhabet[8][0] = '.';
            morseAplhabet[8][1] = '.';

            morseAplhabet[9] = new char[4];         //J
            morseAplhabet[9][0] = '.';
            morseAplhabet[9][1] = '-';
            morseAplhabet[9][2] = '-';
            morseAplhabet[9][3] = '-';

            morseAplhabet[10] = new char[3];        //K
            morseAplhabet[10][0] = '-';
            morseAplhabet[10][1] = '.';
            morseAplhabet[10][2] = '-';

            morseAplhabet[11] = new char[4];        //L
            morseAplhabet[11][0] = '.';
            morseAplhabet[11][1] = '-';
            morseAplhabet[11][2] = '.';
            morseAplhabet[11][3] = '.';

            morseAplhabet[12] = new char[2];        //M
            morseAplhabet[12][0] = '-';
            morseAplhabet[12][1] = '-';

            morseAplhabet[13] = new char[2];        //N
            morseAplhabet[13][0] = '-';
            morseAplhabet[13][1] = '.';

            morseAplhabet[14] = new char[3];        //O
            morseAplhabet[14][0] = '-';
            morseAplhabet[14][1] = '-';
            morseAplhabet[14][2] = '-';

            morseAplhabet[15] = new char[4];        //P
            morseAplhabet[15][0] = '.';
            morseAplhabet[15][1] = '-';
            morseAplhabet[15][2] = '-';
            morseAplhabet[15][3] = '.';

            morseAplhabet[16] = new char[4];        //Q
            morseAplhabet[16][0] = '-';
            morseAplhabet[16][1] = '-';
            morseAplhabet[16][2] = '.';
            morseAplhabet[16][3] = '-';

            morseAplhabet[17] = new char[3];        //R
            morseAplhabet[17][0] = '.';
            morseAplhabet[17][1] = '-';
            morseAplhabet[17][2] = '.';

            morseAplhabet[18] = new char[3];        //S
            morseAplhabet[18][0] = '.';
            morseAplhabet[18][1] = '.';
            morseAplhabet[18][2] = '.';

            morseAplhabet[19] = new char[1];        //T
            morseAplhabet[19][0] = '-';

            morseAplhabet[20] = new char[3];        //U
            morseAplhabet[20][0] = '.';
            morseAplhabet[20][1] = '.';
            morseAplhabet[20][2] = '-';

            morseAplhabet[21] = new char[4];        //V
            morseAplhabet[21][0] = '.';
            morseAplhabet[21][1] = '.';
            morseAplhabet[21][2] = '.';
            morseAplhabet[21][3] = '-';

            morseAplhabet[22] = new char[3];        //W
            morseAplhabet[22][0] = '.';
            morseAplhabet[22][1] = '-';
            morseAplhabet[22][2] = '-';

            morseAplhabet[23] = new char[4];        //X
            morseAplhabet[23][0] = '-';
            morseAplhabet[23][1] = '.';
            morseAplhabet[23][2] = '.';
            morseAplhabet[23][3] = '-';

            morseAplhabet[24] = new char[4];        //Y
            morseAplhabet[24][0] = '-';
            morseAplhabet[24][1] = '.';
            morseAplhabet[24][2] = '-';
            morseAplhabet[24][3] = '-';

            morseAplhabet[25] = new char[4];        //Z
            morseAplhabet[25][0] = '-';
            morseAplhabet[25][1] = '-';
            morseAplhabet[25][2] = '.';
            morseAplhabet[25][3] = '.';

            morseAplhabet[26] = new char[1];         //(space)
            morseAplhabet[26][0] = ' ';
        }
    }
}
