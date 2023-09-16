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


    private bool isPlaying = true;

    void Start()
    {
        playerStare = GameObject.FindObjectOfType(typeof(StareAtPlayer)) as StareAtPlayer;
    }

    
   public void Interact()
   {
        if (characterRB != null)
        {
            //characterRB.constraints = RigidbodyConstraints.FreezePosition;
        }
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
}
