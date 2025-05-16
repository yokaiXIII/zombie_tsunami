using System.Collections;
using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Start()
    {
        // Start the movement coroutine
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            // Set the speed of the object
            float gameSpeed = GameController.Instance.GameSpeedMultipler;
            // Move the object to the left
            transform.Translate(Vector3.left * _speed * gameSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
