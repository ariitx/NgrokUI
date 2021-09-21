Namespace Interfaces
    Public Interface IModuleBackground
        Function Run() As Boolean 'function to execute
        ReadOnly Property Cycles As Integer 'number of cycle before try again.
        Property SleepCycle As Integer 'count down until cycle value is hit.
        Property IsDisabled As Boolean 'if set true, this module should be skipped.
    End Interface
End Namespace
