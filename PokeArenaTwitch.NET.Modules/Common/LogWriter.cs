namespace PokeArenaTwitch.NET.Modules.Common
{
    public static class LogWriter
    {
        private static void WriteLog(string preamble, ConsoleColor color, string logText)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(preamble + ":" + logText);
            Console.ResetColor();
        }

        public static void Log(string Text)
        {
            WriteLog("[INFO]", ConsoleColor.White, Text);
        }

        public static void LogWarning(string Text)
        {
            WriteLog("[WARNING]", ConsoleColor.Yellow, Text);
        }

        public static void LogError(string Text)
        {
            WriteLog("[ERROR]", ConsoleColor.Red, Text);
        }
    }
}