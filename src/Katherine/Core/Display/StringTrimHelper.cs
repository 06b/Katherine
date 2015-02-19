using System;

namespace Katherine.Core.Display
{
    /// <summary>
    /// Helper class used for trimming strings up to a certain chartacter limit and adds an ellipsis afterwards if requested
    /// </summary>
    public class StringTrimHelper
    {
        /// <summary>
        /// Trims the string.
        /// </summary>
        /// <param name="Str">The string.</param>
        /// <param name="CharacterLimit">The character limit.</param>
        /// <returns></returns>
        public static string TrimString(object Str, object CharacterLimit)
        {
            return TrimString(Str.ToString(), Convert.ToInt32(CharacterLimit));
        }

        /// <summary>
        /// Trims the string.
        /// </summary>
        /// <param name="Str">The string.</param>
        /// <param name="CharacterLimit">The character limit.</param>
        /// <param name="AddEllipsis">if set to <c>true</c> [add ellipsis].</param>
        /// <returns></returns>
        public static string TrimString(string Str, int CharacterLimit, bool AddEllipsis)
        {
            if (Str.Length > CharacterLimit)
            {
                if (AddEllipsis) { return Str.Substring(0, CharacterLimit) + "..."; }
                else
                {
                    return Str.Substring(0, CharacterLimit);
                }
            }

            return Str;
        }
    }
}