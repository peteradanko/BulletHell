Module AI
    Public Sub AI_active(ByVal enemy As enemy)
        If enemy.Type = 1 Then
            enemy.Ly = enemy.Ly + 1
            If enemy.count > 120 Then
                enemy.count = 0
                Dim th2 As Single
                th2 = Math.Atan2(Player_loc.Y - enemy.Ly, Player_loc.X - enemy.Lx) Mod 3.14 * 2
                particle_attack_create(1, enemy.Lx, enemy.Ly, 4, th2, Color.FromArgb(254, 142, 18), 2)
            Else
                enemy.count = enemy.count + 1
            End If
            If enemy.HP <= 0 Then
                enemy.useable = False
                particle_effect_create(2, enemy.Lx, enemy.Ly, 2.5, 25, 7, Color.Orange)
                particle_effect_create(20, enemy.Lx, enemy.Ly, 0, 5, 1, Color.Yellow)
            End If
        ElseIf enemy.Type = 2 Then
            enemy.Ly = enemy.Ly + 1
            If enemy.count > 120 Then
                enemy.count = 0
                Dim th2 As Single
                th2 = Math.Atan2(Player_loc.Y - enemy.Ly, Player_loc.X - enemy.Lx) Mod 3.14 * 2
                For i = 1 To 3
                    particle_attack_create(1, enemy.Lx, enemy.Ly, 4, th2 + (i - 2) * 3.14 / 12, Color.FromArgb(254, 142, 18), 2)
                Next
            Else
                enemy.count = enemy.count + 1
            End If
            If enemy.HP <= 0 Then
                enemy.useable = False
                particle_effect_create(2, enemy.Lx, enemy.Ly, 2.5, 25, 7, Color.Orange)
                particle_effect_create(20, enemy.Lx, enemy.Ly, 0, 5, 1, Color.Yellow)
            End If
        ElseIf enemy.Type = 99 Then '第一隻BOSS

            If enemy.count > 1000 Then
                enemy.count = 100
            Else
                enemy.count = enemy.count + 1
            End If

            If enemy.count < 100 Then
                enemy.Ly = enemy.Ly + 1
                '施放璇狀彈幕
            ElseIf enemy.count > 200 And enemy.count < 400 And (enemy.count Mod 5 = 0) Then
                Dim kk As Integer
                kk = enemy.count - 200
                Dim th As Single
                th = kk / 200 * 3.14 * 2
                For j = 0 To 3
                    Dim th2 As Single
                    th2 = (th + j * 3.14 / 2) Mod 3.14 * 2
                    particle_attack_create(1, enemy.Lx, enemy.Ly, 3.5, th2, Color.Yellow, 2)
                Next
            End If
            '施放包圍彈幕
            If enemy.count > 600 And enemy.count < 700 And (enemy.count Mod 5 = 0) Then
                Dim kk As Integer
                kk = enemy.count - 600
                Dim th As Single
                th = kk / 200 * 3.14 * 2 + 3.14 / 2
                Dim th2 As Single
                th2 = Math.Atan2(enemy.Ly - Player_loc.Y, enemy.Lx - Player_loc.X)
                For i = 0 To 1
                    particle_attack_create(1, enemy.Lx, enemy.Ly, 2.5, th2 + th * (2 * i - 1), Color.Red, 2)
                Next

            End If
            '對玩家霰彈
            If enemy.count > 100 And enemy.count Mod 40 = 0 Then
                For j = 1 To 10
                    Dim th2 As Single
                    th2 = Math.Atan2(Player_loc.Y - enemy.Ly, Player_loc.X - enemy.Lx) Mod 3.14 * 2 + (-(10 / 2) + j) * 3.14 / 20
                    particle_attack_create(1, enemy.Lx, enemy.Ly, 2, th2, Color.FromArgb(254, 142, 18), 2)
                Next
            End If
            If enemy.HP <= 0 Then
                enemy.useable = False
                particle_effect_create(2, enemy.Lx, enemy.Ly, 2.5, 25, 7, Color.Orange)
                particle_effect_create(20, enemy.Lx, enemy.Ly, 0, 5, 1, Color.Yellow)
                Form1.Timer_Level_Counter.Enabled = True
            End If
        End If

    End Sub
End Module
