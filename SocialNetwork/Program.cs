using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL;
using SocialNetwork.PLL.Views;
using SocialNetwork.PLL.Views.UserViev;
using SocialNetwork.PLL.Views.FriendsView;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        static FriendService friendService;
        static MessageService messageService;
        static UserService userService;
        public static FriendsMenuView friendsMenuView;
        public static FriendsInfoView friendsInfoView;
        public static FriendsOptionView friendsOptionView;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        static void Main(string[] args)
        {
            var isPause = true;
            friendService = new FriendService();
            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            friendsMenuView = new FriendsMenuView();
            friendsInfoView = new FriendsInfoView(friendService);
            friendsOptionView = new FriendsOptionView(friendService);

            while (isPause)
            {
                isPause = mainView.Show();
            }
        }
    }
}