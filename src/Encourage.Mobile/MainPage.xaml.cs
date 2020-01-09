﻿using System;
using Encourage.Mobile;
using Encourage.Mobile.Data;
using Encourage.Mobile.Models;
using Xamarin.Forms;

namespace Encourage
{
    public partial class MainPage : ContentPage
    {
        readonly EncouragementRepository _encouragementRepository;
        readonly EncouragementDatabase _database;

        public MainPage(EncouragementDatabase database)
        {
            InitializeComponent();
            _database = database;
            _encouragementRepository = new EncouragementRepository(_database);
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var mood = (sender as Button)?.Text ?? "unknown";
            var encouragement = await _encouragementRepository.GetRandomEncouragement(mood);
            await Navigation.PushAsync(new EncouragementPage
            {
                BindingContext = encouragement
            });
        }
    }
}