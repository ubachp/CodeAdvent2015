using CodeAdvent2022.Shared;

namespace CodeAdvent2022.Challenges
{
    public class Day01 : AdventDayBase, IAdventDay
    {
        public Day01(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/1/input", Cookie);
            var floor = 0;
            var position = 0;
            var found = false;
            foreach (char key in input)
            {
                if (key == '(')
                {
                    floor++;
                }
                else if (key == ')')
                {
                    floor--;
                }

                if (!found)
                {
                    position++;
                    if (floor == -1)
                    {
                        found = true;
                    }
                }

            }

            Helper.PrintResults("floor", floor, "position", position);
        }
    }
}
