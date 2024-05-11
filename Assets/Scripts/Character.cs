using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement Settings"), Space, SerializeField]
    private float moveSpeed;
    private Vector2 moveDirection;

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(x, y);
        moveDirection.Normalize();
    }

    private void Move()
    {
        Vector2 newPosition = rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        rigidbody.MovePosition(newPosition);
    }
}
