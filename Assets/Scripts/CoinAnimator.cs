using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    private void Update()
    {
        var rotationalSpeed = 50;
        transform.Rotate(0, rotationalSpeed * Time.deltaTime, 0);
    }
}
