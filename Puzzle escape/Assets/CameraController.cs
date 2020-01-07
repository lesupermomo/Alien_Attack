using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 20f;
    public float panBoarderThickness = 10f;
    public Vector2 panLimit;
    public Vector2 panLimit2;
    public float scrollSpeed = 20f;
    public float minY=20f;
    public float maxY = 12000f;

    public float posx;
    public float posy;
    public float posz;

    void Start()
    {
        transform.position = transform.position;   
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height - panBoarderThickness))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || (Input.mousePosition.y <= panBoarderThickness))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || (Input.mousePosition.x >= Screen.width - panBoarderThickness))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || (Input.mousePosition.x <= panBoarderThickness))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        
        pos.x = Mathf.Clamp(pos.x, -panLimit2.x, panLimit.x);
        pos.z= Mathf.Clamp(pos.z, -panLimit2.y, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;
        posx = transform.position.x;
        posy = transform.position.y;
        posz = transform.position.z;
}
}
