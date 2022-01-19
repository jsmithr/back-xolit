using System;

namespace XolitTest.Utils
{
    public class Message
    {
        public static object build(object data, String message, string type, Boolean status)
        {
            return new
            {
                data = data,
                status = status,
                type = type,
                message = message
            };
        }
    }
}
