using System;

public delegate void RecieverError(string message = null);
public delegate void RequestFailedHandler(Request request, Exception ex = null);