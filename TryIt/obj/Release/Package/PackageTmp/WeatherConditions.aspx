<%@ Page Title="Weather Conditions Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeatherConditions.aspx.cs" Inherits="TryIt.WeatherConditions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <h3>
                <asp:Image ID="IMG1" runat="server" ImageUrl="http://icons-ak.wxug.com/graphics/wu2/logo_130x80.png" />
                &nbsp;Weather Underground API - Wrapped service</h3>
            <h4>ZIP code details: Returns weather details of the ZIP code</h4>
            <p class="absolute">
                Method Name: getLocationDetails(...)<br />
            Input parameter: string
                (zipcode)<br />
            Return type: string[ ]</p>
            <p>
                Enter a valid ZIP code:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtBox_ZIP1" runat="server"></asp:TextBox>
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
    <p>&nbsp;</p>
</asp:Content>
