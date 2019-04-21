using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 10.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        // Move the cursor
        Vector3 pos = transform.position;
        // Returns a float from -1.0 to 1.0
        pos.x += maxSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        pos.y += maxSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position = pos;
    }
}
