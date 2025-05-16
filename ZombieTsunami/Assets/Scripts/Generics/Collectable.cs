using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.TryGetComponent<ZombieCollider>(out ZombieCollider zombie))
        {
            Interact();
            Destroy(this.gameObject);
        }
    }

    protected abstract void Interact();
}
