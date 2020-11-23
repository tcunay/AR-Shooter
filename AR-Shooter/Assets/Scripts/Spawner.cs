﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;


    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        while (true)
        {
            Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], GetRandomPlaceInSphere(_spawnRadius), Quaternion.identity);
            Vector3 lookDirection = _target.transform.position - newEnemy.transform.position;
            newEnemy.transform.rotation = Quaternion.LookRotation(lookDirection);
            newEnemy.Dying += OnEnemyDying;
            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
    
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _target.AddScore();
    }
    private Vector3 GetRandomPlaceInSphere(float radius)
    {
        return Random.insideUnitSphere * radius;
    }

}
