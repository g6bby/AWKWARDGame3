using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareAtPlayer : MonoBehaviour
{
    public Transform Target;



    public void Stare()
    {
        transform.LookAt(Target);
        
        Debug.Log("Stare");
    }
}
