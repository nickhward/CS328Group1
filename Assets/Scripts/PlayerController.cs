using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Material hitMaterial;

    public GameObject cube;

    private Rigidbody rb;

    private bool launched;
    private bool madeContact;

    private float movementX;
    private float movementY;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GenerateCubes(9);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnLaunch()
    {
        launched = true;
        Debug.Log("launched");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            GameManager.Instance.SetContact(true);
            Debug.Log("madecontact");
            collision.gameObject.GetComponent<MeshRenderer>().material = hitMaterial;
        }
    }

    //my Functions
    private void NextTurn()
    {
        GameManager.Instance.SetContact(false);
        launched = false;
        rb.velocity = new Vector3(0f,0f,0f);
        this.transform.position = startPos;
    }

    private void GenerateCubes(int n)
    {
        for (int k = 0; k < n; k++)
        {
            float offCeneter = 1.1f * (n - k) / 2f;
            for (int i = 0; i < n - k; i++)
            {
                if ((n-k) % 2 == 0)
                {
                    Instantiate(cube, new Vector3((i * 1.1f) - offCeneter, .505f + 1.1f * k, -2f), Quaternion.identity);
                }
                else
                {
                    Instantiate(cube, new Vector3((i * 1.1f) - offCeneter, .505f + 1.1f * k, -2f), Quaternion.identity);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!launched)
        {
            this.rb.velocity = Vector3.zero;
            this.transform.position = startPos;
        }
        else
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            rb.AddForce(-1f * movement * speed * Time.fixedDeltaTime);

            if (this.transform.position.y < 0)
            {
                NextTurn();
            }
        }
    }
}
