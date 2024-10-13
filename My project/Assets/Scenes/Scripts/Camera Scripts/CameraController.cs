using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 targetPoint = Vector3.zero;

    public Movement player;
    

    public float moveSpeed;

    public float lookAheadDistance = 10f;
    public float lookAheadSpeed = 5f;

    private float lookOffset;


    // Start is called before the first frame update
    void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetPoint.x = player.transform.position.x;
        targetPoint.y = player.transform.position.y;

        if(targetPoint.y < 0)
        {
            targetPoint.y = 0;
        }

        if(player.rb.velocity.x > 0f)
        {
            lookOffset = Mathf.Lerp(lookOffset,  lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }
        if(player.rb.velocity.x < 0f)
        {
            lookOffset = Mathf.Lerp(lookOffset, -lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }

        targetPoint.x = player.transform.position.x + lookOffset;


        //transform.position = targetPoint;
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
    }
}
