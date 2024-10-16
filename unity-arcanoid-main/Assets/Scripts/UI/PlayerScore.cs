using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text text;
    [SerializeField] 
    private int score;

    public void AddScore(int addition){
        score+=addition;
        text.text = score.ToString();
    }
}
