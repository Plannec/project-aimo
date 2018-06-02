using UnityEngine;

public class CamaraFollow : MonoBehaviour {

    public Transform player;

    private Rigidbody2D rb;
    private Camera cam;

    public float smoothLevel = .15f;
    public Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        // Forward/Backward
        Vector3 normalPos;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0) normalPos = player.position + offset + new Vector3(0, 0, -4);
        else normalPos = player.position + offset;

        // Up/Down
        if (Input.GetAxis("Vertical") > 0) normalPos = player.position + offset + new Vector3(0, 4, 0);
        else if(Input.GetAxis("Vertical") < 0) normalPos = player.position + offset + new Vector3(0, -4, 0);

        // Perform motion
        Vector3 smoothedPos = Vector3.Lerp(transform.position, normalPos, smoothLevel * 100 * Time.deltaTime);
        transform.position = smoothedPos;
    }

}
