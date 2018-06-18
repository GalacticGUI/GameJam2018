using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour {

    public Camera camera;
    private Vector2 pos;
	
	// Update is called once per frame
	void Update () {
        pos.x = camera.transform.position.x;
        pos.y = camera.transform.position.y;
        transform.position = pos;
	}
}
