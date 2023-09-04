namespace DotNet.IoC.Template.Application.Services.Helpers
{
    using System.Globalization;
    using System.Text;

    public static class HelperAlias
    {
        public static string ProcessAlias(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            else
            {
                var result = string.Concat(text.Where(i => !new[] { '.', ' ', '-', '(', ')' }.Contains(i)));
                result = RemoveDiacritics(result);

                return result.ToLower();
            }
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
