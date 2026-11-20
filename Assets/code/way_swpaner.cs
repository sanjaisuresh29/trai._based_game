using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;

public class way_swpaner : MonoBehaviour
{
    public enum SpwanState { SPWANING,WAITING,COUNTING};
    [Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextwave = 0;


    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchcount = 1f;

    private SpwanState state = SpwanState.COUNTING;

    public Transform[] spawnpoints;
    private void Start()
    {
        if (spawnpoints.Length == 0)
        {
            Debug.LogError("no points");
        }
        waveCountdown = timeBetweenWaves;
        
    }

    private void Update()
    {
        
        //if(state == SpwanState.WAITING)
        {
            //if (!Enemyisalive())
            {
                //wavecompleted();
            }
            //else
            {
                //return;
            }
        }


        if (waveCountdown <= 0)
        {
            if (state != SpwanState.SPWANING)
            {
                StartCoroutine(SpwanWave(waves[nextwave]));
            }
        }

        else 
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    bool Enemyisalive()
    {
        
        searchcount -= Time.deltaTime;

        if(searchcount <= 0f)
        {
            searchcount = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        

        return true;
    }
    IEnumerator SpwanWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpwanState.SPWANING;

        for(int i = 0; i < _wave.count; i++)
        {
            Spawn(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpwanState.WAITING;

        yield break;
    }

    void Spawn(Transform _enemy)
    {
        
        
        Debug.Log("Spwaning enmey:" + _enemy.name);
        int k = UnityEngine.Random.Range(0, spawnpoints.Length);
        Transform sp = spawnpoints[k];
        Instantiate(_enemy, sp.position, sp.rotation);
    }

    void wavecompleted()
    {
        Debug.Log("completed");

        state = SpwanState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextwave + 1 > waves.Length - 1)
        {
            nextwave = 0;
            Debug.Log("All Waves complete looping..");
        }

        nextwave++;
    }
}
