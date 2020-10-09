using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    private bool isMoving = false;
    private Vector2 startPosition;
    private bool isOnDropZone = false;
    private GameObject dropZone;
    private GameObject startParent;


    public GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Main Canvas");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move card to mouse position
        if (isMoving)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnDropZone = false;
        dropZone = null;
    }

    public void StartMove()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isMoving = true;
    }

    public void StopMove()
    {
        isMoving = false;
        //put in drop if its in drop, otherwise put it back where it came from
        if (isOnDropZone)
        {
            transform.SetParent(dropZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, true);
        }
    }
}
