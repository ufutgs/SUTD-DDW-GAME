
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEditor;
public class rng : MonoBehaviour
{
    private List<int> sequence = new List<int>();
    private static int size = 20;
    private int[] random_sequence = new int[size];
    public GameObject parent;
    public Transform prefab;
    private static string path = "Assets/python code/sequence.txt";
     private void Awake() 
    {
        for(int i =0;i<size; i++)
        {
            sequence.Add(i+1);
        }
        rng_function();
    }
    void Start()
    {
        Debug.Log("random list : " + string.Join(",",random_sequence));
    }
private void rng_function()
{
    File.WriteAllText(path, string.Empty);
    StreamWriter writer = new StreamWriter(path, true);
    random_sequence = new List<int>(sequence).ToArray();
    for(int j =0;j<size; j++)
    {
        int chosen= Random.Range(j,sequence.Count);
        int change = random_sequence[j];
        random_sequence[j] =  random_sequence[chosen];
         random_sequence[chosen] = change;
        float color = (float)random_sequence[j] / (float)size;
        Transform square = Instantiate(prefab,new Vector3(-10+j*1f,2,0),Quaternion.identity,parent.transform);
        square.gameObject.GetComponent<SpriteRenderer>().color =new Color(color,color,color);
        if(j!=size-1)
        { writer.Write( random_sequence[j]+",");}else{
             writer.Write( random_sequence[j]);}
    }
     writer.Close();
    AssetDatabase.ImportAsset(path); 
    return;
}


public List<int> get_sequence()
{
    return sequence;
}
public int[] get_random_sequence()
{
    return random_sequence;
}

}
