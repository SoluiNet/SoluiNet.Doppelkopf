using System;

using SoluiNet.Doppelkopf.Models;

namespace SoluiNet.Doppelkopf.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
