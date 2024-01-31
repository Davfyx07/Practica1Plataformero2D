using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealt, maxHealth;
    public float invincibleLeght;
    private float invincibleCounter;
    private SpriteRenderer theSR;
    public GameObject deathEffect;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0 )
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0) 
        {
            currentHealt--;
            PlayerController.instance.anim.SetTrigger("Hurt");
            AudioManager.instance.PlaySFX(9);


            if (currentHealt <= 0)
            {
                currentHealt = 0;

                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
                AudioManager.instance.PlaySFX(8);

                LevelManager.instance.RespawnPlayer();
                
                // gameObject.SetActive(false);
            }
            else
            {
                invincibleCounter = invincibleLeght;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .6f);
                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealtDisplay();
        }


    }

    public void HealPlayer()
    {
        currentHealt++;
        if (currentHealt > maxHealth)
        {
            currentHealt = maxHealth;
        }

        UIController.instance.UpdateHealtDisplay();
    }
}
