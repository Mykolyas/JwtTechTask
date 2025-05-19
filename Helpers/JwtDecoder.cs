using System;
using System.Text;

namespace JwtTechTask.Helpers
{
    public static class JwtDecoder
    {
        public static string DecodePayload(string jwt)
        {
            var parts = jwt.Split('.');
            if (parts.Length != 3)
                throw new ArgumentException("Invalid JWT format");

            string payload = parts[1];

            // Add missing base64 padding if needed
            int padding = 4 - (payload.Length % 4);
            if (padding < 4) payload += new string('=', padding);

            byte[] bytes = Convert.FromBase64String(payload);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
