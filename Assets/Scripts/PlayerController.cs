using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D rb2D;
    private int count;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        count = 10;
        SetCountText(count);

        winText.text = "";
    }

    void SetCountText(int count)
    {
        countText.text = "Gems left to pick up: " + count.ToString();

        if(count == 0)
        {
            winText.text = "You Win !!!";
            countText.text = "";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2D.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count--;
            SetCountText(count);
        }
    }
}
