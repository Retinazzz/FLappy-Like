using System.Collections;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minRandomRange = -2f;
    [SerializeField] private float _maxRandomRange = 3f;
    private Vector2 _posToSpawn = new Vector2(5.3f, 0f);
    private float _timer = 0f;

    private void Start()
    {
        while (true)
        {
            float randompos = Random.Range(_minRandomRange, _maxRandomRange);
            StartCoroutine(Create(new Vector2(_posToSpawn.x, (_posToSpawn.y + randompos))));
        }
    }        

    private IEnumerator Create(Vector2 spawnPoint)
    {
        Instantiate(_enemy, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(_spawnInterval);
    }
}
    
