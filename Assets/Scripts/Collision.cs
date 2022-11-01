using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exited");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Staying");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider Entered");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collider Exited");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collider Staying");
    }
}
