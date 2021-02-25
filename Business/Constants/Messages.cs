using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandListed = "Markalar listelendi.";

        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarFailedAddOrUpdate = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz veya araç ismini iki karakterden uzun giriniz";
        public static string CarListed = "Arabalar listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renkler listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";

        public static string RentalAdded = "Araba kiralandı.";
        public static string RentalDeleted = "Araba kiralanması iptal edildi.";
        public static string RentalUpdated = "Araba kiralanması güncellendi.";
        public static string RentalListed = "Araba kiralanmaları listelendi.";
        public static string RentalFailedAdded = "Araba kiralanamaz. Önceki müşteri teslim etmemiş";
        public static string RentalReturn = "Araba teslim edildi.";
        public static string RentalErrorReturn = "Araba önceden teslim edilmiş";

        public static string CarImagesAdded = "Araba resimleri eklendi.";
        public static string CarImagesDeleted = "Araba resimleri silindi.";
        public static string CarImagesUpdated = "Araba resimleri güncellendi.";
        public static string CarImagesListed = "Araba resimleri listelendi.";
        public static string CarImagesCountError = "Araba resimleri en fazla 5 olabilir";
    }
}
