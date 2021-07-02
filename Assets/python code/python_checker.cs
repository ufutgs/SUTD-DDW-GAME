
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEditor.Scripting.Python;
public class python_checker : MonoBehaviour
{
    public InputField userInput;
    public Button submit_btn;
    private static string path = "Assets/python code/code.txt";
    // Start is called before the first frame update
    void Start()
    {
        submit_btn.onClick.AddListener(submit);
        userInput.text = "def sorting():\n\tglobal sequence_array\n";
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
    }
}
