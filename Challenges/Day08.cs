using CodeAdvent2015.Shared;

namespace CodeAdvent2015.Challenges
{
    public class Day08 : AdventDayBase, IAdventDay
    {

        public Day08(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/7/input", Cookie);

            var inputArray = input.Split("\n");

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
            }

            Helper.PrintResults("wire a", 0, "wire a", 0);
        }
    }
}
