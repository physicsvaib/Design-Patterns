using UnityEngine;
using System.IO;

namespace Phyw.FileSystem
{

  public class FileWrite : MonoBehaviour
  {
    #region Variables
    [SerializeField] private string path;
    private string finalPath;
    #endregion

    #region UnityMethods

    private void Start()
    {
      finalPath = Path.Combine(Application.persistentDataPath, path);

    }

    #endregion

    #region CustomMethods

    public void WriteToFile(string data)
    {

      using (StreamWriter writer = File.AppendText(finalPath))
      {
        // Write data to the file
        writer.WriteLine(data);
      }

    }

    #endregion

  }
}