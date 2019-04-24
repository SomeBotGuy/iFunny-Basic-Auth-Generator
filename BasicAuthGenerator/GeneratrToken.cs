using System;
using System.Security.Cryptography;
using System.Text;

namespace BasicAuthGenerator
{
    public class GenerateToken
    {

        private const string clientId = "MsOIJ39Q28";
        private const string clientSecret = "PTDc3H8a)Vi=UYap";

        private static readonly DateTime UnixTime = new DateTime
(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string GetBasicAuth()
        {
            return getBasicAuth(getInstallationID());
        }

        private static String GenerateID()
        {

            return Guid.NewGuid().ToString(); ;
        }

        private static String getInstallationID()
        {
            Exception e;
            Console.WriteLine("Creating installation ID...");
            long currentTimeMillis = CurrentTimeMillis() / 1000;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("android_1_");
            stringBuilder.Append(currentTimeMillis);
            stringBuilder.Append("_");
            stringBuilder.Append(GenerateID());
            String stringBuilder2 = stringBuilder.ToString();
            stringBuilder = new StringBuilder();
            stringBuilder.Append(" input ");
            stringBuilder.Append(stringBuilder2);
            try
            {
                stringBuilder2 = hashit(stringBuilder2);
                try
                {
                    stringBuilder = new StringBuilder();
                    stringBuilder.Append(" output ");
                    stringBuilder.Append(stringBuilder2);
                }
                catch (Exception e2)
                {
                    e = e2;
                    Console.WriteLine("Failed to create installation ID");
                    return stringBuilder2;
                }
            }
            catch (Exception e3)
            {
                e = e3;
                stringBuilder2 = null;
                Console.WriteLine("Failed to create installation ID");
                return stringBuilder2;
            }
            return stringBuilder2;
        }

        public static String hashit(String str)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("X2"));
            }
            return hash.ToString();
        }

        private static string getBasicAuth(string str)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(str);
                stringBuilder.Append('_');
                stringBuilder.Append(clientId);
                stringBuilder.Append(':');
                StringBuilder stringBuilder2 = new StringBuilder();
                stringBuilder2.Append(str);
                stringBuilder2.Append(":");
                stringBuilder2.Append(clientId);
                stringBuilder2.Append(":");
                stringBuilder2.Append(clientSecret);
                stringBuilder.Append(tokenhash(stringBuilder2.ToString()).ToLower());
                String encodeToString = Convert.ToBase64String(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
                stringBuilder2 = new StringBuilder();
                stringBuilder2.Append("Basic ");
                stringBuilder2.Append(encodeToString);
                return stringBuilder2.ToString();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static string tokenhash(string str)
        {
            SHA1Managed crypt = new SHA1Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("X2"));
            }
            return hash.ToString();

        }


        private static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - UnixTime).TotalMilliseconds;
        }
    }
}
