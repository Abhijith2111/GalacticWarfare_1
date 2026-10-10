using System;
using UnityEngine;

public struct Tile : IEquatable<Tile>
{
    public readonly int X;
    public readonly int Y;

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Tile other) => X == other.X && Y == other.Y;
    public override bool Equals(object obj) => obj is Tile other && Equals(other);
    public override int GetHashCode() => (X * 397) ^ Y;
}

public sealed class ShipUnit
{
    public int Id;
    public int OwnerId;
    public string ShipType;
    public int X;
    public int Y;
    public int Hp;
    public int MaxHp;
    public int Damage;
    public int HealCooldownRemaining;

    public string DisplayName
    {
        get
        {
            if (ShipType == GameConfig.Healer) return "Healing";
            if (ShipType == GameConfig.Tank) return "Tank";
            if (ShipType == GameConfig.Normal) return "Normal";
            return ShipType;
        }
    }

    public static ShipUnit Create(int id, int ownerId, string shipType, int x, int y)
    {
        int hp;
        int damage;
        if (shipType == GameConfig.Healer) { hp = 60; damage = 11; }
        else if (shipType == GameConfig.Tank) { hp = 120; damage = 15; }
        else { hp = 70; damage = 13; }

        return new ShipUnit
        {
            Id = id,
            OwnerId = ownerId,
            ShipType = shipType,
            X = x,
            Y = y,
            Hp = hp,
            MaxHp = hp,
            Damage = damage,
            HealCooldownRemaining = 0
        };
    }
}

public sealed class HealthPickup
{
    public int Id;
    public int X;
    public int Y;
    public bool Active = true;
    public int RespawnTimer;
}

public sealed class AiChoice
{
    public int ShipId;
    public int DirX;
    public int DirY;
    public int ToX;
    public int ToY;
    public string ActionType; // <-attack, heal or do nothing
    public int TargetId = -1;
    public int HealTargetId = -1;
}
public class MatchModels : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
