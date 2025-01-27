﻿using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public bool Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");
            Console.WriteLine("Выйти (нажмите 3)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.registrationView.Show();
                        break;
                    }
                case "3":
                    {
                        return false;

                    }
                default:
                    {
                        Console.WriteLine("Ошибка ввода! Повторите!");
                        break;
                    }
            }
            return true;
        }
    }
}