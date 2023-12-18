using UnityEngine;

public class Spear : Trap
{
    [SerializeField] private Animator _animator;
    private bool _isTrapActive = false;

    protected override void KillPlayer(IPlayer player) {
        if (_isTrapActive) {
            base.KillPlayer(player);
             Debug.Log("Stab!");
        }
    }

    public void PlayAnimation(string name) {
        if (!_isTrapActive) {
            _animator.Play(name, 0, 0);
            _isTrapActive = true;
            Destroy(gameObject.GetComponent<BoxCollider2D>(), 0.44f);
        }
    }
}
