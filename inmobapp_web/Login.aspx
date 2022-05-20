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

    <form id="form1" runat="server">

    <div class="container mx-auto m-5">
        <div class="row">
                <div class="col-md-4 mx-auto">


                <div class="card text-center">
                    <div class="card-header bg-primary">
                        Ingreso de Usuario
                    </div>
                    <div class="card-body">
                            <div class="form-group">
                                <label>USUARIO</label>
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Escribe tu Usuario..."></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-group">
                                <label>CONTRASEÑA</label>
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Escribe tu Contraseña..." BorderStyle="Dotted" TextMode="Password"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-primary" OnClick="btnIngresar_Click" />
                            <br />
                            <br />
                            <asp:Button ID="btnOlvideClave" runat="server" Text="Olvide mi contraseña" class="btn btn-success" OnClick="btnOlvideClave_Click"/>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!----VALIDACIONES---->
    <div>
       <asp:RegularExpressionValidator class="alert alert-danger text-dark bg-danger" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese correctamente un correo de usuario." ControlToValidate="txtUsuario" ValidationExpression="^(?(&quot;&quot;)(&quot;&quot;.+?&quot;&quot;@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&amp;'\*\+/=\?\^`\{\}\|~\w])*)(?&lt;=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"></asp:RegularExpressionValidator>
       <asp:CustomValidator class="alert alert-danger text-dark bg-danger" ID="CustomValidator1" runat="server" ErrorMessage="Ingrese un correo de usuario." ControlToValidate="txtUsuario"></asp:CustomValidator>
        <br />
        <br />
        <asp:CustomValidator class="alert alert-danger text-dark bg-danger" ID="CustomValidator2" runat="server" ErrorMessage="Ingrese una contraseña." ControlToValidate="txtPassword"></asp:CustomValidator>
    </div>
</form>
</body>
</html>
