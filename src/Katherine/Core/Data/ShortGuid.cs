using System;

namespace Katherine.Core.Data
{
    /// <summary>
    /// Encodes a GUID into a 22 character long string and decodes the string back to the original GUID again.
    /// Url: http://madskristensen.net/post/A-shorter-and-URL-friendly-GUID
    /// </summary>
    public static class GuidEncoder
    {
        /// <summary>
        /// Encodes the specified unique identifier text.
        /// </summary>
        /// <param name="guidText">The unique identifier text.</param>
        /// <returns></returns>
        public static string Encode(string guidText)
        {
            Guid guid = new Guid(guidText);
            return Encode(guid);
        }

        /// <summary>
        /// Encodes the specified unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public static string Encode(Guid guid)
        {
            string enc = Convert.ToBase64String(guid.ToByteArray());
            enc = enc.Replace("/", "_");
            enc = enc.Replace("+", "-");
            return enc.Substring(0, 22);
        }

        /// <summary>
        /// Decodes the specified encoded.
        /// </summary>
        /// <param name="encoded">The encoded.</param>
        /// <returns></returns>
        public static Guid Decode(string encoded)
        {
            encoded = encoded.Replace("_", "/");
            encoded = encoded.Replace("-", "+");
            byte[] buffer = Convert.FromBase64String(encoded + "==");
            return new Guid(buffer);
        }
    }
}