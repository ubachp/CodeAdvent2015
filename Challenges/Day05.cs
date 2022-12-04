using CodeAdvent2015.Shared;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CodeAdvent2015.Challenges
{
    public class Day05 : AdventDayBase, IAdventDay
    {
        private List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        private List<string> forbiddenPatterns = new List<string> { "ab", "cd", "pq", "xy" };
        public Day05(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {

            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/5/input", Cookie);
            var inputArray = input.Split("\n");
            var totalNiceRule1 = 0;
            var totalNiceRule2 = 0;

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                totalNiceRule1 += RespectRule1(line);
                totalNiceRule2 += RespectRule2(line);

            }

            Helper.PrintResults("nice", totalNiceRule1, "nice", totalNiceRule2);
        }

        private int RespectRule1(string line)
        {
            var vowelCount = 0;
            var hasDoubleLetter = false;
            var hasForbiddenPatterns = false;
            char lastChar = ' ';

            foreach (char ch in line)
            {
                vowelCount += vowels.Contains(ch) ? 1 : 0;
                hasDoubleLetter = hasDoubleLetter ? true : ch == lastChar;
                hasForbiddenPatterns = hasForbiddenPatterns ? true : forbiddenPatterns.Contains($"{lastChar}{ch}");

                lastChar = ch;
            }

            if (vowelCount >= 3 && hasDoubleLetter && !hasForbiddenPatterns)
            {
                return 1;
            }

            return 0;
        }

        private int RespectRule2(string line)
        {
            var hasPair = false;
            var hasLetterRepeat = false;
            string lastChars = "";

            foreach (char ch in line)
            {

                if ((!hasPair && lastChars.Length >= 2))
                {
                    var regex = new Regex(Regex.Escape(lastChars));
                    var remaining = regex.Replace(line, string.Empty, 1);
                    var lastTwo = lastChars.Substring(lastChars.Length - 2);

                    hasPair = hasPair ? true : remaining.Contains(lastTwo);
                }
                if (!hasLetterRepeat && lastChars.Length >= 2)
                {
                    var lastTwo = lastChars.Substring(lastChars.Length - 2);
                    hasLetterRepeat = lastTwo[0] == ch && lastTwo[1] != ch;
                }

                lastChars = lastChars + ch;

            }

            if (hasPair && hasLetterRepeat)
            {
                return 1;

            }
            return 0;
        }
    }
}
