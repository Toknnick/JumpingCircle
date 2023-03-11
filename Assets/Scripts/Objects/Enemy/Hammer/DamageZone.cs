using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private Hammer hammer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hammer.IsMovingDown)
            if (collision.gameObject.TryGetComponent(out Player player))
                player.GetDamage(LevelManager.levelManager.PlayerHP);
    }
}
