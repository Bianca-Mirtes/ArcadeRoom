using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 3;

    private bool UIOpen = false;
    private float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        rig = GetComponent<Rigidbody>();
    }

    public void setUIOpen(bool value)
    {
        UIOpen = value;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (UIOpen)
        {
            mouseX = 0f;
        }
        else
        {
            mouseX = Input.GetAxisRaw("Mouse X");
        }
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 90f * mouseX * Time.deltaTime, 0));
    }
}
