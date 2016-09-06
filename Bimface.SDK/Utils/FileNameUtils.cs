using System;
using System.Collections.Generic;

namespace Bimface.SDK.Utils
{
    class FileNameUtils
    {

        private static string[] ILLEGAL_CHAR = new string[] { "/", "\n", "*", "\\", "<", ">", "|", "\"", ":", "?" };

        public static void CheckFileName(string name)
        {
            if (name == null || name.Length <= 0)
            {
                throw new ArgumentException("File name must not be empty.");
            }
            if (name.Length > 256)
            {
                throw new ArgumentException("File name too long, no more than 256 characters.");
            }
            string suffix = GetSuffix(name);
            if (suffix == null || suffix.Length <= 0)
            {
                throw new ArgumentException("File name has no suffix.");
            }
            if (ContainsIllegalChar(name))
            {
                throw new ArgumentException("File name contains illegal character.");
            }
        }

        public static void CheckFileType(IList<string> allSupportedType, string name)
        {
            string suffix = GetSuffix(name);
            foreach (string s in allSupportedType) {
                if (s.ToLower().Equals(suffix.ToLower())) {
                    return;
                }
            }
            throw new ArgumentException("File type not supported.");
        }

       
        private static bool ContainsIllegalChar(string value) {
            
            foreach (string x in ILLEGAL_CHAR) {
                if (value.Contains(x)) {
                return true;
                }
             }
   
            return false;
        }

        private static string GetSuffix(string name)
        {
            if (name.IndexOf(".") == -1)
            {
                return null;
            }
            string suffix = null;
            if (name != null && name.Length > 0)
            {
                suffix = name.Substring(name.LastIndexOf(".") + 1);
            }
            return suffix;
        }

    }
}
