<%@ Page Title="Registro exitoso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Final.aspx.cs" Inherits="PresentacionWeb.Final" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>¡Gracias!</h2>
    
    <p>Gracias por participar de nuestro sorteo! Se le ha enviado un correo con más información del mismo.</p>
    
    <asp:Label ID="lblSorteo" runat="server" Text="Participación N°: "></asp:Label>
    
    <div class="row">
        <br />
        <asp:Button ID="btnInicio" runat="server" Text="Inicio" CssClass="btn btn-success" OnClick="btnInicio_Click" />

    </div>
</asp:Content>
