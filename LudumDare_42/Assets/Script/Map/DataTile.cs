using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[System.Serializable]
public class DataTile
{
    public int x;
    public int y;
    public int id;
    public GameObject obj;
    public GameObject baseObj;
    public bool isGoop;

    public DataTile(int xId, int yId, int idId, GameObject objId, GameObject baseObjId)
    {
        x = xId;
        y = yId;
        id = idId;
        obj = objId;
        isGoop = false;
        baseObj = baseObjId;
    }
}
