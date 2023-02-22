using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class waveSpawner : MonoBehaviour
{

    public static int EnnemisAlive = 0;

    public Wave[] waves;
    
    [SerializeField] private float timeBetweenWaves = 10f;

    [SerializeField] private GameObject player;
    
    private float countDown = 2f;

    [SerializeField] private Transform[] spawnPoint;

    private int waveIndex = 0;

    [SerializeField] private TMP_Text KillCounter;

    void Update()
    {
        if (EnnemisAlive > 0)
        {
            return;
        }
        
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        KillCounter.text = string.Format("{0:00:00}", countDown);
    }

    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnnemi(wave.Ennemi);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Beau combat ! Péparez-vous pour le prohain !");
        }
    }

    void SpawnEnnemi(GameObject Ennemi)
    {
        GameObject ennemi = Instantiate(Ennemi, spawnPoint[0]);
        ennemi.GetComponent<EnnemiFollow>().Player = player;

        for (int i = 0; i < spawnPoint.Length-1; i++)
        {
            ennemi = Instantiate(Ennemi, spawnPoint[i]);
            ennemi.GetComponent<EnnemiFollow>().Player = player;
            
        }
        EnnemisAlive++;

    }

}
