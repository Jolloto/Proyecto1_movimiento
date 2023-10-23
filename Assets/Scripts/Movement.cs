using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lateralspeed;

    [SerializeField] private Vector3 offset = new Vector3(x:0, y:5, z:-10);
    

    private float horizontalInput;
    private float verticalInput;

       void Update()
    {
        //La detecci�n de inputs debe ir en el Update
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);


        // Recomendaci�n si trabajamos con direcciones, que sean vector
        // Vector3.right se corresponde con (1, 0, 0)
        // Vector3.left se corresponde con (-1, 0, 0)
        // Vector3.up se corresponde con (0, 1, 0)
        // Vector3.down se corresponde con (0, -1, 0)
        // Vector3.forward se corresponde con (0, 0, 1)
        // Vector3.back se corresponde con (0, 0, -1)

        // Movimiento en funci�n del sistema de coordenadas local (el del objeto)
        // Movimiento hacia adelante autom�tico
        //transform.Translate(translation:Vector3.forward * speed * Time.deltaTime);

        // Movimiento hacia adelante afectado por el input del usuario (vertical)
        transform.Translate(translation:Vector3.forward * speed * Time.deltaTime);

        // Movimiento lateral afectado por el input
        transform.Translate(translation:Vector3.right * lateralspeed * Time.deltaTime * horizontalInput);
    }
}
