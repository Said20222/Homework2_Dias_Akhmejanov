using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    protected virtual void KillPlayer(IPlayer player) {
        player.MakeDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player) {
            KillPlayer(player);
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<IPlayer>() is IPlayer player) {
            KillPlayer(player);
        }  
    }
}
