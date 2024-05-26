using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(CooldownSpawn());
    }

    private IEnumerator CooldownSpawn()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator MovementEnemy(GameObject enemy)
    {
        while (true)
        {
            enemy.transform.Translate(Vector3.left * _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void Spawn()
    {
        Transform pointSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        GameObject enemy = Instantiate(_prefabEnemy, pointSpawn.position, Quaternion.Euler(0, 0, Random.Range(1,4) * 90), pointSpawn);

        StartCoroutine(MovementEnemy(enemy));
    }
}
