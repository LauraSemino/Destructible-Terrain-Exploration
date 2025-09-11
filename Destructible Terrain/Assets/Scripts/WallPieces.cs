using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WallPieces : MonoBehaviour
{

    public bool isBroken;
    public bool isGrounded;
    public bool isConnected;
    public List<GameObject> contactWith;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBroken = false;
        isGrounded = false;
        isConnected = true;

    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject w in contactWith)
        {
            if (w.name == "Ground" && isBroken == false)
            {
                isGrounded = true;
            }
            if (GetComponent<WallPieces>().isGrounded == true)
            {
                isConnected = true;
            }
          
        }

        if(isConnected == false)
        { 
            isBroken = true;
        }
        if(contactWith.Count <= 0)
        {
            isBroken = true;
        }
        if (isBroken)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        contactWith.Add(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        contactWith.Remove(collision.gameObject);
    }
}
