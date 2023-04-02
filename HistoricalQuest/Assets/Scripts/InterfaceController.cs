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
    [SerializeField] private Button answer1;
    [SerializeField] private Button answer2;
    [SerializeField] private Button answer3;
    [SerializeField] private Button answer4;
    [SerializeField] private Game game;
    private System.Random rnd;
    void Awake()
    {
        answer1.onClick.AddListener(OnButton1Click);
        answer2.onClick.AddListener(OnButton2Click);
        answer3.onClick.AddListener(OnButton3Click);
        answer4.onClick.AddListener(OnButton4Click); 
        rnd = new System.Random();
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
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        hp.text = player.hp.ToString();
    }

    void OnButton1Click()
    {
        game.CheckAnswer(answer1.GetComponentInChildren<Text>().text);
    }
    
    void OnButton2Click()
    {
        game.CheckAnswer(answer2.GetComponentInChildren<Text>().text);
    }
    
    void OnButton3Click()
    {
        game.CheckAnswer(answer3.GetComponentInChildren<Text>().text);
    }
    
    private void OnButton4Click()
    {
        game.CheckAnswer(answer4.GetComponentInChildren<Text>().text);
    }

    public void SetQuestionActive(bool set)
    {
        questionText.gameObject.SetActive(set);
        answer1.gameObject.SetActive(set);
        answer2.gameObject.SetActive(set);
        answer3.gameObject.SetActive(set);
        answer4.gameObject.SetActive(set);
    }
}

