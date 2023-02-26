using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private Bullet _bulletScript;
    private int _damage;
    private int _cd;
    private float _speed;
    private LevelManger levelManager;
    private bool _isCanShoot = false;
    private Vector2 _moveDirection;
    private Transform _player;
    private float _nowTime;

    private void Start()
    {
        levelManager = LevelManger.levelManager;
        _bullet = Instantiate(_bullet);
        _bulletScript = _bullet.GetComponent<Bullet>();
        _bullet.gameObject.SetActive(false);
        _damage = levelManager.TurretDamage;
        _speed = levelManager.BulletSpeed;
        _cd = levelManager.CD;
        _bulletScript = _bullet.GetComponent<Bullet>();
    }

    private void Update()
    {
        _nowTime += Time.deltaTime;

        if (_nowTime >= _cd)
            if (_bullet.gameObject.activeSelf == false)
                _isCanShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _player = collision.transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _moveDirection = (_player.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);

            if (_isCanShoot)
                Shoot();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _player = null;
    }

    private void Shoot()
    {
        if (_player != null)
        {
            _isCanShoot = false;
            _bullet.transform.position = transform.position;
            _bulletScript.SetParametrs(_speed, _moveDirection, _damage);
            _bullet.gameObject.SetActive(true);
            _nowTime = 0;
        }
    }
}
