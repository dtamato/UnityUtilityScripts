using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

/// <summary>
/// Countdown timer for a Canvas text object
/// </summary>

[DisallowMultipleComponent]
[RequireComponent(typeof(Text))]
public class CanvasTimer : MonoBehaviour {

    [SerializeField] float startingSeconds;

	// Update is called once per frame
	void Update () {
	
        if (startingSeconds > 0) { startingSeconds -= Time.deltaTime; }

        int minutes = (int)(startingSeconds / 60 % 60);
        int hours = (int)(startingSeconds / 60 / 60);
        int seconds = (int)(startingSeconds % 60);
            
        this.GetComponent<Text>().text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}
