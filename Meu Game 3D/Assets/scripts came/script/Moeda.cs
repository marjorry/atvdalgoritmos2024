using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Moeda : MonoBehaviour
 
{
public int velocidadeGiro = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().SubtrairMoedas();
            Destroy(gameObject);
        }
    }
    
void Update()
    { 
        transform.Rotate(Vector3.forward * velocidadeGiro * Time.deltaTime);
    }
}
