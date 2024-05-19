using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private float _speed;

    public List<GameObject> Enemies { get; private set; }

    private void Start()
    {
        StartCoroutine(CooldownSpawn());

        Enemies = new List<GameObject>();
    }

    private IEnumerator CooldownSpawn()
    {
        Spawn();

        Debug.Log("2 seconds");

        yield return new WaitForSeconds(2);
    }

    private void Spawn()
    {
        Transform pointSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        
        GameObject enemy = Instantiate(_prefabEnemy, Vector3.zero, Random.rotation, pointSpawn);
    }
}
