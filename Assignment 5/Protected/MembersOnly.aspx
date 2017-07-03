<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MembersOnly.aspx.cs" Inherits="Protected_MembersOnly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2>
                Hello, <asp:LoginName runat="server" CssClass="username" />! You are on a members exclusive page!</h2>
    <p>
                &nbsp;</p>
    <h3>Let's have some fun! </h3><h4>Get Random String! (Public Service)</h4>
    <asp:Button ID="Button3" runat="server" Text="Get String" CssClass="auto-style1" OnClick="Button3_Click" Width="181px" />
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <p>
                &nbsp;</p>
    <h3> Encryption and Decryption Functions (Using DLL) </h3>
    <asp:Label ID="Label5" runat="server" Text="Enter text to Encrypt: "></asp:Label>
        <asp:TextBox ID="txt_encr" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Encrypt" OnClick="Button1_Click" />
                <asp:Label ID="lbl_encrypted" runat="server" Text=""></asp:Label> <br />
    <asp:Label ID="Label6" runat="server" Text="Enter text to Decrypt: "></asp:Label>
        <asp:TextBox ID="txt_decr" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Decrypt" OnClick="Button2_Click" />
                <asp:Label ID="lbl_decrypted" runat="server" Text=""></asp:Label>
     <p>
                &nbsp;</p>
    <h3>
                Get Weather Conditions</h3>
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
    <h3>
                Find Nearest Store</h3>
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

    <h3>&nbsp;</h3>
    <h3>Find Distance Service</h3>
        <p class="absolute">
            Origin:</p>
        <p class="absolute"> 
            <asp:RadioButton ID="rdio_btn_address" runat="server" Text="Address" AutoPostBack="True" OnCheckedChanged="rdio_btn_address_CheckedChanged" /> <br />
            <asp:RadioButton ID="rdio_btn_ZIP" runat="server" Text="ZIP code" AutoPostBack="True" OnCheckedChanged="rdio_btn_ZIP_CheckedChanged" />
        </p>
        <p class="absolute"> 
            <asp:Label ID="lbl_1" runat="server"></asp:Label>
&nbsp; 
            <asp:TextBox ID="txtBox_1" runat="server" Visible="False"></asp:TextBox>&nbsp;<br />
            <asp:Label ID="lbl_2" runat="server"></asp:Label>
&nbsp; <asp:TextBox ID="txtBox_2" runat="server" OnTextChanged="txtBox_2_TextChanged" Visible="False"></asp:TextBox>
        &nbsp;</p>
        <p class="absolute"> 
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p class="absolute"> 
            Destination:</p>
        <p class="absolute"> 
            <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Text="Address" OnCheckedChanged="RadioButton1_CheckedChanged" /> <br />
            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Text="ZIP Code" OnCheckedChanged="RadioButton2_CheckedChanged" />
        </p>
        <p class="absolute"> 
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox> <br />
             <asp:Label ID="Label3" runat="server"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        </p>
        <p class="absolute"> 
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </p>
        <p class="absolute"> 
            <asp:Button ID="btn_submit3" runat="server" Text="Submit" OnClick="btn_submit3_Click" />
        </p>
        <p class="absolute"> 
            <asp:Label ID="lbl_result" runat="server"></asp:Label>
        </p>
</asp:Content>

