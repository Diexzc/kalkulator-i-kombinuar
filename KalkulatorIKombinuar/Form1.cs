using System.Globalization;

namespace KalkulatorIKombinuar;

public partial class Form1 : Form
{
    private readonly string _decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    private double? _firstOperand;
    private string? _pendingBinaryOperation;
    private double? _lastOperand;
    private string? _lastBinaryOperation;
    private double _memoryValue;
    private bool _hasMemoryValue;
    private bool _replaceDisplayOnNextInput = true;
    private bool _showingResult;
    private bool _isErrorState;

    public Form1()
    {
        InitializeComponent();
        InitializeCalculator();
    }

    private void InitializeCalculator()
    {
        btnDecimal.Text = _decimalSeparator;
        cmbMode.SelectedIndex = 0;
        UpdateMemoryIndicator();
        UpdateHistoryButtonState();
    }

    private void DigitButton_Click(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            InputDigit(button.Text);
        }
    }

    private void DecimalButton_Click(object? sender, EventArgs e)
    {
        InputDecimal();
    }

    private void BinaryOperatorButton_Click(object? sender, EventArgs e)
    {
        if (sender is Button { Tag: string operation })
        {
            SetPendingBinaryOperation(operation);
        }
    }

    private void UnaryOperatorButton_Click(object? sender, EventArgs e)
    {
        if (sender is Button { Tag: string operation })
        {
            ApplyUnaryOperation(operation);
        }
    }

    private void PercentButton_Click(object? sender, EventArgs e)
    {
        ApplyPercent();
    }

    private void SignButton_Click(object? sender, EventArgs e)
    {
        ToggleSign();
    }

    private void EqualsButton_Click(object? sender, EventArgs e)
    {
        ExecuteEquals();
    }

    private void ClearEntryButton_Click(object? sender, EventArgs e)
    {
        ClearEntry();
    }

    private void ClearAllButton_Click(object? sender, EventArgs e)
    {
        ClearAll();
    }

    private void BackspaceButton_Click(object? sender, EventArgs e)
    {
        Backspace();
    }

    private void MemoryButton_Click(object? sender, EventArgs e)
    {
        if (sender is not Button { Tag: string action })
        {
            return;
        }

        switch (action)
        {
            case "mc":
                ClearMemory();
                break;
            case "mr":
                RecallMemory();
                break;
            case "mplus":
                AddToMemory();
                break;
            case "mminus":
                SubtractFromMemory();
                break;
            case "ms":
                StoreMemory();
                break;
        }
    }

    private void BtnClearHistory_Click(object? sender, EventArgs e)
    {
        lstHistory.Items.Clear();
        UpdateHistoryButtonState();
    }

    private void LstHistory_DoubleClick(object? sender, EventArgs e)
    {
        if (lstHistory.SelectedItem is not string entry)
        {
            return;
        }

        var equalsIndex = entry.LastIndexOf('=');
        var resultText = equalsIndex >= 0 ? entry[(equalsIndex + 1)..].Trim() : entry.Trim();

        lblDisplay.Text = resultText;
        lblExpression.Text = entry;
        _replaceDisplayOnNextInput = true;
        _showingResult = true;
        _isErrorState = false;
    }

    private void CmbMode_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var scientificMode = string.Equals(cmbMode.SelectedItem?.ToString(), "Scientific", StringComparison.Ordinal);
        scientificHost.Visible = scientificMode;
        lblAngleMode.Visible = scientificMode;
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (!e.Shift && e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
        {
            InputDigit(((int)(e.KeyCode - Keys.D0)).ToString(CultureInfo.InvariantCulture));
            MarkKeyAsHandled(e);
            return;
        }

        if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
        {
            InputDigit(((int)(e.KeyCode - Keys.NumPad0)).ToString(CultureInfo.InvariantCulture));
            MarkKeyAsHandled(e);
            return;
        }

        if (e.KeyCode == Keys.D8 && e.Shift)
        {
            SetPendingBinaryOperation("multiply");
            MarkKeyAsHandled(e);
            return;
        }

        switch (e.KeyCode)
        {
            case Keys.Oemplus when e.Shift:
            case Keys.Add:
                SetPendingBinaryOperation("add");
                MarkKeyAsHandled(e);
                break;

            case Keys.OemMinus:
            case Keys.Subtract:
                SetPendingBinaryOperation("subtract");
                MarkKeyAsHandled(e);
                break;

            case Keys.Divide:
            case Keys.OemQuestion:
                SetPendingBinaryOperation("divide");
                MarkKeyAsHandled(e);
                break;

            case Keys.Decimal:
            case Keys.OemPeriod:
            case Keys.Oemcomma:
                InputDecimal();
                MarkKeyAsHandled(e);
                break;

            case Keys.Enter:
            case Keys.Oemplus:
                ExecuteEquals();
                MarkKeyAsHandled(e);
                break;

            case Keys.Back:
                Backspace();
                MarkKeyAsHandled(e);
                break;

            case Keys.Delete:
                ClearEntry();
                MarkKeyAsHandled(e);
                break;

            case Keys.Escape:
                ClearAll();
                MarkKeyAsHandled(e);
                break;

            case Keys.F9:
                ToggleSign();
                MarkKeyAsHandled(e);
                break;
        }
    }

    private static void MarkKeyAsHandled(KeyEventArgs e)
    {
        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    private void InputDigit(string digit)
    {
        if (_isErrorState)
        {
            ClearAll();
        }

        if (_showingResult && _pendingBinaryOperation is null)
        {
            lblExpression.Text = string.Empty;
        }

        if (_replaceDisplayOnNextInput || lblDisplay.Text == "0")
        {
            lblDisplay.Text = digit == "0" ? "0" : digit;
        }
        else
        {
            lblDisplay.Text += digit;
        }

        _replaceDisplayOnNextInput = false;
        _showingResult = false;
    }

    private void InputDecimal()
    {
        if (_isErrorState)
        {
            ClearAll();
        }

        if (_showingResult && _pendingBinaryOperation is null)
        {
            lblExpression.Text = string.Empty;
        }

        if (_replaceDisplayOnNextInput)
        {
            lblDisplay.Text = $"0{_decimalSeparator}";
            _replaceDisplayOnNextInput = false;
            _showingResult = false;
            return;
        }

        if (!lblDisplay.Text.Contains(_decimalSeparator, StringComparison.Ordinal))
        {
            lblDisplay.Text += _decimalSeparator;
        }
    }

    private void SetPendingBinaryOperation(string operation)
    {
        if (_isErrorState)
        {
            return;
        }

        var currentValue = GetDisplayValue();

        if (_pendingBinaryOperation is not null && _firstOperand.HasValue && !_replaceDisplayOnNextInput)
        {
            if (!TryApplyBinaryOperation(_firstOperand.Value, currentValue, _pendingBinaryOperation, out var chainedResult, out var errorMessage))
            {
                ShowError(errorMessage);
                return;
            }

            _firstOperand = chainedResult;
            lblDisplay.Text = FormatValue(chainedResult);
        }
        else
        {
            _firstOperand = currentValue;
        }

        _pendingBinaryOperation = operation;
        _lastBinaryOperation = null;
        _lastOperand = null;
        _replaceDisplayOnNextInput = true;
        _showingResult = false;
        lblExpression.Text = $"{FormatValue(_firstOperand.Value)} {GetOperatorSymbol(operation)}";
    }

    private void ExecuteEquals()
    {
        if (_isErrorState)
        {
            return;
        }

        var currentValue = GetDisplayValue();

        if (_pendingBinaryOperation is not null && _firstOperand.HasValue)
        {
            if (!TryApplyBinaryOperation(_firstOperand.Value, currentValue, _pendingBinaryOperation, out var result, out var errorMessage))
            {
                ShowError(errorMessage);
                return;
            }

            var historyEntry = $"{FormatValue(_firstOperand.Value)} {GetOperatorSymbol(_pendingBinaryOperation)} {FormatValue(currentValue)} = {FormatValue(result)}";
            AddHistoryEntry(historyEntry);

            lblExpression.Text = historyEntry;
            lblDisplay.Text = FormatValue(result);
            _lastBinaryOperation = _pendingBinaryOperation;
            _lastOperand = currentValue;
            _firstOperand = result;
            _pendingBinaryOperation = null;
            _replaceDisplayOnNextInput = true;
            _showingResult = true;
            return;
        }

        if (_lastBinaryOperation is null || !_lastOperand.HasValue)
        {
            return;
        }

        if (!TryApplyBinaryOperation(currentValue, _lastOperand.Value, _lastBinaryOperation, out var repeatedResult, out var repeatedError))
        {
            ShowError(repeatedError);
            return;
        }

        var repeatedEntry = $"{FormatValue(currentValue)} {GetOperatorSymbol(_lastBinaryOperation)} {FormatValue(_lastOperand.Value)} = {FormatValue(repeatedResult)}";
        AddHistoryEntry(repeatedEntry);

        lblExpression.Text = repeatedEntry;
        lblDisplay.Text = FormatValue(repeatedResult);
        _firstOperand = repeatedResult;
        _replaceDisplayOnNextInput = true;
        _showingResult = true;
    }

    private void ApplyUnaryOperation(string operation)
    {
        if (_isErrorState)
        {
            return;
        }

        var currentValue = GetDisplayValue();

        if (!TryApplyUnaryOperation(currentValue, operation, out var result, out var errorMessage, out var description))
        {
            ShowError(errorMessage);
            return;
        }

        lblDisplay.Text = FormatValue(result);

        if (_pendingBinaryOperation is not null && _firstOperand.HasValue)
        {
            lblExpression.Text = $"{FormatValue(_firstOperand.Value)} {GetOperatorSymbol(_pendingBinaryOperation)} {description}";
        }
        else
        {
            var historyEntry = $"{description} = {FormatValue(result)}";
            AddHistoryEntry(historyEntry);
            lblExpression.Text = historyEntry;
            _showingResult = true;
        }

        _replaceDisplayOnNextInput = true;
    }

    private void ApplyPercent()
    {
        if (_isErrorState)
        {
            return;
        }

        var currentValue = GetDisplayValue();
        double result;

        if (_pendingBinaryOperation is not null && _firstOperand.HasValue)
        {
            result = _pendingBinaryOperation is "add" or "subtract"
                ? _firstOperand.Value * currentValue / 100D
                : currentValue / 100D;

            lblExpression.Text = $"{FormatValue(_firstOperand.Value)} {GetOperatorSymbol(_pendingBinaryOperation)} {FormatValue(result)}";
        }
        else
        {
            result = currentValue / 100D;
            var historyEntry = $"{FormatValue(currentValue)} % = {FormatValue(result)}";
            AddHistoryEntry(historyEntry);
            lblExpression.Text = historyEntry;
            _showingResult = true;
        }

        lblDisplay.Text = FormatValue(result);
        _replaceDisplayOnNextInput = true;
    }

    private void ToggleSign()
    {
        if (_isErrorState)
        {
            return;
        }

        var currentValue = GetDisplayValue();

        if (Math.Abs(currentValue) < 1E-12)
        {
            return;
        }

        lblDisplay.Text = FormatValue(-currentValue);
        _replaceDisplayOnNextInput = false;
        _showingResult = false;
    }

    private void ClearEntry()
    {
        if (_isErrorState)
        {
            ClearAll();
            return;
        }

        lblDisplay.Text = "0";
        _replaceDisplayOnNextInput = true;
        _showingResult = false;
    }

    private void ClearAll()
    {
        _firstOperand = null;
        _pendingBinaryOperation = null;
        _lastOperand = null;
        _lastBinaryOperation = null;
        _replaceDisplayOnNextInput = true;
        _showingResult = false;
        _isErrorState = false;
        lblDisplay.Text = "0";
        lblExpression.Text = string.Empty;
    }

    private void Backspace()
    {
        if (_isErrorState)
        {
            ClearAll();
            return;
        }

        if (_replaceDisplayOnNextInput)
        {
            return;
        }

        if (lblDisplay.Text.Length <= 1 ||
            (lblDisplay.Text.Length == 2 && lblDisplay.Text.StartsWith("-", StringComparison.Ordinal)))
        {
            lblDisplay.Text = "0";
            _replaceDisplayOnNextInput = true;
            return;
        }

        lblDisplay.Text = lblDisplay.Text[..^1];

        if (lblDisplay.Text.EndsWith(_decimalSeparator, StringComparison.Ordinal))
        {
            lblDisplay.Text = lblDisplay.Text[..^_decimalSeparator.Length];
        }

        if (lblDisplay.Text is "" or "-")
        {
            lblDisplay.Text = "0";
            _replaceDisplayOnNextInput = true;
        }
    }

    private void ClearMemory()
    {
        _memoryValue = 0;
        _hasMemoryValue = false;
        UpdateMemoryIndicator();
    }

    private void RecallMemory()
    {
        if (!_hasMemoryValue)
        {
            return;
        }

        lblDisplay.Text = FormatValue(_memoryValue);
        _replaceDisplayOnNextInput = true;
        _showingResult = false;
        _isErrorState = false;
    }

    private void StoreMemory()
    {
        _memoryValue = GetDisplayValue();
        _hasMemoryValue = true;
        UpdateMemoryIndicator();
    }

    private void AddToMemory()
    {
        _memoryValue = (_hasMemoryValue ? _memoryValue : 0D) + GetDisplayValue();
        _hasMemoryValue = true;
        UpdateMemoryIndicator();
    }

    private void SubtractFromMemory()
    {
        _memoryValue = (_hasMemoryValue ? _memoryValue : 0D) - GetDisplayValue();
        _hasMemoryValue = true;
        UpdateMemoryIndicator();
    }

    private void UpdateMemoryIndicator()
    {
        lblMemoryFlag.Visible = _hasMemoryValue;
    }

    private void UpdateHistoryButtonState()
    {
        btnClearHistory.Enabled = lstHistory.Items.Count > 0;
    }

    private void AddHistoryEntry(string entry)
    {
        if (string.IsNullOrWhiteSpace(entry))
        {
            return;
        }

        lstHistory.Items.Insert(0, entry);
        lstHistory.SelectedIndex = 0;
        UpdateHistoryButtonState();
    }

    private double GetDisplayValue()
    {
        return double.TryParse(lblDisplay.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out var value)
            ? value
            : 0D;
    }

    private static string FormatValue(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
        {
            return "Error";
        }

        if (Math.Abs(value) < 1E-12)
        {
            value = 0;
        }

        return value.ToString("G15", CultureInfo.CurrentCulture);
    }

    private static string GetOperatorSymbol(string operation)
    {
        return operation switch
        {
            "add" => "+",
            "subtract" => "-",
            "multiply" => "*",
            "divide" => "/",
            "power" => "^",
            _ => operation
        };
    }

    private static bool TryApplyBinaryOperation(double left, double right, string operation, out double result, out string errorMessage)
    {
        result = 0D;
        errorMessage = string.Empty;

        switch (operation)
        {
            case "add":
                result = left + right;
                return true;

            case "subtract":
                result = left - right;
                return true;

            case "multiply":
                result = left * right;
                return true;

            case "divide":
                if (Math.Abs(right) < 1E-12)
                {
                    errorMessage = "Cannot divide by zero.";
                    return false;
                }

                result = left / right;
                return true;

            case "power":
                result = Math.Pow(left, right);
                return true;

            default:
                errorMessage = "Unsupported operation.";
                return false;
        }
    }

    private static bool TryApplyUnaryOperation(double value, string operation, out double result, out string errorMessage, out string description)
    {
        result = 0D;
        errorMessage = string.Empty;
        description = string.Empty;

        switch (operation)
        {
            case "square":
                result = value * value;
                description = $"sqr({FormatValue(value)})";
                return true;

            case "sqrt":
                if (value < 0)
                {
                    errorMessage = "Cannot calculate square root of a negative number.";
                    return false;
                }

                result = Math.Sqrt(value);
                description = $"sqrt({FormatValue(value)})";
                return true;

            case "reciprocal":
                if (Math.Abs(value) < 1E-12)
                {
                    errorMessage = "Cannot divide by zero.";
                    return false;
                }

                result = 1D / value;
                description = $"1/({FormatValue(value)})";
                return true;

            case "sin":
                result = Math.Sin(ToRadians(value));
                description = $"sin({FormatValue(value)})";
                return true;

            case "cos":
                result = Math.Cos(ToRadians(value));
                description = $"cos({FormatValue(value)})";
                return true;

            case "tan":
                result = Math.Tan(ToRadians(value));
                description = $"tan({FormatValue(value)})";
                return true;

            case "log":
                if (value <= 0)
                {
                    errorMessage = "Logarithm is defined only for positive numbers.";
                    return false;
                }

                result = Math.Log10(value);
                description = $"log({FormatValue(value)})";
                return true;

            case "ln":
                if (value <= 0)
                {
                    errorMessage = "Natural logarithm is defined only for positive numbers.";
                    return false;
                }

                result = Math.Log(value);
                description = $"ln({FormatValue(value)})";
                return true;

            default:
                errorMessage = "Unsupported operation.";
                return false;
        }
    }

    private static double ToRadians(double degrees)
    {
        return degrees * (Math.PI / 180D);
    }

    private void ShowError(string message)
    {
        _firstOperand = null;
        _pendingBinaryOperation = null;
        _lastOperand = null;
        _lastBinaryOperation = null;
        _replaceDisplayOnNextInput = true;
        _showingResult = false;
        _isErrorState = true;
        lblDisplay.Text = "Error";
        lblExpression.Text = message;
    }
}
