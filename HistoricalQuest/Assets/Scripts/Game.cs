using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InterfaceController interfaceController;
    private int currentEra;
    private float answerCoordX;
    private int eraCounter;
    private bool isWaitingAnswer;
    private bool isAnswerGetted;

    public bool IsWaitingAnswer
    {
        get => isWaitingAnswer;
        set => isWaitingAnswer = value;
    }

    private Victorina.Question currentQuestion;

    
    //Settings
        private int questionsOnEraAmount = 2;
        private int maxEra = 1;
    //
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsWaitingAnswer)
        {
            if (player.transform.position.x - answerCoordX >= 20)
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
