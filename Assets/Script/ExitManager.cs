using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExitManager : MonoBehaviour
{
    [Header("Door")]
    public DoorInteraction exitDoor;

    [Header("Quiz UI")]
    public GameObject quizPanel;
    public TMP_Text questionText;
    public TMP_Text resultText;
    public Button answerButtonA;
    public Button answerButtonB;
    public Button answerButtonC;

    private int currentQuestion = 0;
    private int correctAnswers = 0;
    private bool quizCompleted = false;
    private bool quizStarted = false;

    private string[] questions = {
        "What is the most common mental health condition in Sub-Saharan Africa?",
        "What percentage of Africa's health budget is spent on mental health?",
        "What is the best first step in breaking mental health stigma?"
    };

    private string[][] answers = {
        new string[] { "Anxiety", "Diabetes", "Asthma" },
        new string[] { "1.4%", "15%", "30%" },
        new string[] { "Talking openly and listening without judgement", "Ignoring the problem", "Avoiding the person" }
    };

    private int[] correctIndex = { 0, 0, 0 };

    void Start()
    {
        quizPanel.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    public void PlayerAtExit()
    {
        if (!quizCompleted && !quizStarted)
        {
            quizStarted = true;
            OpenQuiz();
        }
        else if (quizCompleted)
        {
            exitDoor.isOpen = true;
        }
    }

    void OpenQuiz()
    {
        currentQuestion = 0;
        correctAnswers = 0;
        quizPanel.SetActive(true);
        resultText.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        LoadQuestion();
    }

    void LoadQuestion()
    {
        if (currentQuestion < questions.Length)
        {
            questionText.text = questions[currentQuestion];
            answerButtonA.GetComponentInChildren<TMP_Text>().text =
                "A  " + answers[currentQuestion][0];
            answerButtonB.GetComponentInChildren<TMP_Text>().text =
                "B  " + answers[currentQuestion][1];
            answerButtonC.GetComponentInChildren<TMP_Text>().text =
                "C  " + answers[currentQuestion][2];
        }
        else
        {
            EndQuiz();
        }
    }

    public void AnswerSelected(int index)
    {
        if (index == correctIndex[currentQuestion])
            correctAnswers++;

        currentQuestion++;
        LoadQuestion();
    }

    void EndQuiz()
    {
        quizPanel.SetActive(false);

        if (correctAnswers >= 2)
        {
            quizCompleted = true;
            exitDoor.isOpen = true;
            resultText.gameObject.SetActive(true);
            resultText.text = "Congratulations! You completed the journey.";
            resultText.color = Color.green;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Invoke("HideResult", 3f);
        }
        else
        {
            quizStarted = false;
            currentQuestion = 0;
            correctAnswers = 0;
            resultText.gameObject.SetActive(true);
            resultText.text = "Try again! Review what you learned.";
            resultText.color = Color.red;
            Time.timeScale = 1f;
            Invoke("HideResult", 2f);
        }
    }

    void HideResult()
    {
        resultText.gameObject.SetActive(false);
    }
}
