using System;

public static class Events
{
    public static class Player
    {
        public static Action<bool> TogglePlayerMovement;
    }

    public static class Conversation
    {
        public static Action<bool> ConversationStateChange;
    }

    public static class ObstacleDetected
    {
        public static Action<bool> OnObstacleDetect;
    }
    public static class Keypad
    {
        public static Action<int> KeyPressed;
        public static Action CorrectKeyPressed;
    }
}