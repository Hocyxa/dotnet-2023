﻿using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class PurchaseRecordViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _shopId;
    [Required]
    public int ShopId
    {
        get => _shopId;
        set => this.RaiseAndSetIfChanged(ref _shopId, value);
    }
    private int _customerId;
    [Required]
    public int CustomerId
    {
        get => _customerId;
        set => this.RaiseAndSetIfChanged(ref _customerId, value);
    }
    private int _productId;
    [Required]
    public int ProductId
    {
        get => _productId;
        set => this.RaiseAndSetIfChanged(ref _productId, value);
    }
    private double _quantity;
    [Required]
    public double Quantity
    {
        get => _quantity;
        set => this.RaiseAndSetIfChanged(ref _quantity, value);
    }
    private DateTimeOffset _dateSale;
    [Required]
    public DateTimeOffset DateSale
    {
        get => _dateSale;
        set => this.RaiseAndSetIfChanged(ref _dateSale, value);
    }
    private double _sum;
    public double Sum
    {
        get => _sum;
        set => this.RaiseAndSetIfChanged(ref _sum, value);
    }
    public ReactiveCommand<Unit, PurchaseRecordViewModel> OnSubmitCommand { get; }

    public PurchaseRecordViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
