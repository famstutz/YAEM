// -----------------------------------------------------------------------
// <copyright file="StringUtilities.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Domain.Utilities
{
    using System.Text;

    /// <summary>
    /// Helper class for formatting strings as byte arrays and vice-versa.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Strings to byte array.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns>The byte array.</returns>
        public static byte[] StringToByteArray(string str)
        {
            var enc = new ASCIIEncoding();
            return enc.GetBytes(str);
        }

        /// <summary>
        /// Bytes the array to string.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns>The string.</returns>
        public static string ByteArrayToString(byte[] arr)
        {
            var enc = new ASCIIEncoding();
            return enc.GetString(arr);
        }
    }
}
