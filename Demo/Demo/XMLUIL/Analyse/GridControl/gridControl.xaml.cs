﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Demo.Annotations;
using Demo.Business;
using DevExpress.Data.XtraReports.Wizard.Native;
using DevExpress.Xpo.DB;
using XMLAnalyzer.Business;

namespace Demo.XMLUIL.Analyse.GridControl
{
    /// <summary>
    /// Interaction logic for gridControl.xaml
    /// </summary>
    public partial class gridControl
    {
        public gridControl()
        {
            InitializeComponent();
            DataContext = Domain.Instance;
          
        }

    
    }
}
