using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //[SerializeField] private GameObject camera;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lateralspeed = 5f;
    private int lives;
    private bool isGameOver;
    private Vector3 initialPosition;
    private UIManager uiManager;
    

    //[SerializeField] private Vector3 offset = new Vector3(0, 5, -10);


    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        lives = 3;
        isGameOver = false;
        initialPosition = Vector3.zero;
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideGameOverPanel();
    }
    void Update()
    {
        //La detección de inputs debe ir en el Update
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (transform.position.y < -3)
        {
            lives--;
            uiManager.UpdateLiveText(lives);
            

            if (lives == 0)
            {
                
               
                isGameOver = true;
                uiManager.ShowGameOverPanel(lives);
            }
            else
            {
                transform.rotation = Quaternion.identity;
                transform.position = initialPosition;
            }
        }
       


       

        // Movimiento hacia adelante afectado por el input del usuario (vertical)
        transform.Translate(translation:Vector3.forward * speed * Time.deltaTime * verticalInput);

        transform.Rotate(Vector3.up, lateralspeed * Time.deltaTime * horizontalInput);


        // Recomendación si trabajamos con direcciones, que sean vector
        // Vector3.right se corresponde con (1, 0, 0)
        // Vector3.left se corresponde con (-1, 0, 0)
        // Vector3.up se corresponde con (0, 1, 0)
        // Vector3.down se corresponde con (0, -1, 0)
        // Vector3.forward se corresponde con (0, 0, 1)
        // Vector3.back se corresponde con (0, 0, -1)

        // Movimiento en función del sistema de coordenadas local (el del objeto)
        // Movimiento hacia adelante automático
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Movimiento lateral afectado por el input del usuario (horizontal)
        // transform.Translate(Vector3.right * lateralspeed * Time.deltaTime * horizontalInput);

        // camera.transform.position = transform.position + offset;
    }

    public void Restart() 
    {
        SceneManager.LoadScene("Prototype 1");
    }
}
