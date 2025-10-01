Public Class CCategory
    Private _strCatName As String
    Private _dblTotalValue As Double
    Private _intToralCount As Integer
    'constructor
    Public Sub New(strName As String, dbValue As Double)
        _strcatName = strName
        _dblTotalValue = dbValue
        _intToralCount = 1
    End Sub
    Public ReadOnly Property CatName() As String
        Get
            Return _strCatName
        End Get
    End Property
    Public Property TotalValue() As Double
        Get
            Return _dblTotalValue
        End Get
        Set(dblVal As Double)
            _dblTotalValue = _dblVal
        End Set
    End Property
    Public Property TotalCount() As Integer
        Get
            Return _intToralCount
        End Get
        Set(intVal As Integer)
            _intToralCount = intVal()
        End Set
    End Property
End Class
