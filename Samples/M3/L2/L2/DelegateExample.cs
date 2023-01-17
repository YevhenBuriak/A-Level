namespace L2;

internal class DelegateExample
{
    public static void Execute()
    {
        var swimmingPool = new SwimmingPool();

        swimmingPool.AddWater(51);
        swimmingPool.PullWater(100);
    }

    public class WaterLeveler
    {
        public delegate void WaterLevelHandler(int waterLevel);

        public WaterLevelHandler? HighWaterLevelReached;
        public WaterLevelHandler? LowWaterLevelReached;

        private const int _highWaterLevel = 100;
        private const int _lowWaterLevel = 10;
        private int _currentWaterlevel = 50;

        public int WaterLevel
        {
            get { return _currentWaterlevel; }
            set
            {
                _currentWaterlevel = value;
                try
                {
                    if (_currentWaterlevel >= _highWaterLevel) HighWaterLevelReached?.Invoke(_currentWaterlevel);
                    else if (_currentWaterlevel <= _lowWaterLevel) LowWaterLevelReached?.Invoke(_currentWaterlevel);
                }
                catch
                {
                    //... some handler
                }
            }
        }
    }

    public class SwimmingPool
    {
        public WaterLeveler WaterLeveler { get; init; } = new WaterLeveler();

        public SwimmingPool()
        {
            WaterLeveler.LowWaterLevelReached += (int value) => Console.Write("!! VALUE IS TOO LOW !! ");
            WaterLeveler.LowWaterLevelReached += DisplayInconsole;


            WaterLeveler.HighWaterLevelReached += (int value) => Console.Write("!! VALUE IS TOO HIGH !! ");
            WaterLeveler.HighWaterLevelReached += DisplayInconsole;
        }

        public void AddWater(int amount) => WaterLeveler.WaterLevel += amount;

        public void PullWater(int amount) => WaterLeveler.WaterLevel -= amount;

        private void DisplayInconsole(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Current value is: {value}");

            Console.ResetColor();
        }
    }
}
