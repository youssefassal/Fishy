using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eat : MonoBehaviour
{
    AudioManager audioManager;

    public float growFactor = 1.1f;
    public float FishCounter;
    bool Growth ;
    void Start()
    {
        Growth = true;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            audioManager.PlaySFX(audioManager.eat);

            fishMovement Fish = other.GetComponent<fishMovement>();
            if (Fish != null)
            {

                float playerSize =Mathf.Abs(transform.localScale.x);
                float FishSize = Mathf.Abs(other.transform.localScale.x);
                if(playerSize >= 3)
                {
                    Growth = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

                if (playerSize >FishSize)
                {
                    if (Growth)
                    {
                    if(FishSize<1)
                    {
                        FishCounter += 0.5f;
                    }   
                    else if (FishSize < 2.5)
                    {
                        FishCounter++;
                    }
                    else if(FishSize<3)
                    {
                        FishCounter += 2;
                    }
                   
                    if(FishCounter >= 5 && FishSize <1)
                    {
                        PlayerMovement.FishSize *= growFactor;
                        FishCounter = 0;
                    }
                    else if(FishCounter >= 7 && FishSize < 2.5)
                    {
                        PlayerMovement.FishSize *= growFactor;
                        FishCounter = 0;
                    }
                    }
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                
            }
        }
    }
}
