namespace A_Level.Asynchronous.TaskExample.ThreadExample;

internal static class ConsoleSwitch
{
    public static void SwitchTo(ConsoleColor consoleColor, Action action)
    {
        var current = Console.ForegroundColor;
        Console.ForegroundColor = consoleColor;
        action();
        Console.ForegroundColor = current;
    }
}
