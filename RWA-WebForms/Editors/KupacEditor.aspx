<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="KupacEditor.aspx.cs" Inherits="RWA_WebForms.Editors.KupacEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="my-center-content">
		<h1 class="my-header">
			<asp:Label Text="Uređivanje kupca" ID="lbTitle" runat="server" />
		</h1>
		<hr />
		<div class="my-grouper">
			<asp:Label Text="Ime:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Ime je obavezno" Text="*" CssClass="text-danger" ControlToValidate="tbFirstName" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
						<path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbFirstName" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Prezime:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Prezime je obavezno" Text="*" CssClass="text-danger" ControlToValidate="tbLastName" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
						<path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbLastName" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Email:" runat="server" />
			<asp:RegularExpressionValidator ErrorMessage="Neispravan Email" Text="*" CssClass="text-danger" ControlToValidate="tbEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-at" viewBox="0 0 16 16">
						<path d="M13.106 7.222c0-2.967-2.249-5.032-5.482-5.032-3.35 0-5.646 2.318-5.646 5.702 0 3.493 2.235 5.708 5.762 5.708.862 0 1.689-.123 2.304-.335v-.862c-.43.199-1.354.328-2.29.328-2.926 0-4.813-1.88-4.813-4.798 0-2.844 1.921-4.881 4.594-4.881 2.735 0 4.608 1.688 4.608 4.156 0 1.682-.554 2.769-1.416 2.769-.492 0-.772-.28-.772-.76V5.206H8.923v.834h-.11c-.266-.595-.881-.964-1.6-.964-1.4 0-2.378 1.162-2.378 2.823 0 1.737.957 2.906 2.379 2.906.8 0 1.415-.39 1.709-1.087h.11c.081.67.703 1.148 1.503 1.148 1.572 0 2.57-1.415 2.57-3.643zm-7.177.704c0-1.197.54-1.907 1.456-1.907.93 0 1.524.738 1.524 1.907S8.308 9.84 7.371 9.84c-.895 0-1.442-.725-1.442-1.914z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbEmail" TextMode="Email" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Telefon:" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-telephone-fill" viewBox="0 0 16 16">
						<path fill-rule="evenodd" d="M1.885.511a1.745 1.745 0 0 1 2.61.163L6.29 2.98c.329.423.445.974.315 1.494l-.547 2.19a.678.678 0 0 0 .178.643l2.457 2.457a.678.678 0 0 0 .644.178l2.189-.547a1.745 1.745 0 0 1 1.494.315l2.306 1.794c.829.645.905 1.87.163 2.611l-1.034 1.034c-.74.74-1.846 1.065-2.877.702a18.634 18.634 0 0 1-7.01-4.42 18.634 18.634 0 0 1-4.42-7.009c-.362-1.03-.037-2.137.703-2.877L1.885.511z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbPhone" TextMode="Phone" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Grad:" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-house-fill" viewBox="0 0 16 16">
						<path fill-rule="evenodd" d="m8 3.293 6 6V13.5a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 13.5V9.293l6-6zm5-.793V6l-2-2V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5z" />
						<path fill-rule="evenodd" d="M7.293 1.5a1 1 0 0 1 1.414 0l6.647 6.646a.5.5 0 0 1-.708.708L8 2.207 1.354 8.854a.5.5 0 1 1-.708-.708L7.293 1.5z" />
					</svg>
				</div>
				<asp:DropDownList ID="ddlGradovi" CssClass="form-select" runat="server">
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
