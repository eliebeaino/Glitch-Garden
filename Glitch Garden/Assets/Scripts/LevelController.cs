using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int attackerCount = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject looseLabel;
    [SerializeField] float waitTimerGameFinished;

    private void Start()
    {
        winLabel.SetActive(false);
        looseLabel.SetActive(false);
    }

    public void AttackerSawpned()
    {
        attackerCount++;
    }

    public void AttackerKilled()
    {
        attackerCount--;
        if (attackerCount == 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void HandleLooseCondition()
    {
        looseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitTimerGameFinished);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSawpners();
    }

    private static void StopSawpners()
    {
        AttackerSpawner[] spawnerAray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerAray)
        {
            spawner.StopSpawning();
        }
    }
}
