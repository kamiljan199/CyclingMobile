using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public BicycleController bike;
    private const float MAX_SPEED_ANGLE = -85;
    private const float MIN_SPEED_ANGLE = 60;

    private Transform needleTransform;

    private float speedMax;
    private float speed;

    private void Awake()
    {
        needleTransform = transform.Find("NeedlePivot");
        speed = 0.0f;
        speedMax = 300.0f;
    }

    private void Update()
    {
        speed = bike.velocity;
        needleTransform.eulerAngles = new Vector3(0f, 0f, GetSpeedRotation());
    }

    public float GetSpeedRotation()
    {
        float totalAngleSize = MIN_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return MIN_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
