using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TestGame.Main
{
	public class BinFileIO : MonoBehaviour 
	{
		public void Save<T>(T data, string path)
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream(path, FileMode.Create);
			bf.Serialize(fs, data);
			fs.Close();
		}

		public T Load<T>(string path) where T : class
		{
			T data = null;

			if (File.Exists(path))
			{
				BinaryFormatter bf = new BinaryFormatter();
				FileStream fs = new FileStream(path, FileMode.Open);
				data = bf.Deserialize(fs) as T;
				fs.Close();
			}
			else
			{
				Debug.LogWarning("BinFileIO using Load() can not open file at path: " + path);
			}

			return data;
		}	
	}
}

