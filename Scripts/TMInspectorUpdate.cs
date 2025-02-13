using UnityEngine;
using TMPro;

public class TMPInspectorUpdate : MonoBehaviour
{
    public TMP_Text myText;

    public TimeController op;

    public void Update(){
        myText.text=Mathf.FloorToInt(op.timeRemaining).ToString();
    }
    
}
