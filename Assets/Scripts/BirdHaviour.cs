using UnityEngine;
using UnityEngine.InputSystem;

public class BirdHaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _rb.linearVelocity = Vector2.up * _velocity; 
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle" )
        {
            Object.FindAnyObjectByType<GameScore>().GameOver(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Object.FindAnyObjectByType<GameScore>().GameOver();
        }

        if (collision.gameObject.tag == "Scoring")
        {
            Object.FindAnyObjectByType<GameScore>().IncreaseScore();
        }
    }
}
