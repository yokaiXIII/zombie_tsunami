using System.Collections;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(OnWillRenderObject());
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jump Trigger Entered: " + other.name);
        if (other.gameObject.TryGetComponent<ZombieCollider>(out ZombieCollider zombie))
        {
            Debug.Log("Jump Trigger Activated");
            zombie.Jump();
        }
    }

    IEnumerator OnWillRenderObject()
    {
        float timer = 0f;
        while (timer < 10f)
        {
            timer += Time.deltaTime;

            yield return null;
        }
        Destroy(this.gameObject);
        yield return null;
    }
}
