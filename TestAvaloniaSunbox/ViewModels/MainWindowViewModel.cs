using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using System;

namespace TestAvaloniaSunbox.ViewModels;

public class MainWindowViewModel : ReactiveObject, IValidatableViewModel
{
    [Reactive]
    public int? Value { get; set; }

    public MainWindowViewModel()
    {
        IObservable<bool> valtest =
            this.WhenAnyValue(
                x => x.Value,
                (v) => v != 0 && v != null);

        this.ValidationRule(
            vm => vm.Value, // The property name selector expression.
            valtest, // IObservable<bool>
            "You should set NumericUpDown value!");
    }

    public ValidationContext ValidationContext { get; } = new ValidationContext();
}