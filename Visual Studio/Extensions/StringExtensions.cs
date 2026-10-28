using System;
using System.Text;
using System.Collections.Generic;

namespace Visual_Studio.Extensions
{
    public static class StringExtensions
    {
        
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return true;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                
                if (!char.IsLetterOrDigit(str[left]))
                {
                    left++;
                    continue;
                }
                
                if (!char.IsLetterOrDigit(str[right]))
                {
                    right--;
                    continue;
                }

                
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }

       
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;

            
            string[] words = str.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            char[] charArray = str.ToCharArray();
            int left = 0;
            int right = charArray.Length - 1;

            while (left < right)
            {
                
                char temp = charArray[left];
                charArray[left] = charArray[right];
                charArray[right] = temp;

                left++;
                right--;
            }

            return new string(charArray);
        }
    }
}