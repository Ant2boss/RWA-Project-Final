<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="DrzavaEditor.aspx.cs" Inherits="RWA_WebForms.Editors.DrzavaEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="my-center-content">
		<h1>
			<asp:Label Text="Uređivanje države" ID="lbTitle" runat="server" />
		</h1>
		
		<hr />

		<div class="my-grouper">
			<asp:Label Text="Naziv države:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Naziv države je obavezan" Text="*" CssClass="text-danger" ControlToValidate="tbStateName" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-signpost-split-fill" viewBox="0 0 16 16">
						<path d="M7 16h2V6h5a1 1 0 0 0 .8-.4l.975-1.3a.5.5 0 0 0 0-.6L14.8 2.4A1 1 0 0 0 14 2H9v-.586a1 1 0 0 0-2 0V7H2a1 1 0 0 0-.8.4L.225 8.7a.5.5 0 0 0 0 .6l.975 1.3a1 1 0 0 0 .8.4h5v5z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbStateName" runat="server" />
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
