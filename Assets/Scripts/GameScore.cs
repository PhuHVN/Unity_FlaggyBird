using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public BirdHaviour bird;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject welcomeGame;
    public Transform birdPos;
    private int score = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        StartUI();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = $"Score: {score}";
        playButton.SetActive(false);
        gameOver.SetActive(false);
        welcomeGame.SetActive(false);
        Time.timeScale = 1;

        bird.enabled = true;
        bird.transform.position = birdPos.position;
        //bird.transform.rotation = Quaternion.identity;
        bird.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;


        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }
    void StartUI()
    {

        welcomeGame.SetActive(true);
        playButton.SetActive(true);
        
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
    }
    public void GameOver()
    {
        welcomeGame.SetActive(false);
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
