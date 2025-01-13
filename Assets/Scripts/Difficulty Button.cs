using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gameManager;
    Button difficultyButton;
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
        gameManager.StartGame();
        Debug.Log(gameObject.name + " was clicked.");
        FindFirstObjectByType<GameManager>().spawnRate = new Vector2(0, 1);
    }
}
