using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuCharacterController : MonoBehaviour
{
    Quaternion originalRotation;
    public Animator anim;
    float mouseX;
    float mouseSens = 10;
    public Camera cam;
    public bool Tur;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        anim = this.GetComponent<Animator>();
        if(Tur == true)
        {
            anim.SetBool("GO", true);
            anim.SetBool("STOP", false);
        }
    }

    private void Update()
    {
        transform.localPosition = new Vector3(0, 0.5f, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(0, 0.5f, 0);
        if (Input.GetMouseButton(0))
        {
            mouseX -= Input.GetAxis("Mouse X") * mouseSens;
            Quaternion rotarionY = Quaternion.AngleAxis(mouseX, Vector3.up);
            transform.rotation = originalRotation * rotarionY;
        }
        if (cam.orthographicSize >= 1.1)
        cam.orthographicSize -= Time.deltaTime/((2f-cam.orthographicSize)*100f);
    }
}
