# RockBreaker.Infrastructure.Helper.Tool
Helpers for developers. Compare Helper, IP Helper, Password Helper, Validation Helper, Article Helper and Clean Helper. \
RockBreaker.Infrastructure.Helper.Tool nugget will save your time and effort of writing code for basic tasks. \
Please open issue or feature, if you need anything or catch a bug

## Article Helpers
 ```csharp
// Convert string to seo url
string friendlyUrl = RockBreakerNugget.ArticleHelper.ConvertToSeoFriendlyUrl(title);
Console.WriteLine(friendlyUrl); //clean-code-a-handbook-of-agile-software-craftsmanship
// Generate summary from content
string summarizedText = RockBreakerNugget.ArticleHelper.Summarize(article, 50);
Console.WriteLine(summarizedText); //Clean Code: A Handbook of Agile Software CraftsmanshipYou are reading this book for two reasons. Fir...
// Send ping to url. Method sends ping 3 times.
bool pingResult = RockBreakerNugget.ArticleHelper.SendPing(url);
Console.WriteLine(pingResult); //True
/// Generate tags from string value. Remove Turkish stopwords from string and get most used words
List<string> tags = RockBreakerNugget.ArticleHelper.GenerateTags(article, 3);
Console.WriteLine(string.Join(",", tags)); //to,the,are,a,good
 ```
 
## Clean Helpers
 ```csharp
// Convert unicode to utf.
string unicodeRemovedText = RockBreakerNugget.CleanHelper.ChangeUnicodes(unicodeStr);
Console.WriteLine(unicodeRemovedText); //Clean Code: A Handbook of Agile Software Craftsmanship
// Remove html tags from string value.
string htmlRemovedText = RockBreakerNugget.CleanHelper.RemoveHtmlTags(article);
Console.WriteLine(htmlRemovedText); //Clean Code: A Handbook of Agile Software CraftsmanshipYou are reading this book for two reasons. First, you are a programmer. Second, you wantto be a better programmer. Good. We need better programmers. This is a book about good programming. It is filled with code. We are going to look atcode from every different direction. We'll look down at it from the top, up at it from thebottom, and through it from the inside out. By the time we are done, we're going to know alot about code. What's more, we'll be able to tell the difference between good code and badcode. We'll know how to write good code. And we'll know how to transform bad code intogood code.
 ```
 
## Compare Helper
 ```csharp
// Compare 2 string
bool isStringSame = RockBreakerNugget.CompareHelper.StringCompare(str1, str2);
Console.WriteLine(isStringSame); //False
// Compare 2 object
bool isObjectSame = RockBreakerNugget.CompareHelper.ObjectCompare(book1, book2);
Console.WriteLine(isObjectSame); //False
// Compare 2 array
bool isArraySame = RockBreakerNugget.CompareHelper.ArrayCompare(arr1, arr2);
Console.WriteLine(isArraySame); //True
// Compare 2 array
bool isArraySame2 = RockBreakerNugget.CompareHelper.ArrayCompare(arr1, arr3);
Console.WriteLine(isArraySame2); //False
 ```
 
## Format Helpers
 ```csharp
// DateTime format for database. yyyy-MM-dd
string formatDateTimeForDatabase = RockBreakerNugget.FormatHelper.FormatDateTimeForDatabase(dateTimeNow);
Console.WriteLine(formatDateTimeForDatabase); //2023-04-27
// DateTime format for customer. dd/MM/yyyy HH:mm
string formatDateTimeForCustomer = RockBreakerNugget.FormatHelper.FormatDateTimeForCustomer(dateTimeNow, "/");
Console.WriteLine(formatDateTimeForCustomer); //27/04/2023 19:52
// DateTime format for customer. dd/MM/yyyy HH:mm
string formatDateTimeForCustomer2 = RockBreakerNugget.FormatHelper.FormatDateTimeForCustomer(dateTimeNow2, "/");
Console.WriteLine(formatDateTimeForCustomer2); //27/04/2023 00:00
// DateTime format for database. yyyy-MM-dd
string formatDateTimeForDatabase2 = RockBreakerNugget.FormatHelper.FormatDateTimeForDatabase(dateTimeNow);
Console.WriteLine(formatDateTimeForDatabase2); //2023-04-27
CultureInfo cultureInfo = new CultureInfo("tr-TR");
// Format decimal for customer. 1,111,111.99 TL
string formatDecimalFromLong = RockBreakerNugget.FormatHelper.FormatDecimalFromLong(longVal2, true, cultureInfo);
Console.WriteLine(formatDecimalFromLong); //1.250.000,99 / 1.250.000,99 TRY
// Format decimal for customer. 1,111,111.99 TL
string formatDecimal = RockBreakerNugget.FormatHelper.FormatDecimal(decimalVal2, true, cultureInfo);
Console.WriteLine(formatDecimal); //1.250.000,99 / 1.250.000,99 TRY
 ```
 
## IP Helpers
 ```csharp
// Get IP address
string ipAddress = RockBreakerNugget.IpHelper.GetIpAddress();
Console.WriteLine(ipAddress); //00.000.000.00
// Get visitor data
RemoteIpDto getFullInfo = RockBreakerNugget.IpHelper.GetFullInfo();
Console.WriteLine(getFullInfo); //
 ```
 
## Order Helpers
 ```csharp
// Sort dynamic list. Method can sort any list.
object orderResult = RockBreakerNugget.OrderHelper.OrderByProperty(books);
Console.WriteLine(orderResult as IList); //
// Sort dynamic list. Method can sort any list.
object orderResultByTitle = RockBreakerNugget.OrderHelper.OrderByProperty(books, false, "Title");
Console.WriteLine(orderResultByTitle as IList); //
 ```
 
## Password Helpers
 ```csharp
// Encrypt string. Method use salt + hash. Salt value must fill.
string encryptedPassword = RockBreakerNugget.PasswordHelper.Encrypt(password, "salt_Value_From_Json_File");
Console.WriteLine(encryptedPassword); //c506c997df9ebd6fac1f6551c38d33d6e32bdf826deb1b0dc9168b59ca3890ca
// Generate random password
string randomPassword = RockBreakerNugget.PasswordHelper.RandomPassword();
Console.WriteLine(randomPassword); //IcbImbkPu0
// Generate random password
string randomPassword2 = RockBreakerNugget.PasswordHelper.RandomPassword(15, true);
Console.WriteLine(randomPassword2); //<Q[b)}5<d5}dUB-
 ```
 
## Validation Helpers
 ```csharp
// String validation. Check null or empty
string stringValidation = RockBreakerNugget.ValidationHelper.StringValidation(str1);
Console.WriteLine(stringValidation); //Maintaining Cohesion Results in Many Small Classes
// Turkish Phone validation
string phoneValidation = RockBreakerNugget.ValidationHelper.PhoneValidation(phone);
Console.WriteLine(phoneValidation); //+905551112233
// Url validation. Basic metod
bool urlValidation = RockBreakerNugget.ValidationHelper.UrlValidation(url2);
Console.WriteLine(urlValidation); //True
// Url validation. Best practice is send request to url.
bool urlValidationWithClient = await RockBreakerNugget.ValidationHelper.UrlValidationWithClient(url2);
Console.WriteLine(urlValidationWithClient); //True
// List validation. Check list count
bool listValidation = RockBreakerNugget.ValidationHelper.ListValidation(books);
Console.WriteLine(listValidation); //True
// Int64 validation. Check zero or minus
long longValidation = RockBreakerNugget.ValidationHelper.LongValidation(longVal1);
Console.WriteLine(longValidation); //False
// Decimal validation. Check zero or minus
decimal decimalValidation = RockBreakerNugget.ValidationHelper.DecimalValidation(decimalVal1);
Console.WriteLine(decimalValidation); //False
// Int32 validation. Check zero or minus
int intValidation = RockBreakerNugget.ValidationHelper.IntValidation(intVal1);
Console.WriteLine(intValidation); //False
// Mail address validation
bool mailAddressValidation = RockBreakerNugget.ValidationHelper.MailAddressValidation(email);
Console.WriteLine(mailAddressValidation); //True
// Security validation. Clear dangerous parts from string value. Use Ganss.Xss, HtmlSanitizer
string securityValidation = RockBreakerNugget.ValidationHelper.SecurityValidation(dangerousText);
Console.WriteLine(securityValidation); //clean-code-a-handbook-of-agile-software-craftsmanship
// Turkish Identity validation
bool tcKimlikNoValidation = RockBreakerNugget.ValidationHelper.TcKimlikNoValidation(tcIdentity);
Console.WriteLine(tcKimlikNoValidation); //False
 ```
 
## Test Datas
 ```csharp
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
 ```
