using CodeAdvent2015.Shared;

namespace CodeAdvent2015.Challenges
{
    public class Day02 : AdventDayBase, IAdventDay
    {
        public Day02(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/2/input", Cookie);
            var inputArray = input.Split("\n");
            var totalWrapping = 0;
            var totalRibbon = 0;

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var dimension = line.Split("x");

                var length = int.Parse(dimension[0]);
                var width = int.Parse(dimension[1]);
                var height = int.Parse(dimension[2]);

                var lengthWidth = length * width;
                var widthHeight = width * height;
                var heightLength = height * length;

                var wrappingSize = 2 * (lengthWidth + widthHeight + heightLength);

                var slack = new List<int>() { lengthWidth, widthHeight, heightLength }.Min();

                totalWrapping += wrappingSize + slack;
                
                var sides = new List<int>() { length, width, height }.OrderBy(x=>x).ToArray();
                var ribbon = (2 * sides[0]) + (2 * sides[1]);
                var bow = length * width * height;

                totalRibbon += ribbon + bow;
            }

            Helper.PrintResults("total wrapping paper", totalWrapping, "total ribbon", totalRibbon);
        }
    }
}
