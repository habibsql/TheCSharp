using System;
using System.Collections.Generic;
using System.Text;

namespace TheCSharp.Partial
{
    public partial class UserService
    {
        partial void TrackUser(string userId);
        
        public bool IsUserValid(string userId)
        {
            TrackUser(userId);
            Guid userGuid;
            bool okay = Guid.TryParse(userId, out userGuid);

            return okay;
        }
    }
}
