using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class JsonExampleScript : MonoBehaviour
{
	string jsonString;

	// Use this for initialization
	void Start()
	{
		jsonString = LoadFile(Application.streamingAssetsPath + "/Data.json");

		Owner owner = JsonUtility.FromJson<Owner>(jsonString);

		Dictionary<string, object> dic = MiniJSON.Json.Deserialize(jsonString)as Dictionary<string, object>;

		Debug.Log(dic["cars"]);
		foreach (object item in dic["cars"] as List<object>)
		{
			Debug.Log(MiniJSON.Json.Serialize(item));
		}

	}
	public void SaveFile(string jsonString, string path)
	{
		if (!File.Exists(path))
		{
			string createText = jsonString;
			File.WriteAllText(path, createText);
		}
		else
		{
			File.Delete(path);
			string createText = jsonString;
			File.WriteAllText(path, createText);
		}
	}

	public string LoadFile(string path)
	{
		if (!File.Exists(path))
		{
			return "";
		}
		else
		{
			return File.ReadAllText(path);
		}
	}

}

[System.Serializable]
public class Owner
{
	public string name;
	public int age;
	public Cars[] cars;

	public Owner(string name, int age, Cars[] cars)
	{
		this.name = name;
		this.age = age;

		for (int i = 0; i < cars.Length; i++)
		{
			this.cars[i] = cars[i];
		}
	}
}

[System.Serializable]
public class Cars
{
	public string brandName;
	public string[] modelName;

	public Cars(string brandName, string[] modelName)
	{
		this.brandName = brandName;

		for (int i = 0; i < modelName.Length; i++)
		{
			this.modelName[i] = modelName[i];
		}
	}
}