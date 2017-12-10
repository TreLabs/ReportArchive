<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GoButton = New System.Windows.Forms.Button()
        Me.OutBoxUAT = New System.Windows.Forms.ListBox()
        Me.OutBoxStage = New System.Windows.Forms.ListBox()
        Me.OutBoxProd = New System.Windows.Forms.ListBox()
        Me.CB_UAT = New System.Windows.Forms.CheckBox()
        Me.CB_Stage = New System.Windows.Forms.CheckBox()
        Me.CB_Prod = New System.Windows.Forms.CheckBox()
        Me.CB_All = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.Location = New System.Drawing.Point(31, 465)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(50, 30)
        Me.GoButton.TabIndex = 0
        Me.GoButton.Text = "Go"
        Me.GoButton.UseVisualStyleBackColor = True
        '
        'OutBoxUAT
        '
        Me.OutBoxUAT.FormattingEnabled = True
        Me.OutBoxUAT.Location = New System.Drawing.Point(103, 309)
        Me.OutBoxUAT.Name = "OutBoxUAT"
        Me.OutBoxUAT.ScrollAlwaysVisible = True
        Me.OutBoxUAT.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.OutBoxUAT.Size = New System.Drawing.Size(951, 121)
        Me.OutBoxUAT.TabIndex = 1
        '
        'OutBoxStage
        '
        Me.OutBoxStage.FormattingEnabled = True
        Me.OutBoxStage.Location = New System.Drawing.Point(103, 169)
        Me.OutBoxStage.Name = "OutBoxStage"
        Me.OutBoxStage.ScrollAlwaysVisible = True
        Me.OutBoxStage.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.OutBoxStage.Size = New System.Drawing.Size(951, 121)
        Me.OutBoxStage.TabIndex = 2
        '
        'OutBoxProd
        '
        Me.OutBoxProd.FormattingEnabled = True
        Me.OutBoxProd.Location = New System.Drawing.Point(103, 30)
        Me.OutBoxProd.Name = "OutBoxProd"
        Me.OutBoxProd.ScrollAlwaysVisible = True
        Me.OutBoxProd.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.OutBoxProd.Size = New System.Drawing.Size(951, 121)
        Me.OutBoxProd.TabIndex = 3
        '
        'CB_UAT
        '
        Me.CB_UAT.AutoSize = True
        Me.CB_UAT.Location = New System.Drawing.Point(12, 309)
        Me.CB_UAT.Name = "CB_UAT"
        Me.CB_UAT.Size = New System.Drawing.Size(48, 17)
        Me.CB_UAT.TabIndex = 4
        Me.CB_UAT.Text = "UAT"
        Me.CB_UAT.UseVisualStyleBackColor = True
        '
        'CB_Stage
        '
        Me.CB_Stage.AutoSize = True
        Me.CB_Stage.Location = New System.Drawing.Point(12, 169)
        Me.CB_Stage.Name = "CB_Stage"
        Me.CB_Stage.Size = New System.Drawing.Size(54, 17)
        Me.CB_Stage.TabIndex = 5
        Me.CB_Stage.Text = "Stage"
        Me.CB_Stage.UseVisualStyleBackColor = True
        '
        'CB_Prod
        '
        Me.CB_Prod.AutoSize = True
        Me.CB_Prod.Location = New System.Drawing.Point(12, 30)
        Me.CB_Prod.Name = "CB_Prod"
        Me.CB_Prod.Size = New System.Drawing.Size(77, 17)
        Me.CB_Prod.TabIndex = 6
        Me.CB_Prod.Text = "Production"
        Me.CB_Prod.UseVisualStyleBackColor = True
        '
        'CB_All
        '
        Me.CB_All.AutoSize = True
        Me.CB_All.Location = New System.Drawing.Point(12, 422)
        Me.CB_All.Name = "CB_All"
        Me.CB_All.Size = New System.Drawing.Size(37, 17)
        Me.CB_All.TabIndex = 7
        Me.CB_All.Text = "All"
        Me.CB_All.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 533)
        Me.Controls.Add(Me.CB_All)
        Me.Controls.Add(Me.CB_Prod)
        Me.Controls.Add(Me.CB_Stage)
        Me.Controls.Add(Me.CB_UAT)
        Me.Controls.Add(Me.OutBoxProd)
        Me.Controls.Add(Me.OutBoxStage)
        Me.Controls.Add(Me.OutBoxUAT)
        Me.Controls.Add(Me.GoButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GoButton As Button
    Friend WithEvents OutBoxUAT As ListBox
    Friend WithEvents OutBoxStage As ListBox
    Friend WithEvents OutBoxProd As ListBox
    Friend WithEvents CB_UAT As CheckBox
    Friend WithEvents CB_Stage As CheckBox
    Friend WithEvents CB_Prod As CheckBox
    Friend WithEvents CB_All As CheckBox
End Class
