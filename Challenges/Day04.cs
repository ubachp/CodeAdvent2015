using CodeAdvent2015.Shared;
using Microsoft.VisualBasic;
using System.Drawing;

namespace CodeAdvent2015.Challenges
{
    public class Day04 : AdventDayBase, IAdventDay
    {
        public Day04(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = "iwrupvqb";


            var task1 = FindIteration(input, "00000");
            var task2 = FindIteration(input, "000000");

            var results = await Task.WhenAll(task1, task2);


            Helper.PrintResults("", results[0], "", results[1]);
        }

        private static Task<int> FindIteration(string input, string startWith = "")
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var result = "";
                var iteration = 0;
                while (!result.StartsWith(startWith))
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes($"{input}{++iteration}");
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    result = Convert.ToHexString(hashBytes);
                }
                return Task.FromResult(iteration);
            }
        }
    }
}
