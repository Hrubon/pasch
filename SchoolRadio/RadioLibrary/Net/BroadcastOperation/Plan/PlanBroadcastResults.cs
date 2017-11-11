using System;


[Serializable]
public enum PlanBroadcastResult
{
    CanUpload = 401,
    CanUploadIfAdmin = 402,
    CannotUpload = 403
}