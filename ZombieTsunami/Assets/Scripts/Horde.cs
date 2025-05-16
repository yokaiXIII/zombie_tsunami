using UnityEngine;

public class Horde : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _jumpPrefab;
    [SerializeField] private int _hordeInitSize = 2;
    [SerializeField] private Collider _hordeSpawnArea;

    private Vector3 _hordeSpawnAreaMin;
    private Vector3 _hordeSpawnAreaMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hordeSpawnAreaMin = new Vector3(_hordeSpawnArea.bounds.min.x, _hordeSpawnArea.bounds.max.y, _hordeSpawnArea.bounds.min.z);
        _hordeSpawnAreaMax = new Vector3(_hordeSpawnArea.bounds.max.x, _hordeSpawnArea.bounds.max.y, _hordeSpawnArea.bounds.max.z);
        for (int i = 0; i < _hordeInitSize; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(_hordeSpawnAreaMin.x, _hordeSpawnAreaMax.x), _hordeSpawnAreaMax.y, Random.Range(_hordeSpawnAreaMin.z, _hordeSpawnAreaMax.z));
            GameObject hordeMember = Instantiate(_prefab, spawnPosition, Quaternion.identity, this.transform);
            hordeMember.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlaceJumpTrigger();
        }
    }

    void PlaceJumpTrigger()
    {
        if (Physics.Raycast(_hordeSpawnAreaMax, Vector3.down, out RaycastHit hit))
        {
            Debug.Log("PointHit: " + hit.point);
            GameObject jumpTrigger = Instantiate(_jumpPrefab, hit.point, Quaternion.identity);
            jumpTrigger.transform.localScale = new Vector3(1, 1, 1);
            jumpTrigger.transform.parent = hit.collider.transform.root;
        }
    }
}
