using kr.bbon.Core.Helpers;

namespace Example;

public class TimeZoneTest
{
    public void OnWindows()
    {
        var timeZoneId = "Asia/Seoul";
        //timeZoneId = "Korea Standard Time";
        TimeZoneHelper helper = new TimeZoneHelper();
        var timeZoneInfo = helper.FindSystemTimeZoneById(timeZoneId);

        Console.WriteLine("-".PadLeft(80, '-'));
        Console.WriteLine("id:            {0}", timeZoneInfo?.Id);
        Console.WriteLine("Display name:  {0}", timeZoneInfo?.DisplayName);
        Console.WriteLine("Standard name: {0}", timeZoneInfo?.StandardName);
    }
}