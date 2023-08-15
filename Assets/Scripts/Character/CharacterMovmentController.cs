using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovmentController : MonoBehaviour
{
    private Vector2 touchStartPos; 
    private bool isDragging = false; 

    public float moveSpeed = 5f;
    [SerializeField] private PlayerController playerController;
    private Rigidbody2D rb;
    //private float bounderesTop =10.4f, bounderesRigt=10.31f;
    [SerializeField] private Transform leftBoundary, bottomBoundary, rightBoundary, topBoundary;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnEnable()
    {
        playerController.anim.SetBool("Walk", false);
        playerController.anim.SetBool("StopWalki", true);
        isDragging = false;
        
    }
    private void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isDragging = true;
                    playerController.anim.SetBool("Walk", true);
                
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isDragging)
                    {
                        Vector2 dragDelta = touch.position - touchStartPos;
                        Vector2 movement = dragDelta.normalized;
                       
                            rb.velocity = movement * moveSpeed;
         
                            if (touch.deltaPosition.x < 0)
                            {
                                rb.transform.localScale = new Vector3(-rb.transform.localScale.y, rb.transform.localScale.y, rb.transform.localScale.z);
                                Debug.Log(-1);
                            }
                            else if(touch.deltaPosition.x > 0)
                            {
                                rb.transform.localScale = Vector3.one * rb.transform.localScale.y;
                                Debug.Log(1);
                            }

    
                            float clampedX = Mathf.Clamp(rb.transform.localPosition.x, leftBoundary.transform.localPosition.x, rightBoundary.transform.localPosition.x);
                            float clampedY = Mathf.Clamp(rb.transform.localPosition.y, bottomBoundary.transform.localPosition.y, topBoundary.transform.localPosition.y);

                            // Apply the clamped position
                            rb.transform.localPosition = new Vector3(clampedX, clampedY, rb.transform.localPosition.z);


                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    rb.velocity = Vector2.zero;
                    playerController.anim.SetBool("StopWalki", true);
               
                    break;
                   
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            isDragging = true;
           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            rb.velocity = Vector2.zero;
        }
    }

}
