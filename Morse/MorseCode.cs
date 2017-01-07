using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Morse
{
    /// <summary>
    /// Class for converting latinic to morse alphabet and sending it through the audio card.
    /// </summary>
    public class MorseCode
    {
        private static Dictionary<char, char[]> morseAplhabet;
        private int speed;
        private int tone;

        public MorseCode()
        {
            this.speed = 700;
            this.tone = 200;
        }

        public int GetSpeed()
        {
            return this.speed;
        }

        public void SetSpeed(int newSpeed)
        {
            this.speed = newSpeed;
        }

        public int GetTone()
        {
            return this.tone;
        }

        public void SetTone(int newTone)
        {
            this.tone = newTone;
        }

        /// <summary>
        /// Converts the text to morse code and sends it.
        /// </summary>
        /// <param name="text"></param>
        public void SendCode(string text)
        {
           
            char[] letters = text.ToUpper().ToArray();

            FillAlphabet();

            for (int letter = 0; letter < letters.Length; letter++)
            {
                char currentLetter = letters[letter];

                for (int col = 0; col < morseAplhabet[currentLetter].Length; col++)
                {
                    if (morseAplhabet[currentLetter][col] == '.')
                    {
                        Console.Beep(this.GetTone(), this.GetSpeed());

                    }
                    else if (morseAplhabet[currentLetter][col] == '-')
                    {
                        Console.Beep(this.GetTone(), this.GetSpeed() * 3);

                    }
                    else
                    {
                        Thread.Sleep(this.GetSpeed() * 3);
                    }
                }


            }

        }

        /// <summary>
        /// Fills array with the Morse aplhabet
        /// </summary>
        private static void FillAlphabet()
        {
            morseAplhabet = new Dictionary<char, char[]>();

            morseAplhabet.Add('A' ,new char[2]);         //A
            morseAplhabet['A'][0] = '.';
            morseAplhabet['A'][1] = '-';

            morseAplhabet.Add('B',new char[4]);         //B
            morseAplhabet['B'][0] = '-';
            morseAplhabet['B'][1] = '.';
            morseAplhabet['B'][2] = '.';
            morseAplhabet['B'][3] = '.';

            morseAplhabet.Add('C', new char[4]);         //C
            morseAplhabet['C'][0] = '-';
            morseAplhabet['C'][1] = '.';
            morseAplhabet['C'][2] = '-';
            morseAplhabet['C'][3] = '.';

            morseAplhabet.Add('D', new char[3]);         //D
            morseAplhabet['D'][0] = '-';
            morseAplhabet['D'][1] = '.';
            morseAplhabet['D'][2] = '.';

            morseAplhabet.Add('E', new char[1]);         //E
            morseAplhabet['E'][0] = '.';

            morseAplhabet.Add('F' , new char[4]);         //F
            morseAplhabet['F'][0] = '.';
            morseAplhabet['F'][1] = '.';
            morseAplhabet['F'][2] = '-';
            morseAplhabet['F'][3] = '.';

            morseAplhabet.Add('G', new char[3]);         //G
            morseAplhabet['G'][0] = '-';
            morseAplhabet['G'][1] = '-';
            morseAplhabet['G'][2] = '.';

            morseAplhabet.Add('H', new char[4]);         //H
            morseAplhabet['H'][0] = '.';
            morseAplhabet['H'][1] = '.';
            morseAplhabet['H'][2] = '.';
            morseAplhabet['H'][3] = '.';

            morseAplhabet.Add('I', new char[2]);         //I
            morseAplhabet['I'][0] = '.';
            morseAplhabet['I'][1] = '.';

            morseAplhabet.Add('J', new char[4]);         //J
            morseAplhabet['J'][0] = '.';
            morseAplhabet['J'][1] = '-';
            morseAplhabet['J'][2] = '-';
            morseAplhabet['J'][3] = '-';

            morseAplhabet.Add('K', new char[3]);        //K
            morseAplhabet['K'][0] = '-';
            morseAplhabet['K'][1] = '.';
            morseAplhabet['K'][2] = '-';

            morseAplhabet.Add('L', new char[4]);        //L
            morseAplhabet['L'][0] = '.';
            morseAplhabet['L'][1] = '-';
            morseAplhabet['L'][2] = '.';
            morseAplhabet['L'][3] = '.';

            morseAplhabet.Add('M', new char[2]);        //M
            morseAplhabet['M'][0] = '-';
            morseAplhabet['M'][1] = '-';

            morseAplhabet.Add('N', new char[2]);        //N
            morseAplhabet['N'][0] = '-';
            morseAplhabet['N'][1] = '.';

            morseAplhabet.Add('O', new char[3]);        //O
            morseAplhabet['O'][0] = '-';
            morseAplhabet['O'][1] = '-';
            morseAplhabet['O'][2] = '-';

            morseAplhabet.Add('P', new char[4]);        //P
            morseAplhabet['P'][0] = '.';
            morseAplhabet['P'][1] = '-';
            morseAplhabet['P'][2] = '-';
            morseAplhabet['P'][3] = '.';

            morseAplhabet.Add('Q', new char[4]);        //Q
            morseAplhabet['Q'][0] = '-';
            morseAplhabet['Q'][1] = '-';
            morseAplhabet['Q'][2] = '.';
            morseAplhabet['Q'][3] = '-';

            morseAplhabet.Add('R', new char[3]);        //R
            morseAplhabet['R'][0] = '.';
            morseAplhabet['R'][1] = '-';
            morseAplhabet['R'][2] = '.';

            morseAplhabet.Add('S', new char[3]);        //S
            morseAplhabet['S'][0] = '.';
            morseAplhabet['S'][1] = '.';
            morseAplhabet['S'][2] = '.';

            morseAplhabet.Add('T', new char[1]);        //T
            morseAplhabet['T'][0] = '-';

            morseAplhabet.Add('U', new char[3]);        //U
            morseAplhabet['U'][0] = '.';
            morseAplhabet['U'][1] = '.';
            morseAplhabet['U'][2] = '-';

            morseAplhabet.Add('V', new char[4]);        //V
            morseAplhabet['V'][0] = '.';
            morseAplhabet['V'][1] = '.';
            morseAplhabet['V'][2] = '.';
            morseAplhabet['V'][3] = '-';

            morseAplhabet.Add('W', new char[3]);        //W
            morseAplhabet['W'][0] = '.';
            morseAplhabet['W'][1] = '-';
            morseAplhabet['W'][2] = '-';

            morseAplhabet.Add('X', new char[4]);        //X
            morseAplhabet['X'][0] = '-';
            morseAplhabet['X'][1] = '.';
            morseAplhabet['X'][2] = '.';
            morseAplhabet['X'][3] = '-';

            morseAplhabet.Add('Y' , new char[4]);        //Y
            morseAplhabet['Y'][0] = '-';
            morseAplhabet['Y'][1] = '.';
            morseAplhabet['Y'][2] = '-';
            morseAplhabet['Y'][3] = '-';

            morseAplhabet.Add('Z', new char[4]);        //Z
            morseAplhabet['Z'][0] = '-';
            morseAplhabet['Z'][1] = '-';
            morseAplhabet['Z'][2] = '.';
            morseAplhabet['Z'][3] = '.';

            morseAplhabet.Add(' ', new char[1]);         //(space)
            morseAplhabet[' '][0] = ' ';

            morseAplhabet.Add('0', new char[5]);
            morseAplhabet['0'][0] = '-';
            morseAplhabet['0'][1] = '-';
            morseAplhabet['0'][2] = '-';
            morseAplhabet['0'][3] = '-';
            morseAplhabet['0'][4] = '-';

            morseAplhabet.Add('1', new char[5]);
            morseAplhabet['1'][0] = '.';
            morseAplhabet['1'][1] = '-';
            morseAplhabet['1'][2] = '-';
            morseAplhabet['1'][3] = '-';
            morseAplhabet['1'][4] = '-';

            morseAplhabet.Add('2', new char[5]);
            morseAplhabet['2'][0] = '.';
            morseAplhabet['2'][1] = '.';
            morseAplhabet['2'][2] = '-';
            morseAplhabet['2'][3] = '-';
            morseAplhabet['2'][4] = '-';

            morseAplhabet.Add('3', new char[5]);
            morseAplhabet['3'][0] = '.';
            morseAplhabet['3'][1] = '.';
            morseAplhabet['3'][2] = '.';
            morseAplhabet['3'][3] = '-';
            morseAplhabet['3'][4] = '-';

            morseAplhabet.Add('4', new char[5]);
            morseAplhabet['4'][0] = '.';
            morseAplhabet['4'][1] = '.';
            morseAplhabet['4'][2] = '.';
            morseAplhabet['4'][3] = '.';
            morseAplhabet['4'][4] = '-';

            morseAplhabet.Add('5', new char[5]);
            morseAplhabet['5'][0] = '.';
            morseAplhabet['5'][1] = '.';
            morseAplhabet['5'][2] = '.';
            morseAplhabet['5'][3] = '.';
            morseAplhabet['5'][4] = '.';

            morseAplhabet.Add('6', new char[5]);
            morseAplhabet['6'][0] = '-';
            morseAplhabet['6'][1] = '.';
            morseAplhabet['6'][2] = '.';
            morseAplhabet['6'][3] = '.';
            morseAplhabet['6'][4] = '.';

            morseAplhabet.Add('7', new char[5]);
            morseAplhabet['7'][0] = '-';
            morseAplhabet['7'][1] = '-';
            morseAplhabet['7'][2] = '.';
            morseAplhabet['7'][3] = '.';
            morseAplhabet['7'][4] = '.';

            morseAplhabet.Add('8', new char[5]);
            morseAplhabet['8'][0] = '-';
            morseAplhabet['8'][1] = '-';
            morseAplhabet['8'][2] = '-';
            morseAplhabet['8'][3] = '.';
            morseAplhabet['8'][4] = '.';

            morseAplhabet.Add('9', new char[5]);
            morseAplhabet['9'][0] = '-';
            morseAplhabet['9'][1] = '-';
            morseAplhabet['9'][2] = '-';
            morseAplhabet['9'][3] = '-';
            morseAplhabet['9'][4] = '.';

            morseAplhabet.Add('.', new char[6]);
            morseAplhabet['.'][0] = '.';
            morseAplhabet['.'][1] = '-';
            morseAplhabet['.'][2] = '.';
            morseAplhabet['.'][3] = '-';
            morseAplhabet['.'][4] = '.';
            morseAplhabet['.'][5] = '-';

            morseAplhabet.Add(',', new char[6]);
            morseAplhabet[','][0] = '-';
            morseAplhabet[','][1] = '-';
            morseAplhabet[','][2] = '.';
            morseAplhabet[','][3] = '.';
            morseAplhabet[','][4] = '-';
            morseAplhabet[','][5] = '-';

            morseAplhabet.Add('?', new char[6]);
            morseAplhabet['?'][0] = '.';
            morseAplhabet['?'][1] = '.';
            morseAplhabet['?'][2] = '-';
            morseAplhabet['?'][3] = '-';
            morseAplhabet['?'][4] = '.';
            morseAplhabet['?'][5] = '.';

            morseAplhabet.Add('!', new char[5]);
            morseAplhabet['!'][0] = '.';
            morseAplhabet['!'][1] = '.';
            morseAplhabet['!'][2] = '-';
            morseAplhabet['!'][3] = '-';
            morseAplhabet['!'][4] = '.';

            morseAplhabet.Add(':', new char[6]);
            morseAplhabet[':'][0] = '-';
            morseAplhabet[':'][1] = '-';
            morseAplhabet[':'][2] = '-';
            morseAplhabet[':'][3] = '.';
            morseAplhabet[':'][4] = '.';
            morseAplhabet[':'][5] = '.';

            morseAplhabet.Add('"', new char[6]);
            morseAplhabet['"'][0] = '.';
            morseAplhabet['"'][1] = '-';
            morseAplhabet['"'][2] = '.';
            morseAplhabet['"'][3] = '.';
            morseAplhabet['"'][4] = '-';
            morseAplhabet['"'][5] = '.';

            morseAplhabet.Add('\'', new char[6]);
            morseAplhabet['\''][0] = '.';
            morseAplhabet['\''][1] = '-';
            morseAplhabet['\''][2] = '-';
            morseAplhabet['\''][3] = '-';
            morseAplhabet['\''][4] = '-';
            morseAplhabet['\''][5] = '.';

            morseAplhabet.Add('=', new char[6]);
            morseAplhabet['='][0] = '-';
            morseAplhabet['='][1] = '.';
            morseAplhabet['='][2] = '.';
            morseAplhabet['='][3] = '.';
            morseAplhabet['='][4] = '-';
        }
    }
}

