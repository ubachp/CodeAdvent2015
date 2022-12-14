using CodeAdvent2015.Challenges;

namespace CodeAdvent2015
{
    public class CodeAdvent
    {
        public static string Cookie { get; set; }
        public static async Task Run()
        {
            await new Day01(Cookie).Solve();
            await new Day02(Cookie).Solve();
            await new Day03(Cookie).Solve();
            //await new Day04(Cookie).Solve();
            await new Day05(Cookie).Solve();
            await new Day06(Cookie).Solve();
            await new Day07(Cookie).Solve();
        }
    }
}
