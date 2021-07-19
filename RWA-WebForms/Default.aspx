<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RWA_WebForms.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="CSS/Default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="my-center-content">
		<h1 class="my-header">
			<asp:Label Text="Prijavite se" runat="server" />
		</h1>
		<hr />
		<asp:HyperLink Text="Prijava" NavigateUrl="~/Login/Login.aspx" CssClass="btn btn-outline-primary my-btn" runat="server" />
		<asp:HyperLink Text="Registracija" NavigateUrl="~/Login/Register.aspx" CssClass="btn btn-outline-primary my-btn" runat="server" />
	</div>
</asp:Content>
