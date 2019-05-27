<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PresentacionWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="smartwizard">
        <ul>
            <li><a href="#step-1">Step Title<br />
                <small>Step description</small></a></li>
            <li><a href="#step-2">Step Title<br />
                <small>Step description</small></a></li>
            <li><a href="#step-3">Step Title<br />
                <small>Step description</small></a></li>
            <li><a href="#step-4">Step Title<br />
                <small>Step description</small></a></li>
        </ul>

        <div>
            <div id="step-1" class="">
                Step Content
            </div>
            <div id="step-2" class="">
                Step Content
            </div>
            <div id="step-3" class="">
                Step Content
            </div>
            <div id="step-4" class="">
                Step Content
            </div>
        </div>
    </div>
    <!--<h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>-->
</asp:Content>
