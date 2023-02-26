using UnityEngine;

public class Spike : MonoBehaviour
{
    private int _damage;
    private LevelManger levelManger;

    private void Start()
    {
        levelManger = LevelManger.levelManager;
        _damage = levelManger.SpikeDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.GetDamage(_damage);
    }
}
