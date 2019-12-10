using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 direction = Vector2.right;

    // Keep Track of Tail
    List<Transform> tail = new List<Transform>();

    // Did the snake eat something?
    bool ate = false;

    // Tail Prefab
    public GameObject tailPrefab;

    public KeyCode left;
    public KeyCode right;
    public KeyCode toUp;
    public KeyCode downx;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("Move", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update() {
        // Move in a new Direction?
        if (Input.GetKey(right))
            direction = Vector2.right;
        else if (Input.GetKey(downx))
            direction = Vector2.down;
        else if (Input.GetKey(left))
            direction = Vector2.left;
        else if (Input.GetKey(toUp))
            direction = Vector2.up;
    }

    void Move() {
        if(GameController.isPaused) return;

        // Save current position (gap will be here)
        Vector2 lastHeadPosition = transform.position;

        // Move head into new direction
        transform.Translate(direction);

        // Ate something? Then insert new Element into gap
        if (ate) {
            // Load Prefab into the world
            GameObject snakeApp = (GameObject)Instantiate(tailPrefab, lastHeadPosition, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, snakeApp.transform);

            // Reset the flag
            ate = false;
        }

        // Do we have a Tail?
        if (tail.Count > 0) {
            // Move last Tail Element to where the Head was
            tail.Last().position = lastHeadPosition;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // Food?
        if (collider.name.StartsWith("FoodPrefab")) {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(collider.gameObject);
        }
        // Collided with Tail or Border
        else  if(collider.tag.Contains("Border")){
            // To Do "Your Lose" screen
            GameController.FailGame();
        }
	}
}
