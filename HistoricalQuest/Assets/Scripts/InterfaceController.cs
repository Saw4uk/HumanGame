using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text questionText;
    [SerializeField] private Text hp;
    [SerializeField] private Text answers;
    [SerializeField] public Button answer1;
    [SerializeField] public Button answer2;
    [SerializeField] public Button answer3;
    [SerializeField] public Button answer4;
    [SerializeField] private Game game;
    [SerializeField] private Image background;
    private System.Random rnd;
    private Vector3 questionPos;



    void Awake()
    {
        answer1.onClick.AddListener(OnButton1Click);
        answer2.onClick.AddListener(OnButton2Click);
        answer3.onClick.AddListener(OnButton3Click);
        answer4.onClick.AddListener(OnButton4Click); 
        rnd = new System.Random();
        player.hpChanged += OnHpChanged;
        player.answersChanged += OnAnswersChanged;
        hp.text = player.Hp.ToString();
        answers.text = "0";
    }

    private void OnHpChanged()
    {
        hp.text = player.Hp.ToString();
    }
    private void OnAnswersChanged()
    {
        answers.text = player.RightAnswers.ToString();
    }
    
    public void ChangeQuestion(Victorina.Question question)
    {
        questionText.text = question.textOfQuestion;
        var arrayOfUnusedAnswers = new[]
        {
            question.rightAnswer,
            question.answer2,
            question.answer3,
            question.answer4
        };

        var arrayOfButtons = new[]
        {
            answer1,
            answer2,
            answer3,
            answer4
        };
        
        for (int i = 0; i < 4; i++)
        {
            var x = rnd.Next(0, arrayOfUnusedAnswers.Length);
            arrayOfButtons[i].GetComponentInChildren<Text>().text = arrayOfUnusedAnswers[x];
            arrayOfUnusedAnswers = arrayOfUnusedAnswers.Where(y => y != arrayOfUnusedAnswers[x]).ToArray();
        }
    } 
    

    void OnButton1Click()
    {
        game.CheckAnswer(answer1, new Button[] {answer2,answer3,answer4});
    }
    
    void OnButton2Click()
    {
        game.CheckAnswer(answer2, new Button[] { answer1, answer3, answer4 });
    }
    
    void OnButton3Click()
    {
        game.CheckAnswer(answer3, new Button[] { answer2, answer1, answer4 });
    }
    
    private void OnButton4Click()
    {
        game.CheckAnswer(answer4, new Button[] { answer2, answer3, answer1 });
    }

    public void SetQuestionActive(bool set)
    {
        questionText.gameObject.SetActive(set);
        answer1.gameObject.SetActive(set);
        answer2.gameObject.SetActive(set);
        answer3.gameObject.SetActive(set);
        answer4.gameObject.SetActive(set);
        background.gameObject.SetActive(set);
    }
}

