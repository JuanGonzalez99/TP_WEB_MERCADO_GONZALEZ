<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PresentacionWeb.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h4 id="titulo" runat="server">
            ¡Ingrese sus datos para participar!
        </h4>
    </div>
    <div class="row">
        <div class="col-md-4">     
        <div class="input-group">
                    <span class="input-group-addon">Documento</span>
                      <asp:TextBox ID="textDNI" CssClass="form-control form-control" runat="server" placeholder="Documento sin puntos ni espacios"/>
        </div><br>
        <div class="input-group">
                    <span id="lblNombre" runat="server" class="input-group-addon">Nombre</span>
                      <asp:TextBox ID="textNombre" CssClass="form-control form-control" runat="server" placeholder="Ingrese nombre"/>
        </div><br>
        <div class="input-group">
                    <span id="lblApellido" runat="server" class="input-group-addon">Apellido</span>
                      <asp:TextBox ID="textApellido" CssClass="form-control form-control" runat="server" placeholder="Ingrese apellido"/>
        </div><br>
        <div class="input-group">
                    <span id="lblProvincia" runat="server" class="input-group-addon">Provincia</span>
                      <asp:TextBox ID="textProvincia" CssClass="form-control form-control" runat="server" placeholder="Ingrese provincia"/>
        </div><br>
        <div class="input-group">
                    <span id="lblLocalidad" runat="server" class="input-group-addon">Localidad</span>
                      <asp:TextBox ID="textLocalidad" CssClass="form-control form-control" runat="server" placeholder="Ingrese localidad"/>
        </div><br>
        <div class="input-group">
                    <span id="lblDireccion" runat="server" class="input-group-addon">Direccion</span>
                      <asp:TextBox ID="textDireccion" CssClass="form-control form-control" runat="server" placeholder="Ingrese direccion"/>
        </div><br>
        <div class="input-group">
                    <span id="lblEmail" runat="server" class="input-group-addon">Email</span>
                      <asp:TextBox ID="textEmail" CssClass="form-control form-control" runat="server" placeholder="Ingrese email"/>
        </div><br>
                      
            
            <asp:Button ID="BtnParticipar" runat="server" OnClick="BtnParticipar_Click" Text="Participar" CssClass="btn btn-success"/>
            
    </div>

    </div>

    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header" style="background-color:midnightblue; color:white">
                            <button type="button" style="color:white" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>


