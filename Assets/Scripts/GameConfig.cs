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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
