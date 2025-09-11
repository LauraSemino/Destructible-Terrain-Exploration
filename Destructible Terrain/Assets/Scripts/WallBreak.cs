using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class WallBreak : MonoBehaviour
{
    public Ray mouseRay;
    public Vector3 contactPoint;
    public Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
           // Debug.Log("clicked");
            RaycastHit hit;
            if(Physics.Raycast(transform.position, mouseRay.direction, out hit))
            {
                if(hit.collider != null)
                {
                    Debug.Log(hit.ToString());
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddForce((hit.point - transform.position).normalized * 4, ForceMode.Impulse);

                }
                
            }
           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync("wallTest");
            SceneManager.LoadScene("wallTest", LoadSceneMode.Single);            
        }


    }

    
}
