<%@ Page Title="Premios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="PresentacionWeb.Premios1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Premios</h2>
    <h3>Elegí tu premio</h3>
    <p>En caso de salir ganador, recibirás el premio seleccionado.</p>
    <div class="row">
        <asp:Label ID="lblVoucher" Text="Tu voucher es: " runat="server" />
    </div>
    <div class="row">
        <asp:Button ID="btnSiguiente" Text="Siguiente" runat="server" CssClass="btn btn-primary" Width="10%" OnClick="btnSiguiente_Click" />
    </div>

</asp:Content>
