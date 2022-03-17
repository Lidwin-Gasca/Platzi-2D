using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    [SerializeField] int health = 3;
    [SerializeField] float speed = 5;//lo que esta entre corchetes, es para crear una opcion de personalizacion en unity, asi no tendrias que venir al codigo cada que quieres cambiar el valor de la velocidad "speed". solo inserta " [SerializeField] " espacios antes e la declaracion de tu variable.    
    public bool powerShot;

    private void Start()
    {
        Destroy(gameObject, 5);//esto indica que nuestra bala se desaparecera despues de 5 segundos de vida
    }
    

    void Update()
    {
        //Velocidad de Bala
        transform.position += transform.right * Time.deltaTime * speed;
    }
    

    //metodo para la colision entre dos objetos, en este caso, contra el enemigo.0
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy")) {
            collision.GetComponent<enemy>().TakeDamage();// con esta linea de codigo generas el daño al enemigo
            if (!powerShot)
            {
            Destroy(gameObject);//destruye la bala
            }
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
