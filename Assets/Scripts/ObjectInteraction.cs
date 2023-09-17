using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject talkText;
    private bool talkActive;
    public float interactionDistance = 2f;
    public Transform player;
    public GameObject[] npcLook;

    private Quaternion[] originalRotations;

    public GameObject firstDialogue;
    public GameObject opt1;
    public GameObject opt2;

    void Start()
    {
        talkActive = false;
        originalRotations = new Quaternion[npcLook.Length];

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
            talkText.SetActive(false);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

                if (interactableObject != null)
                {
                    interactableObject.Interact();

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

            yield return new WaitForSeconds(10f);

            for (int i = 0; i < npcLook.Length; i++)
            {
                npcLook[i].transform.rotation = originalRotations[i];
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

                if (firstDialogue.activeSelf)
                {
                    talkText.SetActive(false);
                }

                if (opt1.activeSelf)
                {
                    talkText.SetActive(false);
                }

                if (opt2.activeSelf)
                {
                    talkText.SetActive(false);
                }

                
            }
        }
    }


}
