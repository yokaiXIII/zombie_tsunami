using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _jumpDirection = new Vector3(0, 1, 0);
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector2 _holdStrenghtRange = new Vector2(.3f, .3f);
    [SerializeField] private float _distanceToGround = 0.1f;
    private bool _grounded = false;

    private Rigidbody _rb;

    private float _holdStrenght = 0.3f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.collider != null && Mathf.Abs(hit.point.y - this.transform.position.y) < _distanceToGround)
            {
                _grounded = true;
            }
        }

        // If the player is grounded, apply the jump force
        if (Input.GetButtonDown("Fire1") && _grounded)
        {
            Jump();
            _holdStrenght = Random.Range(_holdStrenghtRange.x, _holdStrenghtRange.y);
        }
        float input = Input.GetAxis("Fire1");
        if (input > 0)
        {
            // ReduceGravity();
        }
    }

    private void Jump()
    {
        Rigidbody _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_jumpDirection * _jumpForce, ForceMode.Impulse);
        _grounded = false;
    }

    private void ReduceGravity()
    {
        _rb.AddForce(Vector3.up * _holdStrenght, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        
    }
}
