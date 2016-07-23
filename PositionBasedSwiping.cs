using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Detects whether the player has swiped left
/// or right depending on the size of the swipe
/// 
/// </summary>

[DisallowMultipleComponent]
public class PositionBasedSwiping : MonoBehaviour {

    [SerializeField, Range(0, 1), Tooltip("Percentage of the screen width the swipe needs to be to count as a swipe.")] 
    float swipePercentage = 0.5f;

    Vector2 touchStartPosition;
    Vector2 touchEndPosition;
    float minimumSwipeSize;


    void Awake () {

        minimumSwipeSize = swipePercentage * Screen.width;
    }

    void Update () {

        WaitForTouch();
    }

    void WaitForTouch () {

        if(Input.touchCount == 1) {

            switch (Input.GetTouch(0).phase) {

                case TouchPhase.Began:
                    touchStartPosition = Input.GetTouch(0).position;
                    break;
                case TouchPhase.Ended:
                    touchEndPosition = Input.GetTouch(0).position;
                    ProcessSwipe();
                    break;
            }
        }
    }

    void ProcessSwipe () {

        Vector2 deltaPosition = touchEndPosition - touchStartPosition;

        if(deltaPosition.x > minimumSwipeSize) {

            Debug.Log("Swiped right!");
        }
        else if(deltaPosition.x < -minimumSwipeSize) {

            Debug.Log("Swiped left!");
        }
    }
}
