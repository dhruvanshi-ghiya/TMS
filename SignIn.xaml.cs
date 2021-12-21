/********************************************//**
 *  Filename: SignIn.xaml.cs
 *	Project: Software Quality Term Project - Team 10
 *  By: Travis Fiander, Patrick Cho, Dhruvanshi Ghiya
 *  Date: November 27, 2021
 *	Description: Contains the class and method definitions for the SignIn xaml page
 ***********************************************/

using System;
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
using System.Windows.Shapes;
using Admin;
using TMS.Communications;

namespace TMS.Pages
{
    /// 
    /// \class SignIn
    ///
    /// \brief This page will simply be the sign in page. It will perform client side validation as well as check the backend
    ///        to see if the user exists.
    ///
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        ///
        /// \brief The button event for the sign in button. It will trigger input field validation as well
        ///        as backend validation to ensure the user exists, and get their role type. Based on the role
        ///        type, a different "dashboard" will be rendered for each role type. 
        ///
        /// \param Default WPF click event parameters
        ///
        /// \return Nothing is returned
        ///
        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateUser();
        }


        private void ValidateUser()
        {
            DataController dc = new DataController();
            string user = UserNameInput.Text;
            string pass = PasswordInput.Text;
            string result = dc.ValidateUser(user, pass);

            if (result == "Not Found")
            {
                SignInErrors.Text = "Incorrect username or password";
                return;
            }
            else
            {
                if (result == "Admin")
                {
                    AdminWindow AW = new AdminWindow();
                    AW.Show();
                    this.Close();
                }
                else if (result == "Planner")
                {
                    PlannerWindow PW = new PlannerWindow();
                    PW.Show();
                    this.Close();
                }
                else if (result == "Buyer")
                {
                    BuyerWindow BW = new BuyerWindow();
                    BW.Show();
                    this.Close();
                }
                else
                {
                    SignInErrors.Text = "Sorry, there was a problem signing in. Please try again.";
                }
            }
        }
    }
}
