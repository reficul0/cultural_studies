using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionStruct
{
    public UIAnsver correct = new UIAnsver();

    //UI
    public string text;
    public AnsversText options = new AnsversText();
}
