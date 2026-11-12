
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CaseData currentCase;

    private List<CaseData> allCases = new List<CaseData>();

    private HashSet<int> completedCases = new HashSet<int>();

    private const string SAVE_KEY = "CompletedCases";

    [Header("Case Illustrations")]
    [SerializeField] private Sprite case01Image;
    [SerializeField] private Sprite case02Image;
    [SerializeField] private Sprite case03Image;
    [SerializeField] private Sprite case04Image;
    [SerializeField] private Sprite case05Image;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        CreateCases();
        LoadProgress();
    }

    private void CreateCases()
    {
        allCases.Clear();

        allCases.Add(new CaseData(
            1, "The Golden Drop Mystery", "Lemon", case01Image));

        allCases.Add(new CaseData(
            2, "The Crimson Clue", "Tomato", case02Image));

        allCases.Add(new CaseData(
            3, "The Forgotten Morning Case", "Toothpaste", case03Image));

        allCases.Add(new CaseData(
            4, "The Whiteout Mystery", "Bleach", case04Image));

        allCases.Add(new CaseData(
            5, "The Silent Sample", "Pure Water", case05Image));
    }

    public void SelectRandomCase()
    {
        List<CaseData> availableCases = new List<CaseData>();

        foreach (CaseData c in allCases)
        {
            if (!completedCases.Contains(c.caseNumber))
            {
                availableCases.Add(c);
            }
        }

        if (availableCases.Count == 0)
        {
            currentCase = null;
            SceneManager.LoadScene("AllCasesCompleted");
            return;
        }

        int randomIndex = Random.Range(0, availableCases.Count);
        currentCase = availableCases[randomIndex];

        Debug.Log("New Case Selected!");
        Debug.Log("Case Number: " + currentCase.caseNumber);
        Debug.Log("Case Name: " + currentCase.caseName);

        SceneManager.LoadScene("StartInvestigation");
    }

    public void CompleteCurrentCase()
    {
        if (currentCase == null)
        {
            Debug.LogWarning("No active case!");
            return;
        }

        completedCases.Add(currentCase.caseNumber);
        SaveProgress();

        Debug.Log("Case " + currentCase.caseNumber + " Completed!");
    }

    public int GetCompletedCount()
    {
        return completedCases.Count;
    }

    public int GetTotalCases()
    {
        return allCases.Count;
    }

    public bool IsCaseCompleted(int caseNumber)
    {
        return completedCases.Contains(caseNumber);
    }

    private void SaveProgress()
    {
        string savedData = string.Join(",", completedCases);

        PlayerPrefs.SetString(SAVE_KEY, savedData);
        PlayerPrefs.Save();

        Debug.Log("Progress Saved!");
    }

    private void LoadProgress()
    {
        completedCases.Clear();

        string savedData = PlayerPrefs.GetString(SAVE_KEY, "");

        if (string.IsNullOrEmpty(savedData))
            return;

        string[] caseIDs = savedData.Split(',');

        foreach (string id in caseIDs)
        {
            int number;

            if (int.TryParse(id, out number))
            {
                if (number >= 1 && number <= 5)
                {
                    completedCases.Add(number);
                }
            }
        }

        Debug.Log("Loaded Completed Cases: " + completedCases.Count);
    }

    public void ResetProgress()
    {
        completedCases.Clear();
        currentCase = null;

        PlayerPrefs.DeleteKey(SAVE_KEY);
        PlayerPrefs.Save();

        Debug.Log("All Progress Reset!");
    }
}
