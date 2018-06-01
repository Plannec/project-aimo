using UnityEngine;

public class CamaraFollow : MonoBehaviour {

    public Transform player;

    public float smoothLevel = .15f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0)
        {
            Vector3 normalPos = player.position + offset+new Vector3(0,0,-4);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, normalPos, smoothLevel * 100 * Time.deltaTime);
            transform.position = smoothedPos;
        } else
        {
            Vector3 normalPos = player.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, normalPos, smoothLevel * 100 * Time.deltaTime);
            transform.position = smoothedPos;
        }
        
    }

}
