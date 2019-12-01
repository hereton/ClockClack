using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Clock : MonoBehaviour
{
    const float
            degreesPerHour = 30f,
            degreesPerMinute = 6f,
            degreesPerSecond = 6f;
    public Transform hoursTransform, minutesTransform, secondsTransform;


    void Awake()
    {
        DateTime time = DateTime.Now;
        hoursTransform.rotation =
            Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.rotation =
            Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.rotation =
            Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }
    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
             Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }
    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }
}
