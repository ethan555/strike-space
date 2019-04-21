using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{

    public float maxSpeed = 10.0f;
    public float mouseSpeed = 10.0f;
    public float rotateSpeed = 1.0f;
    public Transform target = null;
    public float aimDist = 1.0f;

    Vector3 mouse_pos = new Vector3(0.0f,0.0f,0.0f);

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        Vector3 screenSize = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 mPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 trueMPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // If there is no target, then freecam
        if (target == null) {
            // Move the cursor
            // Returns a float from -1.0 to 1.0
            pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
            pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
            
            pos.x = trueMPos.x;//mPos.x;
            pos.y = trueMPos.y;//mPos.y;

            transform.position = pos;
        } else {
            // If there is a target, then cannot move too far away
            // Move the cursor
            Vector3 tPos = target.position;
            mPos = mPos - screenSize/2;
            // Returns a float from -1.0 to 1.0
            /*pos.x += maxSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            pos.y += maxSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            
            pos.x += Mathf.Clamp((mPos.x - mouse_pos.x),
                -mouseSpeed, mouseSpeed);
            pos.y += Mathf.Clamp((mPos.y - mouse_pos.y),
                -mouseSpeed, mouseSpeed);
            mouse_pos.x = mPos.x;
            mouse_pos.y = mPos.y;*/

            Vector3 angle = new Vector3(pos.x - tPos.x, pos.y - tPos.y, 0);//direction;

            //angle = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime) * angle;
            angle = mPos - tPos;
            //if (angle.magnitude > aimDist) {
            angle = angle.normalized * aimDist;
            //}

            transform.position = tPos + angle;
        }
    }
}
