namespace Chess.Common.Console
{
    using System;
    public static class ConsoleHelpers
    {
        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;
            Console.SetCursorPosition(centerCol, centerRow);
        }
    }
}
