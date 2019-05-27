<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Texto grande</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                Texto 1
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                Texto 2
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                Texto 3
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>

    <div class="row">
        <h4>
            ¡Ingresá tu código y participá por increibles premios!
        </h4>
    </div>
    <div class="row">
        <div class="col-md-3">
            <asp:TextBox ID="txtVoucher" CssClass="form-control form-control" runat="server"/>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnSiguiente" Text="Siguiente" CssClass="btn btn-primary" runat="server" Width="30%" OnClick="btnSiguiente_Click" />
        </div>
    </div>
</asp:Content>
