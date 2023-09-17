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

    public GameObject brightLight;
    public GameObject brightLight2;
    public GameObject playerSpotlight;
    public GameObject vLight;

    public GameObject redLight;
    public GameObject blueLight;
    public GameObject purpLight;
    public GameObject greenLight;

    private ObjectInteraction objectInteraction;

    private RigidbodyConstraints originalConstraints;

    public GameObject dialogue1;
    public GameObject dialogue1Answer;
    public GameObject dialogue2Answer;




    private bool musicPlaying = true;

    private bool isPlaying = true;

    void Start()
    {
        //playerStare = GameObject.FindObjectOfType(typeof(StareAtPlayer)) as StareAtPlayer;
        brightLight.SetActive(false);
        brightLight2.SetActive(false);
        playerSpotlight.SetActive(false);
        vLight.SetActive(false);

        dialogue1.SetActive(false);
        dialogue1Answer.SetActive(false);


        originalConstraints = characterRB.constraints;

    }

    
   public void Interact()
   {
        if (characterRB != null)
        {
            characterRB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        PauseAudio();
        brightLight.SetActive(true);
        brightLight2.SetActive(true);
        playerSpotlight.SetActive(true);
        vLight.SetActive(true);


        redLight.SetActive(false);
        blueLight.SetActive(false);
        purpLight.SetActive(false);
        greenLight.SetActive(false);

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

        //DIALOGUE
        dialogue1.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        playerStare.Stare();

        StartCoroutine(WaitTime());

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

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(10f);

        brightLight.SetActive(false);
        brightLight2.SetActive(false);
        playerSpotlight.SetActive(false);
        vLight.SetActive(false);

        redLight.SetActive(true);
        blueLight.SetActive(true);
        purpLight.SetActive(true);
        greenLight.SetActive(true);

        ResumeAudio();

        foreach (GameObject obj in objectsToStop)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = true;
            }
        }

        dialogue1.SetActive(false);
        dialogue1Answer.SetActive(false);
        dialogue2Answer.SetActive(false);

        characterRB.constraints = originalConstraints;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //StartCoroutine(objectInteraction.StopLooking());

    }

    
}
