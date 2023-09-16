using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public Rigidbody characterRB;
    public StareAtPlayer playerStare;

    public GameObject[] objectsToStop;

    public AudioSource musicStop;
    public AudioSource crowdStop;

    private bool musicPlaying = true;

    private bool isPlaying = true;

    void Start()
    {
        //playerStare = GameObject.FindObjectOfType(typeof(StareAtPlayer)) as StareAtPlayer;
    }

    
   public void Interact()
   {
        if (characterRB != null)
        {
            //characterRB.constraints = RigidbodyConstraints.FreezePosition;
        }

        PauseAudio();

        isPlaying = false;

        if (isPlaying)
        {
            foreach (GameObject obj in objectsToStop)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = true;
            }
        }
        }
        else
        {
            foreach (GameObject obj in objectsToStop)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
        }
        }

        
        playerStare.Stare();



    }

    public void PauseAudio()
    {
            musicPlaying = false;

            musicStop.Pause();

            crowdStop.Pause();

    }

    public void ResumeAudio()
    {
        
        musicPlaying = false;

            musicStop.UnPause();

            crowdStop.UnPause();

    }
}
