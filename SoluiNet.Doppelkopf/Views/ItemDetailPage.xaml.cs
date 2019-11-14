// <copyright file="ItemDetailPage.xaml.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf.Views
{
    using System;
    using System.ComponentModel;

    using SoluiNet.Doppelkopf.Models;
    using SoluiNet.Doppelkopf.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            this.InitializeComponent();

            this.BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            this.InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description.",
            };

            this.viewModel = new ItemDetailViewModel(item);
            this.BindingContext = this.viewModel;
        }
    }
}