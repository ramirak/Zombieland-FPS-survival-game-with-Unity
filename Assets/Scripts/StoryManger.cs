using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManger : MonoBehaviour
{

    public GameObject[] texts = new GameObject[5];
    public GameObject mainMenu;
    private int storyCounter = 0;
    private bool routineRunning = false, skip = false;

    private const float fadeFreq = 0.05f, fadeBy = 0.01f;
    // Start is called before the first frame update

    void Start()
    {
        mainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (storyCounter >= texts.Length)
        {
            SceneManager.UnloadScene("MainMenu");
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            texts[storyCounter].SetActive(true);
            TextMesh currentText = texts[storyCounter].GetComponent<TextMesh>();
            if (!routineRunning)
            {
                StartCoroutine(fadeIn(currentText));
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                skip = true;
            }
        }

    }

    IEnumerator fadeIn(TextMesh text)
    {
        routineRunning = true;
        Color color = text.color;
        color.a = 0f;
        text.color = color;
        while (color.a < 1)
        {
            if (skip)
            {
                color.a = 1;
                text.color = color;
                skip = false;
                break;
            }
            yield return new WaitForSeconds(fadeFreq);
            color.a += fadeBy;
            text.color = color;
        }
        StartCoroutine(fadeOut(text));
    }

    IEnumerator fadeOut(TextMesh text)
    {
        Color color = text.color;
        color.a = 1f;
        text.color = color;
        while (color.a > 0)
        {
            if (skip)
            {
                color.a = 0;
                text.color = color;
                skip = false;
                break;
            }
            yield return new WaitForSeconds(fadeFreq);
            color.a -= fadeBy;
            text.color = color;
        }
        storyCounter++;
        routineRunning = false;
    }

}
