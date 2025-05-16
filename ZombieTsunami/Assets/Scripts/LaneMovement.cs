using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
