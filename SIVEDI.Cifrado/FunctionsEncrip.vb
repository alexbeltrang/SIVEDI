Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class FunctionsEncrip
    'key: BD-ESTANDAR
    Public Function Cifrado(ByVal modo As Byte,
                            ByVal cadena As String) As String

        Dim plaintext() As Byte
        Dim VecI As String = "20270430"
        Dim Algoritmo As Byte = 3
        Dim key As String = "SiVeDi"

        If modo = 1 Then ' encriptar
            plaintext = Encoding.ASCII.GetBytes(cadena)
        ElseIf modo = 2 Then 'desencriptar
            plaintext = Convert.FromBase64String(cadena)
        End If

        Dim keys() As Byte = Encoding.ASCII.GetBytes(key)
        Dim memdata As New MemoryStream
        Dim transforma As ICryptoTransform

        Select Case Algoritmo
            Case 1
                Dim des As New DESCryptoServiceProvider With {
                    .Mode = CipherMode.CBC
                } ' DES
                If modo = 1 Then
                    transforma = des.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI))
                ElseIf modo = 2 Then
                    transforma = des.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI))
                End If
            Case 2

                Dim des3 As New TripleDESCryptoServiceProvider With {
                    .Mode = CipherMode.CBC
                } 'TripleDES
                If modo = 1 Then
                    transforma = des3.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI))
                ElseIf modo = 2 Then
                    transforma = des3.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI))
                End If
            Case 3
                Dim rc2 As New RC2CryptoServiceProvider With {
                    .Mode = CipherMode.CBC
                } 'RC2 
                If modo = 1 Then
                    transforma = rc2.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI))
                ElseIf modo = 2 Then
                    transforma = rc2.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI))
                End If

            Case 4
                Dim rj As New RijndaelManaged With {
                    .Mode = CipherMode.CBC
                } 'Rijndael 
                If modo = 1 Then
                    transforma = rj.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI))
                ElseIf modo = 2 Then
                    transforma = rj.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI))
                End If
        End Select

        Dim encstream As New CryptoStream(memdata, transforma, CryptoStreamMode.Write)
        encstream.Write(plaintext, 0, plaintext.Length)

        encstream.FlushFinalBlock()
        encstream.Close()


        If modo = 1 Then
            cadena = Convert.ToBase64String(memdata.ToArray)
        ElseIf modo = 2 Then
            cadena = Encoding.ASCII.GetString(memdata.ToArray)
        End If

        Return cadena 'Aquí es Donde se Devuelve los Datos Cifrados
    End Function


End Class