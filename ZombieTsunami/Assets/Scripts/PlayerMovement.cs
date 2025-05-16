using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _jumpDirection = new Vector3(0, 1, 0);
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector3 _holdAntiGravity = new Vector3(0, 1, 0);
    [SerializeField] private float _distanceToGround = 0.1f;
    private bool _grounded = false;

    private Rigidbody _rb;

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
        }
    }

    private void Jump()
    {
        Rigidbody _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_jumpDirection * _jumpForce, ForceMode.Impulse);
        _grounded = false;
    }

    void FixedUpdate()
    {

    }
}
