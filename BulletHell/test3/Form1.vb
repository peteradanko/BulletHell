Public Class Form1

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.Escape Then
            shutdown_QAQ()
            '10ms /1 count   1sec/100count
        ElseIf e.KeyValue = Keys.Z Then
            If attack_CD(2) = 0 Then
                attack_CD(2) = 500
                Dim j As Integer
                For j = 1 To 3
                    particleP_attack_create(2, Player_loc.X + j * 5, Player_loc.Y + 10 * (j - 1), 1, -3.14 / 2, Color.Blue, 20)
                    particleP_attack_create(2, Player_loc.X + j * -5, Player_loc.Y + 10 * (j - 1), 1, -3.14 / 2, Color.Blue, 20)
                Next
            End If
            
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初始化========================
        Cursor.Hide()
        PictureBox1.Size = Me.Size
        player_HP = 100

        For i = 0 To 100
            '彈幕物件初始化
            Me_Attack(i) = New partcle
            Me_Attack(i).useable = False
            Me_Attack(i).size = New Size(5, 10)
            Me_Attack(i).count = 0
            Me_Attack(i).color = Color.BlueViolet
            Me_Attack(i).Sx = 0
            Me_Attack(i).Sy = 0

            Enemy_Attack(i) = New partcle
            Enemy_Attack(i).useable = False
            Enemy_Attack(i).size = New Size(10, 10)
            Enemy_Attack(i).count = 0
            Enemy_Attack(i).color = Color.Yellow
            Enemy_Attack(i).Sx = 0
            Enemy_Attack(i).Sy = 0

            '敵人
            Enemy_Obj(i) = New enemy
            Enemy_Obj(i).useable = False
            Enemy_Obj(i).HP = 1000
            Enemy_Obj(i).count = 0
            Enemy_Obj(i).color = Color.DarkRed
            Enemy_Obj(i).size = New Size(100, 100)
            Enemy_Obj(i).Lx = 0
            Enemy_Obj(i).Ly = 0

        Next
        For i = 1 To 300

            '特效粒子
            partcal_effect(i) = New partcle
            partcal_effect(i).useable = False
            partcal_effect(i).size = New Size(2, 2)
            partcal_effect(i).count = 0
            partcal_effect(i).color = Color.Green
            partcal_effect(i).Sx = 0
            partcal_effect(i).Sy = 0
        Next
        '放置一隻boss
        'Enemy_Obj(1).useable = True
        'Enemy_Obj(1).Type = 99
        'Enemy_Obj(1).HP = 1000
        'Enemy_Obj(1).count = 0
        'Enemy_Obj(1).color = Color.DarkRed
        'Enemy_Obj(1).size = New Size(100, 100)
        'Enemy_Obj(1).Lx = 240
        'Enemy_Obj(1).Ly = 100
        'load complete,and trun Timer ON


    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        attack = True
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Location.X > 0 And e.Location.Y > 0 And e.Location.X < Me.Width And e.Location.Y < Me.Height Then
            Player_loc = e.Location
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        attack = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Me.Text = "(" & player_loc.X & "," & player_loc.Y & ")"
        Me.Text = player_HP
        If player_HP <= 0 Then
            shutdown_QAQ()
        End If
        '玩家施放彈幕
        attack_count_tick()
        particleP_normal_attack_creat()
        '玩家彈幕運算
        For i = 1 To 100
            particleP_active(Me_Attack(i))
        Next
        '敵人彈幕運算
        For i = 1 To 100
            particle_active(Enemy_Attack(i))
        Next
        '特效粒子運算
        For i = 1 To 100
            If partcal_effect(i).useable Then
                partcal_effect(i).count = partcal_effect(i).count - 1
                If partcal_effect(i).count > 0 Then
                    partcal_effect(i).Lx = partcal_effect(i).Lx + partcal_effect(i).Sx
                    partcal_effect(i).Ly = partcal_effect(i).Ly + partcal_effect(i).Sy
                Else
                    partcal_effect(i).useable = False
                End If
            End If
        Next

    End Sub

    '繪圖用Timer
    Private Sub Timer_Draw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Draw.Tick
        Dim map As Bitmap
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim drawpen As New Pen(drawBrush)
        map = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics
        g = Graphics.FromImage(map)

        For i = 1 To 100
            '繪製彈幕
            If Me_Attack(i).useable Then
                drawBrush.Color = Me_Attack(i).color
                Dim x, y, w, h As Integer
                x = Int(Me_Attack(i).Lx - Me_Attack(i).size.Width / 2)
                y = Int(Me_Attack(i).Ly - Me_Attack(i).size.Height / 2)
                w = Int(Me_Attack(i).size.Width)
                h = Int(Me_Attack(i).size.Height)
                g.FillEllipse(drawBrush, x, y, w, h)
            End If

            '繪製敵人彈幕
            If Enemy_Attack(i).useable Then
                drawBrush.Color = Enemy_Attack(i).color
                Dim x, y, w, h As Integer
                x = Int(Enemy_Attack(i).Lx - Enemy_Attack(i).size.Width / 2)
                y = Int(Enemy_Attack(i).Ly - Enemy_Attack(i).size.Height / 2)
                w = Int(Enemy_Attack(i).size.Width)
                h = Int(Enemy_Attack(i).size.Height)
                g.FillEllipse(drawBrush, x, y, w, h)
            End If

            '繪製粒子
            If partcal_effect(i).useable Then
                drawBrush.Color = partcal_effect(i).color
                Dim x, y, w, h As Integer
                x = Int(partcal_effect(i).Lx - partcal_effect(i).size.Width / 2)
                y = Int(partcal_effect(i).Ly - partcal_effect(i).size.Height / 2)
                w = Int(partcal_effect(i).size.Width)
                h = Int(partcal_effect(i).size.Height)
                g.FillEllipse(drawBrush, x, y, w, h)
            End If

            '繪製敵人
            If Enemy_Obj(i).useable Then
                drawBrush.Color = Enemy_Obj(i).color
                Dim x, y, w, h As Integer
                x = Int(Enemy_Obj(i).Lx - Enemy_Obj(i).size.Width / 2)
                y = Int(Enemy_Obj(i).Ly - Enemy_Obj(i).size.Height / 2)
                w = Int(Enemy_Obj(i).size.Width)
                h = Int(Enemy_Obj(i).size.Height)
                g.FillEllipse(drawBrush, x, y, w, h)
            End If
        Next

        '繪製戰機
        g.DrawImage(Image.FromFile("Image/001.png"), Player_loc.X - 13, Player_loc.Y - 13)

        PictureBox1.Image = map
    End Sub


    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        For i = 1 To 100
            If Enemy_Obj(i).useable = True Then
                If Enemy_Obj(i).Lx < -50 Or Enemy_Obj(i).Ly > Me.Height + 50 Or Enemy_Obj(i).Lx < -50 Or Enemy_Obj(i).Lx > Me.Width + 50 Then
                    Enemy_Obj(i).useable = False
                End If
                AI_active(Enemy_Obj(i))
            End If
        Next
    End Sub
    Sub shutdown_QAQ()
        Timer1.Enabled = False
        Timer_Draw.Enabled = False
        Timer3.Enabled = False
        Timer_Level_Counter.Enabled = False

        End
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'when form1 builed this event is last move
        Timer1.Enabled = True
        Timer_Draw.Enabled = True
        Timer3.Enabled = True
        Timer_Level_Counter.Enabled = True
        'My.Computer.Audio.Play("C:\WINDOWS\system32\oobe\images\title.wma", AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Timer_Level_Counter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Level_Counter.Tick
        level_count = level_count + 1
        level_active()
    End Sub

End Class
