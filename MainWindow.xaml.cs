using System;
using PavileniDB.ModelDB;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PavileniDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Captcha();

        }

        private void ExitProgramm(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SverProgramm(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void SignIN(object sender, RoutedEventArgs e)
        {
            var lg = LoginText.Text.Trim();
            var pw = PasswordText.Password.Trim();
            var cp = CaptchaText.Text.Trim();
            if (string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин, пароль, капча не введены, повторите попытку!");
                return;
            }
            if (string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && !string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин не введен, повторите попытку!");
                return;
            }
            if (string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин и пароль не введены, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин и капча не введены, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && !string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Капча не введена, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Пароль не введен, повторите попытку!");
                return;
            }
            using (var db = new pavileniDBEntities())
            {
                var res = from Users in db.Users where Users.Login == LoginText.Text && Users.Password == PasswordText.Password select Users;
                if(res.Count() == 1 && CaptchaText.Text == CaptchaLabel.Content.ToString())
                {
                    switch (res.First().Role)
                    {
                        case "Менеджер С":
                            WhatTheRole.role = Role.Manager_C;
                            Roles.Manager_C manager_c = new Roles.Manager_C();
                            manager_c.Visibility = Visibility.Visible;
                            this.Close();
                            break;
                        case "Менеджер А":
                            WhatTheRole.role = Role.Manager_A;
                            WhatTheRole.role = Role.Manager_C;
                            Roles.Manager_C manager_a = new Roles.Manager_C();
                            manager_a.Visibility = Visibility.Visible;
                            this.Close();
                            break;
                        case "Администратор":
                            WhatTheRole.role = Role.Administrator;
                            Roles.Manager_C adm = new Roles.Manager_C();
                            adm.Visibility = Visibility.Visible;
                            this.Close();
                            break;
                        case "Удален":
                            WhatTheRole.role = Role.RemoveUser;
                            Roles.Manager_C removeUser = new Roles.Manager_C();
                            removeUser.Visibility = Visibility.Visible;
                            this.Close();
                            break;


                    }

                }
                else if (res.Count() == 1 && CaptchaText.Text != CaptchaLabel.Content.ToString())
                {
                    Captcha();
                    MessageBox.Show("Капча введена не правильно\nПовторите попытку!");
                    return;

                }
                else
                {
                    Captcha();
                    MessageBox.Show("Логин или пароль введены не правильно!\nПовторите попытку!");
                    return;
                }
            }
        }


        public void Captcha()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {

                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            CaptchaLabel.FontFamily = new System.Windows.Media.FontFamily("Curlz MT");

            CaptchaLabel.Content = pwd;
        }

        private void ButtonCaptcha(object sender, RoutedEventArgs e)
        {
            Captcha();
        }
    }
}
