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
}
