using System.Text;
using System.Text.RegularExpressions;

namespace Application.Utilities
{
    public class ConvertNameToCode
    {
        public static string ConvertToSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            input = input.Replace("đ", "d").Replace("Đ", "D").Replace("á", "a").Replace("à", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a").Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a").Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ẫ", "a").Replace("ậ", "a").Replace("é", "e").Replace("è", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e").Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e").Replace("í", "i").Replace("ì", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i").Replace("ó", "o").Replace("ò", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o").Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o").Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o").Replace("ú", "u").Replace("ù", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u").Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u").Replace("ý", "y").Replace("ỳ", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y");

            // Normalize string to decompose diacritical marks
            input = input.Normalize(NormalizationForm.FormD);

            // Replace diacritical marks with empty string
            input = Regex.Replace(input, @"[\u0300-\u036f]", "");

            // Convert to lowercase
            input = input.ToLowerInvariant().Trim();

            // Replace non-letter or non-digit characters with a hyphen
            input = Regex.Replace(input, @"[^a-z0-9]", "-");

            // Remove any leading or trailing hyphens
            input = input.Trim('-');

            // Replace consecutive hyphens with a single hyphen
            input = Regex.Replace(input, @"-+", "-");

            return input;
        }
    }
}
