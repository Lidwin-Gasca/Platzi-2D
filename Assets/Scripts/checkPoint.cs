using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    [SerializeField] int addedTime = 10;
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        gameManager.Instance.time += 10;
        Destroy(gameObject, 0.1f);
    }
}
}
