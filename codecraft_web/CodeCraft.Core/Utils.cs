namespace CodeCraft.Core;

public class Utils
{
    public static string TimeAgo(DateTime dateTime)
    {
        TimeSpan timeSpan = DateTime.Now - dateTime;

        if (timeSpan.TotalSeconds < 60)
            return $"{timeSpan.Seconds} Seconds Ago";
        else if (timeSpan.TotalMinutes < 60)
            return $"{timeSpan.Minutes} Minutes Ago";
        else if (timeSpan.TotalHours < 24)
            return $"{timeSpan.Hours} Hours Ago";
        else return $"{timeSpan.Days} Days Ago";
    }

    public static DateTime GetFutureDateTime(DateTime dateTime, string duration)
    {
        int value = int.Parse(duration[..^1]);
        char unit = duration[^1];

        return unit switch
        {
            'h' => dateTime.AddHours(value),
            'd' => dateTime.AddDays(value),
            'm' => dateTime.AddMonths(value),
            'y' => dateTime.AddYears(value),
            _ => dateTime,
        };
    }
}
