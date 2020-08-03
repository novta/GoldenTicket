// (c) 2017 Optical Tone Ltd. All Rights Reserved.
// Licensed under the MIT License.
//
// MIT License
//
// Copyright(c) 2017 Optical Tone Ltd.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace GoldenTicket.Extensions
{
    using System;
    /// <summary>
    /// DateTimeExtensions extends DateTime to operate UNIX timestamps.
    /// </summary>
    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// Convert from .NET DateTime to UnixTimeStamp.
        /// (FYI in -> https://msdn.microsoft.com/en-us/library/system.datetimeoffset.tounixtimeseconds.aspx)
        /// </summary>
        /// <param name="dateTimeUtc">DateTimeUtc</param>
        /// <returns>Unix TimeStamp</returns>
        public static long ToUnixTimeStamp(this DateTime dateTimeUtc)
        {
            return (long)Math.Round((dateTimeUtc.ToUniversalTime() - UnixEpoch).TotalSeconds);
        }

        /// <summary>
        /// Convert from UnixTimeStamp to .NET DateTime.
        /// (FYI in -> https://msdn.microsoft.com/en-us/library/system.datetimeoffset.tounixtimeseconds.aspx)
        /// </summary>
        /// <param name="unixTimeStamp">UnixTimeStamp</param>
        /// <returns>DateTime by UTC</returns>
        public static DateTime ToDateTimeUtc(this long unixTimeStamp)
        {
            return UnixEpoch.AddSeconds(unixTimeStamp);
        }

        /// <summary>
        /// Compare UnixTimeStamp to .NET DateTime and determines is the UnixTimeStamp expired in order to dateTimeUtc border.
        /// (FYI in -> https://msdn.microsoft.com/en-us/library/system.datetimeoffset.tounixtimeseconds.aspx)
        /// </summary>
        /// <param name="unixTimeStamp">UnixTimeStamp</param>
        /// <param name="dateTimeUtc">DateTimeUtc border to be timestamp compared with.</param>
        /// <returns>True if UnixTimeStamp has expired; False otherwise.</returns>
        public static bool ExpiredUnixTimeStamp(this long unixTimeStamp, DateTime dateTimeUtc)
        {
            return dateTimeUtc.ToUnixTimeStamp() < unixTimeStamp;
        }

        /// <summary>
        /// Compare UnixTimeStamp to now current time and determines is the UnixTimeStamp expired.
        /// (FYI in -> https://msdn.microsoft.com/en-us/library/system.datetimeoffset.tounixtimeseconds.aspx)
        /// </summary>
        /// <param name="unixTimeStamp">UnixTimeStamp</param>
        /// <returns>True if UnixTimeStamp has expired; False otherwise.</returns>
        public static bool ExpiredUnixTimeStamp(this long unixTimeStamp)
        {
            return DateTime.UtcNow.ToUnixTimeStamp() < unixTimeStamp;
        }
    }
}
