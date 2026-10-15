using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdsScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float FlapStrength;

    public LogicScript logic;

    public bool BirdIsAlive = true;

    public int DeadZone = 40;

    // Start is for any code that will run as soon as this script is enabled and it runs precisely once.
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    // Update runs constantly while the script is enabled.
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && BirdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * FlapStrength; 
        }
        /*
        if (Mathf.Abs(transform.position.y) > DeadZone)
        {
            BirdIsAlive = false;
            logic.GameOver();
        }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        if (BirdIsAlive)
        {
            BirdIsAlive = false;
            logic.GameOver();
        }
    }
}
