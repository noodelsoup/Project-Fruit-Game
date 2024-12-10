using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float collectionTime = 5.0f;   // Specific collection time for this item

    private float timer;

    [SerializeField] int itemScore; // the amount of score collecting a specific item gives
    [SerializeField] float itemTime;// the extra time granted by collecting a clock
    UiManager uiManager;

    private void Start()
    {
        timer = collectionTime;   // Set the timer to the item's collection time
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);   // Destroy item if collection time is up
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Add custom logic for item collection, like adding points or effects
        Debug.Log("Item collected!");
        uiManager.score += itemScore;   // adds item score to the Ui score
        uiManager.time += itemTime;     //adds time from clock to timer

        // Destroy item upon collection
        Destroy(gameObject);
    }
}
