// See https://aka.ms/new-console-template for more information
#region 1
//
// using System.Globalization;
//
// Console.WriteLine("輸入系統時間:");
// // var systemTime = Convert.ToDateTime(Console.ReadLine());
// var systemTime = DateTime.Now;
// Console.WriteLine($"系統時間: {systemTime}");
//
// DateTime itemSerialNoToDateTIme(string timeSerialNO)
// {
//     var timeString = timeSerialNO[5..];
//     if (!DateTime.TryParseExact(timeString, "yyyyMMddHH", null, DateTimeStyles.None, out var ExactTIme))
//     {
//         throw new Exception("timeSerialNo not right");
//     }
//     return ExactTIme;
// }
//
// void IsExpired(string itemSerialNo)
// {
//     var exactTime = itemSerialNoToDateTIme(itemSerialNo);
//     var result = "";
//     var timeSpan = exactTime - systemTime;
//     if (timeSpan > TimeSpan.FromMinutes(5) &&
//         timeSpan < TimeSpan.FromMinutes(60))
//     {
//         result = "商品即將過期";
//         
//     } 
//     else if (timeSpan < TimeSpan.FromMinutes(5))
//     {
//         result = "商品已過期";
//     }
//     Console.WriteLine($"{itemSerialNo} {result}");
// }
//
// for (int i = 0; i < 2; i++)
// {
//     Console.WriteLine("輸入商品條碼");
//     var itemSerialNo = Console.ReadLine();
//     IsExpired(itemSerialNo);
// }

#endregion

#region 2

using System.Globalization;

Console.WriteLine("輸入系統日期:"); 
DateTime.TryParseExact(Console.ReadLine(), "yyyyMMdd", null, DateTimeStyles.None, out var systemTime);

var path = "./test_data";
if (Directory.Exists(path))
{
    var fileNames = Directory.GetFiles(path);
    foreach (var fileName in fileNames)
    {
        var fileSplit = fileName.Split('\\');
        var fileTimeStr = fileSplit[^1][8..16];
        DateTime.TryParseExact(fileTimeStr, "yyyyMMdd", null, DateTimeStyles.None, out var fileDate);
        if (systemTime - fileDate > TimeSpan.FromDays(5))
        {
            File.Delete(fileName);
        }
    }
}

#endregion