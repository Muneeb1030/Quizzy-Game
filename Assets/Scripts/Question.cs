using UnityEngine;

[CreateAssetMenu(fileName ="Question No ",menuName ="Question")]
public class Question : ScriptableObject
{
    public string answer;
    public string displayNnswer;

    public string[] hints = new string[3];
    public string[] Hints
    {
        get
        {
            if(hints == null || hints.Length == 0)
            {
                hints = new string[3];
            }
            return hints;
        }
    }
}
