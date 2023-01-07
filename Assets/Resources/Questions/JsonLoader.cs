using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    SeralizingList _seralizingList = new SeralizingList();
    public TextAsset _textAsset;

    private void Awake()
    {
        _seralizingList = JsonUtility.FromJson<SeralizingList>(_textAsset.text);
        Debug.Log("Here");
    }
}
[System.Serializable]
class Seralizing
{
    public string Topic;
    public string QuestionString;
    public string CorrectAnswer;
    public string WrongAnswer1;
    public string WrongAnswer2;
    public string WrongAnswer3;

}
[System.Serializable]
class SeralizingList
{
    public List<Seralizing> Answers;
}