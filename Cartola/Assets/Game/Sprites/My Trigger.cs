using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyTrigger : MonoBehaviour
{
    private GameController gameController;

    [System.Obsolete]

    private UIController uIController;

    [System.Obsolete]
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        uIController = FindObjectOfType<UIController>();
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Point"))
        {
            gameController.score++;
            uIController.txtScore.text = gameController.score.ToString();
            Destroy(this.gameObject);
        }
    }
}
