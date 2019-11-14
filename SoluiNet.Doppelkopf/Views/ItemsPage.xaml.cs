// <copyright file="ItemsPage.xaml.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SoluiNet.Doppelkopf.Models;
    using SoluiNet.Doppelkopf.ViewModels;
    using SoluiNet.Doppelkopf.Views;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemsViewModel viewModel;

        public ItemsPage()
        {
            this.InitializeComponent();

            this.BindingContext = this.viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.viewModel.Items.Count == 0)
            {
                this.viewModel.LoadItemsCommand.Execute(null);
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            await this.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            this.ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}