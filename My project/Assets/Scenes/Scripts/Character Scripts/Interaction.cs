using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool interactsWithDoor;
    private bool interactsWithSword;
    public GameObject Door1;
    public GameObject sword;
    public GameObject swordobject;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interactsWithDoor == true && Input.GetKeyDown(KeyCode.E))
        {
            Door1.gameObject.SetActive(false);
        }
        if(interactsWithSword == true && Input.GetKeyDown(KeyCode.E))
        {
            swordobject.gameObject.SetActive(false);
            sword.gameObject.SetActive(true);
            
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door1"))
        {
            interactsWithDoor = true;
        }

        if (collision.gameObject.CompareTag("sword"))
        {
            interactsWithSword = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door1"))
        {
            interactsWithDoor = false;
        }
        if (collision.gameObject.CompareTag("sword"))
        {
            interactsWithSword = false;
        }
    }

    
}
