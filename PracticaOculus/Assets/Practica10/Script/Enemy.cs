using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent enemy;
    public bool persigue;
    public bool golpe;
    public bool muere;
    public Animator controleEnemy;

    private float distancia;
    private bool muerto;
    //public Transform 
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        enemy = GetComponent<NavMeshAgent>();
        enemy.destination = target.transform.position;
        muerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            distancia = Vector3.Distance(target.transform.position, this.transform.position);
            if (persigue)
            {
                enemy.destination = target.transform.position;
                controleEnemy.SetBool("persigue", persigue);
                controleEnemy.SetBool("golpe", false);
            }
            if (distancia < 2)
            {
                //controleEnemy.SetBool("persigue", false);
                this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                controleEnemy.SetBool("golpe", golpe);
            }
        }
        else
        {
            enemy.destination = this.transform.position;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            muerto = true;
            print("DAÑO A ENEMIGO");
            controleEnemy.SetBool("persigue", false);
            controleEnemy.SetBool("golpe", false);
            controleEnemy.SetBool("muere", muere);
            Destroy(enemy.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+2f);
        }
    }
}
