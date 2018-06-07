using System.Text;

namespace Core
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null; //if empty return null to the MainPage

            raw = raw.ToUpperInvariant(); //changes to uppercase

            var newNumber = new StringBuilder();
            foreach (var c in raw) //for a character in the string
            {
                if (" -0123456789".Contains(c))//if it is a number or -
                    newNumber.Append(c); //add it straight to the list
                else //if it is a letter or other character
                {
                    var result = TranslateToNumber(c); //turn the character to a number using the method below
                    if (result != null)  //if it successfully did that
                        newNumber.Append(result); //add the result to the list
                    // Bad character? Couldn't turn the charater into a number
                    else
                        return null; //return null to the MainPage
                }
            }
            return newNumber.ToString(); //If everything worked return the translated result to MainPage
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++) //i starts at 0, goes up by 1 until the i is equal to the length of digits
            {
                if (digits[i].Contains(c)) //if the current digit contains the character being translated
                    return 2 + i; // returns the index of the digit the character was found in plus 2
            }
            return null; //if the character was not found in digits, return null back to the MainPage
        }
    }
}