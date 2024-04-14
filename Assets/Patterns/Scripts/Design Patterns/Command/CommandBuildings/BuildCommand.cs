using UnityEngine;

namespace Phyw.DesignPatterns
{

  public class BuildCommand : MonoBehaviour, ICommandBuilding
  {
    #region Variables
    public GameObject building;
    GameObject tower;
    Vector3 position, offset;
    Quaternion rotation;

    #endregion

    #region CustomMethods

    public void SetOffset(Vector3 off)
    {
      position -= offset;
      offset = off;
      position += offset;
    }

    public void SetProperties(Vector3 position, Quaternion rotation)
    {
      this.position += position;
      this.rotation *= rotation;
    }

    public void Execute()
    {
      tower = Instantiate(building, position, rotation);
    }

    public void UnExecute()
    {
      Destroy(tower);
    }

    #endregion
  }
}