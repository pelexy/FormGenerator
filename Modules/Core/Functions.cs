using System.Security.Cryptography;
using System.Text;
using NetTopologySuite.Geometries;

namespace Ripple.API.Modules.Core
{
    public static class Functions
    {
        public static string SignatureBuilder(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(data))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string Pad(string id, int length = 10) =>
            string.Concat($"{RandomGenerator.GeneratePhoneCode(length)}".AsSpan(0, Math.Max(0, (length - id.Length))), id);

        public static object ToObject<T>(this T? type)
        {
            return new { Label = type?.ToString(), value = type };
        }

        public static bool ShouldUpdate<T>(T entity)
        {
            if (entity == null) return false;
            return entity!.GetType().GetProperties()
           .Where(p => p.GetValue(entity) != null).Any();
        }

        public static bool CheckPinAndToken(string? pin) => !string.IsNullOrEmpty(pin) ? true : throw new AppException("Authorisation required.");

        public static Point LatLngMaker(double lat, double lng)
        {

            var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return geometryFactory.CreatePoint(new Coordinate(lng, lat));
        }
    }

}
