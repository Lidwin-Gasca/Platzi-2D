using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int health = 1;
    float mov_horizontal;
    float mov_vertical;
    Vector3 moveDirection;
    public float speed = 3;
    [SerializeField] Transform aim;
    [SerializeField] Camera camera;
    Vector2 facingDirection;
    [SerializeField] Transform bulletPrefab;
    bool gunLoaded = true;
    bool powerShotEnabled = true;
    [SerializeField] float fireRate = 1;
    [SerializeField] bool invulnerable;
    [SerializeField] int invulnerableTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //declarando variables
        mov_horizontal = Input.GetAxis("Horizontal");
        mov_vertical = Input.GetAxis("Vertical");
        moveDirection.x = mov_horizontal;
        moveDirection.y = mov_vertical;

        //velocidad del personaje
        transform.position += moveDirection * Time.deltaTime * speed;
        
        // Aim movment:
        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        aim.position = transform.position + (Vector3)facingDirection.normalized; 

        //Codigo de la bala
        if(Input.GetMouseButton(0) && gunLoaded) {//El cero "0" equivale al click izquierdo del raton.
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg; //esta variable se crea para que la bala salga disparado hacia la direccion del mouse.
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward); //con esta linea de codigo haces que funcione la variable "angle".
            Transform bulletClone = Instantiate(bulletPrefab, transform.position, targetRotation); //Esta Instancia, crea eso, instancias, crea balas, y los parametros indican hacia donde se dirijen.  
            if (powerShotEnabled)// esto significa: "if (powerShotEnabled == true)"
            {
                bulletClone.GetComponent<bullet>().powerShot = true;//GetComponent significa Obtener Componente, se usa para llamar a otro archivo .cs, y usar variables publicas de ese archivo script.
            }
            StartCoroutine(ReloadGun());
        }
        // if(Input.GetMouseButton(0) == false){  //con este "if" declaro que cuando sueltas el click izquierdo tu variable arma cargada "gunLoaded" sea verdadero de nuevo "true", es decir puedes vovler a disparar una vez dejes de presionar el click izquierdo.
        //         gunLoaded = true;
        // }
    }
///////El siguiente bloque de codigo es para usar la ultima linea de codigo en "Codigo de Bala" el que empieza: StartCoroutine(ReloadGun()); este es mesjor que el if que use para recargar el arma.
         IEnumerator ReloadGun(){
             yield return new WaitForSeconds(1 / fireRate);
             gunLoaded = true;
         }
        //Metodo de daño
    public void TakeDamage()
    {
        if (invulnerable)
            return;
        health --;//hace que baje la salud del jugador
        invulnerable = true;
        StartCoroutine(MakeVulnerableAgain());
        if (health <= 0)// si la salud llega a cero, hacemos que se muera
        {
            //Destroy(gameObject); //se muere
        }
    }
    IEnumerator MakeVulnerableAgain(){
        yield return new WaitForSeconds(invulnerableTime);
        invulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)//esto es creado para interactuar con los power ups
    {
        if (collision.CompareTag("powerUp"))
        {
            switch (collision.GetComponent<powerUp>().powerUpType)
            {
                case powerUp.PowerUpType.FireRateIncrease:
                    fireRate++;//Incrementar cadencia de disparo
                    break;
                case powerUp.PowerUpType.PowerShot:
                    powerShotEnabled = true;//Activar el power shot
                    break;
            }
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
