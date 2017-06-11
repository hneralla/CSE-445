<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>TryIt </h1>
    </div>

    <div class="row">
        <div >
            <h3>
                <asp:Image ID="Image1" runat="server" ImageUrl="http://icons-ak.wxug.com/graphics/wu2/logo_130x80.png" />
                &nbsp;Weather Underground API - Wrapped service</h3>
            <h4>ZIP code details: Returns details of the ZIP code</h4>
            <p class="absolute">
                Method Name: getLocationDetails(...)<br />
            Input parameter: string
            <br />
            Return type: string[ ]</p>
            <p>
                Enter a valid ZIP code:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="textBox_zipcode" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Submit" />
            </p>
            <p>
                <asp:Label ID="lbl_info" runat="server"></asp:Label>  
            </p>
            <p>
                <asp:Label ID="lbl_first" runat="server"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                <asp:Label ID="lbl_last" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
    </div>

    </div>
</asp:Content>
