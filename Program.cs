using System.IO;
using System.Reflection.Metadata;

namespace PB_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fStream = File.OpenRead("C:\\Users\\tiuti\\OneDrive\\Desktop\\Sample.txt"))
            {
                Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("Введіть число переважності:");
                int n;
                while (!int.TryParse(Console.ReadLine(), out n)) { };
                n /= 2;
                byte[] arr = new byte[fStream.Length];
                fStream.Read(arr, 0, arr.Length);
                string text = System.Text.Encoding.Default.GetString(arr).ToLower();
                Dictionary<string, int> distribution = new Dictionary<string, int>();
                char[] delimiterChars = new char[] { ',', '.', ';', ':', '!', '?', ' ', '\t', '\n', '\r' };
                var words = text.Split(delimiterChars).Where(x => x != "");
                foreach (string word in words)
                {
                    if (!distribution.ContainsKey(word))
                    {
                        distribution.Add(word, 1);
                    }
                    else { distribution[word]++; }
                }
                Console.WriteLine("Слова, що відповідають переважності:");
                foreach (string word in distribution.Keys)
                {
                    if (distribution[word] >= n)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}