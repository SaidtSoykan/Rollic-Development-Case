using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBall : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Collector") && rb.isKinematic == true) {
            rb.isKinematic = false;
        }
        if(other.transform.CompareTag("BallCleaner")) {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.CompareTag("Collector") && rb.isKinematic == true) {
            rb.isKinematic = false;
        }
    }
}
