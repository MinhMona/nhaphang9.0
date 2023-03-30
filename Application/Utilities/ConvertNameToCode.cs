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
