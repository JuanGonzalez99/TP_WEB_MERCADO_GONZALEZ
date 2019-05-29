<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PresentacionWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-md-4">
            Ingresá tu DNI: 
            <input id="txtDNI" type="text" class="form-control" runat="server" />
        </div>
        <div class="col-md-4">
            Seleccioná tu provincia
            <asp:DropDownList runat="server"/>
        </div>
    </div>
</asp:Content>
