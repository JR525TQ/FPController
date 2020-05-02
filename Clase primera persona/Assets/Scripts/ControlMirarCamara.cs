using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMirarCamara : MonoBehaviour
{

    public float sensibilidad;

    public float suavizado = 2.0f;

    Vector2 mouseMirar;
    Vector2 suavidadV;

    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = this.transform.parent.gameObject;        
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado);

        mouseMirar += suavidadV;

        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
        jugador.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, jugador.transform.up);

        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f);
    }
}
