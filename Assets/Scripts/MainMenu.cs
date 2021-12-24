using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public TextMesh[] texts = new TextMesh[3];
    private int userChoice;
    private AudioSource buttonSound;
    public GameObject story, helpMsg;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        userChoice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentOption();
        colorizeOption();
        chooseOption();
    }
    void currentOption()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            userChoice++;
            buttonSound.Play();
            helpMsg.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            userChoice--;
            buttonSound.Play();
            helpMsg.SetActive(false);
        }

        if (userChoice == texts.Length)
            userChoice = 0;
        else if (userChoice < 0)
            userChoice = texts.Length - 1;

    }

    void colorizeOption()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if (i == userChoice)
                texts[i].color = Color.red;
            else
                texts[i].color = Color.white;
        }
    }

    void chooseOption()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttonSound.Play();
            switch (userChoice)
            {
                case 0:
                    {
                        story.SetActive(true);
                        break;
                    }
                case 1:
                    {
                        helpMsg.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        Application.Quit();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
