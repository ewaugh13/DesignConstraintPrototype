using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInputs : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The Rotate Tunnel Component")]
    private RotateTunnel[] rotateTunnels;
    #endregion

    #region Hidden Variables
    private Vector3 FirstTouchPoint;   //First touch position
    private Vector3 LastTouchPoint;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    #endregion

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        Debug.developerConsoleVisible = true;
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                FirstTouchPoint = touch.position;
                LastTouchPoint = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                LastTouchPoint = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                LastTouchPoint = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(LastTouchPoint.x - FirstTouchPoint.x) > dragDistance || Mathf.Abs(LastTouchPoint.y - FirstTouchPoint.y) > dragDistance)
                {
                    //It's a drag
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(LastTouchPoint.x - FirstTouchPoint.x) > Mathf.Abs(LastTouchPoint.y - FirstTouchPoint.y))
                    {
                        //Right swipe
                        if ((LastTouchPoint.x > FirstTouchPoint.x))
                        {   
                            Debug.Log("Right Swipe");
                            for (int i = 0; i < rotateTunnels.Length; i++)
                            {
                                rotateTunnels[i].RotateRight();
                            }
                        }
                        //Left swipe
                        else
                        {   
                            Debug.Log("Left Swipe");
                            for (int i = 0; i < rotateTunnels.Length; i++)
                            {
                                rotateTunnels[i].RotateLeft();
                            }
                        }
                    }
                }
            }
        }
    }
}
