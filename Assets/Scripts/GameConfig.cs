using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public const int GridSize = 25;
    public const float TileSize = 0.32f;

    public const int DiceMin = 1;
    public const int DiceMax = 6;

    public const string Healer = "Healer";
    public const string Tank = "Tank";
    public const string Normal = "Normal";

    public const int HealRange = 3;
    public const int HealAmount = 10;
    public const int HealCooldownTurns = 2;
    public const int CombatRange = 3;

    public const int PickupHeal = 20;
    public const int PickupRespawnTurns = 5;
    public const int PickupSpawnCount = 2;

    public const int StormStartTurns = 8;
    public const float StormFirstShrinkSeconds = 60f;
    public const float StormNextShrinkSeconds = 60f;
    public const int SafeZoneShrinkAmount = 2;
    public const int SafeZoneMinRadius = 0;
    public const int HazardDamage = 10;

    public const float AiRetreatHpThreshold = 0.25f;
    public const float AiRetreatDistanceWeight = 70f;

    public static readonly Color Bg = new Color(7f / 255f, 10f / 255f, 20f / 255f);
    public static readonly Color Grid = new Color(24f / 255f, 30f / 255f, 55f / 255f);
    public static readonly Color Text = new Color(230f / 255f, 235f / 255f, 1f);
    public static readonly Color SafeZone = new Color(55f / 255f, 1650f / 255f, 1f);
    public static readonly Color Storm = new Color(1f, 120f / 255f, 40f / 255f);
    public static readonly Color Pickup = new Color(1f, 240f / 255f, 110f / 255f);

    public static Color OwnerColor(int ownerId)
    {
        switch (ownerId)
        {
            case 0: return new Color(60f / 255f, 230f / 255f, 120f / 255f);
            case 1: return new Color(1f, 90f / 255f, 90f / 255f);
            case 2: return new Color(120f / 255f, 150f / 255f, 1f);
            default: return new Color(205f / 255f, 120f / 255f, 1f);
        }
    }

    public static int Chebyshev(int x1, int y1, int x2, int y2)
    {
        return Mathf.Max(Mathf.Abs(x1 - x2), Mathf.Abs(y1 - y2));
    }

    public static int Clamp(int n, int lo, int hi)
    {
        return Mathf.Max(lo, Mathf.Min(hi, n));
    }
    
}
