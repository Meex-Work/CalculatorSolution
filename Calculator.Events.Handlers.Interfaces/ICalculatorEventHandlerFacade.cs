namespace Calculator.Events.Handlers.Interfaces;

/// <summary>
/// Provides a unified facade for handling all calculator button events.
/// </summary>
/// <remarks>
/// This interface serves as a central entry point for processing calculator button interactions,
/// with dedicated methods for each button type that return potentially modified event objects.
/// </remarks>
public interface ICalculatorEventHandlerFacade
{
    /// <summary>
    /// Handles a number button click event.
    /// </summary>
    /// <param name="event">The number button event containing button information</param>
    /// <returns>The processed number button event, potentially modified by the handler</returns>
    public ClickedNumberButtonEvent HandleNumberButtonEvent(ClickedNumberButtonEvent @event);
    
    /// <summary>
    /// Handles a decimal point button click event.
    /// </summary>
    /// <param name="event">The decimal button event containing button information</param>
    /// <returns>The processed decimal button event, potentially modified by the handler</returns>
    public ClickedDecimalButtonEvent HandleDecimalButtonEvent(ClickedDecimalButtonEvent @event);
    
    /// <summary>
    /// Handles an operator button click event.
    /// </summary>
    /// <param name="event">The operator button event containing button information</param>
    /// <returns>The processed operator button event, potentially modified by the handler</returns>
    public ClickedOperatorButtonEvent HandleOperatorButtonEvent(ClickedOperatorButtonEvent @event);
    
    /// <summary>
    /// Handles an equals button click event.
    /// </summary>
    /// <param name="event">The equals button event containing button information</param>
    /// <returns>The processed equals button event, potentially modified by the handler</returns>
    public ClickedEqualButtonEvent HandleEqualButtonEvent(ClickedEqualButtonEvent @event);
    
    /// <summary>
    /// Handles a clear button click event.
    /// </summary>
    /// <param name="event">The clear button event containing button information</param>
    /// <returns>The processed clear button event, potentially modified by the handler</returns>
    public ClickedClearButtonEvent HandleClearButtonEvent(ClickedClearButtonEvent @event);
    
    /// <summary>
    /// Handles a backspace button click event.
    /// </summary>
    /// <param name="event">The backspace button event containing button information</param>
    /// <returns>The processed backspace button event, potentially modified by the handler</returns>
    public ClickedBackspaceButtonEvent HandleBackspaceButtonEvent(ClickedBackspaceButtonEvent @event);
}