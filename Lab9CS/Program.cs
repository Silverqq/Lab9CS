using System;
using System.Collections.Generic;

class Car
{
    public string Model { get; set; }

    public Car(string model)
    {
        Model = model;
    }
}

class Garage
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public delegate void WashCarDelegate(Car car);

    public void WashAllCars(WashCarDelegate washDelegate)
    {
        foreach (Car car in cars)
        {
            washDelegate(car);
        }
    }
}

class Washer
{
    public void Wash(Car car)
    {
        Console.WriteLine($"Моем машину: {car.Model}");
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("BMW");
        Car car2 = new Car("Mazda");

        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);

        Washer washer = new Washer();
        Garage.WashCarDelegate washDelegate = new Garage.WashCarDelegate(washer.Wash);
        garage.WashAllCars(washDelegate);
    }
}
