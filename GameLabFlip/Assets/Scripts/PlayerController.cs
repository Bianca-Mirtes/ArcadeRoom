using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxisRaw("Mouse X");
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 90f * mouseX * Time.deltaTime, 0));
    }
}
