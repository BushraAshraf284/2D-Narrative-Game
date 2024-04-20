using System;

public static class Events
{
    public static class Player
    {
        public static Action<bool> TogglePlayerMovement;
    }
}