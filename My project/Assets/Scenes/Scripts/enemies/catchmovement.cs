using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class catchmovement : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    
    public bool isChasing;
    public float chaseDistance;
    public float speed;
    public float adeger;
    public float bdeger;
    public float cdeger;

    private void Update()
    {
        if (isChasing)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            

            if (transform.position.x > playerTransform.position.x)
            {
                StartCoroutine(waitsomepls1());
                

            }
            if (transform.position.x < playerTransform.position.x)
            {
                StartCoroutine(waitsomepls2());
                



            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
        }

        
        

        
       
    }
    private IEnumerator waitsomepls1()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        transform.localScale = new Vector3(adeger, bdeger, cdeger);
    }
    private IEnumerator waitsomepls2()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        transform.localScale = new Vector3(-adeger, bdeger, cdeger);
    }


}
