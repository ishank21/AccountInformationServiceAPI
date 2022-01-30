namespace AccountInformationService.Infrastructure.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsBase64String(this string base64)
        {
            var bytes = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, bytes, out int bytesParsed);
        }
    }
}
