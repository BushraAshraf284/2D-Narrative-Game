using System;

public static class Events
{
    public static class Player
    {
        public static Action<bool> TogglePlayerMovement;
    }

    public static class Keypad
    {
        public static Action<int> KeyPressed;
        public static Action CorrectKeyPressed;
    }
}