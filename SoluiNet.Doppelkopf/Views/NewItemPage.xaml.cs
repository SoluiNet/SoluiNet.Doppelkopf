// <copyright file="NewItemPage.xaml.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using SoluiNet.Doppelkopf.Models;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            this.InitializeComponent();

            this.Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description.",
            };

            this.BindingContext = this;
        }

        public Item Item { get; set; }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", this.Item);
            await this.Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }
    }
}