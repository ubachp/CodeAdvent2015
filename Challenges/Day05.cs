using CodeAdvent2015.Shared;
using System.Drawing;

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
            var totalNice = 0;

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

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
                    totalNice++;
                }

            }

            Helper.PrintResults("nice", totalNice, "", 0);
        }
    }
}
