using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGun : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionsForShoot;
    [SerializeField] private GameObject _container;
    [SerializeField] private Bullet _bullet;

    private LevelManager _levelManager;
    private List<Bullet> _bullets = new();
    private int _damage;
    private int _speed;
    private float _timeBetweenShoot;
    private int _numberOfShotPosition = 0;
    private Vector2 _moveDirection;
    private bool _isShooting;

    private void Start()
    {
        _levelManager = LevelManager.levelManager;
        _damage = _levelManager.BulletDamage;
        _speed = _levelManager.BulletSpeed;
        _timeBetweenShoot = _levelManager.MashineGuntimeBetweenShoot;

        for (int i = 0; i < _positionsForShoot.Count; i++)
        {
            _bullets.Add(Instantiate(_bullet, _container.transform));
            _bullets[i].gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            if(!_isShooting)
            StartCoroutine(Shoot());
    }
    private IEnumerator Shoot()
    {
        _isShooting = true;
        Bullet bullet = new();
        _numberOfShotPosition = 0;

        while (_numberOfShotPosition < _positionsForShoot.Count)
        {
            _moveDirection = (_positionsForShoot[_numberOfShotPosition].position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);
            bullet = _bullets[_numberOfShotPosition];
            bullet.transform.position = transform.position;
            bullet.SetParametrs(_speed, _moveDirection, _damage);
            bullet.gameObject.SetActive(true);
            _numberOfShotPosition++;
            yield return new WaitForSeconds(_timeBetweenShoot);
        }

        _isShooting = false;
    }
}
