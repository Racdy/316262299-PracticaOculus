using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform posGun;
    public GameObject bullet;
    public float force;

    private float timer;
    public Text textTimer;
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

        if (timer <= 0)
        {
            transform.position = new Vector3(0.129999995f, 1.40199995f, 5.75f);
            timer = 60;
        }
        else
        {
            timer -= Time.deltaTime;
            textTimer.text = "" + timer.ToString("f2");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Weapon")){
            transform.position = new Vector3(0.129999995f, 1.40199995f, 5.75f);
        }
    }
}
