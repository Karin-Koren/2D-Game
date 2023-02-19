using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallToWater : MonoBehaviour
{
    public GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            gameOverPanel.SetActive(true);
        }
    }
}
