using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidad a la que se va a mover el jugador
    public float velocidad = 2.5f;
    // Referencias
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    //Movimiento
    private Vector2 _movimiento;


    private void Awake()
    {
        // Cogemos las referencias
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // si pulsamos izquierda o derecha....
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movimiento = new Vector2(horizontalInput, 0f);

    }
    //Es para mover cualquier objeto enUnity
    private void FixedUpdate()
    {
        float horizontalVelocity = _movimiento.normalized.x * velocidad;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    // Donde metemos el codigo de las animaciones
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movimiento == Vector2.zero);
    }
}
