Module Module1
    Public partcal_effect(300) As partcle
    Public Me_Attack(100) As partcle
    Public Enemy_Attack(100) As partcle
    Public Enemy_Obj(100) As enemy
    Public attack As Boolean
    Public attack_CD(20) As Integer
    Public attack_ammo(20) As Integer
    Public level_count As Integer

    Public player_HP As Integer
    Public Player_loc As Point
    'particle_effect_create(size,x,y,speed,count,number,color)
    Public Sub particle_effect_create(ByVal size As Integer, ByVal x As Single, ByVal y As Single, ByVal speed As Single, ByVal count As Integer, ByVal number As Integer, ByVal color As Color)
        For j = 1 To number
            For k = 1 To 300
                If partcal_effect(k).useable = False Then
                    partcal_effect(k).useable = True
                    partcal_effect(k).Lx = x
                    partcal_effect(k).Ly = y
                    partcal_effect(k).count = count
                    partcal_effect(k).Sx = speed * Math.Cos((Rnd() * 3.14) * 2 - 3.14)
                    partcal_effect(k).Sy = speed * Math.Sin((Rnd() * 3.14) * 2 - 3.14)
                    partcal_effect(k).size = New Size(size, size)
                    partcal_effect(k).color = color
                    Exit For
                End If
            Next
        Next
    End Sub
    'particle_attack_create(type,x,y,speed,th,color,attack)
    Public Sub particle_attack_create(ByVal type As Integer, ByVal x As Single, ByVal y As Single, ByVal speed As Single, ByVal th As Single, ByVal color As Color, ByVal attack As Integer)
        For i = 0 To 100
            If Enemy_Attack(i).useable = False Then
                Enemy_Attack(i).useable = True
                Enemy_Attack(i).color = color
                Enemy_Attack(i).type = type
                Enemy_Attack(i).Lx = x
                Enemy_Attack(i).Ly = y
                Enemy_Attack(i).Sy = speed * Math.Sin(th)
                Enemy_Attack(i).Sx = speed * Math.Cos(th)
                Exit For
            End If
        Next

    End Sub
    'enemy_create(type  hp , color , size , loc)
    Public Sub enemy_create(ByVal type As Integer, ByVal hp As Integer, ByVal color As Color, ByVal size As Integer, ByVal loc As Point)
        'create a enemy
        For i = 1 To 100
            If Enemy_Obj(i).useable = False Then
                Enemy_Obj(i).useable = True
                Enemy_Obj(i).Type = type
                Enemy_Obj(i).HP = hp
                Enemy_Obj(i).count = 0
                Enemy_Obj(i).color = color
                Enemy_Obj(i).size = New Size(size, size)
                Enemy_Obj(i).Lx = loc.X
                Enemy_Obj(i).Ly = loc.Y

                Exit For
            End If
        Next

    End Sub
    Public Sub particleP_normal_attack_creat()
        If attack And attack_CD(1) = 0 Then
            attack_CD(1) = 3
            For i = 1 To 100
                If Me_Attack(i).useable = False Then
                    Me_Attack(i).useable = True
                    Me_Attack(i).attack = 1
                    Me_Attack(i).type = 1
                    Me_Attack(i).size = New Size(5, 10)
                    Me_Attack(i).color = Color.BlueViolet
                    Me_Attack(i).Lx = Player_loc.X
                    Me_Attack(i).Ly = Player_loc.Y
                    Me_Attack(i).Sy = -10
                    Me_Attack(i).Sx = (Rnd() * 2) - 1
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Sub particleP_attack_create(ByVal type As Integer, ByVal x As Single, ByVal y As Single, ByVal speed As Single, ByVal th As Single, ByVal color As Color, ByVal attack As Integer)
        For i = 1 To 100
            If Me_Attack(i).useable = False Then
                Me_Attack(i).useable = True
                Me_Attack(i).color = color
                Me_Attack(i).type = type
                Me_Attack(i).Lx = x
                Me_Attack(i).Ly = y
                Me_Attack(i).Sy = speed * Math.Sin(th)
                Me_Attack(i).Sx = speed * Math.Cos(th)
                Exit For
            End If
        Next
    End Sub
    Public Sub attack_count_tick()
        '10ms /1 count   1sec/100count
        If attack_CD(1) > 0 Then    'nornal attack
            attack_CD(1) = attack_CD(1) - 1
        End If
        If attack_CD(2) > 0 Then    'rocket attack
            attack_CD(2) = attack_CD(2) - 1
        End If
    End Sub

End Module
