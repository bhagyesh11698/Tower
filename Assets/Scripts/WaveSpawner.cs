using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

   // public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2f;

    //public Text waveCountdownText;
    public TextMeshProUGUI waveCountdownText;

    public GameManager gameManager;


    private int waveIndex = 0;
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        // new wave will not be spawned until all enemies are killed or reached end point

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; // once all enemies from a wave are spawned, timer will go to 0
            // if wave is completely killed, countdown will start from 10

        }
        countdown -= Time.deltaTime; // reduce countdown by 1 every second

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //countdown will not be less than zero / negative

        waveCountdownText.text = string.Format("{0:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
    }
}
