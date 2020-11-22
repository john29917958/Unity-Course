using UnityEngine;

[System.Serializable]
public class Character_Custom : IProperty
{
    [SerializeField]
    int _ad = 100;

    [SerializeField]
    int _ap = 10;

    [SerializeField]
    int _ar = 50;

    [SerializeField]
    int _mr = 50;

    public int Ad
    {
        get { return _ad; }
        set { _ad = value; }
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

