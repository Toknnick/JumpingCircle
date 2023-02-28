using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private LevelManager levelManager;
    private float minForce;
    private float maxForce;
    private float timeForMaxForce;

    private float currentForce;
    private float elapsedTime;
    private float startTime;
    private Rigidbody2D rigidBody2D;
    private Vector2 direction;
    private bool isSticked = false;
    private bool isLuanched = false;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        levelManager = LevelManager.levelManager;
        minForce = levelManager.MinForce;
        maxForce = levelManager.MaxForce;
        timeForMaxForce = levelManager.TimeForMaxForce;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentForce = minForce;
            startTime = Time.time;
        }

        if (Input.GetMouseButton(0) && !isLuanched)
        {
            elapsedTime = Time.time - startTime;
            currentForce = Mathf.Lerp(minForce, maxForce, elapsedTime / timeForMaxForce);

            if (elapsedTime >= timeForMaxForce)
                currentForce = maxForce;

            direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }

        if (Input.GetMouseButtonUp(0) && !isLuanched && isSticked)
        {
            isSticked = false;
            isLuanched = true;
            elapsedTime = 0;
            rigidBody2D.constraints = RigidbodyConstraints2D.None;
            rigidBody2D.AddForce(direction.normalized * currentForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSticked)
        {
            isLuanched = false;
            isSticked = true;
            rigidBody2D.velocity = Vector3.zero;
            rigidBody2D.angularVelocity =0;
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
