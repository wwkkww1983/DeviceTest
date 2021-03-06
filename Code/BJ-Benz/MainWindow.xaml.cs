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
using System.Windows.Shapes;

namespace BJ_Benz
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new ViewModel();
            this.DataContext = viewModel;

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            this.SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            viewModel.LineEndPoint = new Point(e.NewSize.Width, 1);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.Init();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Dispose();
        }
    }
}
