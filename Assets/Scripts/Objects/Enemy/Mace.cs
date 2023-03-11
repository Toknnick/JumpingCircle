using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(DistanceJoint2D))]
public class Mace : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _swingForce = 1f;
    [SerializeField] private float _maxRotationSpeed = 180f;

    private Rigidbody2D _rigidbody;
    private DistanceJoint2D _distanceJoint;
    private int _damage;
    private LevelManager levelManger;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _distanceJoint.autoConfigureDistance = false;
        _distanceJoint.distance = Vector2.Distance(_startPoint.position, _endPoint.position);
        _distanceJoint.connectedAnchor = _endPoint.position;
    }

    private void Start()
    {
        levelManger = LevelManager.levelManager;
        _damage = levelManger.MaceDamage;
    }

    private void FixedUpdate()
    {
        Vector2 dir = (_endPoint.position - transform.position).normalized;
        float dot = Vector2.Dot(dir, _rigidbody.velocity.normalized);

        _rigidbody.AddForce(dir * _swingForce * (1f - Mathf.Abs(dot)));

        // Плавный поворот объекта в направлении цели
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _maxRotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.GetDamage(_damage);
    }
}
