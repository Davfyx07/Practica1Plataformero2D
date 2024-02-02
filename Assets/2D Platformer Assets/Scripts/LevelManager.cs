using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string levelToLoad;
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

        yield return new WaitForSeconds(waitToRespawn - (1f/UIController.instance.fadeSpeed));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);

        UIController.instance.FadeFromBlack();


        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;
        
        PlayerHealthController.instance.currentHealt = PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealtDisplay();

    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFllow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) * .25f);
        SceneManager.LoadScene(levelToLoad);

    }
}
