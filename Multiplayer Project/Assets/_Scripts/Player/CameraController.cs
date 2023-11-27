using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontalSpeed;
    private float VerticalSpeed;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    void FixedUpdate()
    {
        Turn();
    }

    public void TurnHorizontal(float speed)
    {
        horizontalSpeed = speed;
    }

    public void TurnVertical(float speed)
    {
        VerticalSpeed = speed;
    }

    private void Turn()
    {
        transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x + VerticalSpeed, minX, maxX), Mathf.Clamp(transform.eulerAngles.y + horizontalSpeed, minY, maxY), 0);
    }
}