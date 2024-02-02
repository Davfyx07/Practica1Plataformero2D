using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target, farBackground, middleBackground;
    private Vector2 lastPosition;
    public float minHeight, maxHeight;
    public bool stopFllow;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!stopFllow)
        {
            //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            // float amountToMoveX = transform.position.x - lastXPosition;

            Vector2 amountToMove = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);
            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            lastPosition = transform.position;
        }
        
    }
}
