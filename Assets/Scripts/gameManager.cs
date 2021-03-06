using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    
    public static gameManager Instance;//estamos declarando la variable "gameManager". NOTA: No se recomienda usar variables estaticar
    public int time = 30; //sera el tiempo de duracion del videojuego (mas sin embargo esto no es nada si no es por su codigo en las lineas dentro de bloque "IEnumerator")
    public int difficulty = 1;
    [SerializeField] int score; //para saber el puntaje del jugador

    public int Score {
        get => score; //Esta linea nos va a permitir obtener la valor almacenada en la variable "score".
        set {
            score = value; //Asigna el valor que manda a la propiedad de nuestra variable "score".
            if(score % 1000 == 0) { //Cada que el score (puntaje) se incremente de mil en mil puntos, haremos que suceda lo que esta dentro de este bloque de codigo:
                difficulty++;//Esto es lo que sucedera, la difulcatad incrementara de uno en uno (eso es lo que significa "++").
            }//🎈Talvez te preguntes, cada cuando incrementara el puntaje, es decir, cada cuando se usara este bloque de codigo. Bueno, para ello vamos al archivo "enemy.cs" en el bloque de codigo Funcion "TakeDamage()"
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // "this" es una palabra clave que contiene toda la informacion de la clase en la que estamos trabajando, en este caso la variable "gameManager"
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownRoutine()); //esto es un contador de tiempo (la intencion es inicializarlo al comenzar el juego, por esto esta en un "private void Start")
    }
    IEnumerator CountdownRoutine()//dentro de este bloque debemos insertar un tiempo de espera
    {
        while(time > 0)//Con este "while" nos aseguraremos que la partida solo dure 30 segundos (porque 30 segundos es lo que tenemos en el la variable "int time")
        {
            yield return new WaitForSeconds(1);//con esta linea de codigo obligamos que ese ciclo "while" tarde un segundo en ejecutarse completamente, antes de seguir con su ciclo (hasta que llegue a cero y entonces el ciclo terminara).
            time --; //esta linea de codigo significa algo como decir ' "time" menos uno'
        }
    }
}
