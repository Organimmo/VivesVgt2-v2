// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Organimmo.DAL;

// Note: there's no reason why developers strictly need to use this. It's equally valid to
// put a @foreach(var message in context.GetValidationMessages()) { ... } inside a form.
// This component is for convenience only, plus it implements a few small perf optimizations.

/// <summary>
/// Displays a list of validation messages from a cascaded <see cref="EditContext"/>.
/// Derived from https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/ValidationSummary.cs
/// </summary>
public class BlazorValidationSummary : ComponentBase, IDisposable
{
    private EditContext? _previousEditContext;
    private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
    private IList<string> GeneralValidationErrors { get; } = new List<string>();

    /// <summary>
    /// Gets or sets the model to produce the list of validation messages for.
    /// When specified, this lists all errors that are associated with the model instance.
    /// </summary>
    [Parameter] public object? Model { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created <c>ul</c> element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    [Parameter] public ValidationSummaryMode Mode { get; set; } = ValidationSummaryMode.All;

    [CascadingParameter] EditContext CurrentEditContext { get; set; } = default!;

    /// <summary>`
    /// Constructs an instance of <see cref="ValidationSummary"/>.
    /// </summary>
    public BlazorValidationSummary()
    {
        _validationStateChangedHandler = (sender, eventArgs) => StateHasChanged();
    }
    
    protected override void OnParametersSet()
    {
        if (CurrentEditContext == null)
        {
            throw new InvalidOperationException($"{nameof(ValidationSummary)} requires a cascading parameter " +
                $"of type {nameof(EditContext)}. For example, you can use {nameof(ValidationSummary)} inside " +
                $"an {nameof(EditForm)}.");
        }

        if (CurrentEditContext != _previousEditContext)
        {
            DetachValidationStateChangedListener();
            CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
            _previousEditContext = CurrentEditContext;
        }
    }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // As an optimization, only evaluate the messages enumerable once, and
        // only produce the enclosing <ul> if there's at least one message
        var validationMessages = GetValidationErrors();

        var first = true;
        foreach (var error in validationMessages)
        {
            if (first)
            {
                first = false;

                builder.OpenElement(0, "ul");
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddAttribute(2, "class", "validation-errors");
            }

            builder.OpenElement(3, "li");
            builder.AddAttribute(4, "class", "validation-message");
            builder.AddContent(5, error);
            builder.CloseElement();
        }

        if (!first)
        {
            // We have at least one validation message.
            builder.CloseElement();
        }
    }

    private IEnumerable<string> GetValidationErrors()
    {
        if (Mode == ValidationSummaryMode.ModelOnly || Mode == ValidationSummaryMode.All)
        {
            foreach (var error in GeneralValidationErrors)
            {
                yield return error;
            }
        }

        if (Mode == ValidationSummaryMode.All)
        {
            var contextErrors = Model is null ?
                CurrentEditContext.GetValidationMessages() :
                CurrentEditContext.GetValidationMessages(new FieldIdentifier(Model, string.Empty));

            foreach (var contextError in contextErrors)
            {
                yield return contextError;
            }
        }
    }

    public void AddValidationError(string error)
    {
        GeneralValidationErrors.Add(error);
        StateHasChanged();
    }

    public void ClearValidationErrors()
    {
        GeneralValidationErrors.Clear();
        CurrentEditContext.Validate();
        StateHasChanged();
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    void IDisposable.Dispose()
    {
        DetachValidationStateChangedListener();
        Dispose(disposing: true);
    }

    private void DetachValidationStateChangedListener()
    {
        if (_previousEditContext != null)
        {
            _previousEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
        }
    }
}

public enum ValidationSummaryMode
{
    None,
    ModelOnly,
    All
}