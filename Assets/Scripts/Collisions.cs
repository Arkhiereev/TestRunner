using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    private int _coins;
    [SerializeField] private Text score, scoreLose, scoreWin;
    [SerializeField] private GameObject restart, gameOver, finish;

    [Header("Set in Inspector")]
    [SerializeField] private int valueOfCoins;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.Coin)
        {
            _coins += valueOfCoins;
            score.text = _coins.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == Layers.Obstacle)
        {
            gameOver.SetActive(true);
            scoreLose.text = score.text;
            Collision();
        }

        if (other.gameObject.layer == Layers.Finish)
        {
            finish.SetActive(true);
            scoreWin.text = score.text;
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
