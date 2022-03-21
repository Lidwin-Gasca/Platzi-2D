using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{

    float originalSpeed;
    player player;
    [SerializeField] float speedReductionRatio = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<player>();
        originalSpeed = player.speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) {
            player.speed *= speedReductionRatio;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            player.speed = originalSpeed;
        }
    }
}
