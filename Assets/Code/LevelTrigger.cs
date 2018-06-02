using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

    public Camera cam;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player")
        {
            cam.backgroundColor = Color.Lerp(Color.grey, Color.green, 5f);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            cam.backgroundColor = Color.Lerp(Color.green, Color.grey, 5f);
        }
    }
}
