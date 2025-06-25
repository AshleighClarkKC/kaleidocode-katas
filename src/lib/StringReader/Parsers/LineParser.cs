
using Kaleidocode.Katas.Libraries.Contracts;
using Kaleidocode.Katas.Libraries.StringCalculator.Enumerations;
using System.Text;

namespace Kaleidocode.Katas.Libraries.StringReader.Parsers
{
    public class LineParser(string[] lineCollection) : IStringParser
    {
        private string[] ValueCollection { get; set; } = lineCollection;

        public void SetInputCollection(string[] valueCollection)
            => ValueCollection = valueCollection;

        public IEnumerable<string> CollectValues()
        {
            return CountLetterInstancesPerLine(ValueCollection);
        }

        private IEnumerable<string> CountLetterInstancesPerLine(string[]? lineCollection)
        {
            List<string> result = [];

            if (lineCollection?.Length == 0 || lineCollection == null)
            {
                throw new ArgumentNullException(nameof(lineCollection));
            }

            int lineCounter = 1;

            foreach (var line in lineCollection)
            {
                if (line == "end")
                {
                    break;
                }

                if (line.TrimEnd().Length == 1)
                {
                    result.Add($"Case {lineCounter}: {line.Length}");
                }
                else
                {
                    var distinctCollectionMultipleCharacters = line
                        .GroupBy(gb => gb)
                        .Where(w => w.Count() > 1)
                        .Select(s => s.Key);

                    int uniqueCharacterCount = 0;
                    bool firstRepeatedInstanceFound = false;

                    for (int charIndex = 0; charIndex < line.Length; charIndex++)
                    {

                        if (!firstRepeatedInstanceFound)
                        {
                            if (line[charIndex] == distinctCollectionMultipleCharacters.First())
                            {
                                firstRepeatedInstanceFound = true;
                            }

                            uniqueCharacterCount++;
                        }
                        else
                        {
                            if (line[charIndex] == distinctCollectionMultipleCharacters.First())
                            {
                                break;
                            }
                            else
                            {
                                uniqueCharacterCount++;
                            }
                        }
                    }

                    result.Add($"Case {lineCounter}: {uniqueCharacterCount}");
                }
                lineCounter++;
            }

            return result.AsEnumerable();
        }
    }
}
