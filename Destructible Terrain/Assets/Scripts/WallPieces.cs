using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallPieces : MonoBehaviour
{

    public bool isBroken;
    public bool isGrounded;
    public float curStrength;
    public float maxStrength;
    float minAdjacentStrength;
    public List<GameObject> contactWith;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBroken = false;
        
       minAdjacentStrength = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (GameObject w in contactWith)
        {
            if (w.name == "Ground" && isBroken == false)
            {             
                curStrength = 0f;
                isGrounded = true;

            }
            else if(w.GetComponent<WallPieces>() != null)
            {
                if (w.GetComponent<WallPieces>().curStrength < minAdjacentStrength)
                {
                   minAdjacentStrength = w.GetComponent<WallPieces>().curStrength;
                   curStrength = minAdjacentStrength + 1;
                }
            }
           
        }
      
        


        if (curStrength >= maxStrength)
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
