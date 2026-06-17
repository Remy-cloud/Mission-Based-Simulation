using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Room2Manager : MonoBehaviour
{
    [Header("Door")]
    public DoorInteraction roomDoor;

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
    private bool playerInsideRoom = false;

    private string[] questions = {
        "What percentage of Africa's health budget goes to mental health?",
        "How many Africans live with anxiety?",
        "What does PTSD stand for?"
    };

    private string[][] answers = {
        new string[] { "1.4%", "10%", "25%" },
        new string[] { "10 million", "38 million", "5 million" },
        new string[] {
            "Post Traumatic Stress Disorder",
            "Personal Trauma Stress Disease",
            "Partial Trauma Stress Disorder"
        }
    };

    private int[] correctIndex = { 0, 1, 0 };

    void Start()
    {
        quizPanel.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    public void PlayerEnteredRoom()
    {
        if (!playerInsideRoom)
        {
            playerInsideRoom = true;
            roomDoor.isOpen = false;
        }
        else if (playerInsideRoom && !quizCompleted)
        {
            OpenQuiz();
        }
        else if (quizCompleted)
        {
            roomDoor.isOpen = true;
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
            roomDoor.isOpen = true;
            resultText.gameObject.SetActive(true);
            resultText.text = "Well done! You may proceed.";
            resultText.color = Color.green;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Invoke("HideResult", 2f);
        }
        else
        {
            quizCompleted = false;
            roomDoor.isOpen = false;
            currentQuestion = 0;
            correctAnswers = 0;
            resultText.gameObject.SetActive(true);
            resultText.text = "Try again! Review the panels.";
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
