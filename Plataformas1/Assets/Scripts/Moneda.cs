using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    //Audio Source
    private AudioSource _fuenteDeAudio;
    //Clips de Audio
    public AudioClip SonidoMoneda;
    // Start is called before the first frame update
    void Start()
    {
        _fuenteDeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        // si me toca el Player
        if (colision.gameObject.name == "Player")
        {
            
            //Hacer desaparecer la moneda
            Destroy(gameObject, .2f);
            //Emitir el sonido Moneda
            _fuenteDeAudio.clip = SonidoMoneda;
            _fuenteDeAudio.Play();
        }
    }
}
