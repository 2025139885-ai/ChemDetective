
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvestigationUIController : MonoBehaviour
{
    [Header("Case Information")]
    [SerializeField] private TMP_Text caseNumberText;
    [SerializeField] private TMP_Text caseTitleText;
    [SerializeField] private TMP_Text descriptionText;

    [Header("Case Illustration")]
    [SerializeField] private Image mysteryImage;

    private void Start()
    {
        DisplayCaseInformation();
    }

    private void DisplayCaseInformation()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found!");
            return;
        }

        CaseData selectedCase = GameManager.Instance.currentCase;

        if (selectedCase == null)
        {
            Debug.LogWarning("No case has been selected!");
            return;
        }

        caseNumberText.text = "CASE " + selectedCase.caseNumber.ToString("00");
        caseTitleText.text = selectedCase.caseName;

        mysteryImage.sprite = selectedCase.caseImage;

        descriptionText.text = GetCaseDescription(selectedCase.caseNumber);
    }

    private string GetCaseDescription(int caseNumber)
    {
        switch (caseNumber)
        {
            case 1:
                return "A yellowish liquid has been found inside a laboratory flask, surrounded by test tubes containing different coloured substances. What could this mysterious liquid be? Investigate and uncover its identity!";

            case 2:
                return "A mysterious red stain has appeared on a laboratory coat. No one knows where it came from. Examine the unknown substance and discover its identity!";

            case 3:
                return "A strange blue substance has been discovered spilled across a laboratory table, near several test tubes. What is this unusual substance? Conduct your investigation to find out!";

            case 4:
                return "An unidentified liquid has been found inside an unlabelled bottle in the laboratory. Its unusual colour has caught everyone's attention. Investigate the substance and reveal its identity!";

            case 5:
                return "A glass filled with a clear liquid has been discovered on a laboratory table, with some of it spilled nearby. It looks ordinary, but is it really what it seems? Investigate and uncover the truth!";

            default:
                return "Investigate the unknown substance and uncover its identity!";
        }
    }
}