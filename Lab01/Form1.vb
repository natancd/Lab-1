' **************************************************************************************************************************************************/
' * Lab 1: Average Units Shipped
' * Program: Lab01                                            
' * Course: NET DEVELOPMENT I (NETD-2202)                                                                 
' * Author:      Natan Colavite Dellagiustina  - 100722419                                    
' * Date:        January 25th, 2019 
' *                                                                                
' * Description:                                                                    
' *              This program will prompt the user a form where they must insert a unity shipped between 0 and 1000, only whole numbers
' *              and will store it in another text box, where the user can see which units were entered. Everytime a number is entered,
' *              the label showing the day will update and, at the end of all seven days, a label will prompt the user the average of units
' *              that were shipped. Then the user will have the option to reset the program by clicking in the reset button or exit, clicking
' *              exit button or the "X" in the top right corner. If the user enter a non-numeric character or any number that is not an integer
' *              and that isn't in the range of 0 to 1000, the bottom label will prompt an error message and move the focus back to the wrong
' *              value entered and select it, making it possible just to retype the correct information. At any time, the user can reset the
' *              form by clicking the reset button or pressing "Esc". By doing that, the program will reset to its default form, starting from Day 1.
' *              The average will be displayed in two decimal places.
' **************************************************************************************************************************************************/
Option Strict On
Public Class frmAverageUnitsShipped
    ' DECLARATIONS
    ' CONSTANTS
    Const MININUM_INPUT = 0
    Const MAXIMUM_INPUT = 1000
    Const MAXIMUM_DAYS As Integer = 7
    ' VARIABLES
    Dim userInput As Integer = 0 ' The user input number
    Dim userUnits(MAXIMUM_DAYS - 1) As Integer ' Array with all user inputs
    Dim sumOfTotal As Double = 0 ' Sum of total inputs
    Dim dayCounter As Integer = 1 ' Counter of the day
    Dim unitsAverage As Double = 0.0 ' The average

    Private Sub frmAverageUnitsShipped_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' This button will reset everything to the default value
        txtUserInput.ResetText()
        txtUserUnits.ResetText()
        txtUserInput.ReadOnly = False
        lblAverage.Text = ""
        lblDays.Text = "Day 1"
        btnEnter.Enabled = True
        txtUserInput.Focus()
        dayCounter = 1
        sumOfTotal = 0.0

    End Sub

    Private Sub txtUserInput_TextChanged(sender As Object, e As EventArgs) Handles txtUserInput.TextChanged
    End Sub

    Private Sub txtUserUnits_TextChanged(sender As Object, e As EventArgs) Handles txtUserUnits.TextChanged

    End Sub

    Private Sub lblAverage_Click(sender As Object, e As EventArgs) Handles lblAverage.Click
        Dim unitsAverage As String = "" ' Variable for the label to have an empty string
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        ' Loop to check if the input is a number
        If (Integer.TryParse(txtUserInput.Text, userInput)) Then
            ' If it is a number, this loop will check if it is between the range and store it in the array and display in the text box to the user see what values he entered
            If (userInput <= MAXIMUM_INPUT And userInput >= MININUM_INPUT) Then

                userUnits(dayCounter - 1) = userInput
                txtUserUnits.Text += userInput.ToString & vbCrLf

                ' If the number passes both checks and stored the input, then it will loop to check if the counter of the day is lesser than the maximum value set in the constant
                If (dayCounter < MAXIMUM_DAYS) Then

                    ' If the counter is less than the maximum value set, then it will loop until the maximum possible value and display the current day in the label
                    dayCounter = dayCounter + 1
                    lblDays.Text = "Day " + dayCounter.ToString()

                    ' If there were any message in the label, it will make it empty, then move the focus back to the text box again
                    lblAverage.Text = ""
                    txtUserInput.Clear()
                    txtUserInput.Focus()

                Else
                    ' When the counter of the day reach the maximum value set, the program will calculate all stored values and make a sum of them
                    For unitCounter As Integer = 0 To userUnits.Length - 1
                        sumOfTotal += (userUnits(unitCounter))
                    Next
                    ' The program will make the text box as a read only and the button Enter will be disabled, so the user cannot enter any more information
                    txtUserInput.ReadOnly = True
                    txtUserInput.Clear()
                    btnEnter.Enabled = False

                    ' The program will calculate the average per day and display in the label with two decimal places
                    unitsAverage = sumOfTotal / MAXIMUM_DAYS
                    lblAverage.Text = "Average per day: " + FormatNumber(unitsAverage.ToString, 2)

                End If

            Else
                ' If the user didn't enter a number between the range, it will display an error message in the label below the list
                lblAverage.Text = "Units must be between 0 and 1000 inclusive!"
                txtUserInput.SelectAll()

            End If
        Else
            ' If the user didn't a whole number or entered any character than a whole number, it will display an error message in the label below the list
            lblAverage.Text = "Please enter a whole number only."
            txtUserInput.SelectAll()

        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Close the program
        Me.Close()
    End Sub
End Class
