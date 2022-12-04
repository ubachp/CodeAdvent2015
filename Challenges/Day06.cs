using CodeAdvent2015.Shared;

namespace CodeAdvent2015.Challenges
{
    public enum Action
    {
        TurnOn,
        TurnOff,
        Toggle,
    }
    public class Day06 : AdventDayBase, IAdventDay
    {
        private readonly bool[,] _grid = new bool[1000, 1000];
        private readonly uint[,] _brightness = new uint[1000, 1000];

        public Day06(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/6/input", Cookie);
            var inputArray = input.Split("\n");

            foreach (var command in inputArray)
            {
                if (string.IsNullOrWhiteSpace(command)) continue;

                var commandArray = command.Split(" ");

                var action = ExtractAction(commandArray);
                var from = ExtractFrom(commandArray);
                var to = ExtractTo(commandArray);

                ApplyCommandToGrid(action, from, to);
            }

            var (openedLights, totalBrightness) = GetOpenLightsAndBrightness();

            Helper.PrintResults("open lights", openedLights, "brightness", totalBrightness);
        }

        private (int, uint) GetOpenLightsAndBrightness()
        {
            var totalLights =0;
            uint totalBrightness = 0;
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i,j]) totalLights++;
                    totalBrightness += _brightness[i,j];

                }

            }
            return (totalLights, totalBrightness);
        }

        private void ApplyCommandToGrid(Action action, int[] from, int[] to)
        {
            for (int i = from[0]; i <= to[0]; i++)
            {
                for (int j = from[1]; j <= to[1]; j++)
                {
                    switch (action)
                    {
                        case Action.TurnOn:
                            _grid[i,j] = true;
                            _brightness[i,j] += 1;
                            break;
                        case Action.TurnOff:
                            _grid[i,j] = false;
                            _brightness[i,j] -= _brightness[i,j] == 0 ? (uint)0 : (uint)1;
                            break;
                        case Action.Toggle:
                            _grid[i,j] = !_grid[i,j];
                            _brightness[i,j] += 2;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private int[] ExtractTo(string[] commandArray)
        {
            var fromIndex = 3;
            if (commandArray[0] == "turn")
            {
                fromIndex++;
            }
            return commandArray[fromIndex].Split(",").Select(x=> int.Parse(x)).ToArray();
        }

        private int[] ExtractFrom(string[] commandArray)
        {
            var fromIndex = 1;
            if (commandArray[0] == "turn")
            {
                fromIndex++;
            }
            return commandArray[fromIndex].Split(",").Select(x=> int.Parse(x)).ToArray();
        }

        private Action ExtractAction(string[] commandArray)
        {
            if (commandArray[0] == "turn")
            {
                if (commandArray[1] == "on") return Action.TurnOn;
                if (commandArray[1] == "off") return Action.TurnOff;
            }
            return Action.Toggle;
        }
    }
}
