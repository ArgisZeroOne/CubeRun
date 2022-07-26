using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    private int _frames = 0;
    [SerializeField] private int _framesToSpawn = 90;
    [SerializeField] private GameObject[] _enemyObjects = new GameObject[0];
    [SerializeField] private GameObject[] _helperObject = new GameObject[0];
    [SerializeField] private GameObject[] _spawnPositions = new GameObject[0];
    [SerializeField] private int _helperPercent = 20;
    private void Spawn()
    {
        var SpawnPoints = _spawnPositions.Length;
        var SpawnIndexes = new List<int>();
        for (int i = 0; i < SpawnPoints; i++)
        {
            var RandomIndex = Random.Range(0, 6);
            bool Contain = SpawnIndexes.Contains(RandomIndex);
            while (Contain)
            {
                RandomIndex = Random.Range(0, 6);
                Contain = SpawnIndexes.Contains(RandomIndex);
            }

            SpawnIndexes.Add(RandomIndex);
        }
        for (int i = 0; i < SpawnPoints - 1; i++)
        {
            Transform SpawnPoint = _spawnPositions[SpawnIndexes[i]].transform;
            Instantiate(_enemyObjects[Random.Range(0, _enemyObjects.Length)], SpawnPoint);
        }
        var HelperChance = Random.Range(0, 101);
        if (HelperChance <= _helperPercent)
        {
            Transform SpawnHelperPoint = _spawnPositions[SpawnIndexes[SpawnPoints - 1]].transform;
            Instantiate(_helperObject[Random.Range(0, _enemyObjects.Length + 1)], SpawnHelperPoint);
        }

    }

    private void FixedUpdate()
    {
        _frames++;
        if (_framesToSpawn <= _frames)
        {
            _frames = 0;
            Spawn();
        }
    }
}
