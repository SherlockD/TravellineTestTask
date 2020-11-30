using System.Text.RegularExpressions;
using SecureResultCleanerLibrary.Sources.Extensions;

namespace SecureResultCleanerLibrary.Sources.ResultCleanerSources.ResultCleaningPerformersStorageSources.Performers
{
    public class UrlPerformer : IResultCleaningPerformer
    {
        public string Clear(string inputResult, string[] clearKeys)
        {
            string clearKeysString = BuildRegexClearKeysString(clearKeys);
            string replacePattern = $@"(?<={clearKeysString})(\w+)";

            return Regex.Replace(inputResult, replacePattern, (match) =>
            {
                return match.ToString().GetSecureString('X');
            });
        }

        private string BuildRegexClearKeysString(string[] clearKeys)
        {
            string result = string.Empty;

            for(int i = 0; i < clearKeys.Length; i++)
            {
                result += $@"{clearKeys[i]}[\/,=]";

                if(i < clearKeys.Length - 1)
                {
                    result += '|';
                }
            }

            return result;
        }
    }
}
