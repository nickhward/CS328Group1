using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Rigidbody rb;
    private float angle;
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(this.transform.position.x - player.transform.position.x, this.transform.position.y - player.transform.position.y, this.transform.position.z - player.transform.position.z);
        rb = player.GetComponent<Rigidbody>();
        startRotation = this.transform.rotation;
        angle = startRotation.eulerAngles.x;
        Debug.Log(angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.Contact())
        {
            Vector3 newOffset = new Vector3(5.0f, offset.y, -5.0f);
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + 1.4f * newOffset, Time.deltaTime * 2f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(10f, 355f, 0f), Time.deltaTime * 2f);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + 1.4f * offset, Time.deltaTime * 3f);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, startRotation, Time.deltaTime * 10f);
        }
        //Quaternion playerDirection = Quaternion.AngleAxis(,(1,0,0))
        //new Quaternion(-1 * angle, 0, 0)
        //this.transform.RoRotate(-Vector3.Angle(rb.velocity, new Vector3(-1, 0, 0)), 0,0);
    }
}
