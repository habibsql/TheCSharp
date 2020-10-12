using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheCSharp.Partial
{
    public partial class UserService
    {
        partial void TrackUser(string userId)
        {
            Debug.WriteLine($"Tracked user id={userId}");
        }
    }
}
