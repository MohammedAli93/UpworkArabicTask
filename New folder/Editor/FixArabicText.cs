using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using ArabicSupport;
using TMPro;

public class FixArabicText : Editor
{
    [MenuItem("Tools/Fix Arabic Text &%a")]
    public static void Fix()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            var t = Selection.gameObjects[i].GetComponent<Text>();
            if (t != null)
            {
                Undo.RecordObject(t, "Fixing Arabic");
                t.text = ArabicFixer.Fix(t.text, true, true, true);
            }

            var t2 = Selection.gameObjects[i].GetComponent<TextMeshProUGUI>();
            if (t2 != null)
            {
                Undo.RecordObject(t2, "Fixing Arabic");
                t2.text = ArabicFixer.Fix(t2.text, true, true, true);
            }

            var t3 = Selection.gameObjects[i].GetComponent<TextMeshPro>();
            if (t3 != null)
            {
                Undo.RecordObject(t3, "Fixing Arabic");
                t3.text = ArabicFixer.Fix(t3.text, true, true, true);
            }
        }
    }

    [MenuItem("Tool/remove tashkeel")]
    public static string RemoveTashkeel(string text)
    {
        text = "بِسْمِ الله";

        Debug.Log(text);
        // for (int i = 0; i < text.Length; i++)
        {
            text = text.Replace("ُ", "");        // damma
            text = text.Replace("َ", "");        // fatha
            text = text.Replace("ِ", "");        // kasra
            text = text.Replace("ّ", "");        // shadda
            text = text.Replace("َْ", "");        // sokon
        }
        Debug.Log(text);

        return (text);
    }
}