using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private LevelManger levelManager;
    private float _maxSpeed;
    private float _nowSpeed = 3;
    private int _damage;
    private int numberOfPoint;
    private GameObject _player;
    private Vector2 _moveDirection;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = LevelManger.levelManager;
        _maxSpeed = levelManager.MaxSpeed;
        _damage = levelManager.Damage;
    }

    private void Update()
    {
        if (_player == null)
        {
            if (numberOfPoint == _points.Count)
                numberOfPoint = 0;

            transform.position = Vector2.MoveTowards(transform.position, _points[numberOfPoint].position, 0.02f);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, (_points[numberOfPoint].position - transform.position).normalized);

            if (Vector2.Distance(transform.position, _points[numberOfPoint].position) < 0.5)
                numberOfPoint++;
        }
        else
        {
            if (_nowSpeed <= _maxSpeed)
                _nowSpeed += Time.deltaTime; 
        }
    }

    private void FixedUpdate()
    {
        if (_player != null)
            rb.MovePosition(rb.position + _moveDirection * _nowSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _player = collision.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _moveDirection = (_player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _nowSpeed = 3;
            _player = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.GetDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
