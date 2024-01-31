using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToRespawn;

    public int gemsCollected;
    private void Awake()
    {
        instance = this;
    }
   


    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());

    }
    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;
        
        PlayerHealthController.instance.currentHealt = PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealtDisplay();

    }
}
