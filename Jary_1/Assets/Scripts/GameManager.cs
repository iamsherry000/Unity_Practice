using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public InputField playerAnswerUI;
    public int playerAnswer,num=-2;
    public Text hints;
    public Button Enter;
    void Start()
    {
        UpdateHints("根據甜蜜指數 ");
    }
    
    void UpdateHints(string message)
    {
        hints.text = message;
    }

    bool CanGetInputNum() 
    {
        return int.TryParse(playerAnswerUI.text, out playerAnswer);
    }

    public void Compare() 
    {
        //playerAnswer = int.Parse(playerAnswerUI.text);
        if (!CanGetInputNum())
        {
            UpdateHints("numbers only !");
            return;
        }
        num = playerAnswer;
            if (num > -1 && num < 10)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic1");
                if (num == 0) UpdateHints("這麼糟糕麼...，我很抱歉，讓你這麼難過");
            }
            else if (num > 10 && num < 20)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic3");
            }
            else if (num > 20 && num < 30)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic4");
            }
            else if (num > 30 && num < 40)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic5");
            }
            else if (num > 40 && num < 50)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic6");
            }
            else if (num > 50 && num < 60)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic7");
            }
            else if (num > 60 && num < 70)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic8");
            }
            else if (num > 70 && num < 80)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic2");
            }
            else if (num > 80 && num < 90)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic10");
            }
            else if (num > 90 && num < 101)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic11");
            }
            //else if (num == -2) gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load<Sprite>("pic9");
    }

    public void ClearHint() 
    {
        UpdateHints("");
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        
    }
}
