using System;

public static class GameEvent
{
    public static Action<HealthController> onHpPlayerChange;
    public static Action onCoinChange;
}