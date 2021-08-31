using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;

}


public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] SpawnPoints;
    public Animator animator;
    public Text waveName;

    private Wave currentWave;
    private int currentWaveNumber;
    private bool canSpawn = true;
    private bool canAnimate = false;
    private float nextSpawnTime;

    private void Update() {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(totalEnemies.Length);
        if (totalEnemies.Length ==3 ) {
            if (currentWaveNumber+1 != waves.Length ){
                if (canAnimate){
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("IsWaveComplete");
                    canAnimate = false;
                    SpawnNextWave();
                }
            }
            else{
                //Debug.Log("You Won!!");
                PauseMenu.instance.GotoWinScreen();
            }
            
        }
    }

    void SpawnNextWave(){
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave(){
        if (canSpawn && nextSpawnTime < Time.time){
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = SpawnPoints[Random.Range(0 ,SpawnPoints.Length)];
            Instantiate(randomEnemy,randomPoint.position , Quaternion.identity);
            currentWave.noOfEnemies --;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.noOfEnemies ==0){
                canSpawn = false;
                canAnimate = true;
            }
        }
        
    }

}


