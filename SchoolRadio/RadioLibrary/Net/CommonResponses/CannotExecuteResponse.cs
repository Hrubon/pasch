using System;


[Serializable]
public class CannotExecuteResponse : Response
{
    public override int Code
    {
        get
        {
            return 103;
        }
    }
    public Exception Exception { get; private set; }



    public CannotExecuteResponse(Exception exception)
    {
        Exception = exception;
    }
}