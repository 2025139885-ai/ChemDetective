
using System;
using UnityEngine;

[Serializable]
public class CaseData
{
    public int caseNumber;
    public string caseName;
    public string substanceName;
    public Sprite caseImage;

    public CaseData(
        int number,
        string name,
        string substance,
        Sprite image)
    {
        caseNumber = number;
        caseName = name;
        substanceName = substance;
        caseImage = image;
    }
}
