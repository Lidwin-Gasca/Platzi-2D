using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Transform player;
    //variable con valor de vida
    [SerializeField] int health = 1;
    //Velocidad del enemigo
    [SerializeField] float speed = 1;

    private void Start()
    {
        player = FindObjectOfType<player>().transform; //Esto es para que el enemigo pueda encontrar la posicion del jugador.
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("spawnPoint");//localiza todos los objetos que tengan el tag "spawnPoint" en el proyecto Unity.
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);//crea un numnero random,  el cual usaremos en la linea de codigo debajo de esta misma, para seleccionar un spawn en especifico, todo esto de manera aleatorio.
        transform.position = spawnPoint[randomSpawnPoint].transform.position;//esto hace que se escoja de manera aleatoria un objeto de todos los que tengan el tag mencionado en el codigo dos lineas arriba.
    }

    private void Update()
    {
        //Con este bloque de codigo hacemos que el enemigo ejecute la persecucion de seguir al jugador.

        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }

    //Metodo de daño
    public void TakeDamage()
    {
        health --;//se le baja una unidad de vida
        if (health <= 0)//si vida, llega a cero
        {
            Destroy(gameObject); //se muere
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player")) 
        {
                 collision.GetComponent<player>().TakeDamage();// con esta linea de codigo generas el daño al enemigo
        }
        
    }
}
