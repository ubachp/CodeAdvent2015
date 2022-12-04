using CodeAdvent2015.Shared;
using System.Drawing;

namespace CodeAdvent2015.Challenges
{
    public class Day03 : AdventDayBase, IAdventDay
    {
        private readonly Dictionary<Point, int> _distribution = new Dictionary<Point, int>();
        private readonly Dictionary<Point, int> _santa = new Dictionary<Point, int>();
        private readonly Dictionary<Point, int> _robot = new Dictionary<Point, int>();
        public Day03(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/3/input", Cookie);
           
            var currentPosition = new Point(0,0);
            var currentSanta = new Point(0,0);
            var currentRobot = new Point(0,0);
            
            _distribution.Add(currentPosition, 1);
            _santa.Add(currentSanta, 1);
            _robot.Add(currentRobot, 1);

            var santaRobotToggle = true;

            foreach (var direction in input)
            {
                currentPosition = GetNextPosition(currentPosition, direction);

                UpdateDistribution(_distribution,currentPosition);

                if (santaRobotToggle)
                {
                    currentSanta = GetNextPosition(currentSanta, direction);
                    UpdateDistribution(_santa,currentSanta);
                }
                else
                {
                    currentRobot = GetNextPosition(currentRobot, direction);
                    UpdateDistribution(_robot,currentRobot);
                }
                santaRobotToggle = !santaRobotToggle;

            }
            var both = _santa.Select(x=>x.Key).Union(_robot.Select(x=>x.Key));

            Helper.PrintResults("at least one gift", _distribution.Count, "Santa/Robot at least one gilf", both.Count());
        }

        private void UpdateDistribution(Dictionary<Point, int> distribution, Point currentPosition)
        {
            if (distribution.TryGetValue(currentPosition, out var sum))
            {
                distribution[currentPosition] = ++sum;
            }
            else
            {
                distribution.Add(currentPosition, 1);
            }
        }

        private static Point GetNextPosition(Point currentPosition, char direction)
        {
            currentPosition = direction switch
            {
                '^' => new Point(currentPosition.X, ++currentPosition.Y),
                '>' => new Point(++currentPosition.X, currentPosition.Y),
                '<' => new Point(--currentPosition.X, currentPosition.Y),
                'v' => new Point(currentPosition.X, --currentPosition.Y),
                _ => currentPosition,
            };
            return currentPosition;
        }
    }
}
