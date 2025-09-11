using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject rotatePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rotatePoint.transform.eulerAngles += new Vector3(0, 50,0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotatePoint.transform.eulerAngles += new Vector3(0, -50, 0) * Time.deltaTime;
        }
    }
}
