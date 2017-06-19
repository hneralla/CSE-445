<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="TryIt.CreateAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Create Account Service</h3>
    <h4>Creates an account with the username and password. Returns an account creation confirmation.</h4>
    <p class="absolute">
        Method name: createAccount(...)<br />
        Input parameters: string (username), string (password)<br />
        Return type: Boolean</p>
    <p class="absolute">
                Enter a username:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_username" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; </p>
    <p class="absolute">
                &nbsp;Enter a password:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_password" TextMode="Password" runat="server" MaxLength="14"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
<p class="absolute">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_create" runat="server" OnClick="btn_create_Click" Text="Create" />
            </p>
    <p>
        <asp:Label ID="lbl_confirmation" runat="server"></asp:Label>
</p>
</asp:Content>