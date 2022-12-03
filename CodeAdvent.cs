﻿using CodeAdvent2015.Challenges;

namespace CodeAdvent2015
{
    public class CodeAdvent
    {
        public static string Cookie { get; set; }
        public static async Task Run()
        {
            await new Day01(Cookie).Solve();
            await new Day02(Cookie).Solve();
        }
    }
}