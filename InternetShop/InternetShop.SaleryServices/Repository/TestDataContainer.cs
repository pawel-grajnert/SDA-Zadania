using InternetShop.SalaryServices.Entities;

namespace InternetShop.SalaryServices.Repository;

public static class TestDataContainer
{
    public static List<Product> Products => new()
    {
        new () {Id = 1, Name = "Paczka Śrub", Description = "opis", TotalPrice = 17.99m },
        new () {Id = 1, Name = "Deska sedesowa", Description = "opis", TotalPrice = 22.42m },
        new () {Id = 1, Name = "Zaprawa gipsowa 10Kg", Description = "opis", TotalPrice = 95.77m },
        new () {Id = 1, Name = "Miara 3M", Description = "opis", TotalPrice = 2.10m },
        new () {Id = 1, Name = "tytanowe wiertło 55 mm", Description = "opis", TotalPrice = 199.99m },
        new () {Id = 1, Name = "Wiertara do ścian zbrojonych i sąsiadów", Description = "opis", TotalPrice = 1970.00m },
        new () {Id = 1, Name = "Młotek", Description = "opis", TotalPrice = 35.44m },
        new () {Id = 1, Name = "Zestaw Śrubokretów", Description = "opis", TotalPrice = 55.00m },
        new () {Id = 1, Name = "Paczka Gwoździ", Description = "opis", TotalPrice = 6.50m },
        new () {Id = 1, Name = "Wiertło", Description = "opis", TotalPrice = 0.55m },
    };
}