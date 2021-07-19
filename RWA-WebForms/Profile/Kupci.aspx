<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Kupci.aspx.cs" Inherits="RWA_WebForms.Profile.Kupci" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container my-bg">
		<h1 class="my-header">
			<asp:Label Text="Kupci" runat="server" />
		</h1>
		<hr />
		<div class="mb-2 row">
			<%-- Page and Kupac/Page --%>
			<div class="col-lg-6 col-12">
				<div class="my-grouper w-75">
					<asp:Label Text="Stranica" runat="server" />
					<asp:Label ID="lbMaxPages" runat="server" />
					<asp:RequiredFieldValidator ErrorMessage="Broj stranice nije upisan" Text="*" CssClass="text-danger" ControlToValidate="tbPageNum" runat="server" />
					<div class="my-form-group">
						<div>
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-file-earmark-person-fill" viewBox="0 0 16 16">
								<path d="M9.293 0H4a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V4.707A1 1 0 0 0 13.707 4L10 .293A1 1 0 0 0 9.293 0zM9.5 3.5v-2l3 3h-2a1 1 0 0 1-1-1zM11 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0zm2 5.755V14a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1v-.245S4 12 8 12s5 1.755 5 1.755z" />
							</svg>
						</div>
						<asp:TextBox CssClass="form-control" TextMode="Number" ID="tbPageNum" runat="server" />
					</div>
				</div>
				<div class="my-grouper w-75">
					<asp:Label Text="Broj kupaca po stranici:" runat="server" />
					<asp:RequiredFieldValidator ErrorMessage="Broj kupaca nije upisan" Text="*" CssClass="text-danger" ControlToValidate="tbKupacNum" runat="server" />
					<div class="my-form-group">
						<div>
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-stack" viewBox="0 0 16 16">
								<path d="m14.12 10.163 1.715.858c.22.11.22.424 0 .534L8.267 15.34a.598.598 0 0 1-.534 0L.165 11.555a.299.299 0 0 1 0-.534l1.716-.858 5.317 2.659c.505.252 1.1.252 1.604 0l5.317-2.66zM7.733.063a.598.598 0 0 1 .534 0l7.568 3.784a.3.3 0 0 1 0 .535L8.267 8.165a.598.598 0 0 1-.534 0L.165 4.382a.299.299 0 0 1 0-.535L7.733.063z" />
								<path d="m14.12 6.576 1.715.858c.22.11.22.424 0 .534l-7.568 3.784a.598.598 0 0 1-.534 0L.165 7.968a.299.299 0 0 1 0-.534l1.716-.858 5.317 2.659c.505.252 1.1.252 1.604 0l5.317-2.659z" />
							</svg>
						</div>
						<asp:TextBox CssClass="form-control" TextMode="Number" ID="tbKupacNum" runat="server" />
					</div>
				</div>
			</div>
			<%-- Filters and sorts --%>
			<div class="col-lg-6 col-12">
				<div class="my-grouper w-75">
					<asp:Label Text="Država:" runat="server" />
					<div class="my-form-group">
						<div>
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-flag-fill" viewBox="0 0 16 16">
								<path d="M14.778.085A.5.5 0 0 1 15 .5V8a.5.5 0 0 1-.314.464L14.5 8l.186.464-.003.001-.006.003-.023.009a12.435 12.435 0 0 1-.397.15c-.264.095-.631.223-1.047.35-.816.252-1.879.523-2.71.523-.847 0-1.548-.28-2.158-.525l-.028-.01C7.68 8.71 7.14 8.5 6.5 8.5c-.7 0-1.638.23-2.437.477A19.626 19.626 0 0 0 3 9.342V15.5a.5.5 0 0 1-1 0V.5a.5.5 0 0 1 1 0v.282c.226-.079.496-.17.79-.26C4.606.272 5.67 0 6.5 0c.84 0 1.524.277 2.121.519l.043.018C9.286.788 9.828 1 10.5 1c.7 0 1.638-.23 2.437-.477a19.587 19.587 0 0 0 1.349-.476l.019-.007.004-.002h.001" />
							</svg>
						</div>
						<asp:DropDownList CssClass="form-select" ID="ddlStatesFilter" OnSelectedIndexChanged="ddlStatesFilter_SelectedIndexChanged" AutoPostBack="true" runat="server" />
					</div>
				</div>
				<div class="my-grouper w-75">
					<asp:Label Text="Grad:" runat="server" />
					<div class="my-form-group">
						<div>
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-signpost-split-fill" viewBox="0 0 16 16">
								<path d="M7 16h2V6h5a1 1 0 0 0 .8-.4l.975-1.3a.5.5 0 0 0 0-.6L14.8 2.4A1 1 0 0 0 14 2H9v-.586a1 1 0 0 0-2 0V7H2a1 1 0 0 0-.8.4L.225 8.7a.5.5 0 0 0 0 .6l.975 1.3a1 1 0 0 0 .8.4h5v5z" />
							</svg>
						</div>
						<asp:DropDownList CssClass="form-select" ID="ddlCityFilter" AutoPostBack="true" runat="server" />
					</div>
				</div>
				<div class="my-grouper w-75">
					<asp:Label Text="Sortiranje:" runat="server" />
					<div class="form-check form-switch">
						<input class="form-check-input" type="radio" id="rbSortFirstName" runat="server">
						<label class="form-check-label" for="rbSortFirstName">
							<asp:Label Text="Sortiranje po imenu" runat="server" />
						</label>
					</div>
					<div class="form-check form-switch">
						<input class="form-check-input" type="radio" id="rbSortLastName" runat="server">
						<label class="form-check-label" for="rbSortLastName">
							<asp:Label Text="Sortiranje po prezimenu" runat="server" />
						</label>
					</div>
					<div class="form-check form-switch">
						<input class="form-check-input" type="radio" id="rbSortNoSort" checked="true" runat="server">
						<label class="form-check-label" for="rbSortNoSort">
							<asp:Label Text="Bez sortiranja" runat="server" />
						</label>
					</div>
				</div>
			</div>
		</div>
		<div class="d-flex justify-content-center">
			<asp:Button Text="Ažuriraj tablicu" CssClass="btn btn-sm btn-warning" runat="server" />
		</div>

		<hr />

		<asp:Repeater ID="MyRepeater" runat="server">
			<HeaderTemplate>
				<table class="table table-striped table-sm">
					<thead>
						<tr>
							<th>
								<asp:Label Text="Ime" runat="server" />
							</th>
							<th>
								<asp:Label Text="Prezime" runat="server" />
							</th>
							<th>
								<asp:Label Text="Email" runat="server" />
							</th>
							<th>
								<asp:Label Text="Telefon" runat="server" />
							</th>
							<th>
								<asp:Label Text="Grad" runat="server" />
							</th>
							<th></th>
							<th></th>
						</tr>
					</thead>
					<tbody>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<%#Eval("Kupac.Ime") %>
					</td>
					<td>
						<%#Eval("Kupac.Prezime") %>
					</td>
					<td>
						<%#Eval("Kupac.Email") %>
					</td>
					<td>
						<%#Eval("Kupac.Telefon") %>
					</td>
					<td>
						<%#Eval("GradName") %>
					</td>
					<td>
						<asp:LinkButton ID="lbtnEdit" OnClick="lbtnEdit_Click" CommandArgument='<%#Eval("Kupac.IDKupac") %>' Text="Uredi" CssClass="btn btn-sm btn-secondary" runat="server" />
					</td>
					<td>
						<asp:LinkButton ID="lbtnDelete" OnClick="lbtnDelete_Click" CommandArgument='<%#Eval("Kupac.IDKupac") %>' Text="Obriši" CssClass="btn btn-sm btn-danger" runat="server" />
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</tbody>
				</table>
			</FooterTemplate>
		</asp:Repeater>

		<hr />
		<div class="d-flex justify-content-center">
			<asp:HyperLink Text="Dodaj kupca" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Editors/KupacEditor.aspx" runat="server" />
		</div>
		<div style="height: 40px;" />

	</div>
</asp:Content>
