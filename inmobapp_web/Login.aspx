<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="inmobapp_web.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- Standard Meta -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <!-- Site Properties -->
    <title>Bootstrap 4 Login Form</title>
    <!-- Stylesheets -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- js -->
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>

    <div class="container mx-auto m-5">
        <div class="row">
                <div class="col-md-4 mx-auto">


                <div class="card">
                    <div class="card-header">
                        Ingreso de Usuario
                    </div>
                    <div class="card-body">
                        <form id="form1" runat="server">
                            <div class="form-group">
                                <label>USUARIO</label>
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Escribe tu Usuario..."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>CONTRASEÑA</label>
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Escribe tu Contraseña..." BorderStyle="Dotted" TextMode="Password"></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-primary" OnClick="btnIngresar_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
