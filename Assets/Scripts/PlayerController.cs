using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    private Touch _touch;
    private int _coins;
    [SerializeField] private Text score, scoreL, scoreW;
    [SerializeField] private GameObject restart, gameOver, finish;
    
    [Header("Set in Inspector")]
    [SerializeField] private int valueOfCoins;
    [SerializeField] private float speed, sensitivity;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {       
        Vector3 pos = this.transform.position;
        pos.z += speed * Time.deltaTime;
        this.transform.position = pos;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            _coins += valueOfCoins;
            score.text = _coins.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            gameOver.SetActive(true);
            scoreL.text = score.text;
            Collision();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            finish.SetActive(true);
            scoreW.text = score.text;
            Collision();
        }
    }

    private void Collision()
    {
        restart.SetActive(false);
        score.text = " ";
        Time.timeScale = 0;
    }
}
