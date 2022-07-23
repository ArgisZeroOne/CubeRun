using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    private int _frames = 0;
    [SerializeField] private int _framesToSpawn = 90;
    [SerializeField] private GameObject[] _enemyObjects = new GameObject[0];
    [SerializeField] private GameObject[] _spawnPositions = new GameObject[0];
    private void Spawn()
    {
        var SpawnIndexes = new List<int>();
        for (int i = 0; i<5; i++)
        {
            var RandomIndex = Random.Range(0,6);
            bool Contain = SpawnIndexes.Contains(RandomIndex);
            while (Contain)
            {
                RandomIndex = Random.Range(0, 6);
                Contain = SpawnIndexes.Contains(RandomIndex);
            }
            
            SpawnIndexes.Add(RandomIndex);
        }
        for (int i = 0; i < 5; i++)
        {
            Transform SpawnPoint = _spawnPositions[SpawnIndexes[i]].transform;
            Instantiate(_enemyObjects[Random.Range(0, _enemyObjects.Length)],SpawnPoint);
        }
        }
    private void FixedUpdate()
    {
        _frames++;
        if(_framesToSpawn <= _frames)
        {
            _frames = 0;
            Spawn();
        }
    }
}
