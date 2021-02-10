using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public Vector2 direccion; // marcamos hacia donde se mueve la bala
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento = direccion.normalized * velocidad * Time.deltaTime;

        //transform.position = new Vector2(transform.position.x + movimiento.x, transform.position.y + movimiento.y);
        transform.Translate(movimiento);
    }
}
