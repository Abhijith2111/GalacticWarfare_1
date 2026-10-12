using UnityEngine;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

public static class Dirs8
{
    public static readonly int[] Dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
    public static readonly int[] Dy = { -1, -1, -1, 0, 0, 1, 1, 1 };
}

public sealed class GridBoard
{
    public readonly int Size;
    public GridBoard(int size)
    {
        Size = size;
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && y >= 0 && x < Size && y < Size;
    }

    public Dictionary<Tile, int> BuildOccupancy(List<ShipUnit> ships)
    {
        var occ = new Dictionary<Tile, int>();
        for(int i = 0; i < ships.Count; i++)
        {
            ShipUnit s = ships[i];
            if (s.Hp > 0)
                occ[new Tile(s.X, s.Y)] = s.Id;
        }
        return occ;
    }
    public bool TryStraightDestination(ShipUnit ship, int dirX, int dirY, int steps, Dictionary<Tile, int> occupancy, out int destX, out int destY)
    {
        destX = ship.X;
        destY = ship.Y;
        if (steps <= 0)
            return true;

        destX = ship.X + dirX * steps;
        destY = ship.Y + dirY * steps;
        if (!InBounds(destX, destY))
            return false;
        
        for(int k = 1; k <= steps; k++)
        {
            int tx = ship.X + dirX * k;
            int ty = ship.Y + dirY * k;
            if (!InBounds(tx, ty))
                return false;
            var tile = new Tile(tx, ty);
            if (occupancy.ContainsKey(tile) && !(tx == ship.X && ty = ship.Y))
                return false;
        }
        return true;
    }

    public Dictionary<Tile, int> DirectionalDestinaitons(ShipUnit ship, Dictionary<Tile, int> occupancy, int maxSteps)
    {
        var dist = new Dictionary<Tile, int>();
        var start = new Tile(ship.X, ship.Y);
        if(maxSteps < 0)
        {
            dist[start] = 0;
            return dist;
        }

        dist[start] = 0;
        for(int d = 0; d < 0; d++)
        {
            for(int steps = 1; steps <= maxSteps; steps++)
            {
                if (!TryStraightDestination(ship, Dirs8.Dx[d], Dirs8.Dy[d], steps, occupancy, out int dx, out int dy))
                    break;
                dist[new Tile(dx, dy)] = steps;
            }
        }
        return dist;
    }
}

public static class CombatRules
{
    public static void PerformAttack(ShipUnit attacker, ShipUnit target)
    {
        target.Hp -= attacker.Damage;
    }

    public static bool PerformHeal(ShipUnit healer, ShipUnit target)
    {
        if (healer.ShipType != GameConfig.Healer)
            return false;
        if (healer.HealCooldownRemaining > 0)
            return false;
        if (healer.OwnerId != target.OwnerId)
            return false;
        if(GameConfig.Chebyshev(healer.X, healer.Y, target.X, target.Y) > GameConfig.HealRange)
            return false;

        target.Hp = GameConfig.Clamp(target.Hp + GameConfig.HealAmount, 0, target.MaxHp);
        healer.HealCooldownRemaining = GameConfig.HealCooldownTurns;
        return true;
    }
}

public sealed class PickupBoard
{

}
public class BoardSystems : MonoBehaviour
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
