using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetwenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialized(_template);

    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondsBetwenSpawn)
        {
            if(TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 10);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                 
                DisableObjectAbroadScreen();
            }
        }
        

    }
}
