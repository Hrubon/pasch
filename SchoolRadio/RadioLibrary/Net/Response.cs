using System;


[Serializable]
public abstract class Response
{
    public abstract int Code { get; }
    public bool Success
    {
        get
        {
            return (Code == new SuccessResponse().Code);
        }
    }
}