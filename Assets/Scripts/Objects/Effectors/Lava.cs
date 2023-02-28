using System.Collections;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private LevelManager _levelManager;
    private Player _player;
    private int _damage;
    private float _timeForDealDamage;
    private float _nowTime;

    private void Start()
    {
        _levelManager = LevelManager.levelManager;
        _damage = _levelManager.LavaDamage;
        _timeForDealDamage = _levelManager.TimeForLavaForDealDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _player = player;
            StartCoroutine(DealDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            StopCoroutine(DealDamage());
    }

    private IEnumerator DealDamage()
    {
        _nowTime = 0;

        while (_nowTime < _timeForDealDamage)
        {
            _nowTime += Time.deltaTime;
            yield return null;
        }

        _player.GetDamage(_damage);
        StartCoroutine(DealDamage());
    }
}
