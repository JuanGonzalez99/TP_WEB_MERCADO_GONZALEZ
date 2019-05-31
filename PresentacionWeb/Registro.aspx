<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PresentacionWeb.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h4>
            ¡Ingrese Sus Datos Para Participar!
        </h4>
    </div>
    <div class="row">
        <div class="col-md-3">     
        <div class="input-group">
                    <span class="input-group-addon">Documento</span>
                      <asp:TextBox ID="textDNI" CssClass="form-control form-control" runat="server" placeholder="Numero Documento"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Nombre</span>
                      <asp:TextBox ID="textNombre" CssClass="form-control form-control" runat="server" placeholder="Ingrese Nombre"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Apellido</span>
                      <asp:TextBox ID="textApellido" CssClass="form-control form-control" runat="server" placeholder="Ingrese Apellido"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Localidad</span>
                      <asp:TextBox ID="textLocalidad" CssClass="form-control form-control" runat="server" placeholder="Ingrese Localidad"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Provincia</span>
                      <asp:TextBox ID="textProvincia" CssClass="form-control form-control" runat="server" placeholder="Ingrese Provincia"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Direccion</span>
                      <asp:TextBox ID="textDireccion" CssClass="form-control form-control" runat="server" placeholder="Ingrese Direccion"/>
        </div><br>
        <div class="input-group">
                    <span class="input-group-addon">Email</span>
                      <asp:TextBox ID="textEmail" CssClass="form-control form-control" runat="server" placeholder="Ingrese Email"/>
        </div><br>
                      
            
            <asp:Button ID="BtnParticipar" runat="server" OnClick="BtnParticipar_Click" Text="Participar" CssClass="btn btn-success"/>
            
    </div>

    </div>
</asp:Content>


