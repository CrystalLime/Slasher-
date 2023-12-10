using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private int damage = 10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HealthSystem healthSystem;

            if(collision.gameObject.TryGetComponent<HealthSystem>(out healthSystem))
            {
                
            collision.gameObject.GetComponent <HealthSystem>();
            healthSystem.ChangeHealth(-damage);
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
