using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnRate =1;

    void Start()
    {
        StartCoroutine(InstantiateEnemyCoroutine());
    }

    IEnumerator InstantiateEnemyCoroutine()
    {
        yield return new WaitForSeconds(_spawnRate);
        Instantiate(_enemy, gameObject.transform);
        StartCoroutine(InstantiateEnemyCoroutine());
    }
}
