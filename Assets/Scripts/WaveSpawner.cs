﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    //public Text waveCountdownText;
    public TextMeshProUGUI waveCountdownText;


    private int waveIndex = 0;
    private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        countdown -= Time.deltaTime; // reduce countdown by 1 every second

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //countdown will not be less than zero / negative

        waveCountdownText.text = string.Format("{0:00 }", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
