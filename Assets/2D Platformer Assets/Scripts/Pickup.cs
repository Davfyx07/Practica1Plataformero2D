using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;
    private bool isCollected;
    public GameObject pickUpEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isCollected ) 
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemCount();
                Instantiate(pickUpEffect,transform.position, transform.rotation);
                AudioManager.instance.PlaySFX(6);

                isCollected = true;
                Destroy(gameObject);
            }

            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealt != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    AudioManager.instance.PlaySFX(7);

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }

}
