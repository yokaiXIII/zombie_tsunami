using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Zombie : MonoBehaviour
{
    static public int ZombieCount = 0;
    [SerializeField] private Vector3 _jumpDirection = new Vector3(0, 1, 0);
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _distanceToGround = 0.1f;
    [SerializeField] private LayerMask _rayCastLayerMask;
    private bool _grounded = false;

    private Rigidbody _rb;

    static public Action<Zombie> OnZombieDeath;
    void Awake()
    {
        ZombieCount++;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 10, _rayCastLayerMask, QueryTriggerInteraction.Ignore))
        {
            if (Mathf.Abs(hit.point.y - this.transform.position.y) <= _distanceToGround)
            {
                _grounded = true;
            }
            else
            {
                _grounded = false;
            }
        }
        else
        {
            _grounded = false;
        }

        if (this.transform.position.y < -10 || this.transform.position.x < -10)
        {
            Death();
        }
    }

    public void Jump()
    {
        if (!_grounded)
            return;
        _rb.AddForce(_jumpDirection * _jumpForce, ForceMode.Impulse);
        _grounded = false;
    }

    void OnDrawGizmos()
    {
        var ray = Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 10, _rayCastLayerMask, QueryTriggerInteraction.Ignore);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, hit.point);
    }
    public void Death()
    {
        OnZombieDeath?.Invoke(this);
        Destroy(this.gameObject);
        ZombieCount--;
    }
}
