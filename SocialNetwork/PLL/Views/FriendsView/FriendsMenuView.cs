using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views.FriendsView
{
    public class FriendsMenuView
    {
        public void Show(User user)
        {
            var isPause = true;
            while (isPause)
            {
                Console.WriteLine("Раздел - мои друзья:");
                Console.WriteLine("Список друзей:");

                Program.friendsInfoView.Show(user);

                Console.WriteLine(" Выберите действие:");
                Console.WriteLine("  -- Добавить друга (нажмите 1)");
                Console.WriteLine("  -- Удалить из друзей (нажмите 2)");
                Console.WriteLine("  -- Выйти из раздела Мои друзья (нажмите 3)");

                var strValue = Console.ReadLine();



                switch (strValue)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите адрес пользователя для добавление в друзья:");
                            Program.friendsOptionView.Add(user, Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите адрес друга для удаления из друзей:");
                            Program.friendsOptionView.Remove(user, Console.ReadLine());
                            break;
                        }
                    case "3":
                        {
                            isPause = false;
                            break;
                        }
                    default:
                        {
                            AlertMessage.Show("       Error: Вы ввели неверное заначение!\n" +
                                "       Повторите ввод по инструкции!");
                            break;
                        }

                }
            }
        }
    }
}
