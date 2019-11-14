// <copyright file="ItemDetailViewModel.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf.ViewModels
{
    using System;

    using SoluiNet.Doppelkopf.Models;

    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Item item = null)
        {
            this.Title = item?.Text;
            this.Item = item;
        }

        public Item Item { get; set; }
    }
}
