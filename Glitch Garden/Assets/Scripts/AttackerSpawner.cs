using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] Attacker[] attackerPrefabArray;

    [Header("Spawn Time")]
    float spawnTimer;
    [SerializeField] float minSpawnTime;
    [SerializeField] float maxSpawnTime;

    bool spawn = true;


    // start coroutine for spawning enemies
    IEnumerator Start()
    {
        minSpawnTime = minSpawnTime - PlayerPrefsController.GetDifficulty();
        maxSpawnTime = maxSpawnTime - PlayerPrefsController.GetDifficulty();
        while (spawn)
        {
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(spawnTimer);
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    // spawn the attachers within coroutine
    private void SpawnAttacker()
    {
        var index = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[index]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
