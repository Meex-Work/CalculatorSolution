::: mermaid
stateDiagram-v2
    [*] --> Start
    
    Start --> Start: Equal, Backspace, Clear, 0
    Start --> FirstNumber: Number
    Start --> FirstNumberDecimal: Decimal
    Start --> Operator: Operator
    
    FirstNumber --> FirstNumber: Number, Equal
    FirstNumber --> FirstIsEmpty: Backspace
    FirstNumber --> FirstNumberDecimal: Decimal
    FirstNumber --> Operator: Operator
    FirstNumber --> Start: Clear
    
    FirstIsEmpty --> if_state4
    if_state4 --> Start: if input is empty
    if_state4 --> FirstNumber: if input is not empty
    
    FirstNumberDecimal --> FirstNumberDecimal: Number, Decimal, Equal
    FirstNumberDecimal --> Operator: Operator
    FirstNumberDecimal --> IsFirstNumberDecimal: BackSpace
    FirstNumberDecimal --> Start: Clear
    
    IsFirstNumberDecimal --> if_state2
    if_state2 --> FirstNumberDecimal: if char != '.'
    if_state2 --> FirstNumber: if char == '.'
    
    Operator --> Operator: Operator, BackSpace, 0
    Operator --> SecondNumberDecimal: Decimal
    Operator --> SecondNumber: Number
    Operator --> Result: Equal
    Operator --> Start: Clear
    
    SecondNumber --> SecondNumber: Number, Operator
    SecondNumber --> SecondIsEmpty: Backspace
    SecondNumber --> SecondNumberDecimal: Decimal
    SecondNumber --> Result: Equal
    SecondNumber --> Start: Clear
    
    SecondIsEmpty --> if_state5
    if_state5 --> Operator: if input is empty
    if_state5 --> SecondNumber: if input is not empty
    
    SecondNumberDecimal --> SecondNumberDecimal: Number, Decimal, Operator
    SecondNumberDecimal --> Result: Equal
    SecondNumberDecimal --> IsSecondNumberDecimal: Backspace
    SecondNumberDecimal --> Start: Clear
    
    IsSecondNumberDecimal --> if_state3
    if_state3 --> SecondNumberDecimal: if char != '.'
    if_state3 --> SecondNumber: if char == '.'
    
    
    Result --> Start: Clear, Backspace, 0
    Result --> Result: Equal
    Result --> FirstNumber: Number
    Result --> FirstNumberDecimal: Decimal
    Result --> Operator: Operator
:::