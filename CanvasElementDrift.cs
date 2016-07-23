using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This script is attached to a Canvas element to have it drift in random directions
/// but anchored to its starting location
///
/// NOTE:
/// - Heavy use of this results in lag. Need to switch coroutine to a function.
///
/// </summary>

[DisallowMultipleComponent]
public class CanvasElementDrift : MonoBehaviour {
    	
    [SerializeField] float driftSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] float minDriftTime;
    [SerializeField] float maxDriftTime;

    Vector3 startingPosition;
    Vector3 direction;
    Vector3 destination;


    void Awake () {

        startingPosition = this.GetComponent<RectTransform>().localPosition;
        StartCoroutine(GetNewDestination());
        if(minDriftTime >= maxDriftTime) { Debug.LogError("minDriftTime >= maxDriftTime!!!"); }
    }

    void Update () {

        Vector3 currentPosition = this.GetComponent<RectTransform>().localPosition;
        this.transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(currentPosition, destination, driftSpeed * Time.deltaTime);
    }

    IEnumerator GetNewDestination () {
        
        float angle = Random.Range(0f, 360f);
        float newDistance = Random.Range(0f, maxDistance);
        float newX = newDistance * Mathf.Sin(angle) + startingPosition.x;
        float newY = newDistance * Mathf.Cos(angle) + startingPosition.y;
        destination = new Vector3(newX, newY, 0);

        yield return new WaitForSeconds(Random.Range(minDriftTime, maxDriftTime));

        StopCoroutine(GetNewDestination());
        StartCoroutine(GetNewDestination());
    }
}
