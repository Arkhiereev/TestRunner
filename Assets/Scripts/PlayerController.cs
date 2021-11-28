using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Touch touch;
    private int coins;
    public int valueOfCoins;
    public float speed, sensitivity;
    public Text score, score_L, score_W;
    public GameObject restart, gameOver, finish;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(0, 0, speed);
        controller.Move(dir * Time.fixedDeltaTime);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * sensitivity / 100,
                    transform.position.y, transform.position.z);
                
                float posx = transform.position.x;
                if (Math.Abs(posx) > 5)
                {
                    posx = 5 * posx / Math.Abs(posx);
                    transform.position = new Vector3(posx,
                    transform.position.y, transform.position.z);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            coins += valueOfCoins;
            score.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            gameOver.SetActive(true);
            restart.SetActive(false);
            score_L.text = score.text;
            score.text = " ";
            Time.timeScale = 0;
        }

        if (hit.gameObject.tag == "Finish")
        {
            finish.SetActive(true);
            restart.SetActive(false);
            score_W.text = score.text;
            score.text = " ";
            Time.timeScale = 0;
        }
    }
}
