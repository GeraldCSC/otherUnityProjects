using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        this.count = 0;
        rb = GetComponent<Rigidbody>();
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupObject"))
        {
            other.gameObject.SetActive(false);
            this.count++;
            countText.text = "Count: " + count.ToString();
            if (count== 6)
            {
                this.winText.text = "you win";
            }
        }
    }
}
