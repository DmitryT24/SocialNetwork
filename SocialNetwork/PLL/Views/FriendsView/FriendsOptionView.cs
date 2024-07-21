using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views.FriendsView
{
    public class FriendsOptionView
    {
        private FriendService friendService;
        public FriendsOptionView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Add(User user, string friendEmail)
        {
            try
            {
                friendService.AddFriends(user, friendEmail);
                SuccessMessage.Show($"Ваш друг с адресом {friendEmail} успешно добавлен!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show($"Адрес {friendEmail} не зарегистрирован!") ;
            }
            catch (Exception e)
            {
                AlertMessage.Show("Error: " + e.Message);
            }
        }
        public void Remove(User user, string friendEmail)
        {
            try
            {
                friendService.RemoveFriends(user, friendEmail);
                SuccessMessage.Show($"Друг с {friendEmail}  удален из списка друзей!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show($"Пользователь {friendEmail} в списке друзей не найден!");
            }
            catch (Exception e)
            {
                AlertMessage.Show("Error: " + e.Message);
            }
        }
    }
}
