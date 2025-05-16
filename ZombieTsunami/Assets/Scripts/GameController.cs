using System.Collections;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    [SerializeField] Vector2 _gameSpeedRange = new Vector2(1f, 10f);
    [SerializeField] float _timeToMaxSpeed = 0.1f;
    float _gameSpeedMultipler = 1f;
    float _timeFromStart = 0f;

    public float GameSpeedMultipler
    {
        get { return _gameSpeedMultipler; }
        private set { _gameSpeedMultipler = value; }
    }

    void Start()
    {
        // Start the coroutine to increase the game timer
        StartCoroutine(IncreaseGameTimer());
    }
    
    // Update is called once per frame
    void Update()
    {
        GameSpeedMultipler = Mathf.Lerp(_gameSpeedRange.x, _gameSpeedRange.y, _timeFromStart / _timeToMaxSpeed);
    }

    IEnumerator IncreaseGameTimer()
    {
        while (true)
        {
            _timeFromStart += Time.deltaTime;
            yield return null;
        }
    }
}
