using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HatMoviment : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameController gameController;


    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        Dragtouch();

    }

    private void Dragtouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);

        }
    }
}
