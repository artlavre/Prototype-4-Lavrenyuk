using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody rb;
    private GameObject focalPoint;

    public GameObject restart;

    public bool hasPowerup;
    private float powerupStrength = 15;
    public GameObject powerupIndicator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * forwardInput * speed );
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f,0);
        if(transform.position.y <= -2)
        {
            restart.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpcountDown());
        }

    }

    IEnumerator PowerUpcountDown()
    {
        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Boll");

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            
        }
    }
}
