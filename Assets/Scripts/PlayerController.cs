using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject pauseTextObject;
    public GameObject PlayerSphere;
    public static bool gameIsPaused;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    float size = KeepData.passSize;
    int colorSelected = KeepData.PlayerColor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count= 0;
        speed = KeepData.playerSpeed;

        SetCountText();
        winTextObject.SetActive(false);
        pauseTextObject.SetActive(false);

        switch (colorSelected)
        {
            case 0:
                PlayerSphere.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 1:
                PlayerSphere.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                PlayerSphere.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                PlayerSphere.GetComponent<Renderer>().material.color = Color.black;
                break;
        }

        PlayerSphere.transform.localScale = new Vector3(size, size, size);
        PlayerSphere.transform.localPosition = new Vector3(PlayerSphere.transform.localPosition.x, 0.5f * size, PlayerSphere.transform.localPosition.z);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) 
        {
            winTextObject.SetActive(true);

            Invoke("Won", 5.0f);
        }
    }

    //PlayerMovement
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    //Pausing the Game
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseTextObject.SetActive(true);
        }
        else
        {
            pauseTextObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //Pausing code ends here


    void Won()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}