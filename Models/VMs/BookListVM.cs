﻿using _80_MVC_IdentityCustomize.Models.Enums;
using System.ComponentModel;

namespace _80_MVC_IdentityCustomize.Models.VMs
{
    public class BookListVM
    {
        public int Id { get; set; }
        [DisplayName("Kitap Adı")]
        public string Title { get; set; }

        [DisplayName("Yazar Adı")]
        public string Author { get; set; }

        [DisplayName("Kitap Durumu")]
        public Status Status { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
