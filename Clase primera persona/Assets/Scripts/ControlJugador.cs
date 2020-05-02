using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [SerializeField]
    private float rapidezDesplazamiento = 10.0f;

    public Camera camaraPrimeraPersona;

    public float daño = 10.0f;
    public float rango = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoVertical = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoHorizontal = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoVertical *= Time.deltaTime;
        movimientoHorizontal *= Time.deltaTime;

        transform.Translate(movimientoHorizontal, 0, movimientoVertical);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        void Shoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(camaraPrimeraPersona.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0.5f)), out hit, rango))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
