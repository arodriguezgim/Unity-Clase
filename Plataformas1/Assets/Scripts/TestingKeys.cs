using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1.- Obtener eventos del raton
        // 0 - Boton izquierdo
        // 1 - Boton derecho
        // 2 - Boton Central
        if ( Input.GetMouseButtonDown(0) )
        {
            Debug.Log("Podemos usar este evento para lanzar ataque");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Esto es cuando el boton etá pulsado");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Acabo de SOLTAR el boton");
        }
        // 2.- Obtener eventos del teclado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Este sera el boton de SALTAR");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Usando GetButtonDOWN tambien responde");
        }
        // 3.- Obtener los ejes en el movimiento
        float horizontal = Input.GetAxis("Horizontal"); //Van de -1f a 1f
        float vertical = Input.GetAxis("Vertical");

        if ( horizontal < 0f || horizontal > 0f)
        {
            Debug.Log("El valor del eje horizontal es:" + horizontal);
        }
        if (vertical < 0f || vertical > 0f)
        {
            Debug.Log("El valor del eje vertical es:" + vertical);
        }
    }






}
