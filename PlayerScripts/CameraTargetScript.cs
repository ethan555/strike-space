using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    public Transform cursor;
    public Transform target;
    public float speed = 0.5f;
    public float panSpeed = 10.0f;

    // Update is called once per frame
    void Update() {
        // If there is a target, move to between the target and the cursor
        if (target != null) {
            Vector3 tPos = target.position;
            Vector3 curPos = cursor.position;
            Vector3 cPos = transform.position;
            Vector3 destPos = target.position;
            Vector3 mPos = Input.mousePosition;
            destPos.x = (tPos.x + curPos.x)/2;
            destPos.y = (tPos.y + curPos.y)/2;
            cPos.x = Mathf.Lerp(cPos.x, destPos.x, speed);
            cPos.y = Mathf.Lerp(cPos.y, destPos.y, speed);
            transform.position = cPos;
        } else {
            // Otherwise, just move by control and by cursor
            Vector3 curPos = cursor.position;
            Vector3 cPos = transform.position;
            Vector3 v0Pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 v1Pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            // cPos.x = Mathf.Lerp(cPos.x, curPos.x, speed);
            // cPos.y = Mathf.Lerp(cPos.y, curPos.y, speed);
            // transform.position = cPos;
            cPos.x += Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
            cPos.y += Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;

            if (curPos.x <= v0Pos.x || curPos.x >= v1Pos.x) {// < screenSize.x/4 || mPos.x > 3*screenSize.x/4) {
                cPos.x += Mathf.Sign(curPos.x - v0Pos.x - 1) * panSpeed * Time.deltaTime;//Mathf.Clamp(mPos.x - screenSize.x/2,// - mouse_pos.x,-mouseSpeed, mouseSpeed);
            }
            if (curPos.y <= v0Pos.y || curPos.y >= v1Pos.y) {//  < screenSize.y/4 || mPos.y > 3*screenSize.y/4) {
                cPos.y += Mathf.Sign(curPos.y - v0Pos.y - 1) * panSpeed * Time.deltaTime;//Mathf.Clamp(mPos.y - screenSize.y/2,// - mouse_pos.y, -mouseSpeed, mouseSpeed);
            }
            transform.position = cPos;
        }
    }
}
