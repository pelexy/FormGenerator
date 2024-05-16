using System.Security.Cryptography;
using System.Text;


namespace Function.Modules.Core
{
    public static class Functions
    {


        public static object ToObject<T>(this T? type)
        {
            return new { Label = type?.ToString(), value = type };
        }


    }

}
