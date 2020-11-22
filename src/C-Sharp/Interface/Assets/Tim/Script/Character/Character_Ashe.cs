using UnityEngine;

[System.Serializable]
public class Character_Ashe : IProperty
{
    [SerializeField]
    int _ad = 90;

    [SerializeField]
    int _ap = 10;

    [SerializeField]
    int _ar = 10;

    [SerializeField]
    int _mr = 10;

    public int Ad
    {
        get {return _ad;}
        set {_ad = value;}
    }
    public int Ap
    {
        get { return _ap; }
        set { _ap = value; }
    }
    public int Ar
    {
        get { return _ar; }
        set { _ar = value; }
    }
    public int Mr
    {
        get { return _mr; }
        set { _mr = value; }
    }
}
