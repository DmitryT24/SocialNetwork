using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views.FriendsView
{
    public class FriendsInfoView
    {
        FriendService friendService;
        internal FriendsInfoView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(User user)
        {
            var friends = friendService.ShowFriends(user);
            User friendUser;
            if (friends.Count() == 0)
                Console.WriteLine("  Список друзей пуст.");
            else
            {
                Console.WriteLine("  Список ваших друзей:");
                foreach (Friends friend in friends)
                {
                    friendUser = friendService.FindById(friend.FriendId);
                    Console.WriteLine($"   {friendUser.LastName}");
                }
            }
        }
    }
}
