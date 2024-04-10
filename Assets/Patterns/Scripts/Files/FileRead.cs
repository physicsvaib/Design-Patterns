using UnityEngine;
using System.IO;

namespace Phyw.FileSystem
{

  public class FileRead : MonoBehaviour
  {
    #region Variables
    [SerializeField] private string path;
    private string finalPath;

    #endregion

    #region UnityMethods

    private void OnEnable()
    {
      finalPath = Path.Combine(Application.persistentDataPath, path);
      print(ReadData());
      print(finalPath);
    }

    #endregion

    #region CustomMethods
    public string ReadData()
    {
      if (File.Exists(finalPath))
      {
        // Read data from file
        string data = File.ReadAllText(finalPath);
        return data;
      }
      else
      {
        Debug.LogWarning("File not found: " + finalPath);
        return null;
      }
    }

    #endregion

  }
}