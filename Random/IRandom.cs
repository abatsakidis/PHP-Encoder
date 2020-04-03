﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IlluminationTools.Random
{
    public class IRandom
    {
        private static System.Random _RandomGen;

        private static System.Random RandomGen
        {
            get
            {
                if (_RandomGen == null)
                {
                    _RandomGen = new System.Random();
                }
                return _RandomGen;
            }
        }


        public IRandom()
        {

        }

        public static string GetRandomString(int Length, bool IncludeSpecialCharacters, bool IncludeNumbers)
        {
            string returnval = "";
            for (int i = 1; i <= Length; i++)
            {
                returnval += GetRandomChar(IncludeSpecialCharacters, IncludeNumbers).ToString();
            }
            return returnval;
        }

        public static char GetRandomChar(bool IncludeSpecialCharacters, bool IncludeNumbers)
        {
            //33-47 , 58-64, 91-96, 123-126 special characters
            //48-57 numbers
            //65-90 uppercase letters
            //97-122 lowercase letters
            bool GetNewChar = true;
            int randint = 0;
            if (IncludeNumbers && IncludeSpecialCharacters)
            {
                randint = RandomGen.Next(33, 122);
            }
            else if (IncludeNumbers)
            {
                //get a number between  48 and 122 but not between 58 and 64
                while (GetNewChar)
                {
                    randint = RandomGen.Next(48, 122);
                    GetNewChar = (randint >= 58 && randint <= 64);
                }
            }
            else if (IncludeSpecialCharacters)
            {
                while (GetNewChar)
                {
                    randint = RandomGen.Next(33, 122);
                    GetNewChar = (randint >= 48 && randint <= 57);
                }
            }
            else
            {
                while (GetNewChar)
                {
                    randint = RandomGen.Next(65, 122);
                    GetNewChar = (randint >= 91 && randint <= 96);
                }
            }
            return Convert.ToChar(char.ConvertFromUtf32(randint));
        }
    }
}
