using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiros : MonoBehaviour
{
    private float maxTiros = 10f;
    private float tiros;
    private Text tirosText;
    [SerializeField] private GameOver menuGameOver;

    void Start()
    {
        tiros = maxTiros; // Initialize
        tirosText = GetComponent<Text>();
    }

    void Update()
    {

        // Show fuel as a percentage
        tirosText.text = tiros.ToString();

    }
    public void UseTiros(float amount)
    {
        tiros -= amount;
        if (tiros <= 0)
        {
            menuGameOver.ActivateGameOver();
        }
    }
    public void Restore(float amout)
    {
        tiros += maxTiros;
    }
}
