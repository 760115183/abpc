using System;

namespace Lis.PiYanSuoReport.Common.Extension
{
    public static class TimeExtension
    {
        public const long NsPerSeconds = 10000000; // 1秒钟的百纳秒数
        public const long NsPerMs = 10000; // 1ms的百纳秒数

        public static long ToTimeStamp(this DateTime time)
        {
            DateTime t = new DateTime(time.Ticks, DateTimeKind.Utc);
            return t.ToFileTimeUtc();
        }

        public static DateTime ToDateTime(this long timestamp)
        {
            return DateTime.FromFileTimeUtc(timestamp);
        }

        public static long AddSeconds(this long ts, int seconds)
        {
            return ts + (seconds * NsPerSeconds);
        }

        public static long AddMilliSeconds(this long ts, int ms)
        {
            return ts + (ms * NsPerMs);
        }
    }
}
