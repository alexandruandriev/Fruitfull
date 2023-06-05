using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fruit : MonoBehaviour
{
 

    public int scoreValue = 1;
    private bool isCaught = false;
    private AudioSource AudioSrc;
    public AudioClip[] smashSounds;
    public AudioClip[] catchedSounds;

 
    private void Awake()
    {
        AudioSrc = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (Settings.Instance.MUTE)
        {
            AudioSrc.volume = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Ground"))
        {
            //TODO Play Particle before destroying
            float destroyTimer = PlayRandomSmashSound();
            if (!isCaught)
            {
                GameManager.Instance.TakeDamage();
            }
            Destroy(gameObject, destroyTimer);
        }

        if (isCaught) return;

        if (collision.collider.CompareTag("Fruit"))
        {
            Fruit fruit = collision.collider.GetComponent<Fruit>();
            if (fruit.isCaught)
            {
                PlayRandomCatchedSound();
                transform.SetParent(collision.collider.transform, true);
                isCaught = true;
                GameManager.Instance.Score += scoreValue;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCaught) return;
        if (other.CompareTag("Player")) 
        {
            PlayRandomCatchedSound();
            isCaught = true;
            transform.SetParent(other.transform, true);
            GameManager.Instance.Score += scoreValue;
        }
       
    }

    float PlayRandomCatchedSound()
    {
        
        int rand = Random.Range(0, catchedSounds.Length);
        AudioSrc.PlayOneShot(catchedSounds[rand]);
        return catchedSounds[rand].length;
    }
    float PlayRandomSmashSound()
    {
        int rand = Random.Range(0, smashSounds.Length);
        AudioSrc.PlayOneShot(smashSounds[rand]);
        return smashSounds[rand].length;
    }
}
