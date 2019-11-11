using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInputs : MonoBehaviour
{
    #region Hidden Variables
    private Vector3 FirstTouchPoint;   //First touch position
    private Vector3 LastTouchPoint;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    private GameObject SwipeRightText;
    private GameObject SwipeLeftText;
    #endregion


    #region Public Variables

    #endregion

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        SwipeLeftText = GameObject.Find("Swipe Left");
        Debug.Log(SwipeLeftText);
        SwipeRightText = GameObject.Find("Swipe Right");
        Debug.Log(SwipeRightText);
        SwipeLeftText.SetActive(false);
        SwipeRightText.SetActive(false);
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
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(LastTouchPoint.x - FirstTouchPoint.x) > Mathf.Abs(LastTouchPoint.y - FirstTouchPoint.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((LastTouchPoint.x > FirstTouchPoint.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            SwipeRightText.SetActive(true);
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            SwipeLeftText.SetActive(true);
                        }
                    }
                    //else
                    //{   //the vertical movement is greater than the horizontal movement
                    //    if (LastTouchPoint.y > FirstTouchPoint.y)  //If the movement was up
                    //    {   //Up swipe
                    //        Debug.Log("Up Swipe");
                    //    }
                    //    else
                    //    {   //Down swipe
                    //        Debug.Log("Down Swipe");
                    //    }
                    //}
                }
                //else
                //{   //It's a tap as the drag distance is less than 20% of the screen height
                //    Debug.Log("Tap");
                //}
            }
        }
    }
}
