using System;

namespace Musical_WebStore_BlazorApp.Shared
{    
    public enum OrderStatuses
    {
        InConfirmation = 1,
        Confirmed = 2,
        OnTheWay = 3,
        Delivered = 4
    }
}