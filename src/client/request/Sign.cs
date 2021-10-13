using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace songshuwu.client
{
    public static class Sign
    {
        public static string GetInput(string app_key, string app_secret, string @params, int version = 1)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var strsign = $@"{app_secret}app_key{app_key}params{@params}timestamp{timestamp}version{version}{app_secret}";
            using MD5 md5Hash = MD5.Create();
            var sign = Md5HashHelper.GetMd5Hash(md5Hash, strsign).ToUpper();
            return JsonSerializer.Serialize(new BaseInput()
            {
                app_key = app_key,
                sign = sign,
                timestamp = timestamp,
                version = version,
                @params = @params
            }, typeof(BaseInput));
        }
    }

    public static class Md5HashHelper
    {
        internal static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        internal static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
