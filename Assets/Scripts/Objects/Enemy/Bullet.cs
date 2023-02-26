using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private int _damage;
    private Vector2 _moveDirection;
    private Rigidbody2D rb;

    public void SetParametrs(float speed, Vector2 direction, int damage)
    {
        _speed = speed;
        _moveDirection = direction;
        _damage = damage;
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Turret _) == false)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
                player.GetDamge(_damage);

            gameObject.SetActive(false);
        }
    }
}
