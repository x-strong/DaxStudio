﻿using ADOTabular;
using DaxStudio.UI.ViewModels;
using DaxStudio.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DaxStudio.UI.Behaviours
{
    public class FindReplaceBehavior : Behavior<DocumentView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            CommandBinding FindCommandBinding = new CommandBinding(
                ApplicationCommands.Find,
                FindCommandExecuted,
                FindCommandCanExecute );
            AssociatedObject.CommandBindings.Add(FindCommandBinding);

            CommandBinding ReplaceCommandBinding = new CommandBinding(
                ApplicationCommands.Replace,
                ReplaceCommandExecuted,
                ReplaceCommandCanExecute);
            AssociatedObject.CommandBindings.Add(ReplaceCommandBinding);

        }

        private void FindCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var vm = (DocumentViewModel)AssociatedObject.DataContext;
            vm.Find();
            e.Handled = true;
        }

        private void FindCommandCanExecute(object target, CanExecuteRoutedEventArgs e)
        {    
            e.CanExecute = true;
            e.Handled = true;
        }

        private void ReplaceCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var vm = (DocumentViewModel)AssociatedObject.DataContext;
            vm.Replace();
            e.Handled = true;
        }

        private void ReplaceCommandCanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;   
        }

    }
}
