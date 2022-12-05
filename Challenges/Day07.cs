using CodeAdvent2015.Shared;

namespace CodeAdvent2015.Challenges
{
    public class Day07 : AdventDayBase, IAdventDay
    {
        private readonly Dictionary<string, ushort> _wireSignals = new();
        private readonly Dictionary<string, string> _wireMap = new();

        public Day07(string cookie) : base(cookie)
        {
        }

        public async Task Solve()
        {
            string input = await Helper.GetInput(@"https://adventofcode.com/2015/day/7/input", Cookie);

            var inputArray = input.Split("\n");

            foreach (var line in inputArray)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var lineSplit = line.Split(" -> ");
                var command = lineSplit[0];
                var destinationWire = lineSplit[1].Replace("\r", string.Empty);
                _wireMap.Add(destinationWire, command);
            }

            var wireA1 = GetWireSignal("a");
            _wireSignals.Clear();
            _wireSignals["b"] = wireA1;
            var wireA2 = GetWireSignal("a");
       
            Helper.PrintResults("wire a", wireA1, "wire a", wireA2);
        }

        private ushort GetWireSignal(string input)
        {
            if (ushort.TryParse(input, out var signal))
            {
                return signal;
            }

            if (_wireSignals.TryGetValue(input, out var signal1))
            {
                return signal1;
            }

            var rule = _wireMap[input];

            var commandArray = rule.Split(" ");

            if (commandArray.Length == 1) // assignment
            {
                _wireSignals[input] = GetWireSignal(rule);
            }
            else if (commandArray.Length == 2) // not
            {
                _wireSignals[input] = (ushort)~GetWireSignal(commandArray[1]);
            }
            else if (commandArray.Length == 3)
            {
                ushort value1 = GetWireSignal(commandArray[0]);

                var operat = commandArray[1];

                int val1 = operat switch
                {
                    "AND" => value1 & GetWireSignal(commandArray[2]),
                    "OR" => value1 | GetWireSignal(commandArray[2]),
                    "LSHIFT" => value1 << GetWireSignal(commandArray[2]),
                    "RSHIFT" => value1 >> GetWireSignal(commandArray[2]),
                    _ => throw new NotImplementedException()
                };
                _wireSignals[input] = (ushort)val1;
            }

            return _wireSignals[input];
        }
    }
}
