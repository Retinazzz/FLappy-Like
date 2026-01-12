using UnityEngine;

public class EnemyAdder : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnInterval;

    private Vector2 _posToSpawn = new Vector2(5.3f,0f);
    private float _timer = 0f;


    void Update ()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnInterval)
        {
            float _randompose = Random.Range(-2f, 3f);
            Creator(new Vector2(_posToSpawn.x, (_posToSpawn.y + _randompose)));
            _timer = 0f;
        }
    }
    void Creator (Vector2 SpawnPoint)
    {
        Instantiate(_enemy, SpawnPoint, Quaternion.identity);
    }
}
    
