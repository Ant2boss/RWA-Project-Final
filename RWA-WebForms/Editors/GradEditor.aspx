<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="GradEditor.aspx.cs" Inherits="RWA_WebForms.Editors.GradEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="my-center-content">
		<h1 class="my-header">
			<asp:Label Text="Uređivanje grada" ID="lbTitle" runat="server" />
		</h1>
		<hr />
		<div class="my-grouper">
			<asp:Label Text="Naziv grada:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Naziv grada je obavezan" Text="*" CssClass="text-danger" ControlToValidate="tbCityName" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-signpost-split-fill" viewBox="0 0 16 16">
						<path d="M7 16h2V6h5a1 1 0 0 0 .8-.4l.975-1.3a.5.5 0 0 0 0-.6L14.8 2.4A1 1 0 0 0 14 2H9v-.586a1 1 0 0 0-2 0V7H2a1 1 0 0 0-.8.4L.225 8.7a.5.5 0 0 0 0 .6l.975 1.3a1 1 0 0 0 .8.4h5v5z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbCityName" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Drzava:" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-flag-fill" viewBox="0 0 16 16">
						<path d="M14.778.085A.5.5 0 0 1 15 .5V8a.5.5 0 0 1-.314.464L14.5 8l.186.464-.003.001-.006.003-.023.009a12.435 12.435 0 0 1-.397.15c-.264.095-.631.223-1.047.35-.816.252-1.879.523-2.71.523-.847 0-1.548-.28-2.158-.525l-.028-.01C7.68 8.71 7.14 8.5 6.5 8.5c-.7 0-1.638.23-2.437.477A19.626 19.626 0 0 0 3 9.342V15.5a.5.5 0 0 1-1 0V.5a.5.5 0 0 1 1 0v.282c.226-.079.496-.17.79-.26C4.606.272 5.67 0 6.5 0c.84 0 1.524.277 2.121.519l.043.018C9.286.788 9.828 1 10.5 1c.7 0 1.638-.23 2.437-.477a19.587 19.587 0 0 0 1.349-.476l.019-.007.004-.002h.001" />
					</svg>
				</div>
				<asp:DropDownList ID="ddlDrzave" CssClass="form-select" runat="server">
					<asp:ListItem Text="text1" />
					<asp:ListItem Text="text2" />
				</asp:DropDownList>
			</div>
		</div>

		<div>
			<asp:ValidationSummary CssClass="my-valid-summary-css" runat="server" />
		</div>

		<hr />
		<asp:Button ID="btnSubmit" Text="Potvrdi" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-success w-75 m-auto mb-2" runat="server" />
		<asp:Button Text="Povratak" OnClick="btnCancel_Click" OnClientClick="return true;" CssClass="btn btn-sm btn-outline-danger w-50 m-auto" runat="server" />
	</div>
</asp:Content>
