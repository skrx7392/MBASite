using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MBASite.Helpers
{
    public class PasswordGenerator
    {
        /// <summary>
        /// Generates a new Password
        /// </summary>
        /// <returns></returns>
        public static string GeneratePassword()
        {
            return Membership.GeneratePassword(8, 0);
        }

        /// <summary>
        /// Hashes a string to MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            foreach (var i in result)
            {
                strBuilder.Append(i.ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}