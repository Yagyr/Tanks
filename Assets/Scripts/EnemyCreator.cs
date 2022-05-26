using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _numberOfTanksToCreate = 20;
    [SerializeField] private Transform[] _spawns;

    [SerializeField] GameObject _winWindos;

    private int _numberOfEnemiesActive = 0;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_numberOfTanksToCreate == 0)
        {
            return;
        }
        if (_numberOfEnemiesActive < 5)
        {
            if (_timer > 3f)
            {
                if (TryCreate())
                {
                    _timer = 0;
                }
            }
        }
    }
    bool TryCreate()
    {

        int spawnIndex = Random.Range(0, _spawns.Length);
        if (Physics.CheckBox(_spawns[spawnIndex].position, Vector3.one * 0.2f) == false)
        {
            float zRotation = Random.Range(0, 4) * 90f;
            Enemy enemy = Instantiate(_enemyPrefab, _spawns[spawnIndex].position, Quaternion.Euler(0, 0, zRotation));
            enemy.Initialize(this);
            _numberOfTanksToCreate -= 1;
            _numberOfEnemiesActive++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveEnemy (Enemy enemy)
    {
        _numberOfEnemiesActive--;
        if (_numberOfEnemiesActive == 0 && _numberOfTanksToCreate == 0)
        {
            _winWindos.SetActive(true);
        }
    }
}
