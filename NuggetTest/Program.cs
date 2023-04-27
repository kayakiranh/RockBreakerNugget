using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RockBreakerNugget.IpHelper;

namespace NuggetTest
{
    internal class Program
    {
        private static readonly string url = "https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882";
        private static readonly string title = "Clean Code: A Handbook of Agile Software Craftsmanship";
        private static readonly string article = "<h2>Clean Code: A Handbook of Agile Software Craftsmanship</h2><p>You are reading this book for two reasons.</p> <p style=\"color:red;\"><strong>First</strong>, you are a programmer. Second, you want\r\nto be a better programmer. Good. We need better programmers.  This is a book about good programming. It is filled with code. We are going to look at\r\ncode from every different direction.</p><p> We’ll look down at it from the top, up at it from the\r\nbottom, and through it from the inside out. By the time we are done, we’re going to know a\r\nlot about code. What’s more, we’ll be able to tell the difference between good code and bad\r\ncode. We’ll know how to write good code. And we’ll know how to transform bad code into\r\ngood code.</p>";
        private static readonly string dangerousText = "<h2>Clean Code: A Handbook of Agile Software Craftsmanship</h2><script>alert(“XSS”)</script><p>You are reading this book for two reasons.</p> <p style=\"color:red;\"><strong>First</strong>, you are a programmer. Second, you want\r\nto be a better programmer. Good. We need better programmers. <img src=\"https://dummyimage.com/300.png/09f/fff\" onclick=\"window.open(this.src)\"> This is a book about good programming. It is filled with code. We are going to look at\r\ncode from every different direction.</p><p> We’ll look down at it from the top, up at it from the\r\nbottom, and through it from the inside out. By the time we are done, we’re going to know a\r\nlot about code. What’s more, we’ll be able to tell the difference between good code and bad\r\ncode. We’ll know how to write good code. And we’ll know how to transform bad code into\r\ngood code.</p><p>SELECT * FROM INNER JOIN</p>";
        private static readonly string str1 = "Maintaining Cohesion Results in Many Small Classes";
        private static readonly string str2 = "Classes Should Be Small!";
        private static readonly string unicodeStr = "Clean Code&#58; A Handbook of Agile Software Craftsmanship";
        private static readonly DateTime dateTimeNow = DateTime.UtcNow;
        private static readonly string dateTimeNow2 = "2023-04-27";
        private static readonly int intVal1 = 0;
        private static readonly int intVal2 = 99;
        private static readonly long longVal1 = 0;
        private static readonly long longVal2 = 9999;
        private static readonly decimal decimalVal1 = 0;
        private static readonly decimal decimalVal2 = 1250000.99m;
        private static readonly string phone = "905551112233";
        private static readonly string email = "test@test.com.org";
        private static readonly string url2 = "https://www.abcdefgh.com.org.net";
        private static readonly string tcIdentity = "12345678901";
        private static readonly string password = "123abc!?-";

        private class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
        }

        private static Book book1 = new Book { Id = 1, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Price = 100 };
        private static Book book2 = new Book { Id = 2, Title = "The Pragmatic Programmer: From Journeyman to Master", Price = 200 };
        private static List<Book> books = new List<Book>{
            new Book { Id = 1, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Price = 100 },
            new Book { Id = 2, Title = "The Pragmatic Programmer: From Journeyman to Master", Price = 200 }
        };

        private static readonly int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static readonly int[] arr2 = new int[] { 10, 1, 9, 2, 8, 3, 7, 4, 6, 5 };
        private static readonly int[] arr3 = new int[] { 1, 2, 3 };

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Article Helper
            string friendlyUrl = RockBreakerNugget.ArticleHelper.ConvertToSeoFriendlyUrl(title);
            Console.WriteLine(friendlyUrl); //clean-code-a-handbook-of-agile-software-craftsmanship
            string summarizedText = RockBreakerNugget.ArticleHelper.Summarize(article, 50);
            Console.WriteLine(summarizedText); //Clean Code: A Handbook of Agile Software CraftsmanshipYou are reading this book for two reasons. Fir...
            bool pingResult = RockBreakerNugget.ArticleHelper.SendPing(url);
            Console.WriteLine(pingResult); //True
            List<string> tags = RockBreakerNugget.ArticleHelper.GenerateTags(article, 3);
            Console.WriteLine(string.Join(",", tags)); //to,the,are,a,good

            //Clean Helper
            string unicodeRemovedText = RockBreakerNugget.CleanHelper.ChangeUnicodes(unicodeStr);
            Console.WriteLine(unicodeRemovedText); //Clean Code: A Handbook of Agile Software Craftsmanship
            string htmlRemovedText = RockBreakerNugget.CleanHelper.RemoveHtmlTags(article);
            Console.WriteLine(htmlRemovedText); //Clean Code: A Handbook of Agile Software CraftsmanshipYou are reading this book for two reasons. First, you are a programmer. Second, you wantto be a better programmer. Good. We need better programmers. This is a book about good programming. It is filled with code. We are going to look atcode from every different direction. We'll look down at it from the top, up at it from thebottom, and through it from the inside out. By the time we are done, we're going to know alot about code. What's more, we'll be able to tell the difference between good code and badcode. We'll know how to write good code. And we'll know how to transform bad code intogood code.

            //Compare Helper
            bool isStringSame = RockBreakerNugget.CompareHelper.StringCompare(str1, str2);
            Console.WriteLine(isStringSame); //False
            bool isObjectSame = RockBreakerNugget.CompareHelper.ObjectCompare(book1, book2);
            Console.WriteLine(isObjectSame); //False
            bool isArraySame = RockBreakerNugget.CompareHelper.ArrayCompare(arr1, arr2);
            Console.WriteLine(isArraySame); //True
            bool isArraySame2 = RockBreakerNugget.CompareHelper.ArrayCompare(arr1, arr3);
            Console.WriteLine(isArraySame2); //False

            //Format Helper
            string formatDateTimeForDatabase = RockBreakerNugget.FormatHelper.FormatDateTimeForDatabase(dateTimeNow);
            Console.WriteLine(formatDateTimeForDatabase); //2023-04-27
            string formatDateTimeForCustomer = RockBreakerNugget.FormatHelper.FormatDateTimeForCustomer(dateTimeNow, "/");
            Console.WriteLine(formatDateTimeForCustomer); //27/04/2023 19:52
            string formatDateTimeForCustomer2 = RockBreakerNugget.FormatHelper.FormatDateTimeForCustomer(dateTimeNow2, "/");
            Console.WriteLine(formatDateTimeForCustomer2); //27/04/2023 00:00
            string formatDateTimeForDatabase2 = RockBreakerNugget.FormatHelper.FormatDateTimeForDatabase(dateTimeNow);
            Console.WriteLine(formatDateTimeForDatabase2); //2023-04-27
            CultureInfo cultureInfo = new CultureInfo("tr-TR");
            string formatDecimalFromLong = RockBreakerNugget.FormatHelper.FormatDecimalFromLong(longVal2, true, cultureInfo);
            Console.WriteLine(formatDecimalFromLong); //1.250.000,99 / 1.250.000,99 TRY
            string formatDecimal = RockBreakerNugget.FormatHelper.FormatDecimal(decimalVal2, true, cultureInfo);
            Console.WriteLine(formatDecimal); //1.250.000,99 / 1.250.000,99 TRY

            //IP Helper
            string ipAddress = RockBreakerNugget.IpHelper.GetIpAddress();
            Console.WriteLine(ipAddress); //00.000.000.00
            RemoteIpDto getFullInfo = RockBreakerNugget.IpHelper.GetFullInfo();
            Console.WriteLine(getFullInfo); //

            //Order Helper
            object orderResult = RockBreakerNugget.OrderHelper.OrderByProperty(books);
            Console.WriteLine(orderResult as IList); //
            object orderResultByTitle = RockBreakerNugget.OrderHelper.OrderByProperty(books, false, "Title");
            Console.WriteLine(orderResultByTitle as IList); //

            //Password Helper
            string encryptedPassword = RockBreakerNugget.PasswordHelper.Encrypt(password, "salt_Value_From_Json_File");
            Console.WriteLine(encryptedPassword); //c506c997df9ebd6fac1f6551c38d33d6e32bdf826deb1b0dc9168b59ca3890ca
            string randomPassword = RockBreakerNugget.PasswordHelper.RandomPassword();
            Console.WriteLine(randomPassword); //IcbImbkPu0
            string randomPassword2 = RockBreakerNugget.PasswordHelper.RandomPassword(15, true);
            Console.WriteLine(randomPassword2); //<Q[b)}5<d5}dUB-

            //Validation Helper
            string stringValidation = RockBreakerNugget.ValidationHelper.StringValidation(str1);
            Console.WriteLine(stringValidation); //Maintaining Cohesion Results in Many Small Classes
            string phoneValidation = RockBreakerNugget.ValidationHelper.PhoneValidation(phone);
            Console.WriteLine(phoneValidation); //+905551112233
            bool urlValidation = RockBreakerNugget.ValidationHelper.UrlValidation(url2);
            Console.WriteLine(urlValidation); //True
            //bool urlValidationWithClient = await RockBreakerNugget.ValidationHelper.UrlValidationWithClient(url2);
            //Console.WriteLine(urlValidationWithClient); //True
            bool listValidation = RockBreakerNugget.ValidationHelper.ListValidation(books);
            Console.WriteLine(listValidation); //True
            long longValidation = RockBreakerNugget.ValidationHelper.LongValidation(longVal1);
            Console.WriteLine(longValidation); //False
            decimal decimalValidation = RockBreakerNugget.ValidationHelper.DecimalValidation(decimalVal1);
            Console.WriteLine(decimalValidation); //False
            int intValidation = RockBreakerNugget.ValidationHelper.IntValidation(intVal1);
            Console.WriteLine(intValidation); //False
            bool mailAddressValidation = RockBreakerNugget.ValidationHelper.MailAddressValidation(email);
            Console.WriteLine(mailAddressValidation); //True
            string securityValidation = RockBreakerNugget.ValidationHelper.SecurityValidation(dangerousText);
            Console.WriteLine(securityValidation); //clean-code-a-handbook-of-agile-software-craftsmanship
            bool tcKimlikNoValidation = RockBreakerNugget.ValidationHelper.TcKimlikNoValidation(tcIdentity);
            Console.WriteLine(tcKimlikNoValidation); //False

        }
    }
}
