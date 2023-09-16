using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject talkText;
    private bool talkActive;
    
    public float interactionDistance = 2f; 

    public Transform player;
    public GameObject[] npcLook;



     void Start()
        {
        talkActive = false;
        

        }

    void Update()
    {
        
        if (talkActive == false)
        {
            talkText.SetActive(false);
        }
        else
        {
            talkText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                
                if (interactableObject != null)
                {
                    interactableObject.Interact();

                    // foreach (GameObject item in npcLook)
                    // {
                    //     Vector3 direction = player.position - item.transform.position;

                    // item.transform.LookAt(player);  
                    // }

                    StartCoroutine(Looking());

                }
            }
        }

            IEnumerator Looking()
    {
                while(true)
                {
                    foreach (GameObject item in npcLook)
                    {
                        Vector3 direction = player.position - item.transform.position;

                    item.transform.LookAt(player);  
                    }

                    yield return null;
                }
    }


        if (talkActive == false)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                
                if (interactableObject != null)
                {
                    talkText.SetActive(true);
                }
            }
        }
    }
}
