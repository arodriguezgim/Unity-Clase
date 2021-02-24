using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidad a la que se va a mover el jugador
    public float velocidad = 2.5f;
    public float fuerzaSalto = 2.5f;
    // Controlo si estoy en el suelo
    public Transform groundCheck; //desde donde haremos el chequeo del suelo
    public LayerMask groundLayer;// seleccionaremos qué layer es el suelo
    public float groundCheckRadius;
    // Referencias
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    //Movimiento
    private Vector2 _movimiento;
    private bool _facingRight = true;
    private bool _enSuelo;



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

        // Controlamos hacia donde mira el personaje
        if ( horizontalInput < 0f && _facingRight == true)
        {
            Flip();
        } else if ( horizontalInput > 0f && _facingRight == false )
        {
            Flip();
        }

        //Está el personaje en el suelo?
        _enSuelo = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Controlamos el Salto
        if (Input.GetButtonDown("Jump") && _enSuelo == true)
        {
            _rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    //Es para mover cualquier objeto en Unity
    private void FixedUpdate()
    {
        float horizontalVelocity = _movimiento.normalized.x * velocidad;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    // Donde metemos el codigo de las animaciones
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movimiento == Vector2.zero);
        _animator.SetBool("enSuelo", _enSuelo);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
