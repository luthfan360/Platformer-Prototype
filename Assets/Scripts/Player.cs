using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float gravity = 0.25f;
    [SerializeField]
    float jumpHeight = 15;
    [SerializeField]
    float yVelocity;
    [SerializeField]
    int lives = 3;
    int coins = 0;
    UIManager UIManager;
    bool canDoubleJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(XInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump == true)
            {
                yVelocity += jumpHeight;
                canDoubleJump = false;
            }
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    public void addCoin()
    {
        coins++ ;
        UIManager.UpdateCoins(coins);
    }

    public void damaged()
    {
        lives-- ;
        UIManager.UpdateLives(lives);

        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
