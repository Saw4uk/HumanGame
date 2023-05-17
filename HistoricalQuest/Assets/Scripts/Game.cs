using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InterfaceController interfaceController;
    [SerializeField] private GameOverPanelLogic gameOverPanelLogic;
    private static Dictionary<int, int> dict = new ();
    private int currentEra;
    private float answerCoordX;
    private int eraCounter;
    private bool isWaitingAnswer;
    private bool isAnswerGetted;
    private bool isGameOver = true;

    public bool IsGameOver
    {
        get => isGameOver;
        set
        {
            isGameOver = value;
            if (value)
            {
                EndGame();
            }
        } 
    }

    public bool IsWaitingAnswer
    {
        get => isWaitingAnswer;
        set => isWaitingAnswer = value;
    }

    private Victorina.Question currentQuestion;

    
    //Settings
        private int questionsOnEraAmount = 3;
        private int maxEra = 2;
    //
    void Awake()
    {
        Victorina.GameOver += delegate
        {
            SetDefaults();
            IsGameOver = true;
        };
        player.hpChanged+= delegate
        {
            if (player.Hp == 0)
            {
                IsGameOver = true;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) return;
        if (!IsWaitingAnswer)
        {
            if (player.transform.position.x - answerCoordX >= 25)
            {
                currentQuestion = Victorina.GetQuestion(currentEra);
                interfaceController.SetQuestionActive(true);
                interfaceController.ChangeQuestion(currentQuestion);
                player.canMove = false;
                IsWaitingAnswer = true;
                answerCoordX = player.transform.position.x;
                eraCounter += 1;
            }

            if (eraCounter == questionsOnEraAmount && currentEra != maxEra)
            {
                currentEra += 1;
                eraCounter = 0;
            }
        }
        else if (isAnswerGetted)
        {
            var ismoved = false;
            if (Input.GetKey(KeyCode.D))
            {
                ismoved= true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                ismoved= true;
            }
            if (ismoved) 
            { 
                ChangeImageColor(interfaceController.answer1, Color.white, true);
                ChangeImageColor(interfaceController.answer2, Color.white, true);
                ChangeImageColor(interfaceController.answer3, Color.white, true);
                ChangeImageColor(interfaceController.answer4, Color.white, true);
                isWaitingAnswer= false;
                isAnswerGetted = false;
                interfaceController.SetQuestionActive(false);
            }
        }
    }

    public void StartGame()
    {
        isGameOver = false;
    }

    private void EndGame()
    {
        gameOverPanelLogic.gameObject.SetActive(true);
        var vek = dict.OrderBy(x=> x.Value).ToArray().FirstOrDefault();
        var str = $"Ваша слабость - {ParseVek(vek.Key)} век, вы допустили в нем наибольшее количество ошибок - {vek.Value}." +
                  $" Вы ответили правильно ответили на {player.RightAnswers} вопросов из {questionsOnEraAmount * (eraCounter+1)}";
        if (eraCounter==0)
        {
            str= $"Ваша слабость - {ParseVek(vek.Key)} век, вы допустили в нем наибольшее количество ошибок - {vek.Value}." +
                  $" Вы ответили правильно ответили на {player.RightAnswers} вопросов из {questionsOnEraAmount * 3}";
        }
        gameOverPanelLogic.DrawExit(str);
    }

    private string ParseVek(int vek)
    {
        switch (vek)
        {
            case 1:
                return "I";
            case 2:
                return "II";
            case 3:
                return "III";
            case 4:
                return "IV";
            case 5:
                return "V";
            case 6:
                return "VI";
            case 7:
                return "VII";
            case 8:
                return "VIII";
            case 9:
                return "IX";
            case 10:
                return "X";
            case 11:
                return "XI";
            case 12:
                return "XII";
            case 13:
                return "XIII";
            case 14:
                return "XIV";
            case 15:
                return "XV";
            case 16:
                return "XVI";
            case 17:
                return "XVII";
            case 18:
                return "XVIII";
            case 19:
                return "XIX";
            case 20:
                return "XX";
            default:
                return "";
        }
    }
    
    private void SetDefaults()
    {
        currentEra = 0;
        eraCounter = 0;
    }
    
    private void ChangeImageColor(Button button, Color32 color, bool interactable)
    {
        button.interactable = interactable;
        button.GetComponent<Image>().color = color;
    }
    public void CheckAnswer(Button button, Button[] otherButtons)
    {
        if (button.gameObject.GetComponentInChildren<Text>().text == currentQuestion.rightAnswer)
        {
            button.gameObject.GetComponent<Image>().color = Color.green;
            player.RightAnswers += 1;
        }
        else
        {
            if (dict.ContainsKey(currentQuestion.century))
            {
                dict[currentQuestion.century] += 1;
            }
            else
            {
                dict[currentQuestion.century] = 1;
            }
            
            player.Hp -= 1;
            button.gameObject.GetComponent<Image>().color = Color.red;
            foreach (var btn in otherButtons)
            {
                if (btn.gameObject.GetComponentInChildren<Text>().text == currentQuestion.rightAnswer)
                {
                    btn.gameObject.GetComponent<Image>().color = Color.green;
                }
            }
        }
        player.transform.position = new Vector3(player.transform.position.x + 0.1f, player.transform.position.y,
            player.transform.position.z);
        player.canMove = true;
        isAnswerGetted = true;
        foreach (var btn in otherButtons)
        {
            btn.interactable= false;
        }
        button.interactable = false;
    }
}
