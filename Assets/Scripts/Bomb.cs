using UnityEngine;

public class Bomb : Trap
{
    protected override void KillPlayer(IPlayer player)
    {
        base.KillPlayer(player);
        Debug.Log("Boom!");
    }
}
