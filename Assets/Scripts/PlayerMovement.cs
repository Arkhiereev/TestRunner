using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Touch _touch;
    [SerializeField] private float speed, sensitivity;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * sensitivity,
                    transform.position.y, transform.position.z);
                
                var posx = transform.position.x;
                var roadWidth = 10;
                if (Math.Abs(posx) > roadWidth / 2)
                {
                    posx = (roadWidth / 2) * posx / Math.Abs(posx);
                    transform.position = new Vector3(posx,
                    transform.position.y, transform.position.z);
                }
            }
        }
    }
}
