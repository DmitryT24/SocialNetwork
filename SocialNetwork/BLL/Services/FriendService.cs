using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService : UserService
    {
        private IFriendRepository friendRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friends> ShowFriends(User user)
        {
            List<Friends> friends = new List<Friends>();
            foreach (FriendEntity friendEntity in friendRepository.FindAllByUserId(user.Id))
            {
                friends.Add(ConstructFriendModel(friendEntity));
            }
            return friends;
        }

        internal void AddFriends(User user, string friendEmail)
        {
            if (!new EmailAddressAttribute().IsValid(friendEmail))
                throw new ArgumentNullException();

            User friend = FindByEmail(friendEmail);
            if (user is null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = user.Id,
                friend_id = friend.Id,
            };
            if (user.Id == friend.Id)
            {
                AlertMessage.Show("Ошибка! Вы пытаетесь добавить свой адрес!");
            }
            else
            {
                if (friendRepository.Create(friendEntity) == 0)
                    throw new Exception();
            }
        }
        internal void RemoveFriends(User user, string friendEmail)
        {
            if (!new EmailAddressAttribute().IsValid(friendEmail))
                throw new ArgumentNullException();
            
            User friendUser = FindByEmail(friendEmail);
            if (friendUser is null)
                throw new UserNotFoundException();
            int? friendEntityId = null;
            
            var friends = friendRepository.FindAllByUserId(user.Id);
            foreach (var friend in friends)
            {
                if (ConstructFriendModel(friend).FriendId == friendUser.Id)
                {
                    friendEntityId = friend.id;
                    break;
                }
            }
            if (friendEntityId is null)
                throw new Exception();

            if (friendRepository.Delete((int)friendEntityId) == 0)
                throw new Exception();

        }
        private Friends ConstructFriendModel(FriendEntity friendEntity)
        {
            return new Friends(friendEntity.id,
                              friendEntity.user_id,
                              friendEntity.friend_id
                             );
        }
    }

}
