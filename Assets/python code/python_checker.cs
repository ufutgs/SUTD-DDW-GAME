
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEditor.Scripting.Python;
using System;
public class python_checker : MonoBehaviour
{
    public InputField userInput;
    public Button submit_btn;
    private static string path = "Assets/python code/code.txt";
    private static string resultFile = "Assets/python code/result.txt";
    // Start is called before the first frame update
    void Start()
    {
        submit_btn.onClick.AddListener(submit);
        userInput.text = "def sorting():\n\tglobal sequence_array\nsorting()";
    }

    // Update is called once per frame
    private  void submit()
    {
        if(userInput.text!="")
        { writefile(userInput.text); }
        else{Debug.Log("No Text Found !");}
    }
    private static void writefile(string text)
    {
         File.WriteAllText(path, string.Empty);
          StreamWriter writer = new StreamWriter(path, true);
          writer.Write(text);
          writer.Close();
          AssetDatabase.ImportAsset(path); 
          PythonRunner.RunFile($"{Application.dataPath}/python code/syntax_checker.py");
        try {
            StreamReader reader = new StreamReader(resultFile, true);
            string raw_result= reader.ReadLine();
            string[] result_arr = raw_result.Split('@');
            Debug.Log("result : " + result_arr[0]+"\nTime Used: "+result_arr[1]);
            ClientSend.resultSend(float.Parse(result_arr[1]));
        }
        catch(Exception e)
        {
            Debug.Log("Something goes wrong ! :" + e.StackTrace);
        }
    }
}
