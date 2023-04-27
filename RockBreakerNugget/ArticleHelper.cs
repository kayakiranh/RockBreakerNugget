using Ganss.Xss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace RockBreakerNugget
{
    [Serializable]
    public static class ArticleHelper
    {
        /// <summary>
        /// Convert string to seo url
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>Seo Url</returns>
        public static string ConvertToSeoFriendlyUrl(this string val)
        {
            val = ValidationHelper.SecurityValidation(val);

            string str = val.RemoveAccent().ToLower();
            str = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(str));
            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }

        private static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Generate summary from content.
        /// </summary>
        /// <param name="val">String value</param>
        /// <param name="summarizeLenght">Int32 value</param>
        /// <returns>Summarized string</returns>
        public static string Summarize(this string val, int summarizeLenght = 100)
        {
            val = ValidationHelper.SecurityValidation(val);

            val = val.Replace("\r", string.Empty);
            val = val.Replace("\n", string.Empty);
            val = Regex.Replace(val, @"\s+", " ");
            val = val.Trim();

            return val.Length > summarizeLenght ? $"{val.Substring(0, summarizeLenght)}..." : $"{val}...";
        }

        /// <summary>
        /// Generate tags from string value. Remove Turkish stopwords from string and get most used words.
        /// </summary>
        /// <param name="val">String value</param>
        /// <param name="tagCount">Int32 value</param>
        /// <returns>List<string></returns>
        public static List<string> GenerateTags(this string val, int tagCount = 5)
        {
            val = ValidationHelper.SecurityValidation(val);

            string[] stopWords = new string[] { "acaba", "altı", "ama", "ancak", "artık", "asla", "aslında", "az", "bana", "bazen", "bazı", "bazıları", "bazısı", "belki", "ben", "beni", "benim", "beş", "bile", "bir", "birçoğu", "birçok", "birçokları", "biri", "birisi", "birkaç", "birkaçı", "birşey", "birşeyi", "biz", "bize", "bizi", "bizim", "böyle", "böylece", "bu", "buna", "bunda", "bundan", "bunu", "bunun", "burada", "bütün", "çoğu", "çoğuna", "çoğunu", "çok", "çünkü", "da", "daha", "de", "değil", "demek", "diğer", "diğeri", "diğerleri", "diye", "dokuz", "dolayı", "dört", "elbette", "en", "fakat", "falan", "felan", "filan", "gene", "gibi", "hâlâ", "hangi", "hangisi", "hani", "hatta", "hem", "henüz", "hep", "hepsi", "hepsine", "hepsini", "her", "her biri", "herkes", "herkese", "herkesi", "hiç", "hiç kimse", "hiçbiri", "hiçbirine", "hiçbirini", "için", "içinde", "iki", "ile", "ise", "işte", "kaç", "kadar", "kendi", "kendine", "kendini", "ki", "kim", "kime", "kimi", "kimin", "kimisi", "madem", "mı", "mı", "mi", "mu", "mu", "mü", "nasıl", "ne", "ne kadar", "ne zaman", "neden", "nedir", "nerde", "nerede", "nereden", "nereye", "nesi", "neyse", "niçin", "niye", "on", "ona", "ondan", "onlar", "onlara", "onlardan", "onların", "onların", "onu", "onun", "orada", "oysa", "oysaki", "öbürü", "ön", "önce", "ötürü", "öyle", "rağmen", "sana", "sekiz", "sen", "senden", "seni", "senin", "siz", "sizden", "size", "sizi", "sizin", "son", "sonra", "şayet", "şey", "şeyden", "şeye", "şeyi", "şeyler", "şimdi", "şöyle", "şu", "şuna", "şunda", "şundan", "şunlar", "şunu", "şunun", "tabi", "tamam", "tüm", "tümü", "üç", "üzere", "var", "ve", "veya", "veyahut", "ya", "ya da", "yani", "yedi", "yerine", "yine", "yoksa", "zaten", "ile", "kişi", "birçok", "ve" };
            string[] words = val.Split(' ');
            for (int w = 0; w < words.Length; w++)
            {
                if (stopWords.Contains(words[w])) val = val.Replace(words[w], string.Empty);
            }
            val = Regex.Replace(val, @"\s+", " ");

            var orderedWords = val
            .Split(' ')
            .GroupBy(x => x)
            .Select(x => new
            {
                KeyField = x.Key,
                Count = x.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(tagCount);

            return orderedWords.Select(x => x.KeyField).ToList();
        }

        /// <summary>
        /// Send ping to url. Method sends ping 3 times.
        /// </summary>
        /// <param name="val">Url</param>
        /// <returns>True/False</returns>
        public static bool SendPing(this string val)
        {
            Ping ping = new Ping();
            try
            {
                Uri uri = new Uri(val);

                short counter = 0;
                for (int i = 0; i < 3; i++)
                {
                    PingReply reply = ping.Send(uri.Host, 1000);
                    if (reply.Status == IPStatus.Success) counter++;
                }
                return counter == 3;
            }
            catch
            {
                return false;
            }
            finally
            {
                ping.Dispose();
            }
        }
    }
}