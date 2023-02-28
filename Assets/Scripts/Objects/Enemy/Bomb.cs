using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private LevelManager _levelManager;
    private float _timeToBum;
    private int _damage;
    private SpriteRenderer _spriteRenderer;
    private bool _isSeePlayer = false;
    private Player _player;

    private void Start()
    {
        _levelManager = LevelManager.levelManager;
        _timeToBum = _levelManager.TimeForBum;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _player = player;
            _isSeePlayer = true;
            StartCoroutine(Bum());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _isSeePlayer = false;
    }
    private IEnumerator Bum()
    {
        _spriteRenderer.color = Color.red;

        while (_timeToBum > 0)
        {
            _timeToBum -= Time.deltaTime;
            yield return null;
        }

        if (_isSeePlayer)
            _player.GetDamage(_damage);

        gameObject.SetActive(false);
    }
}
