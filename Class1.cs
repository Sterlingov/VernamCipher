namespace VCipherClsLib
{
    public class VCipher
    {
        public static void Hello()
        {
            Console.WriteLine("Hello world!");
        }

        public static string GetBits(string s)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            byte[] arr = System.Text.Encoding.Default.GetBytes(s);

            foreach (var i in arr)
            {
                string tmp = Convert.ToString(i, 2);
                while (tmp.Length < 8)
                {
                    tmp = "0" + tmp;
                }
                sb.Append(tmp);
            }
            return sb.ToString();
        }

        public static string GetStr(string s)
        {

            List<byte> arr = new List<byte>();
            while (s.Length > 0)
            {
                arr.Add(Convert.ToByte(s.Substring(0, 8), 2));
                s = s.Remove(0, 8);
            }
            byte[] barr = arr.ToArray();
            string result = System.Text.Encoding.UTF8.GetString(barr);
            return result;
        }

        static string GenerateKey(int l)
        {
            char[] arr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                'T', 'U', 'V', 'W', 'X', 'Y', 'Z','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '@', '#', '%', '&', '?', '-', '+', '=', '~'};
            string key = "";
            Random random = new Random();
            for (int i = 0; i < l * 3; i++)
            {
                key += arr[random.Next(0, arr.Length)];
            }
            return key + "vendetta";
        }

        public static Tuple<string, string> Vernam(string s)
        {
            string str = GetBits(s);
            string k = GenerateKey(s.Length);
            string key = GetBits(k);
            char[] keyarr = key.ToCharArray();
            char[] strarr = str.ToCharArray();
            string result = "";

            for (int i = 0; i < strarr.Length; i++)
            {
                result += keyarr[i] ^ strarr[i];

            }

            return Tuple.Create(GetBytes(result), GetStr(key));
        }

        static string GetBytes(string bitstring)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            while (bitstring.Length != 0)
            {
                string str = bitstring.Substring(0, 8);
                bitstring = bitstring.Remove(0, 8);
                sb.Append(Convert.ToInt32(str, 2) + "$");
            }
            string s = sb.ToString();
            s = s.Remove(s.Length - 1);

            return s;
        }

        public static string GetBitsFromBytes(string bytestring)
        {
            string[] arr = bytestring.Split("$");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in arr)
            {

                int i = int.Parse(item);
                string tmp = Convert.ToString(i, 2);
                while (tmp.Length < 8)
                {
                    tmp = "0" + tmp;
                }
                sb.Append(tmp);
            }
            return sb.ToString();
        }

        public static string UnVernam(string s, string k)
        {
            string key = VCipher.GetBits(k);
            string str = VCipher.GetBitsFromBytes(s);
            char[] keyarr = key.ToCharArray();
            char[] strarr = str.ToCharArray();
            string result = "";

            for (int i = 0; i < strarr.Length; i++)
            {
                result += keyarr[i] ^ strarr[i];

            }
            return VCipher.GetStr(result);
        }
    }
}