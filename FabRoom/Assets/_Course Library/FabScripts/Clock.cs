using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        // Get the current system time
        DateTime currentTime = DateTime.Now;

        // Calculate angles for each hand
        float secondAngle = (float)currentTime.Second / 60f * 360f;
        float minuteAngle = ((float)currentTime.Minute + (secondAngle / 360f)) / 60f * 360f;
        float hourAngle = ((float)currentTime.Hour + (minuteAngle / 360f)) / 12f * 360f;

        // Rotate the clock hands
        secondHand.localRotation = Quaternion.Euler(0f, 0f, secondAngle);
        minuteHand.localRotation = Quaternion.Euler(0f, 0f, minuteAngle);
        hourHand.localRotation = Quaternion.Euler(0f, 0f, hourAngle);
    }
}
