using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] AudioClip destroyed;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem destropartical;
    [SerializeField] ParticleSystem successpartical;
    AudioSource aud;
    public bool audios;
    bool colisionDisable;

    private void Start()
    {
       audios = false;
       colisionDisable = false;

        aud = GetComponent<AudioSource>();
        

    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.C)) { disablingofcolission(); }
    }
    void disablingofcolission()
    {
        colisionDisable = true;
        
    }

    void OnCollisionEnter(Collision collide)
    {
      if (audios||colisionDisable) { return; }
        switch (collide.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("you safe");
                break;
            case "Finish":
                HitLandingPad();
                break;
            case "Dangerious":
                scatchAnime();
                break;

        }
    }
    void HitLandingPad()
    {
        audios = true;
        aud.PlayOneShot(success);
        successpartical.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 3f);
    }
    void scatchAnime()
    {
        audios = true;
        aud.PlayOneShot(destroyed);
        destropartical.Play();
        GetComponent<Movement>().enabled = false;
        
        Invoke("LoadNewScene", 3f);
        
    }
    void LoadNewScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0) { sceneIndex++; }
        else { sceneIndex = 0; }

        SceneManager.LoadScene(sceneIndex);
    }
}
