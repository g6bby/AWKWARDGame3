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

    private Quaternion[] originalRotations;


     void Start()
        {
            talkActive = false;
            
            originalRotations = new Quaternion[npcLook.Length];

        // Store the original rotations of npcLook objects
        for (int i = 0; i < npcLook.Length; i++)
        {
            originalRotations[i] = npcLook[i].transform.rotation;
        }

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
                Quaternion[] currentRotations = new Quaternion[npcLook.Length];

                for (int i = 0; i < npcLook.Length; i++)
                {
                    Vector3 direction = player.position - npcLook[i].transform.position;

                    npcLook[i].transform.LookAt(player);

                    currentRotations[i] = npcLook[i].transform.rotation;
                }

                yield return new WaitForSeconds(3f);

                for (int i = 0; i < npcLook.Length; i++)
                {
                    npcLook[i].transform.rotation = currentRotations[i];
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
