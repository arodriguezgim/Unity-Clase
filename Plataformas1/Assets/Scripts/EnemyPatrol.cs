using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public float speed = 1f; //velocidad del enemigo
	public float minX;
	public float maxX;
	public float waitingTime = 2f;  //tiempo de Espera que el enemigo usará una vez alcanzado el objetivo

	private GameObject _target;
	// Referencia al componente Animate
	private Animator _animator;

    private void Awake()
    {
		_animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
	{
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}

	// Update is called once per frame
	void Update()
	{

	}


	private void UpdateTarget()
	{
		// Si es la primera vez, crea un objeto target en el escenario con esta posicion
		if (_target == null)
		{
			_target = new GameObject("Target");
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
			return;  //no devuelvo nada para que NO EJECUTE EL RESTO
		}

		// Si la posicion del target esta en el izquierda, muevemo a la derecha
		if (_target.transform.position.x == minX)
		{
			_target.transform.position = new Vector2(maxX, transform.position.y);
			transform.localScale = new Vector3(1, 1, 1);
		}

		// If we are in the right, change target to the left
		else if (_target.transform.position.x == maxX)
		{
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	private IEnumerator PatrolToTarget()
	{
		// Corrutina que mueve el enemigo
		while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
		{
			//El enemigo está andando
			_animator.SetBool("Idle", false);
			// El enemiggo se mueve hacia el target. Mientras no haya llegado al target...
			Vector2 direction = _target.transform.position - transform.position;
			//como solo me interesa saber si voy hacia la derecha o la izquierda...
			float xDirection = direction.x;

			transform.Translate(direction.normalized * speed * Time.deltaTime);

			// IMPORTANTE: Aqui decimos un tipo especial de devolucion. Que no siga adelante.
			yield return null;
		}

		// Aqui he alcanzado el target, mi posicion es la x del target
		Debug.Log("Target alcanzado");
		//Aqui el enemigo estará quieto
		_animator.SetBool("Idle", true);
		transform.position = new Vector2(_target.transform.position.x, transform.position.y);
		//Vamos a esperar un momento.
		// A partir de ahora no hagas nada pero te doy un tiempo para que vuelvas a ejecutarte
		Debug.Log("Esperando " + waitingTime + " segundos");
		yield return new WaitForSeconds(waitingTime); // IMPORTANTE

		// Volvemos a actualizar el target
		Debug.Log("Actualizamos de nuevo el target y nos movemos de nuevo");
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}
}