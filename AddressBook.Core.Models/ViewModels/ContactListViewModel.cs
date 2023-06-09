﻿namespace AddressBook.Core.Models.ViewModels
{
    public class ContactListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public bool IsFavorite { get; set; }
    }
}
