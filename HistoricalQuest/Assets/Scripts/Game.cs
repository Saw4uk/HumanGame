using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InterfaceController interfaceController;
    private int currentEra;
    private float answerCoordX;
    private int eraCounter;
    public bool isWaitingAnswer;
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
        if (!isWaitingAnswer)
        {
            if (player.transform.position.x - answerCoordX >= 10)
            {
                currentQuestion = Victorina.GetQuestion(currentEra);
                interfaceController.SetQuestionActive(true);
                interfaceController.ChangeQuestion(currentQuestion);
                player.canMove = false;
                isWaitingAnswer = true;
                answerCoordX = player.transform.position.x;
                eraCounter += 1;
            }

            if (eraCounter == questionsOnEraAmount && currentEra != maxEra)
            {
                currentEra += 1;
            }
        }
    }
    
    public void CheckAnswer(string str)
    {
        if (str == currentQuestion.rightAnswer)
        {
            player.Hp += 1;
        }
        else
        {
            player.Hp -= 1;
        }
        player.transform.position = new Vector3(player.transform.position.x + 0.1f, player.transform.position.y,
            player.transform.position.z);
        isWaitingAnswer = false;
        player.canMove = true;
        interfaceController.SetQuestionActive(false);
    }
}
