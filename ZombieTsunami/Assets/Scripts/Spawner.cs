using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] SpawnSequence _spawnSequence = null;
    [SerializeField] float _spawnDelay = 5f;

    void Start()
    {
        StartCoroutine(SpawnBlock());
    }
    
    IEnumerator SpawnBlock()
    {
        while (true)
        {
            Instantiate(_spawnSequence.blockToSpawn, this.transform.position, Quaternion.identity);
            _spawnSequence = _spawnSequence.GetNextBlock();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
