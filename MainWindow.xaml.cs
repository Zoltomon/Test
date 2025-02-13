﻿using System;
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
using Test5.Classes;
using Test5.Controllers;
using Test5.Views;

namespace Test5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutorizationController _controller;
        public MainWindow()
        {
            InitializeComponent();
            NavigateClass.navigate = FrmMain;
            _controller = new AutorizationController();
            FrmMain.Navigate(new LoginPage(_controller));
        }
    }
}
