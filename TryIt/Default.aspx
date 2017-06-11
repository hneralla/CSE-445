<%@ Page Title="Try It" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>TryIt Page </h1>
    </div>

    <div class="row">
        <div >
            <h3>
                <asp:Image ID="IMG1" runat="server" ImageUrl="http://icons-ak.wxug.com/graphics/wu2/logo_130x80.png" />
                &nbsp;Weather Underground API - Wrapped service</h3>
            <h4>ZIP code details: Returns details of the ZIP code</h4>
            <p class="absolute">
                Method Name: getLocationDetails(...)<br />
            Input parameter: string
                (zipcode)<br />
            Return type: string[ ]</p>
            <p>
                Enter a valid ZIP code:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtBox_ZIP1" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_submit1" runat="server" OnClick="btn_submit_Click" Text="Submit" />
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
            <h3>
                Find the Nearest Store Service</h3>
            <h4>
                Returns store address and details using the given ZIP code and store name.
                Uses existing Google Maps API.</h4>
            <p class="absolute">
                Method Name: findNearestStore(...)<br />
            Input parameters: string
                (zipcode), string (storeName)<br />
                Return type: string</p>
            <p class="absolute">
                Enter a valid ZIP code:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_ZIP2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; </p>
            <p class="absolute">
                &nbsp;Enter a store name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBox_storeName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_submit2" runat="server" OnClick="btn_submit2_Click" Text="Submit" />
            </p>
            <p class="absolute">
                <asp:Image ID="IMG2" runat="server" />
            </p>
            <p class="absolute">
                <asp:Label ID="lbl_info2" runat="server"></asp:Label>
            </p>
    </div>

    </div>
</asp:Content>
