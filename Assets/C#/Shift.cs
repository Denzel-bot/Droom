using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shift : MonoBehaviour
{
    Button BuyNow;
    Button Remove;


    private void Awake()
    {
        BuyNow = transform.GetChild(0).GetComponent<Button>();
        Remove = transform.GetChild(1).GetComponent<Button>();

        BuyNow.onClick.AddListener(StartGame);
        Remove.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
