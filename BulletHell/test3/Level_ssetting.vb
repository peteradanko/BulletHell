Module Level_ssetting
    Public Sub level_active()
        If level_count = 5 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(Int(Rnd() * 480), 0))
        ElseIf level_count = 10 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(10, 0))
        ElseIf level_count = 11 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(30, 0))
        ElseIf level_count = 12 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(50, 0))
        ElseIf level_count = 13 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(80, 0))
        ElseIf level_count = 14 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(110, 0))
        ElseIf level_count = 15 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(130, 0))
        ElseIf level_count = 16 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(150, 0))
        ElseIf level_count = 17 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(170, 0))
        ElseIf level_count = 18 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(190, 0))
        ElseIf level_count = 19 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point(210, 0))
        ElseIf level_count = 20 Then
            enemy_create(1, 100, Color.DarkRed, 60, New Point(240, 0))
        ElseIf level_count > 20 And level_count < 180 Then
            enemy_create(1, 10, Color.DarkRed, 40, New Point((Rnd() * 480), 0))
        ElseIf level_count = 180 Then
            enemy_create(99, 1500, Color.DarkRed, 100, New Point(240, 0))
            Form1.Timer_Level_Counter.Enabled = False
        ElseIf level_count > 185 And level_count < 200 Then
            enemy_create(2, 15, Color.DarkRed, 40, New Point((Rnd() * 480), 10))
        End If
    End Sub
End Module
