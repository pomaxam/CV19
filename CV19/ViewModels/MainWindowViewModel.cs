﻿using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CV19.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region A : TYPE - DESCRIPTION

        /// <summary>Тестовый набор данных для визуализации графиков</summary>
        private IEnumerable<DataPoint> _TestDataPoints;
        /// <summary>Тестовый набор данных для визуализации графиков</summary>
        public IEnumerable<DataPoint> TestDataPoints {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }
        #endregion

        #region Заголовок окна

        private string _Title = "Анализ статистики CV19";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            /*set
            {
                //if (Equals(_Title, value)) return;
                //_Title = value;
                //OnPropertyChanged();

                Set(ref _Title, value);
            }*/
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status : string - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        
        public string Status
        {
            get => _Status; 
            set => Set(ref _Status, value);
        }

        #endregion

        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int) (360 / 0.1));
            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;
        }
    }
}
