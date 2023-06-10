using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform posGun;
    public GameObject bullet;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.M))
        {
            var bullets = Instantiate(bullet, posGun.position, Quaternion.identity);
            var rb = bullets.GetComponent<Rigidbody>();
            rb.AddForce(posGun.transform.forward*force,ForceMode.Impulse);
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Weapon")){
            transform.position = new Vector3(0.129999995f, 1.40199995f, 5.75f);
        }
    }
}
